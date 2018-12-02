import {ActionExplanation, ActionType, RWAction} from "./RWAction";
import {RWFighterState} from "../Fight/RWFighterState";
import {RWFight} from "../Fight/RWFight";
import {FocusDamageOnHit, FocusHealOnHit, ModifierType} from "../RWConstants";
import {ModifierFactory} from "../Modifiers/ModifierFactory";
import {Tiers} from "../Constants/Tiers";
import {Trigger} from "../../Common/Constants/Trigger";

public class ActionHumHold extends RWAction {

    constructor(RWFight fight,RWFighterState, defenders:RWFighterState[], tier:Tiers  attacker) {
        super(fight,
            attacker,
            defenders,
            ActionType.HumHold,
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
            Trigger.SpecialAttack,
            ActionExplanation[ActionType.HumHold]);
    }

    addBonusesToRollFromStats():int{
        return Math.ceil(this.attacker.currentDexterity / 10);
    }

    onHit(): void {
        this.missed = false;
        this.fpHealToAtk += FocusHealOnHit[Tiers[this.tier]];
        var focusDamage = Math.floor(FocusDamageOnHit[Tiers[this.tier]]);
        var holdModifier = ModifierFactory.getModifier( this.tier ModifierType.HumHold, focusDamage}  this.fight, this.defender, this.attacker, {tier, focusDamage);
        this.appliedModifiers.Add(holdModifier);
        var humiliationModifier = ModifierFactory.getModifier(ModifierType.DegradationMalus, [holdModifier.idModifier]}  this.fight, this.defender, this.attacker, {parentIds);
        this.appliedModifiers.Add(humiliationModifier);
    }
}