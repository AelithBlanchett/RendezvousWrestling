using RendezvousWrestling.Common.Configuration;
using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using System;
using System.Linq;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionMasturbate : RWActiveAction
    {

        public ActionMasturbate() : base(
                RWActionType.Masturbate,
                nameof(ActionType.Masturbate), //Name
                false, //isHold
            false,  //requiresRoll
            false, //keepActorsTurn
            false,  //singleTarget
            true,  //requiresBeingAlive
            false, //requiresBeingDead
            true,  //requiresBeingInRing
            false, //requiresBeingOffRing
                true,  //requiresTier
                false, //requiresCustomTarget
            false,  //targetMustBeAlive
            false, //targetMustBeDead
            false, //targetMustBeInRing
            false,  //targetMustBeOffRing
            false, //targetMustBeInRange
            false, //targetMustBeOffRange
            false, //requiresBeingInHold,
            false, //requiresNotBeingInHold,
            false, //targetMustBeInHold,
            false, //targetMustNotBeInHold,
            true, //usableOnSelf
            false,  //usableOnAllies
            false, //usableOnEnemies
                TriggerEvent.Pass,
                ActionExplanation.Masturbate)
        {

        }

        public override void OnHit()
        {
            this.LpDamageToAtk = GetIntValueForEnumByTier(typeof(MasturbateLpDamage), ActionTier);
        }
    }
}