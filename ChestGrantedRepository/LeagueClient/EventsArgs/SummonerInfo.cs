using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.LeagueClient.EventsArgs
{
    public class SummonerInfo
    {
        public int summonerId { get; internal set; }
        public string displayName { get; internal set; }
        public int earnableChests { get; internal set; }
        public int profileIconId { get; internal set; }
        public string profileIconPath { get; internal set; }
    }
}
