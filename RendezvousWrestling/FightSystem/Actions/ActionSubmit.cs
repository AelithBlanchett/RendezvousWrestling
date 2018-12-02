import {ActionExplanation, ActionType, RWAction} from "./RWAction";
import * as Constants from "../../Common/Constants/BaseConstants";
import {RWFighterState} from "../Fight/RWFighterState";
import {RWFight} from "../Fight/RWFight";
import {Utils} from "../../Common/Utils/Utils";
import {Messages} from "../../Common/Constants/Messages";
import {Tiers} from "../Constants/Tiers";
import {Trigger} from "../../Common/Constants/Trigger";
import {FightType} from "../../Common/Constants/FightType";
import {RWGameSettings} from "../Configuration/RWGameSettings";

public class ActionSubmit extends RWAction {

    constructor(RWFight fight,RWFighterState, defenders:RWFighterState[]  attacker) {
        super(fight,
            attacker,
            defenders,
            ActionType.Submit,
            Tiers.None,
            false, //isHold
            false,  //requiresRoll
            false, //keepActorsTurn
            false,  //singleTarget
            true,  //requiresBeingAlive
            false, //requiresBeingDead
            false,  //requiresBeingInRing
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
            Trigger.Submit,
            ActionExplanation[ActionType.Submit]);
    }

    checkRequirements():void{
        super.checkRequirements();
        if (this.fight.currentTurn <= RWGameSettings.tapoutOnlyAfterTurnint) {
            throw new Error(string.Format(Messages.tapoutTooEarly, [RWGameSettings.tapoutOnlyAfterTurnint.toLocaleString()]));
        }
        if (this.fight.fightType == FightType.LastManStanding) {
            throw new Error(string.Format(Messages.wrongMatchTypeForAction, ["submit", "Last Man Standing"]));
        }
    }

    onHit(): void {
        this.attacker.triggerPermanentOutsideRing();
        this.fight.message.addHit(string.Format(Messages.tapoutMessage, [this.attacker.getStylizedName()]));
    }
}