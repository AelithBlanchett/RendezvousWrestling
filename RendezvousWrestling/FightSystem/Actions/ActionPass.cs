
using System.Collections.Generic;

public class ActionPass : RWAction {

    public ActionPass(RWFight fight, RWFighterState attacker, List<RWFighterState> defenders)
        : base(fight,
            attacker,
            defenders,
            nameof(ActionType.Pass),
            (int)Tiers.None,
            false, //isHold
            false,  //requiresRoll
            false, //keepActorsTurn
            false,  //singleTarget
            true,  //requiresBeingAlive
            false, //requiresBeingDead
            true,  //requiresBeingInRing
            false, //requiresBeingOffRing
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
            Trigger.Pass,
            ActionExplanation.Pass)
    {
        
    }

    public override void onHit() {
        this.fpDamageToAtk = RWGameSettings.passFpDamage;
    }
}