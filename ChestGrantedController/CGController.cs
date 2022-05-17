using ChestGrantedController.Class;
using ChestGrantedRepository;
using ChestGrantedRepository.LeagueClient.Enums;
using ChestGrantedRepository.LeagueClient.EventsArgs;
using ChestGrantedRepository.LeagueClient.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedController
{
    public class CGController
    {
        private IChestGrantedView view;
        private LCUHandler LCUHandler;
        private DDragonHandler dragonHandler;
        private SummonerInfo summoner;

        public CGController(IChestGrantedView view)
        {
            this.view = view;
            CleanShownData();

            LCUHandler = new LCUHandler();
            LCUHandler.OnLeagueClientStatusChange += OnLeagueClientStatusChange;
            LCUHandler.OnGameFlowChanged += OnGameFlowChanged;
            LCUHandler.OnGetCurrentSummoner += OnGetCurrentSummoner;
            LCUHandler.OnGetChestEligibility += OnGetChestEligibility;
            LCUHandler.OnChampSelectedChanged += OnChampSelectedChanged;
            LCUHandler.OnGetSystemBuild += OnGetSystemBuild;

            ConnectLC();
        }

        private async void ConnectLC()
        {
            await LCUHandler.Connect();
            await LCUHandler.GetSystemBuild();
        }

        private void OnGetSystemBuild(object sender, LeagueClientBuild e)
        {
            // e.version = "12.9.440.3307"
            var aVersion = e.version.Split(".");
            var version = $"{aVersion[0]}.{aVersion[1]}.1";

            dragonHandler = new DDragonHandler(version);
            dragonHandler.OnGetProfileIcon += OnGetProfileIcon;
        }

        private void OnLeagueClientStatusChange(object sender, LeagueClientStatusChange e)
        {
            if (e.IsRunning)
            {
                UpdateSummonerInfo();
                UpdateChestInfo();
                GetCurrentStage();             
                view.LoLIsRunning = true;
            }
            else
            {
                view.LoLIsRunning = false;
                CleanShownData();
                ConnectLC();
            }
        }

        private async void GetCurrentStage()
        {
            GameFlowChanged stage = await LCUHandler.GetCurrentStage();
            if (stage.State == GameFlowStates.ChampSelect)
            {
                OnGameFlowChanged(this, stage);
            }
        }

        private void CleanShownData()
        {
            view.EarnableChests = 0;
            view.SummonerName = "";
        }

        private void UpdateChestInfo()
        {
            _ = LCUHandler.GetChestEligibility();
        }

        private void OnGetChestEligibility(object sender, SummonerInfo e)
        {
            view.EarnableChests = e.earnableChests;
        }

        private void UpdateSummonerInfo()
        {
            _ = LCUHandler.GetCurrentSummoner();
        }

        private void OnGetCurrentSummoner(object sender, SummonerInfo e)
        {
            summoner = e;
            view.SummonerName = e.displayName;
            GetProfileIcon(e.profileIconId);
        }

        private void GetProfileIcon(int profileIconId)
        {
            if(dragonHandler != null)
                dragonHandler.GetProfileIcon(profileIconId);
        }

        private void OnGetProfileIcon(object sender, SummonerImage e)
        {
            view.ProfilePicture = e.profileIconPath;
        }

        private void OnGameFlowChanged(object sender, GameFlowChanged e)
        {
            if (e.State == GameFlowStates.ChampSelect)
            {
                view.ChampSelectStageVisible = true;
                LCUHandler.SubscribeToChampSelected();
            }
            else
            {
                view.ChampSelectStageVisible = false;
                LCUHandler.UnsubscribeToChampSelected();
            }

            if (e.State == GameFlowStates.WaitingForStats)
                UpdateChestInfo();
        }

        private void OnChampSelectedChanged(object sender, Session e)
        {
            foreach (MyTeam t in e.myTeam)
            {

            }
            //List<SelectedChampion> teamChamps = e.myTeam.Select(x => new SelectedChampion(x)).ToList();
            //view.MySelectedChamp = teamChamps.FirstOrDefault(x => x.summonerId == summoner.summonerId);
            //view.MyTeamChamps = teamChamps;
        }
    }
}
