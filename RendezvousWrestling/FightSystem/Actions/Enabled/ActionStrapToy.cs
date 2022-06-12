using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using System;
using System.Collections.Generic;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionStrapToy : RWActiveAction
    {

        public ActionStrapToy() : base(
                RWActionType.StrapToy,
                nameof(ActionType.StrapToy), //Name
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
                TriggerEvent.BonusPickup,
                ActionExplanation.StrapToy)
        {

        }

        public override int AddBonusesToRollFromStats()
        {
            return base.AddBonusesToRollFromStats() + (int)Math.Ceiling(this.Attacker.CurrentSensuality / 10m);
        }

        public override void OnHit()
        {
            this.FpHealToAtk += GetIntValueForEnumByTier(typeof(FocusHealOnHit), ActionTier);
            this.FpDamageToDef += GetIntValueForEnumByTier(typeof(FocusDamageOnHit), ActionTier);

            var nbOfTurnsWearingToy = (int)ActionTier + 1;
            var lpDamage = GetIntValueForEnumByTier(typeof(StrapToyLPDamagePerTurn), ActionTier);
            var strapToyModifier = Fight.ModifierFactory.Build(RWModifierType.StrapToy, this.Fight, this.Defender, null, new RWModifierParameters() { FocusDamage = this.FpDamageToDef, LustDamage = lpDamage, Tier = ActionTier, DiceRoll = GetIntValueForEnumByTier(typeof(StrapToyDiceRollPenalty), ActionTier), Uses = nbOfTurnsWearingToy});
            AddModifier(strapToyModifier);
            this.Fight.Message.addHit("The sextoy started vibrating!");
        }
    }
}