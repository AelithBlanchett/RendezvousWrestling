using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Modifiers.Enabled
{
    public class RWSextoyPickupBonusModifier : RWModifier
    {
        public RWSextoyPickupBonusModifier() : base()
        {

        }

        public override void Initialize(RWModifierType modifierType, string name, TriggerMoment timeToTrigger = TriggerMoment.Never, TriggerEvent triggeringEvent = TriggerEvent.None)
        {
            base.Initialize(modifierType, RWModifierNames.SextoyPickupBonus, TriggerMoment.Before, TriggerEvent.MagicalAttack);
            DiceRoll = 5;
            Uses = 3;
        }
    }
}