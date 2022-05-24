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
        private GameMode currentMode;
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
            LCUHandler.OnGetCurrentStage += OnGetCurrentStage;
            LCUHandler.OnGetCurrentSelectedChamp += OnGetCurrentSelectedChamp;
            LCUHandler.OnGetRegion += OnGetRegion;

            ConnectLC();
            InitializeRiotApi();
        }

        private async void InitializeRiotApi()
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
            await LCUHandler.ExperimentalGetRegion();
        }

        private void OnGetRegion(object sender, Region e)
        {
            if (e != null)
            {
                region = e.summonerRegion;
                InitializeRiotApi();
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
                LCUHandler.GetCurrentStage();
                view.LoLIsRunning = true;
            }
            else
            {
                view.LoLIsRunning = false;
                CleanShownData();
                ConnectLC();
            }
        }

        private void OnGetCurrentStage(object sender, GameFlowChanged e)
        {
            if (e.State == GameFlowStates.ChampSelect)
            {
                LCUHandler.GetCurrentSelectedChamp();
                OnGameFlowChanged(this, e);
            }
        }

        private void OnGetCurrentSelectedChamp(object sender, ChampionPool e)
        {
            OnChampSelectedChanged(this, e);
        }

        private void CleanShownData()
        {
            view.EarnableChests = 0;
            view.SummonerName = "";
            view.MySelectedChamp = null;
            view.PickableChampions = null;
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
            InitializeRiotApi();
        }

        private void GetProfileIcon(int profileIconId)
        {
            if (dragonHandler != null)
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
            }
            else
            {
                view.ChampSelectStageVisible = false;
            }

            if (e.State == GameFlowStates.WaitingForStats)
            {
                HasChampionsGrantedChestUpdated = false;
                _ = riotHandler.UpdateAllChestGranted();
                UpdateChestInfo();
            }
                
        }

        private void OnChampSelectedChanged(object sender, ChampionPool e)
        {
            // TODO get map info to for improve of displayed data
            ARAMSettings(e.SelectedChampions, e.BenchChampions);
        }

        private async void ARAMSettings(List<Champion> teamSelecction, List<BenchChampion> benchChampions)
        {
            // getting champs selected from all my team
            var champs = new List<Champion>();
            champs.AddRange(teamSelecction);
            // remove summoner with out champ selected
            champs.RemoveAll(x => x.Id == 0);

            if (!champs.Any())
            {
                view.MySelectedChamp = null;
                view.PickableChampions = null;
                return;
            }

            // crete a list of ids for collect data
            var ids = champs.Where(x => x.Id != 0).Select(x => x.Id).ToList();
            // add to list the champs on the bench
            ids.AddRange(benchChampions.Select(x => x.ChampionId).ToList());

            if (!ids.Any())
            {
                view.MySelectedChamp = null;
                view.PickableChampions = null;
                return;
            }

            // get data of champs from DataDragon
            var champsData = dragonHandler.GetChampionData(ids);
            if (!HasChampionsGrantedChestUpdated)
                await riotHandler.UpdateAllChestGranted();

            // get data of chest granted from Riot Api
            var chestsGranted = riotHandler.GetChestGrantedById(ids);

            // fecht data to my list of champs
            foreach (Champion c in champs)
            {
                var ddChamp = champsData.FirstOrDefault(x => x.Id == c.Id);
                if (ddChamp != null)
                {
                    c.Name = ddChamp.Name;
                    c.PictureName = ddChamp.PictureName;
                    c.PicturePath = ddChamp.PicturePath;
                }

                var riotChamp = chestsGranted.FirstOrDefault(x => x.Id == c.Id);
                if (riotChamp != null)
                    c.ChestEarned = riotChamp.ChestEarned;
            }

            foreach (var benchChamp in benchChampions)
            {
                var ddChamp = champsData.FirstOrDefault(x => x.Id == benchChamp.ChampionId);
                if (ddChamp != null)
                {
                    ddChamp.AssignedPosition = "";
                    ddChamp.SummonerId = 0;
                    ddChamp.ChestEarned = false;

                    var riotChamp = chestsGranted.FirstOrDefault(x => x.Id == benchChamp.ChampionId);
                    if (riotChamp != null)
                        ddChamp.ChestEarned = riotChamp.ChestEarned;

                    champs.Add(ddChamp);
                }
            }

            view.MySelectedChamp = champs.FirstOrDefault(x => x.SummonerId == summoner.summonerId);
            champs.RemoveAll(x => x.SummonerId == summoner.summonerId);
            view.PickableChampions = champs;
        }

        private void OnUpdateAllChestGranted(object sender, List<Champion> e)
        {
            HasChampionsGrantedChestUpdated = true;
        }

    }
}
