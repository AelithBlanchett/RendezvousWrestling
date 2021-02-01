using RendezvousWrestling.Common.Utils;
using System;

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
