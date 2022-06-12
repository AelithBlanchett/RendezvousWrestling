using RendezvousWrestling.Common.Configuration;
using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using System;
using System.Linq;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionTag : RWActiveAction
    {

        public ActionTag() : base(
                RWActionType.Tag,
                nameof(ActionType.Tag), //Name
                false, //isHold
            true,  //requiresRoll
            false, //keepActorsTurn
            true,  //singleTarget
            true,  //requiresBeingAlive
            false, //requiresBeingDead
            true,  //requiresBeingInRing
            false, //requiresBeingOffRing
                false,  //requiresTier
                true, //requiresCustomTarget
            true,  //targetMustBeAlive
            false, //targetMustBeDead
            false, //targetMustBeInRing
            true,  //targetMustBeOffRing
            false, //targetMustBeInRange
            false, //targetMustBeOffRange
            false, //requiresBeingInHold,
            true, //requiresNotBeingInHold,
            false, //targetMustBeInHold,
            false, //targetMustNotBeInHold,
            false, //usableOnSelf
            true,  //usableOnAllies
            false, //usableOnEnemies
                TriggerEvent.Tag,
                ActionExplanation.Tag)
        {

        }

        public override void OnHit()
        {
            this.Attacker.LastTagTurn = this.AtTurn;
            this.Defenders[0].LastTagTurn = this.AtTurn;
            this.Attacker.IsInTheRing = false;
            this.Defenders[0].IsInTheRing = true;
        }

        public override void CheckRequirements()
        {
            base.CheckRequirements();
            var turnsSinceLastTag = (this.Attacker.LastTagTurn - this.Fight.CurrentTurn);
            var turnsToWait = (GameSettings.TurnsToWaitBetweenTwoTags * this.Fight.AlivePlayers.Count(x => x.AssignedTeam == this.Attacker.AssignedTeam)) - turnsSinceLastTag;
            if (turnsToWait > 0)
            {
                throw new Exception($"[b][color = red]You can't tag yet. Turns left: {turnsToWait}[/color][/b]");
            }
            if (!this.Defenders[0].CanMoveFromOrOffRing)
            {
                throw new Exception($"[b][color = red]You can't tag with this character. They're permanently out.[/ color][/ b]");
            }
            if (!this.Attacker.CanMoveFromOrOffRing)
            {
                throw new Exception($"[b][color = red]You can't tag with this character. You can't move from or off the ring.[/ color][/ b]");
            }
        }

        public override int RequiredDiceScore => GameSettings.RequiredScoreTag;
    }
}