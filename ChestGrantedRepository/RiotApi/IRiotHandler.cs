using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.RiotApi
{
    public interface IRiotHandler
    {
        public event EventHandler<List<Champion>> OnUpdateAllChestGranted;

        public Task GetSummonerByName(string summonerName);
        public Task UpdateAllChestGranted();
        public List<Champion> GetChestGrantedById(List<int> ids);
    }
}
