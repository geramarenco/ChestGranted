using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.LeagueClient.EventsArgs
{
    public class SummonerImage
    {
        public int summonerId { get; internal set; }
        public string profileIconPath { get; internal set; }
    }
}
