using Microsoft.Extensions.Configuration;
using System;

namespace RendezvousWrestling
{
    class Program
    {
        static void Main(string[] args)
        {
            var plugin = new RendezVousWrestling(true);
            plugin.Initialize();
            plugin.Run();
        }
    }
}
