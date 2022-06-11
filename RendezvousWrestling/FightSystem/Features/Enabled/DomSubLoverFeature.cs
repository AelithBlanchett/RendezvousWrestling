using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Features.Enabled
{
    public class DomSubLoverFeature : RWFeature
    {

        public DomSubLoverFeature(int uses) : base(RWFeatureType.DomSubLover, uses)
        {

        }

        public override int Cost => 0;

        public override string ApplyFeature(TriggerMoment moment, TriggerEvent triggeringEvent, RWFeatureParameter parameters = null)
        {
            return "";
        }
    }
}
