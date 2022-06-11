using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Modifiers.Enabled
{
    public class RWItemPickupBonusModifier : RWModifier
    {
        public RWItemPickupBonusModifier() : base()
        {

        }

        public override void Initialize(RWModifierType modifierType, string name, TriggerMoment timeToTrigger = TriggerMoment.Never, TriggerEvent triggeringEvent = TriggerEvent.None)
        {
            base.Initialize(modifierType, RWModifierNames.ItemPickupBonus, TriggerMoment.Before, TriggerEvent.PhysicalAttack);
            DiceRoll = 5;
            Uses = 3;
        }
    }
}