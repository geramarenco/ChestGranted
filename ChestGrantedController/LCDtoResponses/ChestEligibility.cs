using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedCore.LCDtoResponses
{
    public class ChestEligibility
    {
        public int earnableChests { get; set; }
        public int maximumChests { get; set; }
        public long nextChestRechargeTime { get; set; }
    }
}
