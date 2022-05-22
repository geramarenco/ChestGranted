using ChestGrantedRepository;
using ChestGrantedRepository.DataDragon;
using ChestGrantedRepository.DataDragon.Responses;
using ChestGrantedRepository.LeagueClient;
using ChestGrantedRepository.LeagueClient.Enums;
using ChestGrantedRepository.LeagueClient.EventsArgs;
using ChestGrantedRepository.RiotApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedController
{
    public class CGController
    {
        private IChestGrantedView view;
        private ILCUHandler LCUHandler;
        private IDDragonHandler dragonHandler;
        private IRiotHandler riotHandler;

        private SummonerInfo summoner = null;
        private GameMode currentMap;
        private string region = string.Empty;
        private bool HasChampionsGrantedChestUpdated = false;

        public CGController(IChestGrantedView view)
        {
            this.view = view;
            CleanShownData();

            LCUHandler = new LCUHandler();
            LCUHandler.OnLeagueClientStatusChange += OnLeagueClientStatusChange;
            LCUHandler.OnGameFlowChanged += OnGameFlowChanged;
            LCUHandler.OnGetCurrentSummoner += OnGetCurrentSummoner;
            LCUHandler.OnGetChestEligibility += OnGetChestEligibility;
            LCUHandler.OnChampSelectedChanged += OnChampSelectedChanged;
            LCUHandler.OnGetSystemBuild += OnGetSystemBuild;
            LCUHandler.OnGetLobbyStatus += OnGetLobbyStatus;

            ConnectLC();
            InitialiceRiotApi();
        }

        private async void InitialiceRiotApi()
        {
            if (riotHandler != null) return;
            if (region == string.Empty) return;
            if (summoner == null) return;

            riotHandler = new RiotHandler(region);
            riotHandler.OnUpdateAllChestGranted += OnUpdateAllChestGranted;
            await riotHandler.GetSummonerByName(summoner.displayName);
        }

        private async void ConnectLC()
        {
            await LCUHandler.Connect();
            await LCUHandler.GetSystemBuild();
            var objRegion = await LCUHandler.ExperimentalGetRegion();
            if (objRegion != null)
            {
                region = objRegion.summonerRegion;
                InitialiceRiotApi();
            }
        }

        private void OnGetSystemBuild(object sender, LeagueClientBuild e)
        {
            // e.version = "12.9.440.3307"
            var aVersion = e.version.Split(".");
            var version = $"{aVersion[0]}.{aVersion[1]}.1";

            dragonHandler = new DDragonHandler(version);
            dragonHandler.OnGetProfileIcon += OnGetProfileIcon;
            dragonHandler.GetAllChampionsIconsAsync();
        }

        private void OnLeagueClientStatusChange(object sender, LeagueClientStatusChange e)
        {
            if (e.IsRunning)
            {
                UpdateSummonerInfo();
                UpdateChestInfo();
                GetCurrentStage();             
                view.LoLIsRunning = true;
            }
            else
            {
                view.LoLIsRunning = false;
                CleanShownData();
                ConnectLC();
            }
        }

        private async void GetCurrentStage()
        {
            GameFlowChanged stage = await LCUHandler.GetCurrentStage();
            if (stage.State == GameFlowStates.ChampSelect)
            {
                ChampionPool champs = await GetCurrentSelectedChamp();
                OnGameFlowChanged(this, stage);
                OnChampSelectedChanged(this, champs);
            }
        }

        private async Task<ChampionPool> GetCurrentSelectedChamp()
        {
            ChampionPool champs = await LCUHandler.GetCurrentSelectedChamp();
            return champs;
        }

        private void CleanShownData()
        {
            view.EarnableChests = 0;
            view.SummonerName = "";
        }

        private void UpdateChestInfo()
        {
            _ = LCUHandler.GetChestEligibility();
        }

        private void OnGetChestEligibility(object sender, SummonerInfo e)
        {
            view.EarnableChests = e.earnableChests;
        }

        private void UpdateSummonerInfo()
        {
            _ = LCUHandler.GetCurrentSummoner();
        }

        private void OnGetCurrentSummoner(object sender, SummonerInfo e)
        {
            summoner = e;
            view.SummonerName = e.displayName;
            GetProfileIcon(e.profileIconId);
            InitialiceRiotApi();
        }

        private void GetProfileIcon(int profileIconId)
        {
            if(dragonHandler != null)
                dragonHandler.GetProfileIcon(profileIconId);
        }

        private void OnGetProfileIcon(object sender, SummonerImage e)
        {
            view.ProfilePicture = e.profileIconPath;
        }

        private void OnGameFlowChanged(object sender, GameFlowChanged e)
        {
            if (e.State == GameFlowStates.ChampSelect)
            {
                view.ChampSelectStageVisible = true;
                LCUHandler.SubscribeToChampSelected();
            }
            else
            {
                view.ChampSelectStageVisible = false;
                LCUHandler.UnsubscribeToChampSelected();
            }

            if (e.State == GameFlowStates.WaitingForStats)
            {
                HasChampionsGrantedChestUpdated = false;
                _ = riotHandler.UpdateAllChestGranted();
                UpdateChestInfo();
            }
                
        }

        private async void OnChampSelectedChanged(object sender, ChampionPool e)
        {
            // getting champs selected from all my team
            var champs = new List<Champion>();
            champs.AddRange(e.SelectedChampions);
            champs.RemoveAll(x => x.Id == 0);

            if (!champs.Any())
            {
                view.MySelectedChamp = null;
                view.MyTeamChamps = null;
                return;
            }

            var ids = champs.Where(x => x.Id != 0).Select(x => x.Id).ToList();
            ids.AddRange(e.AvailableTrades.Select(x => x.ChampionId).ToList());

            var champsData = dragonHandler.GetChampionData(ids);
            if (!HasChampionsGrantedChestUpdated)
                await riotHandler.UpdateAllChestGranted();

            var chestsGranted = riotHandler.GetChestGrantedById(ids);


            foreach (Champion c in champs)
            {
                var foundChamp = champsData.FirstOrDefault(x => x.Id == c.Id);
                if (foundChamp == null)
                    Console.WriteLine("whyyyy");
                else
                {
                    c.Name = foundChamp.Name;
                    c.PictureName = foundChamp.PictureName;
                    c.PicturePath = foundChamp.PicturePath;
                    c.ChestEarned = chestsGranted.FirstOrDefault(x => x.Id == c.Id).ChestEarned;
                }
            }

            // getting champs from posible trades
            var trades = new List<Champion>();
            trades.AddRange(e.AvailableTrades.Select(x => new Champion() { Id = x.ChampionId}).ToList());

            foreach (Champion c in trades)
            {
                var foundChamp = champsData.FirstOrDefault(x => x.Id == c.Id);
                if (foundChamp == null)
                    Console.WriteLine("whyyyy");
                else
                {
                    c.SummonerId = 0;
                    c.Name = foundChamp.Name;
                    c.PictureName = foundChamp.PictureName;
                    c.PicturePath = foundChamp.PicturePath;
                    c.ChestEarned = chestsGranted.FirstOrDefault(x => x.Id == c.Id).ChestEarned;
                }
            }

            view.MySelectedChamp = champs.FirstOrDefault(x => x.SummonerId == summoner.summonerId);
            champs.RemoveAll(x => x.SummonerId == summoner.summonerId);
            view.MyTeamChamps = champs;
        }

        private void OnGetLobbyStatus(object sender, LobbyStatus e)
        {
            currentMap = e.GameSelected;
        }

        private void OnUpdateAllChestGranted(object sender, List<Champion> e)
        {
            HasChampionsGrantedChestUpdated = true;
        }

    }
}
