using ChestGrantedRepository.PublicEventsArgs;
using ChestGrantedRepository.Responses;
using LCUSharp;
using LCUSharp.Websocket;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ChestGrantedRepository
{
    public class ChestGrantedEventHandler : IDisposable
    {
        // Message sender
        private readonly SynchronizationContext SyncContext;
        private LeagueClientApi api;

        // Public Events, events who listen the controller (who has some instance of this class)
        public event EventHandler<LeagueClientStatusChange> OnLeagueClientStatusChange;
        public event EventHandler<GameFlowChangedResponse> OnGameFlowChanged;

        // Private Events, event who listen by my selft (subscribe to accions of LCU)
        private event EventHandler<LeagueEvent> GameFlowChanged;
        private event EventHandler<LeagueEvent> ChampSelectedChanged;

        public ChestGrantedEventHandler()
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
            api.Disconnected += OnGameDisconected;

            // subscribed event = my event handler
            GameFlowChanged += _GameFlowChanged;
            ChampSelectedChanged += _ChampSelectedChanged;

            // start listening that event
            api.EventHandler.Subscribe($"/{LCUEndPoints.GameFlow}", GameFlowChanged);

            // fires my public event to indicate LCU is running
            var response = new LeagueClientStatusChange(true);
            SyncContext.Post(e => OnLeagueClientStatusChange?.Invoke(this, response), null);
        }

        private void OnGameDisconected(object sender, EventArgs e)
        {
            // TODO dudoso esta linea
            api.Disconnected -= OnGameDisconected;

            // fires my public event to indicate LCU is NOT running
            var response = new LeagueClientStatusChange(false);
            SyncContext.Post(e => OnLeagueClientStatusChange?.Invoke(this, response), null);
        }

        // Get some change of game flow
        private void _GameFlowChanged(object sender, LeagueEvent e)
        {
            var result = e.Data.ToString();

            // fires my public event to indicate the game flow
            var response = new GameFlowChangedResponse(Helpers.GetStateFromString(result));
            SyncContext.Post(e => OnGameFlowChanged?.Invoke(this, response), null);
        }
          
        public async Task<SummonerProfile> GetSummonerProfile()
        {
            var result = await api.RequestHandler.GetResponseAsync<SummonerProfile>(HttpMethod.Get, LCUEndPoints.SummonerProfile);
            return result;
        }

        public async Task<CurrentSummoner> GetCurrentSummoner()
        {
            var result = await api.RequestHandler.GetResponseAsync<CurrentSummoner>(HttpMethod.Get, LCUEndPoints.CurrentSummoner);
            return result;
        }

        public async Task<ChestEligibility> GetChestEligibility()
        {
            var result = await api.RequestHandler.GetResponseAsync<ChestEligibility>(HttpMethod.Get, LCUEndPoints.ChestEligibility);
            return result;
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
            Console.WriteLine(e.Data);
        }

    }
}
