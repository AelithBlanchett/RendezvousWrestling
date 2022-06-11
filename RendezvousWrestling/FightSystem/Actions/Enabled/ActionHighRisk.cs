using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using System;
using System.Linq;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionHighRisk : RWActiveAction
    {

        public ActionHighRisk() : base(
                RWActionType.HighRisk,
                nameof(ActionType.HighRisk), //Name
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
                TriggerEvent.PhysicalAttack,
                ActionExplanation.HighRisk)
        {

        }

        public override void OnHit()
        {
            this.FpHealToAtk += GetIntValueForEnumByTier(typeof(FocusHealOnHit), ActionTier);
            this.FpDamageToDef += GetIntValueForEnumByTier(typeof(FocusDamageOnHit), ActionTier);
            this.HpDamageToDef = (int)Math.Floor(this.AttackFormula(this.ActionTier, (int)Math.Floor(this.Attacker.CurrentPower * 1m), this.Defender.CurrentToughness, this.DiceScore) * GetDecValueForEnumByTier(typeof(HighRiskMultipliers), ActionTier) * 1m);
        }

        public override int AddBonusesToRollFromStats()
        {
            return (int)Math.Ceiling(this.Attacker.CurrentDexterity / 10m);
        }

        public override void OnMiss()
        {
            this.FpDamageToAtk += GetIntValueForEnumByTier(typeof(FocusDamageOnHit), ActionTier);
            this.FpHealToDef += GetIntValueForEnumByTier(typeof(FocusHealOnHit), ActionTier);
            this.HpDamageToDef = (int)Math.Floor(this.AttackFormula(this.ActionTier, (int)Math.Floor(this.Attacker.CurrentPower * 1m), this.Attacker.CurrentToughness, 0) * GetDecValueForEnumByTier(typeof(HighRiskMultipliers), ActionTier) * GetDecValueForEnumByTier(typeof(FailedHighRiskMultipliers), ActionTier) * 1m);
            this.ApplyDamage();
        }
    }
}