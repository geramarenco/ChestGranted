using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.LeagueClient.Responses
{
    public class SummonerProfile
    {
        public int backgroundSkinId { get; set; }
        public EquippedBannerFlag equippedBannerFlag { get; set; }
        public Regalia regalia { get; set; }
    }

    public class EquippedBannerFlag
    {
        public int itemId { get; set; }
        public int level { get; set; }
        public int seasonId { get; set; }
        public string theme { get; set; }
    }

    public class Regalia
    {
        public int bannerType { get; set; }
        public int crestType { get; set; }
    }
}
