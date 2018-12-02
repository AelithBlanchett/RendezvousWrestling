///<reference path="../../Common/Actions/BaseActiveAction.ts"/>
import {BaseActiveAction} from "../../Common/Actions/BaseActiveAction";
import {RWFight} from "../Fight/RWFight";
import {RWFighterState} from "../Fight/RWFighterState";
import {BaseDamage, FocusDamageOnMiss} from "../RWConstants";
import {Modifier} from "../Modifiers/Modifier";
import * as Constants from "../RWConstants"
import {TierDifficulty, Tiers} from "../Constants/Tiers";
import {Trigger} from "../../Common/Constants/Trigger";

public abstract class RWAction extends BaseActiveAction<RWFight, RWFighterState> {

public  int[] = []    hpDamageToDefs {get; set;}
public  int[] = []    lpDamageToDefs {get; set;}
public  int[] = []    fpDamageToDefs {get; set;}
public  int = 0    hpDamageToAtk {get; set;}
public  int = 0    lpDamageToAtk {get; set;}
public  int = 0    fpDamageToAtk {get; set;}
public  int[] = []    hpHealToDefs {get; set;}
public  int[] = []    lpHealToDefs {get; set;}
public  int[] = []    fpHealToDefs {get; set;}
public  int = 0    hpHealToAtk {get; set;}
public  int = 0    lpHealToAtk {get; set;}
public  int = 0    fpHealToAtk {get; set;}

public  int    diceScoreBaseDamage {get; set;}
public  int    diceScoreStatDifference {get; set;}
public  int    diceScoreBonusPoints {get; set;}

public  Modifier[] = []    appliedModifiers {get; set;}

    get avgHpDamageToDefs():int{
        if(this.hpDamageToDefs != null && this.hpDamageToDefs.length == 1){
            return this.hpDamageToDefs[0];
        }
        else if(this.hpDamageToDefs != null && this.hpDamageToDefs.length > 1){
            return this.hpDamageToDefs.reduce((a, b) => a + b, 0);
        }
        else{
            return 0;
        }
    }

    get avgLpDamageToDefs():int{
        if(this.lpDamageToDefs != null && this.lpDamageToDefs.length == 1){
            return this.lpDamageToDefs[0];
        }
        else if(this.lpDamageToDefs != null && this.lpDamageToDefs.length > 1){
            return this.lpDamageToDefs.reduce((a, b) => a + b, 0);
        }
        else{
            return 0;
        }
    }

    get avgFpDamageToDefs():int{
        if(this.fpDamageToDefs != null && this.fpDamageToDefs.length == 1){
            return this.fpDamageToDefs[0];
        }
        else if(this.fpDamageToDefs != null && this.fpDamageToDefs.length > 1){
            return this.fpDamageToDefs.reduce((a, b) => a + b, 0);
        }
        else{
            return 0;
        }
    }

    get hpDamageToDef():int{
        if(this.hpDamageToDefs != null && this.hpDamageToDefs.length == 1){
            return this.hpDamageToDefs[0];
        }
        else{
            return 0;
        }
    }

    set hpDamageToDef(value:int){
        this.hpDamageToDefs = [value];
    }

    get lpDamageToDef():int{
        if(this.lpDamageToDefs != null && this.lpDamageToDefs.length == 1){
            return this.lpDamageToDefs[0];
        }
        else{
            return 0;
        }
    }

    set lpDamageToDef(value:int){
        this.lpDamageToDefs = [value];
    }

    get fpDamageToDef():int{
        if(this.fpDamageToDefs != null && this.fpDamageToDefs.length == 1){
            return this.fpDamageToDefs[0];
        }
        else{
            return 0;
        }
    }

    set fpDamageToDef(value:int){
        this.fpDamageToDefs = [value];
    }

    get hpHealToDef():int{
        if(this.hpHealToDefs != null && this.hpHealToDefs.length == 1){
            return this.hpHealToDefs[0];
        }
        else{
            return 0;
        }
    }

    set hpHealToDef(value:int){
        this.hpHealToDefs = [value];
    }

    get lpHealToDef():int{
        if(this.lpHealToDefs != null && this.lpHealToDefs.length == 1){
            return this.lpHealToDefs[0];
        }
        else{
            return 0;
        }
    }

    set lpHealToDef(value:int){
        this.lpHealToDefs = [value];
    }

    get fpHealToDef():int{
        if(this.fpHealToDefs != null && this.fpHealToDefs.length == 1){
            return this.fpHealToDefs[0];
        }
        else{
            return 0;
        }
    }

    set fpHealToDef(value:int){
        this.fpHealToDefs = [value];
    }

    attackFormula( Tiers tier, int, targetDef: int, roll: int  actorAtk): int {
         int statDiff = 0;
        if (actorAtk - targetDef > 0) {
            statDiff = Math.ceil((actorAtk - targetDef) / 10);
        }

         int diceBonus = 0;
        var calculatedBonus = Math.floor((roll - TierDifficulty[Tiers[tier]]) / 2);
        if (calculatedBonus > 0) {
            diceBonus = calculatedBonus;
        }

        this.diceScoreBaseDamage = parseInt(BaseDamage[Tiers[tier]]);
        this.diceScoreStatDifference = statDiff;
        this.diceScoreBonusPoints = diceBonus;

        return this.diceScoreBaseDamage + this.diceScoreStatDifference + this.diceScoreBonusPoints;
    }

    specificRequiredDiceScore():int{
        var scoreRequired = 0;

        if(this.tier != -1){
            scoreRequired += this.addRequiredScoreWithExplanation(TierDifficulty[Tiers[this.tier]], "TIER");
        }

        scoreRequired += this.addRequiredScoreWithExplanation((Constants.Fight.Action.Globals.difficultyIncreasePerBondageItem * this.attacker.bondageItemsOnSelf()), "BDG");

        //No effects apply if it's a multi-target action. Should we have any?
        if(this.singleTarget && this.defender){
            scoreRequired += this.addRequiredScoreWithExplanation(-(Constants.Fight.Action.Globals.difficultyIncreasePerBondageItem * this.defender.bondageItemsOnSelf()), "BDG");
            scoreRequired += this.addRequiredScoreWithExplanation(Math.floor((this.defender.currentDexterity - this.attacker.currentDexterity) / 15), "DEXDIFF");

            if(this.defender.focus >= 0){
                scoreRequired += this.addRequiredScoreWithExplanation(Math.floor((this.defender.focus - this.attacker.focus) / 15), "FPDIFF");
            }
            if(this.defender.focus < 0){
                scoreRequired += this.addRequiredScoreWithExplanation(Math.floor(this.defender.focus / 10) - 1, "FPZERO");
            }

            var defenderStunnedTier = this.defender.getStunnedTier();
            if(defenderStunnedTier >= Tiers.Light){
                switch(defenderStunnedTier){
                    case Tiers.Light:
                        scoreRequired += this.addRequiredScoreWithExplanation(-2, "L-STUN");
                        break;
                    case Tiers.Medium:
                        scoreRequired += this.addRequiredScoreWithExplanation(-4, "M-STUN");
                        break;
                    case Tiers.Heavy:
                        scoreRequired += this.addRequiredScoreWithExplanation(-6, "H-STUN");
                        break;
                }
            }
        }

        return scoreRequired;
    }

    onMiss():void{
        this.attacker.hitFP(FocusDamageOnMiss[Tiers[this.tier]]);
    }

    applyDamage():void{
        if (this.hpDamageToDefs.length > 0) {
            for(var i = 0; i < this.hpDamageToDefs.length; i++){
                if(this.hpDamageToDefs[i] > 0){
                    this.defenders[i].hitHP(this.hpDamageToDefs[i]);
                }
            }
        }
        if (this.lpDamageToDefs.length > 0) {
            for(var i = 0; i < this.lpDamageToDefs.length; i++){
                if(this.lpDamageToDefs[i] > 0){
                    this.defenders[i].hitLP(this.lpDamageToDefs[i]);
                }
            }
        }
        if (this.fpDamageToDefs.length > 0) {
            for(var i = 0; i < this.fpDamageToDefs.length; i++){
                if(this.fpDamageToDefs[i] > 0){
                    this.defenders[i].hitFP(this.fpDamageToDefs[i]);
                }
            }
        }
        if (this.hpHealToDefs.length > 0) {
            for(var i = 0; i < this.hpHealToDefs.length; i++){
                if(this.hpHealToDefs[i] > 0){
                    this.defenders[i].healHP(this.hpHealToDefs[i]);
                }
            }
        }
        if (this.lpHealToDefs.length > 0) {
            for(var i = 0; i < this.lpHealToDefs.length; i++){
                if(this.lpHealToDefs[i] > 0){
                    this.defenders[i].healLP(this.lpHealToDefs[i]);
                }
            }
        }
        if (this.fpHealToDefs.length > 0) {
            for(var i = 0; i < this.fpHealToDefs.length; i++){
                if(this.fpHealToDefs[i] > 0){
                    this.defenders[i].healFP(this.fpHealToDefs[i]);
                }
            }
        }

        if (this.hpDamageToAtk > 0) {
            this.attacker.hitHP(this.hpDamageToAtk);
        }
        if (this.lpDamageToAtk > 0) {
            this.attacker.hitLP(this.lpDamageToAtk);
        }
        if (this.fpDamageToAtk > 0) {
            this.attacker.hitFP(this.fpDamageToAtk);
        }
        if (this.hpHealToAtk > 0) {
            this.attacker.healHP(this.hpHealToAtk);
        }
        if (this.lpHealToAtk > 0) {
            this.attacker.healLP(this.lpHealToAtk);
        }
        if (this.fpHealToAtk > 0) {
            this.attacker.healFP(this.fpHealToAtk);
        }


        if (this.appliedModifiers.length > 0) {
            if (this.isHold) { //for any holds, do the stacking here
                var indexOfNewHold = this.appliedModifiers.findIndex(x => x.isAHold());

                for(var defender of this.defenders){
                    //START
                    var indexOfAlreadyExistantHoldForDefender = defender.modifiers.findIndex(x => x.isAHold());
                    if (indexOfAlreadyExistantHoldForDefender != -1) {
                        var idOfFormerHold = defender.modifiers[indexOfAlreadyExistantHoldForDefender].idModifier;
                        for (var mod of defender.modifiers) {
                            //we updated the children and parent's damage and turns
                            if (mod.idModifier == idOfFormerHold) {
                                mod.name = this.appliedModifiers[indexOfNewHold].name;
                                mod.event = this.appliedModifiers[indexOfNewHold].event;
                                mod.uses += this.appliedModifiers[indexOfNewHold].uses;
                                mod.hpDamage += this.appliedModifiers[indexOfNewHold].hpDamage;
                                mod.lustDamage += this.appliedModifiers[indexOfNewHold].lustDamage;
                                mod.focusDamage += this.appliedModifiers[indexOfNewHold].focusDamage;
                                //Did not add the dice/escape score modifications, if needed, implement here
                            }
                            else if (mod.idParentActions && mod.idParentActions.indexOf(idOfFormerHold) != -1) {
                                mod.uses += this.appliedModifiers[indexOfNewHold].uses;
                            }
                        }
                        for (var mod of this.attacker.modifiers) {
                            //update the bonus appliedModifiers length
                            if (mod.idParentActions && mod.idParentActions.indexOf(idOfFormerHold) != -1) {
                                mod.uses += this.appliedModifiers[indexOfNewHold].uses;
                            }
                        }
                        this.fight.message.addSpecial(`[b][color=red]Hold Stacking![/color][/b] ${defender.getStylizedName()} will have to suffer this hold for ${this.appliedModifiers[indexOfNewHold].uses} more turns, and will also suffer a bit more, as it has added
                                         ${(this.appliedModifiers[indexOfNewHold].hpDamage > 0 ? " -" + this.appliedModifiers[indexOfNewHold].hpDamage + " HP per turn " : "")}
                                         ${(this.appliedModifiers[indexOfNewHold].lustDamage > 0 ? " +" + this.appliedModifiers[indexOfNewHold].lustDamage + " Lust per turn " : "")}
                                         ${(this.appliedModifiers[indexOfNewHold].focusDamage > 0 ? " -" + this.appliedModifiers[indexOfNewHold].focusDamage + " Focus per turn" : "")}
                         `);
                    }
                    else {
                        for (var mod of this.appliedModifiers) {
                            if (mod.receiver.name == defender.name) {
                                defender.modifiers.push(mod);
                            }
                            else if (mod.receiver.name == this.attacker.name) {
                                this.attacker.modifiers.push(mod);
                            }
                        }
                    }


                }
            }
            else {
                for (var mod of this.appliedModifiers) {
                    if (mod.receiver == this.attacker) {
                        this.attacker.modifiers.push(mod);
                    }
                    else if (this.defenders.findIndex(x => x.name == mod.receiver.name) != -1) {
                        this.defenders.find(x => x.name == mod.receiver.name).modifiers.push(mod);
                    }
                }
            }
        }
    }

}

public class EmptyAction extends RWAction {

    constructor(any fight,any, defender:any  attacker){
        super(fight, attacker, [defender], "actionName", -1, false, false, false, true, true, false, true, false, true, false, true, false, true, false, false, true, false, true, false, false, true, Trigger.None, "no explanation", 1);
    }

    onHit(): void {

    }
}

public enum ActionType  {
    Brawl = "Brawl",
    Tease  = "Tease",
    Tag = "Tag",
    Rest = "Rest",
    SubHold = "SubHold",
    SexHold = "SexHold",
    Bondage = "Bondage",
    HumHold = "HumHold",
    ItemPickup = "ItemPickup",
    SextoyPickup = "SextoyPickup",
    Degradation = "Degradation",
    ForcedWorship = "ForcedWorship",
    HighRisk = "HighRisk",
    RiskyLewd = "RiskyLewd",
    Stun = "Stun",
    Escape = "Escape",
    Submit = "Submit",
    StrapToy = "StrapToy",
    Finisher = "Finisher",
    Masturbate = "Masturbate",
    Pass = "Pass",
    ReleaseHold = "ReleaseHold",
    SelfDebase = "SelfDebase"
}

public class ActionExplanation {
    static Tag = `[b][color=red]TAG![/color][/b] %s heads out of the ring!`;
    static Rest = `[b][color=red]%s rests for a bit![/color][/b]`;
    static Bondage = `[b][color=red]%s just tied up their opponent a little bit more![/color][/b]`;
    static ItemPickup = `[b][color=red]%s's picked up item looks like it could it hit hard![/color][/b]`;
    static SextoyPickup = `[b][color=red]%s is going to have a lot of fun with this sex-toy![/color][/b]`;
    static Escape = `[b][color=red]%s got away![/color][/b]`;
    static Submit = `[b][color=red]%s taps out! It's over, it's done![/color][/b]`;
    static Masturbate = `[b][color=red]%s really needed those strokes apparently![/color][/b]`;
    static Pass = `[b][color=red]%s passed their turn...[/color][/b]`;
    static SelfDebase = `[b][color=red]%s is sinking deeper...[/color][/b]`;
}