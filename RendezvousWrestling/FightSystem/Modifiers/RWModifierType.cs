using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.FightSystem.Modifiers.Enabled;
using System;
using System.Collections.Generic;

namespace RendezvousWrestling.FightSystem.Modifiers
{
    public class RWModifierType : BaseModifierType
    {
        public static RWModifierType Bondage { get; } = new RWModifierType(1000, typeof(RWBondageModifier));

        private static ICollection<RWModifierType> _rwModifiers = new List<RWModifierType>()
        {
            Bondage
        };

        public override ICollection<BaseEntityType> List { get => (ICollection<BaseEntityType>)_rwModifiers; }

        public RWModifierType()
        {

        }

        public RWModifierType(int value, Type type) : base(value, type)
        {

        }
    }
}
