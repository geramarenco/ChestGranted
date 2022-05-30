using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository.RiotApi
{
    public class RiotApiException : Exception
    {
        public RiotApiException()
        {
        }

        public RiotApiException(string message) : base(message)
        {
        }

        public RiotApiException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
