using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ChestGrantedRepository.Enums;

namespace ChestGrantedRepository.PublicEventsArgs
{
    public class GameFlowChangedResponse
    {
        private GameFlowStates _state;
        internal GameFlowChangedResponse(GameFlowStates state)
        {
            _state = state;
        }

        public GameFlowStates State { get => _state; }
    }
}
