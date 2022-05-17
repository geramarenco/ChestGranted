using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.LeagueClient.EventsArgs
{
    public class LeagueClientBuild
    {
        public string branch { get; internal set; }
        public string patchline { get; internal set; }
        public string patchlineVisibleName { get; internal set; }
        public string version { get; internal set; }
    }
}
