using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.LeagueClient.Responses
{
    class GameFlowSession
    {
        public GameClient gameClient { get; set; }
        public GameData gameData { get; set; }
        public GameDodge gameDodge { get; set; }
        public Map map { get; set; }
        public string phase { get; set; }
    }

    class CategorizedContentBundles
    {
    }

    class GameClient
    {
        public string observerServerIp { get; set; }
        public int observerServerPort { get; set; }
        public bool running { get; set; }
        public string serverIp { get; set; }
        public int serverPort { get; set; }
        public bool visible { get; set; }
    }

    class GameData
    {
        public int gameId { get; set; }
        public string gameName { get; set; }
        public bool isCustomGame { get; set; }
        public string password { get; set; }
        public List<object> playerChampionSelections { get; set; }
        public Queue queue { get; set; }
        public bool spectatorsAllowed { get; set; }
        public List<object> teamOne { get; set; }
        public List<object> teamTwo { get; set; }
    }

    class GameDodge
    {
        public List<object> dodgeIds { get; set; }
        public string phase { get; set; }
        public string state { get; set; }
    }

    class Map
    {
        //public string assets { get; set; }
        public CategorizedContentBundles categorizedContentBundles { get; set; }
        public string description { get; set; }
        public string gameMode { get; set; }
        public string gameModeName { get; set; }
        public string gameModeShortName { get; set; }
        public string gameMutator { get; set; }
        public int id { get; set; }
        public bool isRGM { get; set; }
        public string mapStringId { get; set; }
        public string name { get; set; }
        public PerPositionDisallowedSummonerSpells perPositionDisallowedSummonerSpells { get; set; }
        public PerPositionRequiredSummonerSpells perPositionRequiredSummonerSpells { get; set; }
        public string platformId { get; set; }
        public string platformName { get; set; }
        public Properties properties { get; set; }
    }

    class PerPositionDisallowedSummonerSpells
    {
    }

    class PerPositionRequiredSummonerSpells
    {
    }

    class Properties
    {
        public bool suppressRunesMasteriesPerks { get; set; }
    }

    class Queue
    {
        public List<int> allowablePremadeSizes { get; set; }
        public bool areFreeChampionsAllowed { get; set; }
        public string assetMutator { get; set; }
        public string category { get; set; }
        public int championsRequiredToPlay { get; set; }
        public string description { get; set; }
        public string detailedDescription { get; set; }
        public string gameMode { get; set; }
        public GameTypeConfig gameTypeConfig { get; set; }
        public int id { get; set; }
        public bool isRanked { get; set; }
        public bool isTeamBuilderManaged { get; set; }
        public bool isTeamOnly { get; set; }
        public long lastToggledOffTime { get; set; }
        public long lastToggledOnTime { get; set; }
        public int mapId { get; set; }
        public int maxLevel { get; set; }
        public int maxSummonerLevelForFirstWinOfTheDay { get; set; }
        public int maximumParticipantListSize { get; set; }
        public int minLevel { get; set; }
        public int minimumParticipantListSize { get; set; }
        public string name { get; set; }
        public int numPlayersPerTeam { get; set; }
        public string queueAvailability { get; set; }
        public QueueRewards queueRewards { get; set; }
        public bool removalFromGameAllowed { get; set; }
        public int removalFromGameDelayMinutes { get; set; }
        public string shortName { get; set; }
        public bool showPositionSelector { get; set; }
        public bool spectatorEnabled { get; set; }
        public string type { get; set; }
    }

    class QueueRewards
    {
        public bool isChampionPointsEnabled { get; set; }
        public bool isIpEnabled { get; set; }
        public bool isXpEnabled { get; set; }
        public List<object> partySizeIpRewards { get; set; }
    }
}
