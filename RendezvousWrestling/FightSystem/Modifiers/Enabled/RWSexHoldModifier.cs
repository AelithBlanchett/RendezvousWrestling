using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Modifiers.Enabled
{
    public class RWSexHoldModifier : RWModifier
    {
        public RWSexHoldModifier() : base()
        {

        }

        public override void Initialize(RWModifierType modifierType, string name, TriggerMoment timeToTrigger = TriggerMoment.Never, TriggerEvent triggeringEvent = TriggerEvent.None)
        {
            base.Initialize(modifierType, RWModifierNames.SexHold, TriggerMoment.Any, TriggerEvent.TurnChange);
            Uses = 5;
        }
    }
}