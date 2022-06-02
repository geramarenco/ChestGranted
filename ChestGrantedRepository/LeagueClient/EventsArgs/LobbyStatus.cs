using ChestGrantedRepository.LeagueClient.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.LeagueClient.EventsArgs
{
    public class LobbyStatus
    {
        public double gameId { get; internal set; }
        public bool isCustomGame { get; internal set; }
        public GameMode GameMode { get; internal set; }
        public int id { get; internal set; }
        public string type { get; internal set; }
        public int mapId { get; internal set; }
        public string mapStringId { get; internal set; }
    }
}
