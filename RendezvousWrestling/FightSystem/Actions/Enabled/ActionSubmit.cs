using RendezvousWrestling.Common.Configuration;
using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using System;
using System.Linq;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionSubmit : RWActiveAction
    {

        public ActionSubmit() : base(
                RWActionType.Submit,
                nameof(ActionType.Submit), //Name
                false, //isHold
            false,  //requiresRoll
            false, //keepActorsTurn
            false,  //singleTarget
            true,  //requiresBeingAlive
            false, //requiresBeingDead
            false,  //requiresBeingInRing
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
                TriggerEvent.Submit,
                ActionExplanation.Submit)
        {

        }

        public override void OnHit()
        {
            this.Attacker.TriggerPermanentOutsideRing();
            this.Fight.Message.addHit(string.Format(BaseMessages.tapoutMessage, this.Attacker.GetStylizedName()));
        }

        public override void CheckRequirements()
        {
            base.CheckRequirements();
            if (this.Fight.CurrentTurn <= RWGameSettings.TapoutOnlyAfterTurnint)
            {
                throw new Exception(string.Format(BaseMessages.tapoutTooEarly, RWGameSettings.TapoutOnlyAfterTurnint.ToString()));
            }
            if (this.Fight.FightType == FightType.LastManStanding)
            {
                throw new Exception(string.Format(BaseMessages.wrongMatchTypeForAction, "submit", "Last Man Standing"));
            }
        }
    }
}