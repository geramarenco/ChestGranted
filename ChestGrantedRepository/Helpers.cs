using ChestGrantedRepository.LeagueClient.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository
{
    static class Helpers
    {
        public static GameFlowStates GetStateFromString(string state)
        {
            var result = GameFlowStates.Other;
            
            var list = Enum.GetNames(typeof(GameFlowStates)).ToList();
            if (list.Any(x => x == state))
                result = (GameFlowStates)Enum.Parse(typeof(GameFlowStates), state);

            return result;
        }
    }
}
