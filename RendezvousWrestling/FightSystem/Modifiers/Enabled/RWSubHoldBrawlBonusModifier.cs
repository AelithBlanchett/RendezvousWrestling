using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Modifiers.Enabled
{
    public class RWSubHoldBrawlBonusModifier : RWModifier
    {
        public RWSubHoldBrawlBonusModifier() : base()
        {

        }

        public override void Initialize(RWModifierType modifierType, string name, TriggerMoment timeToTrigger = TriggerMoment.Never, TriggerEvent triggeringEvent = TriggerEvent.None)
        {
            base.Initialize(modifierType, RWModifierNames.SubHoldBrawlBonus, TriggerMoment.Before, TriggerEvent.PhysicalAttack);
            DiceRoll = 3;
            Uses = 1;
        }
    }
}