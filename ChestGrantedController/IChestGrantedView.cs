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
    }
}
