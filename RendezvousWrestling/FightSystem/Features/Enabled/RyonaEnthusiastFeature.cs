using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.FightSystem.Modifiers;
using System;

namespace RendezvousWrestling.FightSystem.Features.Enabled
{
    public class RyonaEnthusiastFeature : RWFeature
    {

        public RyonaEnthusiastFeature(int uses) : base(RWFeatureType.RyonaEnthusiast, uses)
        {

        }

        public override int Cost => this.Uses * 5;

        public double LpDamageFromHpMultiplier => 0.5;

        public override string ApplyFeature(TriggerMoment moment, TriggerEvent triggeringEvent, RWFeatureParameter parameters = null)
        {
            if (GlobalUtils.WillTriggerForEvent(moment, TriggerMoment.After, triggeringEvent, TriggerEvent.Attack))
            {
                if (parameters.Action.AvgHpDamageToDefs > 0)
                {
                    var addedLPs = 0;
                    var defenderIndex = parameters.Action.Defenders.FindIndex(x => x.Name == this.Receiver.Id);
                    if (defenderIndex != -1)
                    {
                        addedLPs = (int)(parameters.Action.HpDamageToDefs[defenderIndex] * this.LpDamageFromHpMultiplier);
                        parameters.Action.LpDamageToDefs[defenderIndex] += addedLPs;
                    }
                    return $"converting some of the HP damage to LP! (+{addedLPs}LP)";
                }
            }
            return "";
        }
    }
}
