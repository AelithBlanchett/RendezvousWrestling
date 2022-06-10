import {ActionExplanation, ActionType, RWAction} from "./RWAction";
import {RWFighterState} from "../Fight/RWFighterState";
import {RWFight} from "../Fight/RWFight";
import {FailedHighRiskMultipliers, FocusDamageOnHit, FocusHealOnHit, HighRiskMultipliers} from "../RWConstants";
import {Tiers} from "../Constants/Tiers";
import {Trigger} from "../../Common/Constants/Trigger";

public class ActionRiskyLewd extends RWAction {

    constructor(RWFight fight,RWFighterState, defenders:RWFighterState[], tier:Tiers  attacker) {
        super(fight,
            attacker,
            defenders,
            ActionType.RiskyLewd,
            tier,
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
            Trigger.MagicalAttack,
            ActionExplanation[ActionType.RiskyLewd]);
    }

    addBonusesToRollFromStats():int{
        return Math.ceil(this.attacker.currentSensuality / 10);
    }

    onHit(): void {
        this.fpHealToAtk += FocusHealOnHit[Tiers[this.tier]];
        this.fpDamageToDef += FocusDamageOnHit[Tiers[this.tier]];
        this.lpDamageToDef += Math.floor(this.attackFormula(this.tier, this.attacker.currentSensuality, this.defender.currentEndurance, this.diceScore) * HighRiskMultipliers[Tiers[this.tier]]);
        this.lpDamageToAtk += Math.floor(this.attackFormula(this.tier, this.attacker.currentSensuality, this.defender.currentEndurance, this.diceScore) * FailedHighRiskMultipliers[Tiers[this.tier]]);
    }

    onMiss():void{
        this.fpDamageToAtk += FocusDamageOnHit[Tiers[this.tier]];
        this.fpHealToDef += FocusHealOnHit[Tiers[this.tier]];
        this.lpDamageToAtk += Math.floor(this.attackFormula(this.tier, this.attacker.currentSensuality, this.attacker.currentEndurance, 0) * HighRiskMultipliers[Tiers[this.tier]] * FailedHighRiskMultipliers[Tiers[this.tier]]);
        this.lpDamageToDef += Math.floor(this.attackFormula(this.tier, this.attacker.currentSensuality, this.defender.currentEndurance, 0) * FailedHighRiskMultipliers[Tiers[this.tier]]);
        this.applyDamage();
    }
}