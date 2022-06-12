using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Modifiers.Enabled
{
    public class RWHumHoldModifier : RWModifier
    {
        public RWHumHoldModifier() : base()
        {

        }

        public override void Initialize(RWModifierType modifierType, string name, TriggerMoment timeToTrigger = TriggerMoment.Never, TriggerEvent triggeringEvent = TriggerEvent.None)
        {
            base.Initialize(modifierType, RWModifierNames.HumHold, TriggerMoment.Any, TriggerEvent.TurnChange);
            IsHold = true;
            Uses = 5;
        }
    }
}