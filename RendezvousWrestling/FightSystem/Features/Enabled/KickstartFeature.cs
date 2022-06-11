using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.FightSystem.Modifiers;

namespace RendezvousWrestling.FightSystem.Features.Enabled
{
    public class KickstartFeature : RWFeature
    {

        public KickstartFeature(int uses) : base(RWFeatureType.Kickstart, uses)
        {

        }

        public override int Cost => this.Uses * 5;

        public double HpDamageMultiplier => 1.5;

        public override string ApplyFeature(TriggerMoment moment, TriggerEvent triggeringEvent, RWFeatureParameter parameters = null)
        {
            if (GlobalUtils.WillTriggerForEvent(moment, TriggerMoment.After, triggeringEvent, TriggerEvent.InitiationRoll))
            {
                if (parameters.Fighter != null)
                {
                    var modifier = parameters.Fight.ModifierFactory.Build(RWModifierType.ItemPickupBonus, parameters.Fight, parameters.Fighter, null, new RWModifierParameters() { Uses = 1 });
                    parameters.Fighter.Modifiers.Add(modifier);
                    return $"multiplying their damage by {HpDamageMultiplier}!";
                }
            }
            return "";
        }
    }
}
