using System;
using System.Collections.Generic;
using System.Text;

namespace RendezvousWrestling.Tests.Fakes
{
    class FakeAction : BaseAction
    {
        public FakeAction(string name, int tier, bool isHold, bool requiresRoll, bool keepActorsTurn, bool singleTarget, bool requiresBeingAlive, bool requiresBeingDead, bool requiresBeingInRing, bool requiresBeingOffRing, bool targetMustBeAlive, bool targetMustBeDead, bool targetMustBeInRing, bool targetMustBeOffRing, bool targetMustBeInRange, bool targetMustBeOffRange, bool requiresBeingInHold, bool requiresNotBeingInHold, bool targetMustBeInHold, bool targetMustNotBeInHold, bool usableOnSelf, bool usableOnAllies, bool usableOnEnemies, Trigger trigger, string explanation = null, int? maxTargets = null) : base(name, tier, isHold, requiresRoll, keepActorsTurn, singleTarget, requiresBeingAlive, requiresBeingDead, requiresBeingInRing, requiresBeingOffRing, targetMustBeAlive, targetMustBeDead, targetMustBeInRing, targetMustBeOffRing, targetMustBeInRange, targetMustBeOffRange, requiresBeingInHold, requiresNotBeingInHold, targetMustBeInHold, targetMustNotBeInHold, usableOnSelf, usableOnAllies, usableOnEnemies, trigger, explanation, maxTargets)
        {
        }

        public override int requiredDiceScore => 1;
    }
}
