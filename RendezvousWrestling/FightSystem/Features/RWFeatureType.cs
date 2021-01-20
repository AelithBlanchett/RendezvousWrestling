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

        public RWFeatureType(int value, Type type) : base(value, type)
        {
            
        }
    }
}
