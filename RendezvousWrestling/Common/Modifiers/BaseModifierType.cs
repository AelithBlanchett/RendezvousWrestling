using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RendezvousWrestling.Common.Modifiers
{
    public abstract class BaseModifierType : BaseEntityType
    {
        public BaseModifierType()
        {
        }

        public BaseModifierType(int val, Type type) : base(val, type)
        {
        }
    }
}
