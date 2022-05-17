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

        public string GetChampionNameById(int id)
        {
            var champId = id.ToString();
            if(champs == null)
            {
                var champsPath = $"{ResoursesPath}\\champion.json";
                var url = $"http://ddragon.leagueoflegends.com/cdn/{Version}/data/en_US/champion.json";
                DownloadFile(url, champsPath);

                using (StreamReader r = new StreamReader("file.json"))
                {
                    string json = r.ReadToEnd();
                    champs = JsonConvert.DeserializeObject<RootChampion>(json);
                }
            }

            return "";
        }

        private void GetChampionsJson()
        {
        //http://ddragon.leagueoflegends.com/cdn/6.24.1/data/en_US/champion.json
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

        private void DownloadFile(string url, string fileName)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, fileName);
            }
        }

        private void LoadJson()
        {
            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                RootChampion champs = JsonConvert.DeserializeObject<RootChampion>(json);
            }
        }
    }
}
