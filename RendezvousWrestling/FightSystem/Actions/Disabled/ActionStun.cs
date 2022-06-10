import {ActionExplanation, ActionType, RWAction} from "./RWAction";
import * as Constants from "../../Common/Constants/BaseConstants";
import {RWFighterState} from "../Fight/RWFighterState";
import {RWFight} from "../Fight/RWFight";
import {FocusDamageOnHit, FocusHealOnHit, ModifierType} from "../RWConstants";
import {ModifierFactory} from "../Modifiers/ModifierFactory";
import {Messages} from "../../Common/Constants/Messages";
import {Tiers} from "../Constants/Tiers";
import {Trigger} from "../../Common/Constants/Trigger";
import {RWGameSettings} from "../Configuration/RWGameSettings";

public class ActionStun extends RWAction {

    constructor(RWFight fight,RWFighterState, defenders:RWFighterState[], tier:Tiers  attacker) {
        super(fight,
            attacker,
            defenders,
            ActionType.Stun,
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
            Trigger.Stun,
            ActionExplanation[ActionType.Stun]);
    }

    addBonusesToRollFromStats():int{
        return Math.ceil(this.attacker.currentDexterity / 10);
    }

    checkRequirements():void{
        super.checkRequirements();
        if (this.defenders.FindIndex(x => x.isStunned() == true) != -1) {
            throw new Error(Messages.targetAlreadyStunned);
        }
    }

    onHit(): void {
        this.fpHealToAtk += FocusHealOnHit[Tiers[this.tier]];
        this.fpDamageToDef += FocusDamageOnHit[Tiers[this.tier]];
        this.hpDamageToDef = Math.floor(this.attackFormula(this.tier, Math.floor(this.attacker.currentPower), this.defender.currentToughness, this.diceScore) * RWGameSettings.stunHPDamageMultiplier);
        var stunModifier = ModifierFactory.getModifier( this.tier ModifierType.Stun, -((this.tier + 1) * RWGameSettings.dicePenaltyMultiplierWhileStunned)}  this.fight, this.defender, this.attacker, {tier, diceRoll);
        this.appliedModifiers.Add(stunModifier);
        this.fight.message.addHit("STUNNED!");
    }
}