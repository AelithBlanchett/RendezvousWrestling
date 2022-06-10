import {ActionExplanation, ActionType, RWAction} from "./RWAction";
import * as Constants from "../../Common/Constants/BaseConstants";
import {RWFighterState} from "../Fight/RWFighterState";
import {RWFight} from "../Fight/RWFight";
import {SelfDebaseFpDamage} from "../RWConstants";
import {Tiers} from "../Constants/Tiers";
import {Trigger} from "../../Common/Constants/Trigger";

public class ActionSelfDebase extends RWAction {

    constructor(RWFight fight,RWFighterState, defenders:RWFighterState[], tier: Tiers  attacker) {
        super(fight,
            attacker,
            defenders,
            ActionType.SelfDebase,
            tier,
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
            ActionExplanation[ActionType.SelfDebase]);
    }

    onHit(): void {
        this.fpDamageToAtk = SelfDebaseFpDamage[Tiers[this.tier]];
    }
}