using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace ChestGrantedRepository.EventsArgs
{
    /// <summary>
    ///     Communication class for threads
    /// </summary>
    public class LeagueClientStatusChange
    {
        private bool _isRunning;
        internal LeagueClientStatusChange(bool isRunning)
        {
            _isRunning = isRunning;
        }

        /// <summary>
        ///     LoLC is running?
        /// </summary>
        public bool IsRunning { get => _isRunning; }
    }
}
