using RendezvousWrestling.Common.Configuration;
using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using System;
using System.Linq;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionEscape : RWActiveAction
    {

        public ActionEscape() : base(
                RWActionType.Escape,
                nameof(ActionType.Escape), //Name
                false, //isHold
            true,  //requiresRoll
            true, //keepActorsTurn
            true,  //singleTarget
            true,  //requiresBeingAlive
            false, //requiresBeingDead
            true,  //requiresBeingInRing
            false, //requiresBeingOffRing
                false,  //requiresTier
                false, //requiresCustomTarget
            true,  //targetMustBeAlive
            false, //targetMustBeDead
            true, //targetMustBeInRing
            false,  //targetMustBeOffRing
            true, //targetMustBeInRange
            false, //targetMustBeOffRange
            true, //requiresBeingInHold,
            false, //requiresNotBeingInHold,
            false, //targetMustBeInHold,
            false, //targetMustNotBeInHold,
            true, //usableOnSelf
            false,  //usableOnAllies
            false, //usableOnEnemies
                TriggerEvent.Escape,
                ActionExplanation.Escape)
        {

        }

        public override void OnHit()
        {
            this.Attacker.ReleaseAllHolds();
        }

        public override int AddBonusesToRollFromStats()
        {
            return base.AddBonusesToRollFromStats() + (int)Math.Ceiling(this.Attacker.CurrentDexterity / 10m);
        }

        public override void CheckRequirements()
        {
            base.CheckRequirements();
            if (!this.Attacker.IsInHold())
            {
                throw new Exception($"You aren't in a hold... what are you trying to escape!");
            }
        }
    }
}