using RendezvousWrestling.Common.Utils;
using System;

namespace RendezvousWrestling.Common.Features
{
    public abstract class BaseActionType : BaseEntityType
    {
        public BaseActionType()
        {
        }

        public BaseActionType(int val, Type type) : base(val, type)
        {
        }
    }
}
