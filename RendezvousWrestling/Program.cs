using System;

namespace RendezvousWrestling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var plugin = new RendezVousWrestling(true);
            plugin.Run();
        }
    }
}
