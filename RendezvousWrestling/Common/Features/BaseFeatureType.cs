using RendezvousWrestling.Common.Utils;
using System;

namespace RendezvousWrestling.Common.Features
{
    public abstract class BaseFeatureType : BaseEntityType
    {
        public BaseFeatureType()
        {
        }

        public BaseFeatureType(int val, Type type) : base(val, type)
        {
        }
    }
}
