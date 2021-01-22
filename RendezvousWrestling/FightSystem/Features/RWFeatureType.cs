using RendezvousWrestling.Common.Features;
using RendezvousWrestling.FightSystem.Features.Enabled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RendezvousWrestling.FightSystem.Features
{
    public class RWFeatureType : BaseFeatureType
    {
        public static RWFeatureType Bondage { get; } = new RWFeatureType(1000, typeof(BondageBunnyFeature));

        private static ICollection<RWFeatureType> _rwFeatures = new List<RWFeatureType>()
        {
            Bondage
        };

        public override ICollection<BaseFeatureType> FeaturesList { get => (ICollection<BaseFeatureType>)_rwFeatures; }

        public RWFeatureType() : base()
        {

        }

        public RWFeatureType(int value, Type type) : base(value, type)
        {
            
        }
    }
}
