using ChestGrantedRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedController
{
    public interface IChestGrantedView
    {
        bool LoLIsRunning { get; set; }
        string SummonerName { get; set; }
        int EarnableChests { get; set; }
        string ProfilePicture { get; set; }
        bool ChampSelectStageVisible { get; set; }
        Champion MySelectedChamp { get; set; }
        List<Champion> PickableChampions { get; set; }
        int ChestCount { get; set; }
        int EarnedChests { get; set; }
        long nextChestRechargeTime { get; set; }
        void ShowAlert(string message, string caption = "Alert");
        void ShowError(string message, string caption = "Error");
    }
}
