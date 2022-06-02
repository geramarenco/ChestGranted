using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.LeagueClient.Responses
{
    class GameTypeConfig
    {
        public bool advancedLearningQuests { get; set; }
        public bool allowTrades { get; set; }
        public string banMode { get; set; }
        public double banTimerDuration { get; set; }
        public bool battleBoost { get; set; }
        public bool crossTeamChampionPool { get; set; }
        public bool deathMatch { get; set; }
        public bool doNotRemove { get; set; }
        public bool duplicatePick { get; set; }
        public bool exclusivePick { get; set; }
        public double id { get; set; }
        public bool learningQuests { get; set; }
        public double mainPickTimerDuration { get; set; }
        public double maxAllowableBans { get; set; }
        public string name { get; set; }
        public bool onboardCoopBeginner { get; set; }
        public string pickMode { get; set; }
        public double postPickTimerDuration { get; set; }
        public bool reroll { get; set; }
        public bool teamChampionPool { get; set; }
    }
}
