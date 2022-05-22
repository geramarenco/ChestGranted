using ChestGrantedRepository.LeagueClient.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestGrantedRepository
{
    static class Helpers
    {
        public static GameFlowStates GetStateFromString(string state)
        {
            var result = GameFlowStates.Other;
            
            var list = Enum.GetNames(typeof(GameFlowStates)).ToList();
            if (list.Any(x => x == state))
                result = (GameFlowStates)Enum.Parse(typeof(GameFlowStates), state);

            return result;
        }

        public static GameMode GetModeFromString(string state)
        {
            var result = GameMode.OTHER;

            var list = Enum.GetNames(typeof(GameMode)).ToList();
            if (list.Any(x => x == state))
                result = (GameMode)Enum.Parse(typeof(GameMode), state);

            return result;
        }

        static readonly object _locker = new object();

        public static void Log(string message)
        {
            try
            {
                var filePath = System.Reflection.Assembly.GetEntryAssembly().Location;
                filePath = $"{Path.GetDirectoryName(filePath)}\\Log_{DateTime.Now.ToString("yyyy-MM-dd")}.txt";
                WriteToLog(message, filePath);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        static void WriteToLog(string message, string filePath)
        {
            lock (_locker)
            {
                File.AppendAllText(filePath, $"{DateTime.Now} - {message}{Environment.NewLine}");
            }
        }
    }
}
