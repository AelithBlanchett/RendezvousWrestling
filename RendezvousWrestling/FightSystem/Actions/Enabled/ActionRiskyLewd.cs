using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using System;
using System.Linq;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionRiskyLewd : RWActiveAction
    {

        public ActionRiskyLewd() : base(
                RWActionType.RiskyLewd,
                nameof(ActionType.RiskyLewd), //Name
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
                ActionExplanation.RiskyLewd)
        {

        }

        public override void OnHit()
        {
            this.FpHealToAtk += GetIntValueForEnumByTier(typeof(FocusHealOnHit), ActionTier);
            this.FpDamageToDef += GetIntValueForEnumByTier(typeof(FocusDamageOnHit), ActionTier);
            this.LpDamageToDef = (int)Math.Floor(this.AttackFormula(this.ActionTier, (int)Math.Floor(this.Attacker.CurrentSensuality * 1m), this.Defender.CurrentEndurance, this.DiceScore) * GetDecValueForEnumByTier(typeof(HighRiskMultipliers), ActionTier) * 1m);
            this.LpDamageToAtk = (int)Math.Floor(this.AttackFormula(this.ActionTier, (int)Math.Floor(this.Attacker.CurrentSensuality * 1m), this.Defender.CurrentEndurance, this.DiceScore) * GetDecValueForEnumByTier(typeof(FailedHighRiskMultipliers), ActionTier) * 1m);
        }

        public override void OnMiss()
        {
            this.FpDamageToAtk += GetIntValueForEnumByTier(typeof(FocusDamageOnHit), ActionTier);
            this.FpHealToDef += GetIntValueForEnumByTier(typeof(FocusHealOnHit), ActionTier);
            this.LpDamageToAtk = (int)Math.Floor(this.AttackFormula(this.ActionTier, (int)Math.Floor(this.Attacker.CurrentSensuality * 1m), this.Attacker.CurrentEndurance, this.DiceScore) * GetDecValueForEnumByTier(typeof(HighRiskMultipliers), ActionTier) * GetDecValueForEnumByTier(typeof(FailedHighRiskMultipliers), ActionTier) * 1m);
            this.LpDamageToDef = (int)Math.Floor(this.AttackFormula(this.ActionTier, (int)Math.Floor(this.Attacker.CurrentSensuality * 1m), this.Defender.CurrentEndurance, this.DiceScore) * GetDecValueForEnumByTier(typeof(FailedHighRiskMultipliers), ActionTier) * 1m);
            this.ApplyDamage();
        }

        public override int AddBonusesToRollFromStats()
        {
            return (int)Math.Ceiling(this.Attacker.CurrentSensuality / 20m);
        }
    }
}