using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.FightSystem.Modifiers;
using System;

namespace RendezvousWrestling.FightSystem.Features.Enabled
{
    public class CumSlutFeature : RWFeature
    {

        public CumSlutFeature(int uses) : base(RWFeatureType.CumSlut, uses)
        {

        }

        public override int Cost => this.Uses * 5;

        public int AdditionalLPDamage => 3;

        public override string ApplyFeature(TriggerMoment moment, TriggerEvent triggeringEvent, RWFeatureParameter parameters = null)
        {
            if (GlobalUtils.WillTriggerForEvent(moment, TriggerMoment.After, triggeringEvent, TriggerEvent.Attack))
            {
                if (parameters.Action.Attacker.Name == this.Receiver.Id && parameters.Action.LpDamageToAtk > 0)
                {
                    parameters.Action.LpDamageToAtk += this.AdditionalLPDamage;
                    return $"dealing more LP Damage (+{this.AdditionalLPDamage}LP)";
                }
                else if (parameters.Action.AvgLpDamageToDefs > 0)
                {
                    var defenderIndex = parameters.Action.Defenders.FindIndex(x => x.Name == this.Receiver.Id);
                    if (defenderIndex != -1)
                    {
                        parameters.Action.LpDamageToDefs[defenderIndex] += this.AdditionalLPDamage;
                    }
                    return $"dealing more LP Damage (+{this.AdditionalLPDamage}LP)";
                }
            }
            return "";
        }
    }
}
