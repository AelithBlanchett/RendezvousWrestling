using System;
using System.Collections.Generic;
using System.Text;

namespace RendezvousWrestling.Tests.Fakes
{
    class FakeActionFactory : IActionFactory
    {
        public BaseActiveAction GetAction(string actionName, BaseFight fight, BaseFighterState attacker, List<BaseFighterState> defenders, int tier)
        {
            return null;
        }
    }
}
