using RendezvousWrestling.Common.Utils;
using System;

namespace RendezvousWrestling.Common.Modifiers
{
    public abstract class BaseModifierType<T> : BaseEntityType<T> where T : BaseModifierType<T>
    {
        public BaseModifierType()
        {
        }

        public BaseModifierType(int val, Type type) : base(val, type)
        {
        }
    }
}
