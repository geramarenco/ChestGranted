using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.Responses
{
    public class ChestEligibility
    {
        public int earnableChests { get; set; }
        public int maximumChests { get; set; }
        public long nextChestRechargeTime { get; set; }
    }
}
