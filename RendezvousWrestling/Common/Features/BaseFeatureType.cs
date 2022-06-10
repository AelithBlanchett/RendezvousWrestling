using RendezvousWrestling.Common.Utils;
using System;

namespace RendezvousWrestling.Common.Features
{
    public abstract class BaseFeatureType<T> : BaseEntityType<T> where T : BaseFeatureType<T>
    {
        public BaseFeatureType()
        {
        }

        public BaseFeatureType(int val, Type type) : base(val, type)
        {
        }
    }
}
