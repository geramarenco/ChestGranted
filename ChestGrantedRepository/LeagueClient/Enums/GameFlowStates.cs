﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.LeagueClient.Enums
{
    public enum GameFlowStates
    {
        Other,
        None,
        Lobby,
        ChampSelect,
        GameStart,
        InProgress,
        WaitingForStats,
        EndOfGame,
        PreEndOfGame,
    }
}