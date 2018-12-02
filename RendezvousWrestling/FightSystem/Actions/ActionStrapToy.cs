import {ActionExplanation, ActionType, RWAction} from "./RWAction";
import {RWFighterState} from "../Fight/RWFighterState";
import {RWFight} from "../Fight/RWFight";
import {FocusDamageOnHit, FocusHealOnHit, ModifierType, StrapToyDiceRollPenalty, StrapToyLPDamagePerTurn} from "../RWConstants";
import {ModifierFactory} from "../Modifiers/ModifierFactory";
import {Tiers} from "../Constants/Tiers";
import {Trigger} from "../../Common/Constants/Trigger";

public class ActionStrapToy extends RWAction {

    constructor(RWFight fight,RWFighterState, defenders:RWFighterState[], tier:Tiers  attacker) {
        super(fight,
            attacker,
            defenders,
            ActionType.StrapToy,
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
            false, //targetMustBeOffRing
            true, //targetMustBeInRange
            false, //targetMustBeOffRange
            false, //requiresBeingInHold,
            false, //requiresNotBeingInHold,
            false, //targetMustBeInHold,
            false, //targetMustNotBeInHold,
            false, //usableOnSelf
            false,  //usableOnAllies
            true, //usableOnEnemies
            Trigger.BonusPickup,
            ActionExplanation[ActionType.StrapToy]);
    }

    addBonusesToRollFromStats():int{
        return Math.ceil(this.attacker.currentSensuality / 10);
    }

    onHit(): void {
        this.fpHealToAtk += FocusHealOnHit[Tiers[this.tier]];
        this.fpDamageToDef += FocusDamageOnHit[Tiers[this.tier]];
        var nbOfTurnsWearingToy = this.tier + 1;
        var lpDamage = StrapToyLPDamagePerTurn[Tiers[this.tier]];
public  this.tier, diceRoll: StrapToyDiceRollPenalty[Tiers[this.tier]], uses: nbOfTurnsWearingToy}  this.fight, this.defender, null, {focusDamage, lustDamage)        var strapToyModifier = ModifierFactory.getModifier( this.fpDamageToDef ModifierType.StrapToy, lpDamage, tier {get; set;}
        this.appliedModifiers.Add(strapToyModifier);
        this.fight.message.addHit("The sextoy started vibrating!");
    }
}