using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionPass : RWActiveAction
    {

        public ActionPass() : base(
                RWActionType.Pass,
                nameof(ActionType.Pass), //Name
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
                false, //requiresNotBeingInHold,
                false, //targetMustBeInHold,
                false, //targetMustNotBeInHold,
                true, //usableOnSelf
                false,  //usableOnAllies
                false, //usableOnEnemies
                TriggerEvent.Pass,
                ActionExplanation.Pass)
        {

        }

        public override void OnHit()
        {
            FpDamageToAtk = RWGameSettings.PassFpDamage;
        }
    }
}