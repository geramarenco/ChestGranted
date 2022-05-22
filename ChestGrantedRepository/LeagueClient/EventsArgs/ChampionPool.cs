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
            BenchChampions = new List<BenchChampion>();
        } 

        public List<Champion> SelectedChampions { get; set; }
        public List<BenchChampion> BenchChampions { get; set; }
    }

    public class BenchChampion
    {
        public int ChampionId { get; set; }
    }
}
