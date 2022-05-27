using ChestGrantedRepository.RiotApi.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ChestGrantedRepository.RiotApi
{
    public class RiotHandler : IRiotHandler
    {
        public event EventHandler<List<Champion>> OnUpdateAllChestGranted;

        private readonly SynchronizationContext SyncContext;
        private string Region;
        private string EncryptedSummonerId;
        private List<Champion> Champions = null;

        private string ApiUrl { get => $"https://{Region}.api.riotgames.com/lol"; }
        private string ApiToken { get; set; }

        public RiotHandler(string region)
        {
            Region = region.ToLower();
            SyncContext = AsyncOperationManager.SynchronizationContext;
            // TODO this es temporal, only until RIOT give me a production token
            GetApiKeyFromFile();
        }

        private void GetApiKeyFromFile()
        {
            var path = System.Reflection.Assembly.GetEntryAssembly().Location;
            path = Path.GetDirectoryName(path);
            var tokenPath = $"{path}\\RiotApi.txt";
            using (StreamReader r = new StreamReader(tokenPath))
            {
                ApiToken = r.ReadLine();
            }
        }

        public async Task GetSummonerByName(string summonerName)
        {
            try
            {
                var url = $"{ApiUrl}/{RiotApiEndPoints.SummonerByName}/{summonerName}";
                var client = new HttpClient();

                var msg = new HttpRequestMessage(HttpMethod.Get, url);
                msg.Headers.Add("X-Riot-Token", ApiToken);

                var res = await client.SendAsync(msg);
                if (res.StatusCode != HttpStatusCode.OK)
                    throw new Exception($"imposible connect to RiotApi - response code : {res.StatusCode} - URL: {url} - Token: {ApiToken}");

                var json = await res.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<Summoner>(json);

                EncryptedSummonerId = result.id;

            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}.GetSummonerByName - {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAllChestGranted()
        {
            try
            {
                var url = $"{ApiUrl}/{RiotApiEndPoints.ChampionMasteriesBySummoner}/{EncryptedSummonerId}";
                var client = new HttpClient();

                var msg = new HttpRequestMessage(HttpMethod.Get, url);
                msg.Headers.Add("X-Riot-Token", ApiToken);

                var res = await client.SendAsync(msg);
                if(res.StatusCode != HttpStatusCode.OK)
                    throw new Exception($"imposible connect to RiotApi - response code : {res.StatusCode} - URL: {url} - Token: {ApiToken}");

                var json = await res.Content.ReadAsStringAsync();
                var champs = JsonSerializer.Deserialize<List<ChampionMastery>>(json);

                Champions = new List<Champion>();
                foreach (ChampionMastery c in champs)
                {
                    var champ = new Champion()
                    {
                        Id = c.championId,
                        ChestEarned = c.chestGranted,
                    };
                    Champions.Add(champ);
                }
                
                SyncContext.Post(e => OnUpdateAllChestGranted?.Invoke(this, Champions), null);
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}.UpdateAllChestGranted - {ex.Message}");
                throw;
            }
        }

        public List<Champion> GetChestGrantedById(List<int> ids)
        {
            try
            {
                var result = Champions.Where(x => ids.Contains(x.Id)).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name}.GetChestGrantedById - {ex.Message}");
                throw;
            }
        }
    }
}
