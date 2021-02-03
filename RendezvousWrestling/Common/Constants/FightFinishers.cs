using RendezvousWrestling.Common.Configuration;
using System;

namespace RendezvousWrestling.Common.Constants
{
    public class FightFinishers
    {

        public static string[] GetAll()
        {
            return GameSettings.AvailableFinishers;
        }

        public static string Pick()
        {
            var finishers = GetAll();
            return finishers[(int)Math.Floor(new Random().NextDouble() * finishers.Length)];
        }
    }
}