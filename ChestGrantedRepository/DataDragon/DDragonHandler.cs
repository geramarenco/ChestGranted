using ChestGrantedRepository.DataDragon.Responses;
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
    public class DDragonHandler : IDDragonHandler
    {
        public event EventHandler<SummonerImage> OnGetProfileIcon;

        private readonly SynchronizationContext SyncContext;
        private string Version;
        private string ResoursesPath;
        private RootChampion champs;

        private string ChampsIconsPath { get => $"{ResoursesPath}\\ChampionsIcons";  }
        private string ProfileIconsPath { get => $"{ResoursesPath}\\ProfileIcons"; }
        private string UrlProfileIcon { get => $"https://ddragon.leagueoflegends.com/cdn/{Version}/img/profileicon"; }
        private string UrlChampions { get => $"http://ddragon.leagueoflegends.com/cdn/{Version}/data/en_US/champion.json"; }
        private string UrlChampionsIcons { get => $"http://ddragon.leagueoflegends.com/cdn/{Version}/img/champion"; }

        public DDragonHandler(string version)
        {
            Version = version;
            SyncContext = AsyncOperationManager.SynchronizationContext;
            var path = System.Reflection.Assembly.GetEntryAssembly().Location;
            path = Path.GetDirectoryName(path);
            ResoursesPath = $"{path}\\{Version}";
            Directory.CreateDirectory(ResoursesPath);
            Directory.CreateDirectory(ChampsIconsPath);
            Directory.CreateDirectory(ProfileIconsPath);
        }

        public void GetProfileIcon(int iconId)
        {
            var response = new SummonerImage();
            response.profileIconPath = "";

            try
            {
                var icon = iconId.ToString();
                var filePath = $"{ProfileIconsPath}\\{icon}.png";

                if (!File.Exists(filePath))
                {
                    var url = $"{UrlProfileIcon}/{iconId}.png";
                    DownloadFile(url, filePath);
                }

                response.profileIconPath = filePath;
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name} - GetProfileIcon " + ex.Message);
            }

            if (response.profileIconPath != "")
                SyncContext.Post(e => OnGetProfileIcon?.Invoke(this, response), null);
        }

        private void GetChampionsJson()
        {
            try
            {
                var champsPath = $"{ResoursesPath}\\champion.json";
                if (!File.Exists(champsPath))
                {
                    DownloadFile(UrlChampions, champsPath);
                }

                using (StreamReader r = new StreamReader(champsPath))
                {
                    string json = r.ReadToEnd();
                    champs = JsonConvert.DeserializeObject<RootChampion>(json);
                }
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name} - GetPGetChampionsJsonrofileIcon " + ex.Message);
            }
        }

        public List<Champion> GetChampionData(List<int> ids)
        {
            try
            {
                var result = new List<Champion>();
                var champIds = ids.Select(x => x.ToString()).ToList();
                if (champs == null) GetChampionsJson();

                var filteredChamps = champs.Data.Where(x => champIds.Contains(x.Value.key)).ToList();
                List<Responses.Champion> champions = filteredChamps.Select(x => x.Value).ToList();

                foreach (var c in champions)
                {
                    var filePath = $"{ChampsIconsPath}\\{c.image.full}";

                    if (!File.Exists(filePath))
                    {
                        var url = $"{UrlChampionsIcons}/{c.image.full}";
                        DownloadFile(url, filePath);
                    }
                    var champ = new Champion()
                    {
                        Id = int.Parse(c.key),
                        PictureName = c.image.full,
                        Name = c.name,
                        PicturePath = filePath,
                    };

                    result.Add(champ);
                }

                return result;
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name} - GetChampionData " + ex.Message);
                throw;
            }
        }

        private void DownloadFile(string url, string fileName)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, fileName);
            }
        }

        public void GetAllChampionsIconsAsync()
        {
            if (champs == null) GetChampionsJson();
            Thread thread = new Thread(new ThreadStart(DonwloadAll));
            thread.Start();
        }

        private void DonwloadAll()
        {
            try
            {
                List<Responses.Champion> champions = champs.Data.Select(x => x.Value).ToList();

                foreach (Responses.Champion c in champions)
                {
                    var filePath = $"{ChampsIconsPath}\\{c.image.full}";

                    if (!File.Exists(filePath))
                    {
                        var url = $"{UrlChampionsIcons}/{c.image.full}";
                        DownloadFile(url, filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                Helpers.Log($"{GetType().Name} - DonwloadAll " + ex.Message);
            }
        }

        public void DeleteAllPreviousData()
        {
            // TODO
        }
    }
}
