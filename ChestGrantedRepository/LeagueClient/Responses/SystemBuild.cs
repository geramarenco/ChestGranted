using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.LeagueClient.Responses
{
    class SystemBuild
    {
        public string branch { get; set; }
        public string patchline { get; set; }
        public string patchlineVisibleName { get; set; }
        public string version { get; set; }
    }
}
