using ChestGrantedRepository.RiotApi.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        private const string API_KEY = "RGAPI-49bf8f8d-b2ae-4c00-b898-1a80de7f3812"; // for development purpose only
        private readonly SynchronizationContext SyncContext;
        private string Region;
        private string EncryptedSummonerId;
        private List<Champion> Champions = null;

        private string ApiUrl { get => $"https://{Region}.api.riotgames.com/lol"; }

        public RiotHandler(string region)
        {
            Region = region.ToLower();
            SyncContext = AsyncOperationManager.SynchronizationContext;
        }

        public async Task GetSummonerByName(string summonerName)
        {
            try
            {
                var url = $"{ApiUrl}/{RiotApiEndPoints.SummonerByName}/{summonerName}";
                var client = new HttpClient();

                var msg = new HttpRequestMessage(HttpMethod.Get, url);
                msg.Headers.Add("X-Riot-Token", API_KEY);

                var res = await client.SendAsync(msg);
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
                msg.Headers.Add("X-Riot-Token", API_KEY);

                var res = await client.SendAsync(msg);
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
