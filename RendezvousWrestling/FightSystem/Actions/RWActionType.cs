using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.FightSystem.Actions.Enabled;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace RendezvousWrestling.FightSystem.Features
{
    public class RWActionType : BaseActionType<RWActionType>
    {
        public static RWActionType Bondage { get; } = new RWActionType(1010, typeof(ActionBondage));
        public static RWActionType Brawl { get; } = new RWActionType(1020, typeof(ActionBrawl));
        public static RWActionType Degradation { get; } = new RWActionType(1030, typeof(ActionDegradation));
        public static RWActionType Escape { get; } = new RWActionType(1040, typeof(ActionEscape));
        public static RWActionType Finisher { get; } = new RWActionType(1050, typeof(ActionFinisher));
        public static RWActionType ForcedWorship { get; } = new RWActionType(1060, typeof(ActionForcedWorship));
        public static RWActionType HighRisk { get; } = new RWActionType(1070, typeof(ActionHighRisk));
        public static RWActionType HumHold { get; } = new RWActionType(1080, typeof(ActionHumHold));
        public static RWActionType ItemPickup { get; } = new RWActionType(1090, typeof(ActionItemPickup));
        public static RWActionType Masturbate { get; } = new RWActionType(1100, typeof(ActionMasturbate));
        public static RWActionType Pass { get; } = new RWActionType(1110, typeof(ActionPass));
        public static RWActionType ReleaseHold { get; } = new RWActionType(1120, typeof(ActionReleaseHold));
        public static RWActionType Rest { get; } = new RWActionType(1130, typeof(ActionRest));
        public static RWActionType RiskyLewd { get; } = new RWActionType(1140, typeof(ActionRiskyLewd));
        public static RWActionType SelfDebase { get; } = new RWActionType(1150, typeof(ActionSelfDebase));
        public static RWActionType SexHold { get; } = new RWActionType(1160, typeof(ActionSexHold));
        public static RWActionType SextoyPickup { get; } = new RWActionType(1170, typeof(ActionSextoyPickup));
        public static RWActionType StrapToy { get; } = new RWActionType(1180, typeof(ActionStrapToy));
        public static RWActionType Stun { get; } = new RWActionType(1190, typeof(ActionStun));
        public static RWActionType SubHold { get; } = new RWActionType(1200, typeof(ActionSubHold));
        public static RWActionType Submit { get; } = new RWActionType(1210, typeof(ActionSubmit));
        public static RWActionType Tag { get; } = new RWActionType(1220, typeof(ActionTag));
        public static RWActionType Tease { get; } = new RWActionType(1230, typeof(ActionTease));

        private static readonly ICollection<RWActionType> _rwActionTypes = new List<RWActionType>()
        {
            Bondage,
            Brawl,
            Degradation,
            Escape,
            Finisher,
            ForcedWorship,
            HighRisk,
            HumHold,
            ItemPickup,
            Masturbate,
            Pass,
            ReleaseHold,
            Rest,
            RiskyLewd,
            SelfDebase,
            SexHold,
            SextoyPickup,
            StrapToy,
            Stun,
            SubHold,
            Submit,
            Tag,
            Tease
        };

        public override ICollection<RWActionType> List { get => _rwActionTypes; }

        public RWActionType() : base()
        {

        }

        public RWActionType(int value, Type type) : base(value, type)
        {

        }
    }
}
