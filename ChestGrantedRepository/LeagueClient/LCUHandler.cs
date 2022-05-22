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
        public event EventHandler<ChampionPool> OnChampSelectedChanged;
        public event EventHandler<LeagueClientBuild> OnGetSystemBuild;
        public event EventHandler<SummonerInfo> OnGetCurrentSummoner;
        public event EventHandler<SummonerInfo> OnGetChestEligibility;

        // Private Events, event who listen by my selft (subscribe to accions of LCU)
        private event EventHandler<LeagueEvent> GameFlowChanged;
        private event EventHandler<LeagueEvent> ChampSelectedChanged;

        // for manager bench champs on aram
        private List<BenchChampion> benchChampions;

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
            try
            {
                var data = e.Data.ToString();
                var session = JsonSerializer.Deserialize<Session>(data);
                Helpers.Log(data);
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

        public async Task<GameFlowChanged> GetCurrentStage()
        {
            try
            {
                var json = await api.RequestHandler.GetJsonResponseAsync(HttpMethod.Get, LCUEndPoints.GameFlow);
                string strState = JsonSerializer.Deserialize<string>(json);
                return new GameFlowChanged(Helpers.GetStateFromString(strState));
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}.GetCurrentStage - {ex.Message}");
                throw;
            }
        }

        public async Task<ChampionPool> GetCurrentSelectedChamp()
        {
            try
            {
                var json = await api.RequestHandler.GetJsonResponseAsync(HttpMethod.Get, LCUEndPoints.ChampSelectSession);
                ChampionPool result = JsonSerializer.Deserialize<ChampionPool>(json);
                return result;
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
                };
                SyncContext.Post(e => OnGetChestEligibility?.Invoke(this, response), null);
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}.GetChestEligibility - {ex.Message}");
                throw;
            }
        }

        public async Task<Region> ExperimentalGetRegion()
        {
            try
            {
                // trying to get an error as response
                /*
                 {
                    "errorCode": "RPC_ERROR",
                    "httpStatus": 404,
                    "implementationDetails": {},
                    "message": "No survey available at this moment for puuid '3bdecfef-74af-58c2-8a95-e9f739a6f419', region 'LA2', locale 'en_US'."
                */

                var json = await api.RequestHandler.GetJsonResponseAsync(HttpMethod.Get, LCUEndPoints.Survey, ensureSuccessStatusCode: false);
                var surveyError = JsonSerializer.Deserialize<SurveyError>(json);
                var message = surveyError.message.Split(",");
                var region = message[1];
                region = region.Replace("region '", "");
                region = region.Replace("'", "");
                region = region.Trim();

                var result = new Region()
                {
                    summonerRegion = region,
                };

                return result;
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}.ExperimentalGetRegion - {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}
