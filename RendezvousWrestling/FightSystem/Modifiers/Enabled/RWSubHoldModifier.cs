using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Modifiers.Enabled
{
    public class RWSubHoldModifier : RWModifier
    {
        public RWSubHoldModifier() : base()
        {

        }

        public override void Initialize(RWModifierType modifierType, string name, TriggerMoment timeToTrigger = TriggerMoment.Never, TriggerEvent triggeringEvent = TriggerEvent.None)
        {
            base.Initialize(modifierType, RWModifierNames.SubHold, TriggerMoment.Any, TriggerEvent.TurnChange);
            IsHold = true;
            Uses = 5;
        }
    }
}