using RendezvousWrestling.Common.Utils;
using System;
using System.Reflection;

namespace RendezvousWrestling.Common.Features
{
    public abstract class BaseActionType<T> : BaseEntityType<T> where T : BaseActionType<T>
    {

        public BaseActionType()
        {
        }

        public BaseActionType(int val, Type type) : base(val, type)
        {
        }
    }
}
