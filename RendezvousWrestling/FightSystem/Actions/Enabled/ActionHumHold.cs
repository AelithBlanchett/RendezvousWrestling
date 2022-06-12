using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using System;
using System.Collections.Generic;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionHumHold : RWActiveAction
    {

        public ActionHumHold() : base(
                RWActionType.HumHold,
                nameof(ActionType.HumHold), //Name
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
                TriggerEvent.SpecialAttack,
                ActionExplanation.HumHold)
        {

        }

        public override void OnHit()
        {
            this.Missed = false;
            this.FpHealToAtk += GetIntValueForEnumByTier(typeof(FocusHealOnHit), ActionTier);

            var focusDamage = GetIntValueForEnumByTier(typeof(FocusDamageOnHit), ActionTier);
            var holdModifier = Fight.ModifierFactory.Build(RWModifierType.HumHold, this.Fight, this.Defender, this.Attacker, new RWModifierParameters() { Tier = ActionTier, FocusDamage = focusDamage });
            AddModifier(holdModifier);

            var humiliationModifier = Fight.ModifierFactory.Build(RWModifierType.DegradationMalus, this.Fight, this.Defender, this.Attacker, new RWModifierParameters() { IdParentActions = new List<string>() { holdModifier.Id } });            
            AddModifier(humiliationModifier);
    }

        public override int AddBonusesToRollFromStats()
        {
            return (int)Math.Ceiling(this.Attacker.CurrentDexterity / 10m);
        }
    }
}