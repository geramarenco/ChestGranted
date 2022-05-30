using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.LeagueClient.Responses
{
    class LoginDataPacket
    {
        public double bannedUntilDateMillis { get; set; }
        public BroadcastNotification broadcastNotification { get; set; }
        public double coOpVsAiMinutesLeftToday { get; set; }
        public double coOpVsAiMsecsUntilReset { get; set; }
        public string competitiveRegion { get; set; }
        public double customMinutesLeftToday { get; set; }
        public double customMsecsUntilReset { get; set; }
        public bool displayPrimeReformCard { get; set; }
        public string emailStatus { get; set; }
        public List<GameTypeConfig> gameTypeConfigs { get; set; }
        public bool inGhostGame { get; set; }
        public List<string> languages { get; set; }
        public double leaverBusterPenaltyTime { get; set; }
        public bool matchMakingEnabled { get; set; }
        public double maxPracticeGameSize { get; set; }
        public bool minor { get; set; }
        public bool minorShutdownEnforced { get; set; }
        public double minutesUntilMidnight { get; set; }
        public double minutesUntilShutdown { get; set; }
        public bool minutesUntilShutdownEnabled { get; set; }
        public object platformGameLifecycle { get; set; }
        public string platformId { get; set; }
        public object playerStatSummaries { get; set; }
        public double restrictedChatGamesRemaining { get; set; }
        public double restrictedGamesRemainingForRanked { get; set; }
        public bool showEmailVerificationPopup { get; set; }
        public List<SimpleMessage> simpleMessages { get; set; }
    }

    class BroadcastNotification
    {
        public object broadcastMessages { get; set; }
    }

    class GameTypeConfig
    {
        public bool allowTrades { get; set; }
        public string banMode { get; set; }
        public double banTimerDuration { get; set; }
        public bool crossTeamChampionPool { get; set; }
        public bool duplicatePick { get; set; }
        public bool exclusivePick { get; set; }
        public double id { get; set; }
        public double mainPickTimerDuration { get; set; }
        public double maxAllowableBans { get; set; }
        public string name { get; set; }
        public string pickMode { get; set; }
        public double postPickTimerDuration { get; set; }
        public bool teamChampionPool { get; set; }
    }

    class SimpleMessage
    {
        public double accountId { get; set; }
        public string bodyCode { get; set; }
        public string msgId { get; set; }
        public List<string> @params { get; set; }
        public string titleCode { get; set; }
        public string type { get; set; }
    }
}
