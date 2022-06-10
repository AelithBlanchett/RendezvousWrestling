using RendezvousWrestling.FightSystem;

namespace RendezvousWrestling
{
    class Program
    {
        static void Main(string[] args)
        {
            var plugin = new RendezVousWrestlingGame(true);
            plugin.Initialize();
            plugin.Run();
        }
    }
}
