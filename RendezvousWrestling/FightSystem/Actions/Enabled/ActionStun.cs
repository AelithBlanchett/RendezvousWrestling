using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using System;
using System.Linq;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionStun : RWActiveAction
    {

        public ActionStun() : base(
                RWActionType.Stun,
                nameof(ActionType.Stun), //Name
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
                TriggerEvent.Stun,
                ActionExplanation.Stun)
        {

        }

        public override void OnHit()
        {
            this.FpHealToAtk += GetIntValueForEnumByTier(typeof(FocusHealOnHit), ActionTier);
            this.FpDamageToDef += GetIntValueForEnumByTier(typeof(FocusDamageOnHit), ActionTier);
            this.HpDamageToDef = (int)Math.Floor(this.AttackFormula(this.ActionTier, (int)Math.Floor(this.Attacker.CurrentPower * 1m), this.Defender.CurrentToughness, this.DiceScore) * RWGameSettings.StunHPDamageMultiplier);
            var requiredDiceRoll = -(((int)this.ActionTier + 1) * RWGameSettings.DicePenaltyMultiplierWhileStunned);
            var stunModifier = Fight.ModifierFactory.Build(RWModifierType.Stun, this.Fight, this.Defender, this.Attacker, new RWModifierParameters() { Tier = ActionTier, DiceRoll = requiredDiceRoll });
            this.AppliedModifiers.Add(stunModifier);
            this.Fight.Message.addHit("STUNNED!");
        }

        public override int AddBonusesToRollFromStats()
        {
            return (int)Math.Ceiling(this.Attacker.CurrentDexterity / 10m);
        }

        public override void CheckRequirements()
        {
            base.CheckRequirements();
            if (this.Defenders.Any(x => x.IsStunned))
            {
                throw new Exception(BaseMessages.targetAlreadyStunned);
            }
        }
    }
}