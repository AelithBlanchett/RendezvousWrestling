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
        public static RWModifierType DegradationMalus { get; } = new RWModifierType(1010, typeof(RWDegradationMalusModifier));
        public static RWModifierType HumHold { get; } = new RWModifierType(1020, typeof(RWHumHoldModifier));
        public static RWModifierType ItemPickupBonus { get; } = new RWModifierType(1030, typeof(RWItemPickupBonusModifier));
        public static RWModifierType SexHold { get; } = new RWModifierType(1040, typeof(RWSexHoldModifier));
        public static RWModifierType SexHoldLustBonus { get; } = new RWModifierType(1050, typeof(RWSexHoldLustBonusModifier));
        public static RWModifierType SextoyPickupBonus { get; } = new RWModifierType(1060, typeof(RWSextoyPickupBonusModifier));
        public static RWModifierType StrapToy { get; } = new RWModifierType(1070, typeof(RWStrapToyModifier));
        public static RWModifierType Stun { get; } = new RWModifierType(1080, typeof(RWStunModifier));
        public static RWModifierType SubHold { get; } = new RWModifierType(1090, typeof(RWSubHoldModifier));
        public static RWModifierType SubHoldBrawlBonus { get; } = new RWModifierType(1100, typeof(RWSubHoldBrawlBonusModifier)); 
        

        private static ICollection<RWModifierType> _rwModifiers = new List<RWModifierType>()
        {
            Bondage,
            DegradationMalus,
            HumHold,
            ItemPickupBonus,
            SexHold,
            SexHoldLustBonus,
            SextoyPickupBonus,
            StrapToy,
            Stun,
            SubHold,
            SubHoldBrawlBonus
        };

        public override ICollection<RWModifierType> List { get => _rwModifiers; }

        public RWModifierType()
        {

        }

        public RWModifierType(int value, Type type) : base(value, type)
        {

        }
    }
}
