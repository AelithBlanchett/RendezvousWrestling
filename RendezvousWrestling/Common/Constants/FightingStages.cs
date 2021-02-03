using RendezvousWrestling.Common.Configuration;
using System;

namespace RendezvousWrestling.Common.Constants
{
    public class FightingStages
    {
        public static string[] GetAll()
        {
            return GameSettings.AvailableStages;
        }

        public static string Pick()
        {
            var stages = GetAll();
            return stages[(int)Math.Floor(new Random().NextDouble() * stages.Length)];
        }
    }
}