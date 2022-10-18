using ChestGrantedRepository.RiotApi.Response;
using Microsoft.Extensions.Configuration;
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
        public event EventHandler<RiotApiException> OnGetError;

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
            GetApiKeyFromSecrets();
        }

        private void GetApiKeyFromSecrets()
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .AddUserSecrets<RiotHandler>()
                    .Build();
                ApiToken = config["RiotApiKey"];
            }
            catch (Exception ex)
            {
                throw new Exception("Getting api token", ex);
            }
        }

        private void CheckForConfig()
        {
            if (Region == string.Empty)
                throw new RiotApiException("Summoner region is not configured");

            if(EncryptedSummonerId == string.Empty)
                throw new RiotApiException("Encrypted summoner id is not configured");

            if (ApiToken == string.Empty)
                throw new RiotApiException("Riot token is not configured");
        }

        public async Task GetSummonerByName(string summonerName)
        {
            try
            {
                CheckForConfig();

                var url = $"{ApiUrl}/{RiotApiEndPoints.SummonerByName}/{summonerName}";
                var client = new HttpClient();

                var msg = new HttpRequestMessage(HttpMethod.Get, url);
                msg.Headers.Add("X-Riot-Token", ApiToken);

                var res = await client.SendAsync(msg);
                if (res.StatusCode == HttpStatusCode.Forbidden)
                    throw new RiotApiException($"impossible connect to RiotApi check your Riot Token");

                if (res.StatusCode != HttpStatusCode.OK)
                    throw new Exception($"impossible connect to RiotApi - response code : {res.StatusCode} - URL: {url} - Token: {ApiToken}");

                var json = await res.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<Summoner>(json);

                EncryptedSummonerId = result.id;
            }
            catch (RiotApiException ex)
            {
                SyncContext.Post(e => OnGetError?.Invoke(this, ex), null);
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
                if (res.StatusCode == HttpStatusCode.Forbidden)
                    throw new RiotApiException($"impossible connect to RiotApi check your Riot Token");

                if (res.StatusCode != HttpStatusCode.OK)
                    throw new Exception($"impossible connect to RiotApi - response code : {res.StatusCode} - URL: {url} - Token: {ApiToken}");

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
            catch(RiotApiException ex)
            {
                SyncContext.Post(e => OnGetError?.Invoke(this, ex), null);
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
