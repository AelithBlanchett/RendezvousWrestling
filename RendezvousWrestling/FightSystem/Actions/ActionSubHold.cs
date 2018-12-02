import {ActionExplanation, ActionType, RWAction} from "./RWAction";
import * as Constants from "../../Common/Constants/BaseConstants";
import {RWFighterState} from "../Fight/RWFighterState";
import {RWFight} from "../Fight/RWFight";
import {FocusDamageOnHit, FocusHealOnHit, ModifierType} from "../RWConstants";
import {ModifierFactory} from "../Modifiers/ModifierFactory";
import {Tiers} from "../Constants/Tiers";
import {Trigger} from "../../Common/Constants/Trigger";
import {RWGameSettings} from "../Configuration/RWGameSettings";

public class ActionSubHold extends RWAction {

    constructor(RWFight fight,RWFighterState, defenders:RWFighterState[], tier:Tiers  attacker) {
        super(fight,
            attacker,
            defenders,
            ActionType.SubHold,
            tier,
            true, //isHold
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
            true, //requiresNotBeingInHold,
            false, //targetMustBeInHold,
            false, //targetMustNotBeInHold,
            false, //usableOnSelf
            false,  //usableOnAllies
            true, //usableOnEnemies
            Trigger.PhysicalAttack,
            ActionExplanation[ActionType.SubHold]);
    }

    addBonusesToRollFromStats():int{
        return Math.ceil(this.attacker.currentDexterity / 10);
    }

    onHit(): void {
        this.fpHealToAtk += FocusHealOnHit[Tiers[this.tier]];
        this.fpDamageToDef += FocusDamageOnHit[Tiers[this.tier]];
        var hpDamage = Math.floor(this.attackFormula(this.tier, this.attacker.currentPower, this.defender.currentToughness, this.diceScore) * RWGameSettings.holdDamageMultiplier);
        var holdModifier = ModifierFactory.getModifier( this.tier ModifierType.SubHold, hpDamage}  this.fight, this.defender, this.attacker, {tier, hpDamage);
        var brawlBonusAttacker = ModifierFactory.getModifier(ModifierType.SubHoldBrawlBonus, [holdModifier.idModifier]}  this.fight, this.attacker, null, {parentIds);
        var brawlBonusDefender = ModifierFactory.getModifier(ModifierType.SubHoldBrawlBonus, [holdModifier.idModifier]}  this.fight, this.defender, null, {parentIds);
        this.appliedModifiers.push(holdModifier);
        this.appliedModifiers.push(brawlBonusAttacker);
        this.appliedModifiers.push(brawlBonusDefender);
    }
}