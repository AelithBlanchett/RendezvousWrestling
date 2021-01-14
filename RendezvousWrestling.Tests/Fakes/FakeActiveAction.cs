using System;
using System.Collections.Generic;
using System.Text;

namespace RendezvousWrestling.Tests.Fakes
{
    class FakeActiveAction : BaseActiveAction
    {
        public FakeActiveAction(BaseFight fight, BaseFighterState attacker, List<BaseFighterState> defenders, string name, int tier, bool isHold, bool requiresRoll, bool keepActorsTurn, bool singleTarget, bool requiresBeingAlive, bool requiresBeingDead, bool requiresBeingInRing, bool requiresBeingOffRing, bool targetMustBeAlive, bool targetMustBeDead, bool targetMustBeInRing, bool targetMustBeOffRing, bool targetMustBeInRange, bool targetMustBeOffRange, bool requiresBeingInHold, bool requiresNotBeingInHold, bool targetMustBeInHold, bool targetMustNotBeInHold, bool usableOnSelf, bool usableOnAllies, bool usableOnEnemies, Trigger trigger, string explanation = null, int? maxTargets = null) : base(fight, attacker, defenders, name, tier, isHold, requiresRoll, keepActorsTurn, singleTarget, requiresBeingAlive, requiresBeingDead, requiresBeingInRing, requiresBeingOffRing, targetMustBeAlive, targetMustBeDead, targetMustBeInRing, targetMustBeOffRing, targetMustBeInRange, targetMustBeOffRange, requiresBeingInHold, requiresNotBeingInHold, targetMustBeInHold, targetMustNotBeInHold, usableOnSelf, usableOnAllies, usableOnEnemies, trigger, explanation, maxTargets)
        {
        }

        public override int SpecificRequiredDiceScore { get => 1; set => throw new NotImplementedException(); }

        public override void applyDamage()
        {
            throw new NotImplementedException();
        }

        public override void onHit()
        {
            throw new NotImplementedException();
        }

        public override void onMiss()
        {
            throw new NotImplementedException();
        }
    }
}
