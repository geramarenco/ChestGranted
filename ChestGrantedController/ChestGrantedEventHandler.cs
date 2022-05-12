using ChestGrantedCore.EventsArgs;
using LCUSharp;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace ChestGrantedCore
{
    class ChestGrantedEventHandler
    {
        public ChestGrantedEventHandler()
        {
            SyncContext = AsyncOperationManager.SynchronizationContext;
        }

        // Message sender
        private readonly SynchronizationContext SyncContext;
        private LeagueClientApi api;

        #region Public Events

        public event EventHandler<LeagueClientStatusChange> LeagueClientStatus;
        public event EventHandler<CurrentSummoner> OnGetCurrentSummoner;


        #endregion

        public async Task Connect()
        {
            // Initialize a connection to the league client.
            api = await LeagueClientApi.ConnectAsync();
            api.Disconnected += OnGameDisconected;
            var response = new LeagueClientStatusChange(true);
            SyncContext.Post(e => LeagueClientStatus?.Invoke(this, response), null);
        }

        private void OnGameDisconected(object sender, EventArgs e)
        {
            api.Disconnected -= OnGameDisconected;
            var response = new LeagueClientStatusChange(false);
            SyncContext.Post(e => LeagueClientStatus?.Invoke(this, response), null);
        }
    }
}
