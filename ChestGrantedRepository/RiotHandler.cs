using ChestGrantedRepository.RiotApi.EventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChestGrantedRepository
{
    public class RiotHandler
    {
        private const string API_KEY = "RGAPI-2f428ba2-b5ec-4cc6-b474-74de1a70c2fe";
        private readonly SynchronizationContext SyncContext;
        private string Region;
        private string EncryptedSummonerId;

        public RiotHandler(string region, string summonerName)
        {
            Region = region;
            SyncContext = AsyncOperationManager.SynchronizationContext;
            GetEncryptedSummonerId(summonerName);
        }

        private async void GetEncryptedSummonerId(string summonerName)
        {
            await GetSummonerByName(summonerName);
        }

        private Task GetSummonerByName(string summonerName)
        {
            throw new NotImplementedException();
            //https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/Arcessam?api_key=API_KEY
            EncryptedSummonerId = "";
        }

        public async Task<List<Champion>> GetChestGrantedById(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
