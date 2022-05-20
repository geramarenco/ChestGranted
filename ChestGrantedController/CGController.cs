using ChestGrantedRepository;
using ChestGrantedRepository.LeagueClient.Enums;
using ChestGrantedRepository.LeagueClient.EventsArgs;
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
        private LCUHandler LCUHandler;
        private DDragonHandler dragonHandler;
        private RiotHandler riotHandler;
        private SummonerInfo summoner;

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

            ConnectLC();
        }

        private async void ConnectLC()
        {
            await LCUHandler.Connect();
            await LCUHandler.GetSystemBuild();
        }

        private void OnGetSystemBuild(object sender, LeagueClientBuild e)
        {
            // e.version = "12.9.440.3307"
            var aVersion = e.version.Split(".");
            var version = $"{aVersion[0]}.{aVersion[1]}.1";

            dragonHandler = new DDragonHandler(version);
            dragonHandler.OnGetProfileIcon += OnGetProfileIcon;
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
                UpdateChestInfo();
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
            //var chestsGranted = await riotHandler.GetChestGrantedById(ids);

            foreach (Champion c in champs)
            {
                c.Name = champsData.FirstOrDefault(x => x.Id == c.Id).Name;
                c.PictureName = champsData.FirstOrDefault(x => x.Id == c.Id).PictureName;
                c.PicturePath = champsData.FirstOrDefault(x => x.Id == c.Id).PicturePath;
                //ChestEarned = chestsGranted.FirstOrDefault(x => x.Id == c.Id).ChestEarned,
            }

            // getting champs from posible trades
            var trades = new List<Champion>();
            trades.AddRange(e.AvailableTrades.Select(x => new Champion() { Id = x.ChampionId}).ToList());

            foreach (Champion c in trades)
            {
                c.SummonerId = 0;
                c.Name = champsData.FirstOrDefault(x => x.Id == c.Id).Name;
                c.PictureName = champsData.FirstOrDefault(x => x.Id == c.Id).PictureName;
                c.PicturePath = champsData.FirstOrDefault(x => x.Id == c.Id).PicturePath;
                //ChestEarned = chestsGranted.FirstOrDefault(x => x.Id == c.Id).ChestEarned,
            }

            view.MySelectedChamp = champs.FirstOrDefault(x => x.SummonerId == summoner.summonerId);
            champs.RemoveAll(x => x.SummonerId == summoner.summonerId);
            view.MyTeamChamps = champs;
        }
    }
}
