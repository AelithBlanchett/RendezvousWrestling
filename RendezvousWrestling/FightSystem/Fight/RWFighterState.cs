import "reflect-metadata";
import {Utils} from "../../Common/Utils/Utils";
import {BaseFighterState} from "../../Common/Fight/BaseFighterState";
import {Parser} from "../../Common/Utils/Parser";
import {Modifier} from "../Modifiers/Modifier";
import {FeatureType, ModifierType} from "../RWConstants";
import {GameSettings} from "../../Common/Configuration/GameSettings";
import {FightLength} from "../../Common/Constants/FightLength";
import {TriggerMoment} from "../../Common/Constants/TriggerMoment";
import {Trigger} from "../../Common/Constants/Trigger";
import {FightType} from "../../Common/Constants/FightType";
import {TransactionType} from "../../Common/Constants/TransactionType";
import {RWGameSettings} from "../Configuration/RWGameSettings";
import {ChildEntity, Column, Entity, JoinColumn, OneToOne} from "typeorm";
import {Stats} from "../Constants/Stats";
import {BaseFight} from "../../Common/Fight/BaseFight";
import {BaseUser} from "../../Common/Fight/BaseUser";
import {RWFight} from "./RWFight";
import {RWUser} from "./RWUser";

@ChildEntity("rw")
public class RWFighterState extends BaseFighterState{

    @Column()
public int = 0    hp {get; set;}
    @Column()
public int = 0    lust {get; set;}
    @Column()
public int = 0    livesRemaining {get; set;}
    @Column()
public int = 0    focus {get; set;}
    @Column()
public int    consecutiveTurnsWithoutFocus {get; set;}

    @Column()
public int    startingPower {get; set;}
    @Column()
public int    startingSensuality {get; set;}
    @Column()
public int    startingToughness {get; set;}
    @Column()
public int    startingEndurance {get; set;}
    @Column()
public int    startingDexterity {get; set;}
    @Column()
public int    startingWillpower {get; set;}
    @Column()
public int    powerDelta {get; set;}
    @Column()
public int    sensualityDelta {get; set;}
    @Column()
public int    toughnessDelta {get; set;}
    @Column()
public int    enduranceDelta {get; set;}
    @Column()
public int    dexterityDelta {get; set;}
    @Column()
public int    willpowerDelta {get; set;}

    @Column()
public  int = 0    hpDamageLastRound {get; set;}
    @Column()
public  int = 0    lpDamageLastRound {get; set;}
    @Column()
public  int = 0    fpDamageLastRound {get; set;}
    @Column()
public  int = 0    hpHealLastRound {get; set;}
    @Column()
public  int = 0    lpHealLastRound {get; set;}
    @Column()
public  int = 0    fpHealLastRound {get; set;}
    @Column()
public  int = 0    heartsDamageLastRound {get; set;}
    @Column()
public  int = 0    orgasmsDamageLastRound {get; set;}
    @Column()
public  int = 0    heartsHealLastRound {get; set;}
    @Column()
public  int = 0    orgasmsHealLastRound {get; set;}

public Modifier[]    modifiers {get; set;}

public RWUser    user {get; set;}

    constructor(RWFight fight,RWUser  user){
        super(fight, user);
        this.startingToughness = user.toughness;
        this.startingEndurance = user.endurance;
        this.startingWillpower = user.willpower;
        this.startingSensuality = user.sensuality;
        this.startingPower = user.power;
        this.startingDexterity = user.dexterity;

        this.hp = this.hpPerHeart();
        this.lust = 0;
        this.livesRemaining = this.maxLives();
        this.focus = this.initialFocus();
        this.consecutiveTurnsWithoutFocus = 0;

        this.powerDelta = 0;
        this.sensualityDelta = 0;
        this.toughnessDelta = 0;
        this.enduranceDelta = 0;
        this.dexterityDelta = 0;
        this.willpowerDelta = 0;

        this.hpDamageLastRound = 0;
        this.lpDamageLastRound = 0;
        this.fpDamageLastRound = 0;
        this.hpHealLastRound = 0;
        this.lpHealLastRound = 0;
        this.fpHealLastRound = 0;
        this.heartsDamageLastRound = 0;
        this.orgasmsDamageLastRound = 0;
        this.heartsHealLastRound = 0;
        this.orgasmsHealLastRound = 0;
    }

    initialFocus():int{
        return this.maxFocus();
    }

    maxFocus():int {
        return 30 + this.focusResistance();
    }

    totalHp():int{
        var hp = 130;
        if (this.currentToughness > 10) {
            hp += (this.currentToughness - 10);
        }
        switch (this.fightDuration()){
            case FightLength.Epic:
                hp = hp * 1.33;
                break;
            case FightLength.Long:
                hp = hp * 1.00;
                break;
            case FightLength.Medium:
                hp = hp * 0.66;
                break;
            case FightLength.Short:
                hp = hp * 0.33;
                break;
        }
        return hp;
    }

    hpPerHeart():int {
        return Math.ceil(this.totalHp() / this.maxLives());
    }

    totalLust():int{
        var lust = 130;
        if (this.currentEndurance > 10) {
            lust += (this.currentEndurance - 10);
        }
        switch (this.fightDuration()){
            case FightLength.Epic:
                lust = lust * 1.33;
                break;
            case FightLength.Long:
                lust = lust * 1.00;
                break;
            case FightLength.Medium:
                lust = lust * 0.66;
                break;
            case FightLength.Short:
                lust = lust * 0.33;
                break;
        }
        return lust;
    }

    lustPerOrgasm():int {
        return Math.ceil(this.totalLust() / this.maxLives());
    }

    maxLives():int {
        var maxLives = -1;
        switch (this.fightDuration()){
            case FightLength.Epic:
                maxLives = 4;
                break;
            case FightLength.Long:
                maxLives = 3;
                break;
            case FightLength.Medium:
                maxLives = 2;
                break;
            case FightLength.Short:
                maxLives = 1;
                break;
        }
        return maxLives;
    }

    minFocus():int {
        return 0;
    }

    focusResistance():int{
        var resistance = 30;
        if (this.currentWillpower > 10) {
            resistance += (this.currentWillpower - 10);
        }
        return resistance;
    }

    maxBondageItemsOnSelf():int {
        var maxBondageItemsOnSelf = -1;
        switch (this.fightDuration()){
            case FightLength.Epic:
                maxBondageItemsOnSelf = 5;
                break;
            case FightLength.Long:
                maxBondageItemsOnSelf = 4;
                break;
            case FightLength.Medium:
                maxBondageItemsOnSelf = 3;
                break;
            case FightLength.Short:
                maxBondageItemsOnSelf = 2;
                break;
        }
        return maxBondageItemsOnSelf;
    }

    getStatsInString():string{
        return "${this.user.power},${this.user.sensuality},${this.user.toughness},${this.user.endurance},${this.user.dexterity},${this.user.willpower}";
    }

    //fight is "mistakenly" set as optional to be compatible with the super.init
    initialize():void {
        super.initialize();
        this.startingToughness = this.user.toughness;
        this.startingEndurance = this.user.endurance;
        this.startingWillpower = this.user.willpower;
        this.startingSensuality = this.user.sensuality;
        this.startingPower = this.user.power;
        this.startingDexterity = this.user.dexterity;

        this.hp = this.hpPerHeart();
        this.lust = 0;
        this.livesRemaining = this.maxLives();
        this.focus = this.initialFocus();

        this.powerDelta = 0;
        this.sensualityDelta = 0;
        this.toughnessDelta = 0;
        this.enduranceDelta = 0;
        this.dexterityDelta = 0;
        this.willpowerDelta = 0;
    }

    validateStats():string{
        var statsInString = this.getStatsInString();
        return Parser.checkIfValidStats(statsInString, GameSettings.intOfRequiredStatPoints, GameSettings.intOfDifferentStats, GameSettings.minStatLimit, GameSettings.maxStatLimit);
    }

    get currentPower():int{
        return this.startingPower + this.powerDelta;
    }

    set currentPower(delta:int){
        this.powerDelta += delta;
    }

    get currentSensuality():int{
        return this.startingSensuality + this.sensualityDelta;
    }

    set currentSensuality(delta:int){
        this.sensualityDelta += delta;
    }

    get currentToughness():int{
        return this.startingToughness + this.toughnessDelta;
    }

    set currentToughness(delta:int){
        this.toughnessDelta += delta;
    }

    get currentEndurance():int{
        return this.startingEndurance + this.enduranceDelta;
    }

    set currentEndurance(delta:int){
        this.enduranceDelta += delta;
    }

    get currentDexterity():int{
        return this.startingDexterity + this.dexterityDelta;
    }

    set currentDexterity(delta:int){
        this.dexterityDelta += delta;
    }

    get currentWillpower():int{
        return this.startingWillpower + this.willpowerDelta;
    }

    set currentWillpower(delta:int){
        this.willpowerDelta += delta;
    }

    get livesDamageLastRound():int{
        return this.heartsDamageLastRound + this.orgasmsDamageLastRound;
    }

    get livesHealLastRound():int{
        return this.heartsHealLastRound + this.orgasmsHealLastRound;
    }

    get displayRemainingLives():string{
        var str = "";
        for(var i = 1; i <= this.maxLives(); i++){
            if(i < this.livesRemaining){
                str += "❤️";
            }
            else if(i == this.livesRemaining){
                str += "💓";
            }
            else{
                str += "🖤";
            }
        }
        return str;
    }

    nextRound(){
        super.nextRound();
        this.hpDamageLastRound = 0;
        this.lpDamageLastRound = 0;
        this.fpDamageLastRound = 0;
        this.hpHealLastRound = 0;
        this.lpHealLastRound = 0;
        this.fpHealLastRound = 0;

        this.heartsDamageLastRound = 0;
        this.orgasmsDamageLastRound = 0;
        this.heartsHealLastRound = 0;
        this.orgasmsHealLastRound = 0;
    }

    healHP(int hp,bool = true  triggerMods) {
        hp = Math.floor(hp);
        if (hp < 1) {
            hp = 1;
        }
        if (triggerMods) {
            this.triggerMods(TriggerMoment.Before, Trigger.MainBarHealing);
        }
        if (this.hp + hp > this.hpPerHeart()) {
            hp = this.hpPerHeart() - this.hp; //reduce the int if it overflows the bar
        }
        this.hp += hp;
        this.hpHealLastRound += hp;
        if (triggerMods) {
            this.triggerMods(TriggerMoment.After, Trigger.MainBarHealing);
        }
    }

    healLP(int lust,bool = true  triggerMods) {
        lust = Math.floor(lust);
        if (lust < 1) {
            lust = 1;
        }
        if (triggerMods) {
            this.triggerMods(TriggerMoment.Before, Trigger.SecondaryBarHealing);
        }
        if (this.lust - lust < 0) {
            lust = this.lust; //reduce the int if it overflows the bar
        }
        this.lust -= lust;
        this.lpHealLastRound += lust;
        if (triggerMods) {
            this.triggerMods(TriggerMoment.After, Trigger.SecondaryBarHealing);
        }
    }

    healFP(int focus,bool = true  triggerMods) {
        focus = Math.floor(focus);
        if (focus < 1) {
            focus = 1;
        }
        if (triggerMods) {
            this.triggerMods(TriggerMoment.Before, Trigger.UtilitaryBarHealing);
        }
        if (this.focus + focus > this.maxFocus()) {
            focus = this.maxFocus() - this.focus; //reduce the int if it overflows the bar
        }
        this.focus += focus;
        this.fpHealLastRound += focus;
        if (triggerMods) {
            this.triggerMods(TriggerMoment.After, Trigger.UtilitaryBarHealing);
        }
    }

    hitHP(int hp,bool = true  triggerMods) {
        hp = Math.floor(hp);
        if (hp < 1) {
            hp = 1;
        }
        if (triggerMods) {
            this.triggerMods(TriggerMoment.Before, Trigger.MainBarDamage);
        }
        this.hp -= hp;
        this.hpDamageLastRound += hp;
        if (this.hp <= 0) {
            this.triggerMods(TriggerMoment.Before, Trigger.MainBarDepleted);
            this.hp = 0;
            //this.heartsRemaining--;
            this.livesRemaining--;
            this.heartsDamageLastRound += 1;
            this.fight.message.addHit($"[b][color=red]Heart broken![/color][/b] ${this.name} has ${this.livesRemaining} lives left.");
            if (this.livesRemaining > 0) {
                this.hp = this.hpPerHeart();
            }
            else if (this.livesRemaining == 1) {
                this.fight.message.addHit($"[b][color=red]Last life[/color][/b] for ${this.name}!");
            }
            this.triggerMods(TriggerMoment.After, Trigger.MainBarDepleted);
        }
        if (triggerMods) {
            this.triggerMods(TriggerMoment.After, Trigger.MainBarDamage);
        }
    }

    hitLP(int lust,bool = true  triggerMods) {
        lust = Math.floor(lust);
        if (lust < 1) {
            lust = 1;
        }
        if (triggerMods) {
            this.triggerMods(TriggerMoment.Before, Trigger.SecondaryBarDamage);
        }
        this.lust += lust;
        this.lpDamageLastRound += lust;
        if (this.lust >= this.lustPerOrgasm()) {
            this.triggerMods(TriggerMoment.Before, Trigger.SecondaryBarDepleted);
            this.lust = 0;
            //this.orgasmsRemaining--;
            this.livesRemaining--;
            this.orgasmsDamageLastRound += 1;
            this.fight.message.addHit($"[b][color=pink]Orgasm on the mat![/color][/b] ${this.name} has ${this.livesRemaining} lives left.");
            this.lust = 0;
            if (triggerMods) {
                this.triggerMods(TriggerMoment.After, Trigger.SecondaryBarDepleted);
            }
            if (this.livesRemaining == 1) {
                this.fight.message.addHit($"[b][color=red]Last life[/color][/b] for ${this.name}!");
            }
        }
        this.triggerMods(TriggerMoment.After, Trigger.SecondaryBarDamage);
    }

    hitFP(int focusDamage,bool = true  triggerMods) {
        if (focusDamage <= 0) {
            return;
        }
        focusDamage = Math.floor(focusDamage);
        if (triggerMods) {
            this.triggerMods(TriggerMoment.Before, Trigger.UtilitaryBarDamage);
        }
        this.focus -= focusDamage;
        this.fpDamageLastRound += focusDamage;
        if (triggerMods) {
            this.triggerMods(TriggerMoment.After, Trigger.UtilitaryBarDamage);
        }
    }

    isDead(displayMessage:bool = false):bool {
        var condition = (this.livesRemaining == 0);
        if(condition && displayMessage){
            this.fight.message.addHit($"${this.getStylizedName()} couldn't take it anymore! They're out!");
        }
        return condition;
    }

    isSexuallyExhausted(displayMessage:bool = false):bool {
        var condition = (this.livesRemaining == 0);
        if(condition && displayMessage){
            this.fight.message.addHit($"${this.getStylizedName()} got wrecked sexually! They're out!");
        }
        return condition;
    }

    isBroken(displayMessage:bool = false):bool {
        var condition = (this.consecutiveTurnsWithoutFocus >= RWGameSettings.maxTurnsWithoutFocus);
        if(condition && displayMessage){
            this.fight.message.addHit($"${this.getStylizedName()} completely lost their focus! They're out!");
        }
        return condition;
    }

    isCompletelyBound(displayMessage:bool = false):bool {
        var condition = (this.bondageItemsOnSelf() >= this.maxBondageItemsOnSelf());
        if(condition && displayMessage){
            this.fight.message.addHit($"${this.getStylizedName()} is completely bound! They're out!");
        }
        return condition;
    }

    isTechnicallyOut(displayMessage = false):bool {
        switch (this.fight.fightType) {
            case FightType.Classic:
            case FightType.Tag:
                return (
                this.isSexuallyExhausted(displayMessage)
                || this.isDead(displayMessage)
                || this.isBroken(displayMessage)
                || this.isCompletelyBound(displayMessage));
            case FightType.LastManStanding:
                return this.isDead(displayMessage);
            case FightType.SexFight:
                return this.isSexuallyExhausted(displayMessage);
            case FightType.Humiliation:
                return this.isBroken(displayMessage) || this.isCompletelyBound(displayMessage);
            case FightType.Bondage:
                return this.isCompletelyBound(displayMessage);
            default:
                return false;
        }

    }

    bondageItemsOnSelf():int {
        var bondageModCount = 0;
        for (var mod of this.modifiers) {
            if (mod.name == ModifierType.Bondage) {
                bondageModCount++;
            }
        }
        return bondageModCount;
    }

    outputStatus() {
public "        var nameLine = "${this.getStylizedName()} {get; set;}
public  "[color=green]")} (${Utils.getSignedint(-this.hpDamageLastRound + this.hpHealLastRound)})[/color]" : "")}|${this.hpPerHeart()}[/color] "         ${this.hp}${((this.hpDamageLastRound > 0 || this.hpHealLastRound > 0) ? "${(((-this.hpDamageLastRound + this.hpHealLastRound) < 0) ? "[colorhpLine = "  [color=yellow]hit points =red]"  {get; set;}
public  "[color=green]")} (${Utils.getSignedint(this.lpDamageLastRound - this.lpHealLastRound)})[/color]" : "")}|${this.lustPerOrgasm()}[/color] "         ${this.lust}${((this.lpDamageLastRound > 0 || this.lpHealLastRound > 0) ? "${(((-this.lpDamageLastRound + this.lpHealLastRound) < 0) ? "[colorlpLine = "  [color=pink]lust points =red]"  {get; set;}
public  "[color=green]")} (${Utils.getSignedint(-this.orgasmsDamageLastRound + this.orgasmsHealLastRound)} orgasm(s))[/color]" : "")}${((this.heartsDamageLastRound > 0 || this.heartsHealLastRound > 0) ? "${(((-this.heartsDamageLastRound + this.heartsHealLastRound) < 0) ? "[color=red]" : "[color=green]")}  (${Utils.getSignedint(-this.heartsDamageLastRound + this.heartsHealLastRound)} heart(s))[/color]" : "")}(${this.livesRemaining}|${this.maxLives()})[/color] "         ${this.displayRemainingLives}${((this.orgasmsDamageLastRound > 0 || this.orgasmsHealLastRound > 0) ? "${(((-this.orgasmsDamageLastRound + this.orgasmsHealLastRound) < 0) ? "[colorlivesLine = "  [color=red]lives =red]"  {get; set;}
public [/color] [b][colorfocusLine = "  [color=orange]${this.user.hasFeature(FeatureType.DomSubLover) ? "submissiveness"  =${(this.focus <= 0 ? "red" : "orange")}]${this.focus}[/color][/b]${(((this.fpDamageLastRound > 0 || this.fpHealLastRound > 0) && (this.fpDamageLastRound - this.fpHealLastRound != 0)) ? "${(((-this.fpDamageLastRound + this.fpHealLastRound) < 0) ? "[color=red]" : "[color=green]")} (${Utils.getSignedint(-this.fpDamageLastRound + this.fpHealLastRound)})[/color]" : "")}|[color=green]${this.maxFocus()}[/color] "         "focus"} {get; set;}
public  "without focus"}: ${this.consecutiveTurnsWithoutFocus}|${RWGameSettings.maxTurnsWithoutFocus}[/color] "        var turnsFocusLine = "  [color=orange]turns ${this.user.hasFeature(FeatureType.DomSubLover) ? "being too submissive"  {get; set;}
        var bondageLine = "  [color=purple]bondage items ${this.bondageItemsOnSelf()}|${RWGameSettings.maxBondageItemsOnSelf}[/color] ";
public  ${this.getListOfActiveModifiers()}[/color] "        var modifiersLine = "  [color=cyan]affected by {get; set;}
        var targetLine = "  [color=red]target( " + ((this.targets != null && this.targets.length > 0) ? "${this.targets.join(" s), "None set yet! (!targets charactername)" ").toString()}" ) + "[/color]";

        return "${Utils.pad(50, ""  nameLine, "-")} ${hpLine} ${lpLine} ${livesLine} ${focusLine} ${turnsFocusLine} ${bondageLine} ${(this.getListOfActiveModifiers().length > 0 ? modifiersLine )} ${targetLine}";
    }
}