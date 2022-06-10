import {ActionExplanation, ActionType, RWAction} from "./RWAction";
import * as Constants from "../../Common/Constants/BaseConstants";
import {RWFighterState} from "../Fight/RWFighterState";
import {RWFight} from "../Fight/RWFight";
import {Tiers} from "../Constants/Tiers";
import {Trigger} from "../../Common/Constants/Trigger";
import {RWGameSettings} from "../Configuration/RWGameSettings";

public class ActionRest extends RWAction {

    constructor(RWFight fight,RWFighterState, defenders:RWFighterState[]  attacker) {
        super(fight,
            attacker,
            defenders,
            ActionType.Rest,
            Tiers.None,
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
            true, //usableOnSelf
            false,  //usableOnAllies
            false, //usableOnEnemies
            Trigger.Rest,
            ActionExplanation[ActionType.Rest]);
    }

    get requiredDiceScore():int{
        return RWGameSettings.requiredScoreRest;
    }

    addBonusesToRollFromStats():int{
        return Math.ceil(this.attacker.currentDexterity / 10);
    }

    onHit(): void {
        this.hpHealToAtk += this.attacker.hpPerHeart() * RWGameSettings.hpPercentageToHealOnRest;
        this.lpHealToAtk += this.attacker.lustPerOrgasm() * RWGameSettings.lpPercentageToHealOnRest;
        this.fpHealToAtk += this.attacker.maxFocus() * RWGameSettings.fpPercentageToHealOnRest;
    }
}