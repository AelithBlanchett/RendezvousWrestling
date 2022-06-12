using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using System;
using System.Collections.Generic;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionItemPickup : RWActiveAction
    {

        public ActionItemPickup() : base(
                RWActionType.ItemPickup,
                nameof(ActionType.ItemPickup), //Name
                false, //isHold
            false,  //requiresRoll
            false, //keepActorsTurn
            false,  //singleTarget
            true,  //requiresBeingAlive
            false, //requiresBeingDead
            true,  //requiresBeingInRing
            false, //requiresBeingOffRing
                false,  //requiresTier
                false, //requiresCustomTarget
            false,  //targetMustBeAlive
            false, //targetMustBeDead
            false, //targetMustBeInRing
            false,  //targetMustBeOffRing
            false, //targetMustBeInRange
            false, //targetMustBeOffRange
            false, //requiresBeingInHold,
            true, //requiresNotBeingInHold,
            false, //targetMustBeInHold,
            false, //targetMustNotBeInHold,
            true, //usableOnSelf
            false,  //usableOnAllies
            false, //usableOnEnemies
                TriggerEvent.BonusPickup,
                ActionExplanation.ItemPickup)
        {

        }

        public override void OnHit()
        {
            this.FpHealToAtk += GetIntValueForEnumByTier(typeof(FocusHealOnHit), Tier.Light);
            this.FpDamageToDef += GetIntValueForEnumByTier(typeof(FocusDamageOnHit), Tier.Light);

            var itemPickupModifier = Fight.ModifierFactory.Build(RWModifierType.ItemPickupBonus, this.Fight, this.Attacker, null);
            AddModifier(itemPickupModifier);
        }
    }
}