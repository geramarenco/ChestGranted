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
        public GameMode GameSelected { get; internal set; }
        public int mapId { get; internal set; }
        public string partyId { get; internal set; }
        public string partyType { get; internal set; }
        public int queueId { get; internal set; }
    }
}
