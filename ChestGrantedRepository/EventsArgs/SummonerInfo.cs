using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.EventsArgs
{
    public class SummonerInfo
    {
        public string displayName { get; internal set; }
        public int earnableChests { get; internal set; }
        public int profileIconId { get; internal set; }
    }
}
