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

namespace ChestGrantedRepository
{
    public class DDragonHandler
    {
        private readonly SynchronizationContext SyncContext;
        private string Version;
        private string ResoursesPath;
        private RootChampion champs;

        public event EventHandler<SummonerImage> OnGetProfileIcon;

        public DDragonHandler(string version)
        {
            Version = version;
            SyncContext = AsyncOperationManager.SynchronizationContext;
            var path = System.Reflection.Assembly.GetEntryAssembly().Location;
            path = Path.GetDirectoryName(path);
            ResoursesPath = $"{path}\\{Version}";
            Directory.CreateDirectory(ResoursesPath);
        }

        public void GetProfileIcon(int iconId)
        {
            var response = new SummonerImage();
            response.profileIconPath = GetProfileIconPath(iconId);

            if(response.profileIconPath != "")
                SyncContext.Post(e => OnGetProfileIcon?.Invoke(this, response), null);
        }

        private string GetProfileIconPath(int iconId)
        {
            try
            {
                var icon = iconId.ToString();
                var filePath = $"{ResoursesPath}\\{icon}.png";

                if (!File.Exists(filePath))
                {
                    var url = $"https://ddragon.leagueoflegends.com/cdn/{Version}/img/profileicon/{iconId}.png";
                    DownloadFile(url, filePath);
                }

                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        private void GetChampionsJson()
        {
            var champsPath = $"{ResoursesPath}\\champion.json";
            if (!File.Exists(champsPath))
            {
                var url = $"http://ddragon.leagueoflegends.com/cdn/{Version}/data/en_US/champion.json";
                DownloadFile(url, champsPath);
            }

            using (StreamReader r = new StreamReader(champsPath))
            {
                string json = r.ReadToEnd();
                champs = JsonConvert.DeserializeObject<RootChampion>(json);
            }
        }

        public Champion GetChampionData(int id)
        {
            var champId = id.ToString();
            if (champs == null) GetChampionsJson();

            var filteredChamp = champs.Data.Where(x => x.Value.key == champId).FirstOrDefault();
            DataDragon.Responses.Champion champ = filteredChamp.Value;
            var filePath = $"{ResoursesPath}\\{champ.image.full}";
            if (!File.Exists(filePath))
            {
                var url = $"http://ddragon.leagueoflegends.com/cdn/{Version}/img/champion/{champ.image.full}";
                DownloadFile(url, filePath);
            }

            var result = new Champion()
            {
                Id = int.Parse(champ.key),
                PictureName = champ.image.full,
                Name = champ.name,
                PicturePath = filePath,
            };

            return result;
        }

        public List<Champion> GetChampionData(List<int> ids)
        {
            var result = new List<Champion>();
            var champIds = ids.Select(x => x.ToString()).ToList();
            if (champs == null) GetChampionsJson();

            var filteredChamps = champs.Data.Where(x => champIds.Contains(x.Value.key)).ToList();
            List<DataDragon.Responses.Champion> champions = filteredChamps.Select(x => x.Value).ToList();

            foreach (var c in champions)
            {
                var filePath = $"{ResoursesPath}\\{c.image.full}";

                if (!File.Exists(filePath))
                {
                    var url = $"http://ddragon.leagueoflegends.com/cdn/{Version}/img/champion/{c.image.full}";
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

        private void DownloadFile(string url, string fileName)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, fileName);
            }
        }
    }
}
