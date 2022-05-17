using ChestGrantedRepository.LeagueClient;
using ChestGrantedRepository.LeagueClient.EventsArgs;
using ChestGrantedRepository.LeagueClient.Responses;
using LCUSharp;
using LCUSharp.Websocket;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ChestGrantedRepository
{
    public class LCUHandler : IDisposable
    {
        // Message sender
        private readonly SynchronizationContext SyncContext;
        private LeagueClientApi api;

        // Public Events, events who listen the controller (who has some instance of this class)
        public event EventHandler<LeagueClientStatusChange> OnLeagueClientStatusChange;
        public event EventHandler<GameFlowChanged> OnGameFlowChanged;
        public event EventHandler<Session> OnChampSelectedChanged;
        public event EventHandler<LeagueClientBuild> OnGetSystemBuild;
        public event EventHandler<SummonerInfo> OnGetCurrentSummoner;
        public event EventHandler<SummonerInfo> OnGetChestEligibility;

        // Private Events, event who listen by my selft (subscribe to accions of LCU)
        private event EventHandler<LeagueEvent> GameFlowChanged;
        private event EventHandler<LeagueEvent> ChampSelectedChanged;

        public LCUHandler()
        {
            SyncContext = AsyncOperationManager.SynchronizationContext;
        }

        public void Dispose()
        {
            api.EventHandler.UnsubscribeAll();
        }

        public async Task Connect()
        {
            // Initialize a connection to the league client.
            api = await LeagueClientApi.ConnectAsync();
            api.Disconnected += _GameDisconected;

            // subscribed event = my event handler
            GameFlowChanged += _GameFlowChanged;
            ChampSelectedChanged += _ChampSelectedChanged;

            // start listening that event
            api.EventHandler.Subscribe($"/{LCUEndPoints.GameFlow}", GameFlowChanged);

            // fires my public event to indicate LCU is running
            var response = new LeagueClientStatusChange(true);
            SyncContext.Post(e => OnLeagueClientStatusChange?.Invoke(this, response), null);
        }

        public async Task GetSystemBuild()
        {
            var result = await api.RequestHandler.GetResponseAsync<SystemBuild>(HttpMethod.Get, LCUEndPoints.SystemBuild);
            var response = new LeagueClientBuild()
            {
                version = result.version,
            };
            SyncContext.Post(e => OnGetSystemBuild?.Invoke(this, response), null);
        }

        private void _GameDisconected(object sender, EventArgs e)
        {
            // TODO dudoso esta linea
            api.Disconnected -= _GameDisconected;

            // fires my public event to indicate LCU is NOT running
            var response = new LeagueClientStatusChange(false);
            SyncContext.Post(e => OnLeagueClientStatusChange?.Invoke(this, response), null);
        }

        // Get some change of game flow
        private void _GameFlowChanged(object sender, LeagueEvent e)
        {
            var result = e.Data.ToString();

            // fires my public event to indicate the game flow
            var response = new GameFlowChanged(Helpers.GetStateFromString(result));
            SyncContext.Post(e => OnGameFlowChanged?.Invoke(this, response), null);
        }

        public async Task<GameFlowChanged> GetCurrentStage()
        {
            var json = await api.RequestHandler.GetJsonResponseAsync(HttpMethod.Get ,LCUEndPoints.GameFlow);
            string strState = JsonSerializer.Deserialize<string>(json);
            return new GameFlowChanged(Helpers.GetStateFromString(strState));
        }

        public async Task GetCurrentSummoner()
        {
            var result = await api.RequestHandler.GetResponseAsync<CurrentSummoner>(HttpMethod.Get, LCUEndPoints.CurrentSummoner);
            var response = new SummonerInfo()
            {
                displayName = result.displayName,
                profileIconId = result.profileIconId,
                summonerId = result.summonerId,
            };
            SyncContext.Post(e => OnGetCurrentSummoner?.Invoke(this, response), null);
        }

        public async Task GetChestEligibility()
        {
            var result = await api.RequestHandler.GetResponseAsync<ChestEligibility>(HttpMethod.Get, LCUEndPoints.ChestEligibility);
            var response = new SummonerInfo()
            {
                earnableChests = result.earnableChests,
            };
            SyncContext.Post(e => OnGetChestEligibility?.Invoke(this, response), null);
        }

        public void SubscribeToChampSelected()
        {
            api.EventHandler.Subscribe($"/{LCUEndPoints.ChampSelectSession}", ChampSelectedChanged);
        }

        public void UnsubscribeToChampSelected()
        {
            api.EventHandler.Unsubscribe($"/{LCUEndPoints.ChampSelectSession}");
        }

        private void _ChampSelectedChanged(object sender, LeagueEvent e)
        {
            var data = e.Data.ToString();
            var response = JsonSerializer.Deserialize<Session>(data);

            // fires my public event to indicate the game flow
            SyncContext.Post(e => OnChampSelectedChanged?.Invoke(this, response), null);
        }
    }
}
