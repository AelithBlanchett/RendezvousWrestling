using RendezvousWrestling.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
