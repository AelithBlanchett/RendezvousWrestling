using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using System;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionDegradation : RWActiveAction
    {

        public ActionDegradation() : base(
                RWActionType.Degradation,
                nameof(ActionType.Degradation), //Name
                false, //isHold
            true,  //requiresRoll
            false, //keepActorsTurn
            true,  //singleTarget
            true,  //requiresBeingAlive
            false, //requiresBeingDead
            true,  //requiresBeingInRing
            false, //requiresBeingOffRing
                true,  //requiresTier
                false, //requiresCustomTarget
            true,  //targetMustBeAlive
            false, //targetMustBeDead
            true, //targetMustBeInRing
            false, //targetMustBeOffRing
            true, //targetMustBeInRange
            false, //targetMustBeOffRange
            false, //requiresBeingInHold,
            false, //requiresNotBeingInHold,
            false, //targetMustBeInHold,
            false, //targetMustNotBeInHold,
            false, //usableOnSelf
            false,  //usableOnAllies
            true, //usableOnEnemies
                TriggerEvent.SpecialAttack,
                ActionExplanation.Degradation)
        {

        }

        public override void OnHit()
        {
            this.FpHealToAtk += GetIntValueForEnumByTier(typeof(FocusHealOnHit), ActionTier);
            this.FpDamageToDef += (int)(GetIntValueForEnumByTier(typeof(FocusDamageOnHit), ActionTier) * RWGameSettings.DegradationFocusMultiplier);
        }

        public override int AddBonusesToRollFromStats()
        {
            return (int)Math.Ceiling(this.Attacker.CurrentSensuality / 10m);
        }
    }
}