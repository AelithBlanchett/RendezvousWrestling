using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.FightSystem.Modifiers;
using System;

namespace RendezvousWrestling.FightSystem.Features.Enabled
{
    public class SadistFeature : RWFeature
    {

        public SadistFeature(int uses) : base(RWFeatureType.Sadist, uses)
        {

        }

        public override int Cost => this.Uses * 5;

        public double LpDamageFromHpMultiplier => 0.5;

        public override string ApplyFeature(TriggerMoment moment, TriggerEvent triggeringEvent, RWFeatureParameter parameters = null)
        {
            if (GlobalUtils.WillTriggerForEvent(moment, TriggerMoment.After, triggeringEvent, TriggerEvent.Attack))
            {
                if (parameters.Action.Attacker.Name == this.Receiver.Id && parameters.Action.AvgHpDamageToDefs > 0)
                {
                    parameters.Action.LpDamageToAtk = (int)Math.Floor(parameters.Action.AvgHpDamageToDefs * this.LpDamageFromHpMultiplier);
                    return $"returning some of the HP damage dealt for a total of {parameters.Action.LpDamageToAtk}LP!";
                }
            }
            return "";
        }
    }
}
