using ChestGrantedRepository.DataDragon.Responses;
using ChestGrantedRepository.LeagueClient.EventsArgs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChestGrantedRepository.DataDragon
{
    public interface IDDragonHandler
    {
        public event EventHandler<SummonerImage> OnGetProfileIcon;

        public void GetProfileIcon(int iconId);
        public List<Champion> GetChampionData(List<int> ids);
        public void GetAllChampionsIconsAsync();
        public void DeleteAllPreviousData();
    }
}
