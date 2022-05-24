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
    public interface ILCUHandler : IDisposable
    {
        // Public Events, events who listen the controller (who has some instance of this class)
        public event EventHandler<LeagueClientStatusChange> OnLeagueClientStatusChange;
        public event EventHandler<GameFlowChanged> OnGameFlowChanged;
        public event EventHandler<GameFlowChanged> OnGetCurrentStage;
        public event EventHandler<ChampionPool> OnChampSelectedChanged;
        public event EventHandler<ChampionPool> OnGetCurrentSelectedChamp;
        public event EventHandler<LeagueClientBuild> OnGetSystemBuild;
        public event EventHandler<SummonerInfo> OnGetCurrentSummoner;
        public event EventHandler<SummonerInfo> OnGetChestEligibility;
        public event EventHandler<Region> OnGetRegion;

        public Task Connect();
        public Task GetSystemBuild();
        public Task GetCurrentStage();
        public Task GetCurrentSelectedChamp();
        public Task GetCurrentSummoner();
        public Task GetChestEligibility();
        public Task ExperimentalGetRegion();
    }
}
