using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.FightSystem.Features.Enabled;
using System;
using System.Collections.Generic;

namespace RendezvousWrestling.FightSystem.Features
{
    public class RWFeatureType : BaseFeatureType
    {
        public static RWFeatureType BondageBunny { get; } = new RWFeatureType(1000, typeof(BondageBunnyFeature));
        public static RWFeatureType DomSubLover { get; } = new RWFeatureType(1001, typeof(BondageBunnyFeature));

        private static ICollection<RWFeatureType> _rwFeatures = new List<RWFeatureType>()
        {
            BondageBunny,
            DomSubLover
        };

        public override ICollection<BaseEntityType> List { get => (ICollection<BaseEntityType>)_rwFeatures; }

        public RWFeatureType() : base()
        {

        }

        public RWFeatureType(int value, Type type) : base(value, type)
        {

        }
    }
}
