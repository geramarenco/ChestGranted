using ChestGrantedController.Class;
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
        SelectedChampion MySelectedChamp { get; set; }
        List<SelectedChampion> MyTeamChamps { get; set; }
    }
}
