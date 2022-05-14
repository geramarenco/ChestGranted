﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository
{
    internal static class LCUEndPoints
    {
        public const string SummonerProfile = "lol-summoner/v1/current-summoner/summoner-profile";
        public const string CurrentSummoner = "lol-summoner/v1/current-summoner";
        public const string ChestEligibility = "lol-collections/v1/inventories/chest-eligibility";
        public const string GameFlow = "lol-gameflow/v1/gameflow-phase";
        public const string ChampSelectSession = "lol-champ-select/v1/session";
    }
}
