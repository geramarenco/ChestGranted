using ChestGrantedRepository.LeagueClient.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository
{
    public class Champion
    {
        public double SummonerId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public string PictureName { get; set; }
        public bool ChestEarned { get; set; }
        public string AssignedPosition { get; set; }
    }
}
