using ChestGrantedRepository;
using ChestGrantedRepository.PublicEventsArgs;
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
            eventHandler = new ChestGrantedEventHandler();
            eventHandler.OnLeagueClientStatusChange += OnLeagueClientStatusChange;
            eventHandler.OnGameFlowChanged += OnGameFlowChanged;
            ConnectLC();
        }

        private async void ConnectLC()
        {
            await eventHandler.Connect();
        }

        private async void OnLeagueClientStatusChange(object sender, LeagueClientStatusChange e)
        {
            if (e.IsRunning)
            {
                // TODO aca tira 404 porque todavia no levanto (al momento de tener corriendo esto antes que el lol)
                await UpdateSummonerInfo();
                await UpdateChestInfo();
                view.LoLIsRunning = true;
            }
            else
            {
                // TODO unsubscribe of all events
                // Wait untill LC is opened again
                ConnectLC();
            }
        }

        private async Task UpdateChestInfo()
        {
            var chestEligibility = await eventHandler.GetChestEligibility();
            view.EarnableChests = chestEligibility.earnableChests;
        }

        private async Task UpdateSummonerInfo()
        {
            var currentSummoner = await eventHandler.GetCurrentSummoner();
            // TODO get summoner Icon
            //var icon = currentSummoner.profileIconId;

            view.SummonerName = currentSummoner.displayName;
            //view.ProfilePicture = profilePicture;
        }

        private async void OnGameFlowChanged(object sender, GameFlowChangedResponse e)
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
                await UpdateChestInfo();
        }

    }
}
