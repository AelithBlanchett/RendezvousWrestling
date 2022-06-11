using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.FightSystem.Modifiers.Enabled;
using System;
using System.Collections.Generic;

namespace RendezvousWrestling.FightSystem.Modifiers
{
    public class RWModifierType : BaseModifierType<RWModifierType>
    {
        public static RWModifierType Bondage { get; } = new RWModifierType(1000, typeof(RWBondageModifier));
        public static RWModifierType SubHold { get; } = new RWModifierType(1001, typeof(RWSubHoldModifier));
        public static RWModifierType SubHoldBrawlBonus { get; } = new RWModifierType(1002, typeof(RWSubHoldBrawlBonusModifier));

        private static ICollection<RWModifierType> _rwModifiers = new List<RWModifierType>()
        {
            Bondage,
            SubHold,
            SubHoldBrawlBonus
        };

        public override ICollection<RWModifierType> List { get => _rwModifiers; }
        public static RWModifierType Stun { get; internal set; }
        public static RWModifierType SextoyPickupBonus { get; internal set; }
        public static RWModifierType StrapToy { get; internal set; }
        public static RWModifierType SexHold { get; internal set; }
        public static RWModifierType SexHoldLustBonus { get; internal set; }
        public static RWModifierType HumHold { get; internal set; }
        public static RWModifierType DegradationMalus { get; internal set; }
        public static RWModifierType ItemPickupBonus { get; internal set; }

        public RWModifierType()
        {

        }

        public RWModifierType(int value, Type type) : base(value, type)
        {

        }
    }
}
