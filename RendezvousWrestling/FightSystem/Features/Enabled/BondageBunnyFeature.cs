using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Features.Enabled
{
    public class BondageBunnyFeature : RWFeature
    {

        public BondageBunnyFeature(int uses) : base(RWFeatureType.BondageBunny, uses)
        {

        }

        public override int Cost => 0;

        public override string ApplyFeature(TriggerMoment moment, TriggerEvent triggeringEvent, RWFeatureParameter parameters = null)
        {
            return "";
        }
    }
}
