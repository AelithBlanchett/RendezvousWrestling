using RendezvousWrestling.Common.Fight;
using System;
using System.Collections.Generic;
using System.Text;

namespace RendezvousWrestling.Tests.Fakes
{
    class FakeFight : BaseFight
    {
        public FakeFight() : base(new Action)
        {

        }

        public override void punishPlayerOnForfeit(BaseFighterState fighter)
        {
            //throw new NotImplementedException();
        }

        public override void save()
        {
            //throw new NotImplementedException();
        }
    }
}
