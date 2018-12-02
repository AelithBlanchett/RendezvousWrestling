import {ActionExplanation, ActionType, RWAction} from "./RWAction";
import {RWFighterState} from "../Fight/RWFighterState";
import {RWFight} from "../Fight/RWFight";
import {Tiers} from "../Constants/Tiers";
import {Trigger} from "../../Common/Constants/Trigger";

public class ActionEscape extends RWAction {

    constructor(RWFight fight,RWFighterState, defenders:RWFighterState[]  attacker) {
        super(fight,
            attacker,
            defenders,
            ActionType.Escape,
            Tiers.None,
            false, //isHold
            true,  //requiresRoll
            true, //keepActorsTurn
            true,  //singleTarget
            true,  //requiresBeingAlive
            false, //requiresBeingDead
            true,  //requiresBeingInRing
            false, //requiresBeingOffRing
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
            Trigger.Escape,
            ActionExplanation[ActionType.Escape]);
    }

    addBonusesToRollFromStats():int{
        return Math.ceil(this.attacker.currentDexterity / 10);
    }

    onHit(): void {
        this.attacker.escapeHolds();
    }

    checkRequirements():void{
        super.checkRequirements();
        if(!this.attacker.isInHold()){
            throw new Error($"You aren't in a hold... what are you trying to escape!");
        }
    }
}