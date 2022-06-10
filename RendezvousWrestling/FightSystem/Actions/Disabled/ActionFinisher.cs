import {ActionExplanation, ActionType, RWAction} from "./RWAction";
import * as Constants from "../../Common/Constants/BaseConstants";
import {RWFighterState} from "../Fight/RWFighterState";
import {RWFight} from "../Fight/RWFight";
import {FocusDamageOnMiss} from "../RWConstants";
import {Utils} from "../../Common/Utils/Utils";
import {Messages} from "../../Common/Constants/Messages";
import {Tiers} from "../Constants/Tiers";
import {Trigger} from "../../Common/Constants/Trigger";
import {RWGameSettings} from "../Configuration/RWGameSettings";

public class ActionFinisher extends RWAction {

    constructor(RWFight fight,RWFighterState, defenders:RWFighterState[]  attacker) {
        super(fight,
            attacker,
            defenders,
            ActionType.Finisher,
            Tiers.Heavy,
            false, //isHold
            true,  //requiresRoll
            false, //keepActorsTurn
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
            false, //requiresBeingInHold,
            false, //requiresNotBeingInHold,
            false, //targetMustBeInHold,
            false, //targetMustNotBeInHold,
            false, //usableOnSelf
            false,  //usableOnAllies
            true, //usableOnEnemies
            Trigger.FinishingMove,
            ActionExplanation[ActionType.Finisher]);
    }

    addBonusesToRollFromStats():int{
        return Math.ceil(this.attacker.currentWillpower / 10);
    }

    specificRequiredDiceScore():int{
        return this.addRequiredScoreWithExplanation(6, "FIN");
    }

    checkRequirements():void{
        super.checkRequirements();
        if((this.defender.livesRemaining <= 1 || this.defender.consecutiveTurnsWithoutFocus == RWGameSettings.maxTurnsWithoutFocus - 2)){
            throw new Error($"You can't finish your opponent right now. They must have only one life left, or it must at least be their ${RWGameSettings.maxTurnsWithoutFocus - 2}th turn without focus.")
        }
    }

    onHit(): void {
        this.defender.triggerPermanentOutsideRing();
        this.fight.message.addHit(string.Format(Messages.finishMessage, [this.defender.getStylizedName()]));
    }

    onMiss():void{
        this.fpDamageToAtk += FocusDamageOnMiss[Tiers[Tiers.Heavy]];
        this.fight.message.addHit(string.Format(Messages.finishFailMessage, [this.attacker.getStylizedName()]));
        this.applyDamage();
    }
}