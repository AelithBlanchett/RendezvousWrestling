using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Modifiers.Enabled
{
    public class RWDegradationMalusModifier : RWModifier
    {
        public RWDegradationMalusModifier() : base()
        {

        }

        public override void Initialize(RWModifierType modifierType, string name, TriggerMoment timeToTrigger = TriggerMoment.Never, TriggerEvent triggeringEvent = TriggerEvent.None)
        {
            base.Initialize(modifierType, RWModifierNames.DegradationMalus, TriggerMoment.Before, TriggerEvent.UtilitaryBarDamage);
            FocusDamage = 10;
            Uses = 5;
        }
    }
}