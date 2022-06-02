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
using System.Collections.Generic;

namespace ChestGrantedRepository.LeagueClient
{
    public class LCUHandler : ILCUHandler, IDisposable
    {
        // Message sender
        private readonly SynchronizationContext SyncContext;
        private LeagueClientApi api;

        // Public Events, events who listen the controller (who has some instance of this class)
        public event EventHandler<LeagueClientStatusChange> OnLeagueClientStatusChange;
        public event EventHandler<GameFlowChanged> OnGameFlowChanged;
        public event EventHandler<GameFlowChanged> OnGetCurrentStage;
        public event EventHandler<LobbyStatus> OnGameFlowSession;
        public event EventHandler<ChampionPool> OnChampSelectedChanged;
        public event EventHandler<ChampionPool> OnGetCurrentSelectedChamp;
        public event EventHandler<LeagueClientBuild> OnGetSystemBuild;
        public event EventHandler<SummonerInfo> OnGetCurrentSummoner;
        public event EventHandler<SummonerInfo> OnGetChestEligibility;
        public event EventHandler<SummonerInfo> OnGetRegion;
        

        // Private Events, event who listen by my self (subscribe to accions of LCU)
        private event EventHandler<LeagueEvent> GameFlowChanged;
        private event EventHandler<LeagueEvent> ChampSelectedChanged;
        private event EventHandler<LeagueEvent> GameFlowSessionChanged;

        public LCUHandler()
        {
            SyncContext = AsyncOperationManager.SynchronizationContext;
        }

        public void Dispose()
        {
            try
            {
                api.EventHandler.UnsubscribeAll();
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}.Dispose - {ex.Message}");
                throw;
            }
        }

        public async Task Connect()
        {
            try
            {
                // Initialize a connection to the league client.
                api = await LeagueClientApi.ConnectAsync();
                api.Disconnected += _GameDisconected;

                // subscribed event = my event handler
                SubscribeToGameFlow();
                SubscribeToChampSelected();
                SubscribeToGameFlowSession();

                // fires my public event to indicate LCU is running
                var response = new LeagueClientStatusChange(true);
                SyncContext.Post(e => OnLeagueClientStatusChange?.Invoke(this, response), null);
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}.Connect - {ex.Message}");
                throw;
            }
        }

        #region Subscribe Methods
        private void SubscribeToGameFlow()
        {
            GameFlowChanged += _GameFlowChanged;
            api.EventHandler.Subscribe($"/{LCUEndPoints.GameFlow}", GameFlowChanged);
        }

        private void UnsubscribeToGameFlow()
        {
            GameFlowChanged -= _GameFlowChanged;
            api.EventHandler.Unsubscribe($"/{LCUEndPoints.GameFlow}");
        }

        private void SubscribeToGameFlowSession()
        {
            GameFlowSessionChanged += _OnGameFlowSession;
            api.EventHandler.Subscribe($"/{LCUEndPoints.GameFlowSession}", GameFlowSessionChanged);
        }

        private void UnsubscribeToGameFlowSession()
        {
            GameFlowSessionChanged -= _OnGameFlowSession;
            api.EventHandler.Unsubscribe($"/{LCUEndPoints.GameFlowSession}");
        }

        public void SubscribeToChampSelected()
        {
            ChampSelectedChanged += _ChampSelectedChanged;
            api.EventHandler.Subscribe($"/{LCUEndPoints.ChampSelectSession}", ChampSelectedChanged);
        }

        public void UnsubscribeToChampSelected()
        {
            ChampSelectedChanged -= _ChampSelectedChanged;
            api.EventHandler.Unsubscribe($"/{LCUEndPoints.ChampSelectSession}");
        }

        #endregion

        #region LCU Events Handler
        private void _GameDisconected(object sender, EventArgs e)
        {
            try
            {
                // fires my public event to indicate LCU is NOT running
                var response = new LeagueClientStatusChange(false);
                SyncContext.Post(e => OnLeagueClientStatusChange?.Invoke(this, response), null);
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}._GameDisconected - {ex.Message}");
                throw;
            }
        }

        private void _GameFlowChanged(object sender, LeagueEvent e)
        {
            try
            {
                var result = e.Data.ToString();

                // fires my public event to indicate the game flow
                var response = new GameFlowChanged(Helpers.GetStateFromString(result));
                SyncContext.Post(e => OnGameFlowChanged?.Invoke(this, response), null);
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}._GameFlowChanged - {ex.Message}");
                throw;
            }
        }

        private void _ChampSelectedChanged(object sender, LeagueEvent e)
        {
            Helpers.Log(e.ToString());
            try
            {
                var data = e.Data.ToString();
                var session = JsonSerializer.Deserialize<ChampSelectSession>(data);

                ChampionPool response = new ChampionPool();

                foreach (Team t in session.myTeam)
                {
                    var champ = new Champion()
                    {
                        Id = t.championId,
                        AssignedPosition = t.assignedPosition,
                        SummonerId = t.summonerId,
                    };

                    response.SelectedChampions.Add(champ);
                }

                if (session.benchEnabled && session.benchChampionIds != null)
                {
                    foreach (int champId in session.benchChampionIds)
                    {
                        var champ = new BenchChampion()
                        {
                            ChampionId = champId,
                        };
                        response.BenchChampions.Add(champ);
                    }
                }

                // fires my public event to indicate the change
                SyncContext.Post(e => OnChampSelectedChanged?.Invoke(this, response), null);
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}._ChampSelectedChanged - {ex.Message}");
                throw;
            }
        }

        private void _OnGameFlowSession(object sender, LeagueEvent e)
        {
            var data = e.Data.ToString();
            var session = JsonSerializer.Deserialize<GameFlowSession>(data);
            if (session.phase == "Lobby")
            {
                var response = new LobbyStatus()
                {
                    gameId = session.gameData.gameId,
                    GameMode = Helpers.GetModeFromString(session.map.gameMode),
                    id = session.gameData.queue.id,
                    isCustomGame = session.gameData.isCustomGame,
                    mapId = session.map.id,
                    mapStringId = session.map.mapStringId,
                };
                SyncContext.Post(e => OnGameFlowSession?.Invoke(this, response), null);
            }
            else if (session.phase == "ChampSelect")
            {
                Helpers.Log(e.ToString());
                // game in progress (?
            }
        }


        #endregion

        #region Get data from LCU
        public async Task GetSystemBuild()
        {
            try
            {
                var result = await api.RequestHandler.GetResponseAsync<SystemBuild>(HttpMethod.Get, LCUEndPoints.SystemBuild);
                var response = new LeagueClientBuild()
                {
                    version = result.version,
                };
                SyncContext.Post(e => OnGetSystemBuild?.Invoke(this, response), null);
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}.GetSystemBuild - {ex.Message}");
                throw;
            }
        }

        public async Task GetCurrentStage()
        {
            try
            {
                var json = await api.RequestHandler.GetJsonResponseAsync(HttpMethod.Get, LCUEndPoints.GameFlow);
                string strState = JsonSerializer.Deserialize<string>(json);
                var response = new GameFlowChanged(Helpers.GetStateFromString(strState));
                SyncContext.Post(e => OnGetCurrentStage?.Invoke(this, response), null);
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}.GetCurrentStage - {ex.Message}");
                throw;
            }
        }

        public async Task GetCurrentSelectedChamp()
        {
            try
            {
                var json = await api.RequestHandler.GetJsonResponseAsync(HttpMethod.Get, LCUEndPoints.ChampSelectSession);
                ChampionPool response = JsonSerializer.Deserialize<ChampionPool>(json);
                SyncContext.Post(e => OnGetCurrentSelectedChamp?.Invoke(this, response), null);
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}.GetCurrentSelectedChamp - {ex.Message}");
                throw;
            }
        }

        public async Task GetCurrentSummoner()
        {
            try
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
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}.GetCurrentSummoner - {ex.Message}");
                throw;
            }
        }

        public async Task GetChestEligibility()
        {
            try
            {
                var result = await api.RequestHandler.GetResponseAsync<ChestEligibility>(HttpMethod.Get, LCUEndPoints.ChestEligibility);
                var response = new SummonerInfo()
                {
                    earnableChests = result.earnableChests,
                    nextChestRechargeTime = result.nextChestRechargeTime,
                };
                SyncContext.Post(e => OnGetChestEligibility?.Invoke(this, response), null);
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}.GetChestEligibility - {ex.Message}");
                throw;
            }
        }

        public async Task GetRegion()
        {
            try
            {
                var result = await api.RequestHandler.GetResponseAsync<LoginDataPacket>(HttpMethod.Get, $"/{LCUEndPoints.LoginDataPacket}");
                var response = new SummonerInfo()
                {
                    region = result.platformId,
                };
                SyncContext.Post(e => OnGetRegion?.Invoke(this, response), null);
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}.GetCurrentSummoner - {ex.Message}");
                throw;
            }

        }

        #endregion
    }
}
