using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Modifiers.Enabled
{
    public class RWSexHoldLustBonusModifier : RWModifier
    {
        public RWSexHoldLustBonusModifier() : base()
        {

        }

        public override void Initialize(RWModifierType modifierType, string name, TriggerMoment timeToTrigger = TriggerMoment.Never, TriggerEvent triggeringEvent = TriggerEvent.None)
        {
            base.Initialize(modifierType, RWModifierNames.SexHoldLustBonus, TriggerMoment.Before, TriggerEvent.MagicalAttack);
            DiceRoll = 3;
            Uses = 1;
        }
    }
}