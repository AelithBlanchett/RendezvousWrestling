using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Modifiers.Enabled
{
    public class RWStrapToyModifier : RWModifier
    {
        public RWStrapToyModifier() : base()
        {

        }

        public override void Initialize(RWModifierType modifierType, string name, TriggerMoment timeToTrigger = TriggerMoment.Never, TriggerEvent triggeringEvent = TriggerEvent.None)
        {
            base.Initialize(modifierType, RWModifierNames.StrapToy, TriggerMoment.Any, TriggerEvent.TurnChange);
        }
    }
}