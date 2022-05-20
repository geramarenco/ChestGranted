using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.LeagueClient.EventsArgs
{
    public class ChampionPool
    {
        // TODO
        //private List<Champion> _champions;

        //public IList<Champion> Champions
        //{
        //    get
        //    {
        //        return _champions.AsReadOnly();
        //    }
        //}

        //internal void AddChamp(Champion champ)
        //{
        //    if(_champions == null) _champions = new List<Champion>();
        //    _champions.Add(champ);
        //}

        public ChampionPool()
        {
            SelectedChampions = new List<Champion>();
            AvailableTrades = new List<AvailableTrade>();
        } 

        public List<Champion> SelectedChampions { get; set; }
        public List<AvailableTrade> AvailableTrades { get; set; }
    }

    public class AvailableTrade
    {
        public int ChampionId { get; set; }
    }
}
