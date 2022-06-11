using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.FightSystem.Features.Enabled;
using System;
using System.Collections.Generic;

namespace RendezvousWrestling.FightSystem.Features
{
    public class RWFeatureType : BaseFeatureType<RWFeatureType>
    {
        public static RWFeatureType BondageBunny { get; } = new RWFeatureType(1000, typeof(BondageBunnyFeature));
        public static RWFeatureType CumSlut { get; } = new RWFeatureType(1010, typeof(BondageBunnyFeature));
        public static RWFeatureType DomSubLover { get; } = new RWFeatureType(1020, typeof(DomSubLoverFeature));
        public static RWFeatureType Kickstart { get; } = new RWFeatureType(1030, typeof(KickstartFeature));
        public static RWFeatureType RyonaEnthusiast { get; } = new RWFeatureType(1040, typeof(KickstartFeature));
        public static RWFeatureType Sadist { get; } = new RWFeatureType(1050, typeof(SadistFeature));


        private static readonly ICollection<RWFeatureType> _rwFeatures = new List<RWFeatureType>()
        {
            BondageBunny,
            CumSlut,
            DomSubLover,
            Kickstart,
            RyonaEnthusiast,
            Sadist
        };

        public override ICollection<RWFeatureType> List { get => _rwFeatures; }
       

        public RWFeatureType() : base()
        {

        }

        public RWFeatureType(int value, Type type) : base(value, type)
        {

        }
    }
}
