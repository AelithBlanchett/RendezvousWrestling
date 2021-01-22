using RendezvousWrestling.Common.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RendezvousWrestling.FightSystem.Modifiers
{
    public class RWModifierType : BaseModifierType
    {
        public static RWModifierType Bondage { get; } = new RWModifierType(1000, typeof(RWBondageModifier));

        public RWModifierType()
        {

        }

        public RWModifierType(int value, Type type) : base(value, type)
        {
            
        }
    }
}
