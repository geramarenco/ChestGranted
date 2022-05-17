using ChestGrantedRepository.LeagueClient.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedController.Class
{
    public class SelectedChampion
    {
        public long summonerId { get; internal set; }
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string PicturePath { get; internal set; }
        public bool ChestEarned { get; internal set; }
    }
}
