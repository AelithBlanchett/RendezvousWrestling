using RendezvousWrestling.Common.Configuration;
using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using System;
using System.Linq;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionSelfDebase : RWActiveAction
    {

        public ActionSelfDebase() : base(
                RWActionType.SelfDebase,
                nameof(ActionType.SelfDebase), //Name
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
                ActionExplanation.SelfDebase)
        {

        }

        public override void OnHit()
        {
            this.FpDamageToAtk = GetIntValueForEnumByTier(typeof(SelfDebaseFpDamage), ActionTier);
        }
    }
}