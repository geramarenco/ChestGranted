using ChestGrantedCore.EventsArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedCore
{
    public class ChestGrantedController
    {
        private IChestGrantedView view;
        private ChestGrantedEventHandler eventHandler;
        public ChestGrantedController(IChestGrantedView view)
        {
            this.view = view;
            eventHandler = new ChestGrantedEventHandler();
            eventHandler.LeagueClientStatus += LeagueClientStatus;
            ConnectLC();
        }

        private void LeagueClientStatus(object sender, LeagueClientStatusChange e)
        {
            view.LoLIsRunning = e.IsRunning;
            if (e.IsRunning)
            {
                // get summoner info
            }
            else
            {
                // TODO unsubscribe of all events

                // wait untill LC is opened again
                ConnectLC();
            }
        }

        private async void ConnectLC()
        {
            await eventHandler.Connect();
        }



    }
}
