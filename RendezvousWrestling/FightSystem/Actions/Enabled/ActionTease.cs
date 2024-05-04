using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using System;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionTease : RWActiveAction
    {

        public ActionTease() : base(
                RWActionType.Tease,
                nameof(ActionType.Tease), //Name
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
                false,  //targetMustBeOffRing
                true, //targetMustBeInRange
                false, //targetMustBeOffRange
                false, //requiresBeingInHold,
                false, //requiresNotBeingInHold,
                false, //targetMustBeInHold,
                false, //targetMustNotBeInHold,
                false, //usableOnSelf
                false,  //usableOnAllies
                true, //usableOnEnemies
                TriggerEvent.MagicalAttack,
                ActionExplanation.Tease)
        {

        }

        public override void OnHit()
        {
            this.FpHealToAtk += GetIntValueForEnumByTier(typeof(FocusHealOnHit), ActionTier);
            this.FpDamageToDef += GetIntValueForEnumByTier(typeof(FocusDamageOnHit), ActionTier);
            this.LpDamageToDef += this.AttackFormula(this.ActionTier, this.Attacker.CurrentSensuality, this.Defender.CurrentEndurance, this.DiceScore);
        }

        public override int AddBonusesToRollFromStats()
        {
            return (int)Math.Ceiling(this.Attacker.CurrentDexterity / 20m);
        }
    }
}