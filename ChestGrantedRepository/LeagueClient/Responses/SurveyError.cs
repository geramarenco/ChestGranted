using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.LeagueClient.Responses
{
    class SurveyError
    {
        public string errorCode { get; set; }
        public int httpStatus { get; set; }
        public string message { get; set; }
    }
}
