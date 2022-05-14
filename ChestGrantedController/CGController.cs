using ChestGrantedRepository;
using ChestGrantedRepository.EventsArgs;
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
        private ChestGrantedEventHandler eventHandler;
        public CGController(IChestGrantedView view)
        {
            this.view = view;
            CleanShownData();

            eventHandler = new ChestGrantedEventHandler();
            eventHandler.OnLeagueClientStatusChange += OnLeagueClientStatusChange;
            eventHandler.OnGameFlowChanged += OnGameFlowChanged;
            eventHandler.OnGetCurrentSummoner += OnGetCurrentSummoner;
            eventHandler.OnGetChestEligibility += OnGetChestEligibility;
            eventHandler.OnGetProfileIcon += OnGetProfileIcon;

            ConnectLC();
        }

        private async void ConnectLC()
        {
            await eventHandler.Connect();
        }

        private void OnLeagueClientStatusChange(object sender, LeagueClientStatusChange e)
        {
            if (e.IsRunning)
            {
                UpdateSummonerInfo();
                UpdateChestInfo();
                view.LoLIsRunning = true;
            }
            else
            {
                view.LoLIsRunning = false;
                CleanShownData();
                ConnectLC();
            }
        }

        private void CleanShownData()
        {
            view.EarnableChests = 0;
            view.SummonerName = "";
        }

        private void UpdateChestInfo()
        {
            _ = eventHandler.GetChestEligibility();
        }

        private void OnGetChestEligibility(object sender, SummonerInfo e)
        {
            view.EarnableChests = e.earnableChests;
        }

        private void UpdateSummonerInfo()
        {
            _ = eventHandler.GetCurrentSummoner();
        }

        private void OnGetCurrentSummoner(object sender, SummonerInfo e)
        {
            view.SummonerName = e.displayName;
            GetProfileIcon(e.profileIconId);
        }

        private void GetProfileIcon(int profileIconId)
        {
            _ = eventHandler.GetProfileIcon();
        }

        private void OnGetProfileIcon(object sender, SummonerInfo e)
        {
            //view.ProfilePicture = profilePicture;
        }

        private void OnGameFlowChanged(object sender, GameFlowChanged e)
        {
            if (e.State == ChestGrantedRepository.Enums.GameFlowStates.ChampSelect)
            {
                eventHandler.SubscribeToChampSelected();   
            }
            else
            {
                eventHandler.UnsubscribeToChampSelected();
            }

            if (e.State == ChestGrantedRepository.Enums.GameFlowStates.WaitingForStats)
                UpdateChestInfo();
        }

    }
}
