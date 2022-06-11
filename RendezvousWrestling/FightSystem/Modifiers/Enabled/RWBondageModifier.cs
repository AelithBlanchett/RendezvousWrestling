using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Modifiers.Enabled
{
    public class RWBondageModifier : RWModifier
    {
        public RWBondageModifier() : base()
        {

        }

        public override void Initialize(RWModifierType modifierType, string name, TriggerMoment timeToTrigger = TriggerMoment.Never, TriggerEvent triggeringEvent = TriggerEvent.None)
        {
            base.Initialize(modifierType, RWModifierNames.Bondage, timeToTrigger, triggeringEvent);
            Uses = 1;
        }
    }
}