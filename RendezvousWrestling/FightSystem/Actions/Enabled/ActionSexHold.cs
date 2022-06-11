using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using System;
using System.Collections.Generic;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionSexHold : RWActiveAction
    {

        public ActionSexHold() : base(
                RWActionType.SexHold,
                nameof(ActionType.SexHold), //Name
                true, //isHold
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
            true, //requiresNotBeingInHold,
            false, //targetMustBeInHold,
            false, //targetMustNotBeInHold,
            false, //usableOnSelf
            false,  //usableOnAllies
            true, //usableOnEnemies
                TriggerEvent.MagicalAttack,
                ActionExplanation.SexHold)
        {

        }

        public override void OnHit()
        {
            this.FpHealToAtk += GetIntValueForEnumByTier(typeof(FocusHealOnHit), ActionTier);
            this.FpDamageToDef += GetIntValueForEnumByTier(typeof(FocusDamageOnHit), ActionTier);

            var lustDamage = (int)Math.Floor(this.AttackFormula(this.ActionTier, this.Attacker.CurrentSensuality, this.Defender.CurrentEndurance, this.DiceScore) * RWGameSettings.HoldDamageMultiplier * 1m);
            var holdModifier = Fight.ModifierFactory.Build(RWModifierType.SexHold, this.Fight, this.Defender, this.Attacker, new RWModifierParameters() { Tier = ActionTier, LustDamage = lustDamage });
            var lustBonusAttacker = Fight.ModifierFactory.Build(RWModifierType.SexHoldLustBonus, this.Fight, this.Attacker, null, new RWModifierParameters() { IdParentActions = new List<string>() { holdModifier.Id } });
            var lustBonusDefender = Fight.ModifierFactory.Build(RWModifierType.SexHoldLustBonus, this.Fight, this.Defender, null, new RWModifierParameters() { IdParentActions = new List<string>() { holdModifier.Id } });

            this.AppliedModifiers.Add(holdModifier);
            this.AppliedModifiers.Add(lustBonusAttacker);
            this.AppliedModifiers.Add(lustBonusDefender);
    }

        public override int AddBonusesToRollFromStats()
        {
            return (int)Math.Ceiling(this.Attacker.CurrentDexterity / 10m);
        }
    }
}