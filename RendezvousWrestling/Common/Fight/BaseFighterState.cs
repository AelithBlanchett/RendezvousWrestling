public abstract class BaseFighterState<Modifier> where Modifier : BaseModifier
{

public Team = Team.Unknown    assignedTeam {get; set;}
public string[] = []    targets {get; set;}
public bool = false    isReady {get; set;}
public int = 0    lastDiceRoll {get; set;}
public bool = true    isInTheRing {get; set;}
public bool = true    canMoveFromOrOffRing {get; set;}
public int = 9999999    lastTagTurn {get; set;}
public bool = false    wantsDraw {get; set;}
public int    distanceFromRingCenter {get; set;}
public Date    createdAt {get; set;}
public Date    updatedAt {get; set;}
public bool = false    deleted {get; set;}
public  FightStatus    fightStatus {get; set;}

public BaseFight    fight {get; set;}
public BaseUser    user {get; set;}
public Modifier[]    modifiers {get; set;}

public Dice    dice {get; set;}

    public string name { get { return this.user.name } }

    public BaseFighterState(BaseFight fight,BaseUser  fighter){
        super();
        this.fight = fight;
        this.user = fighter;
        this.assignedTeam = Team.Unknown;
        this.targets = null;
        this.isReady = false;

        this.lastDiceRoll = null;
        this.isInTheRing = true;
        this.canMoveFromOrOffRing = true;
        this.lastTagTurn = 9999999;
        this.distanceFromRingCenter = 0;
        this.wantsDraw = false;
        this.modifiers = [];
        this.targets = [];

        this.dice = new Dice(GameSettings.diceSides);
        this.fightStatus = FightStatus.Idle;
        this.lastDiceRoll = 0;
    }

    assignFight(fight:BaseFight):void{
        this.fight = fight;
    }

    getTargets():BaseFighterState[]{
        BaseFighterState[] fighters = [];
        for(var name of this.targets){
            var fighter = this.fight.getFighterByName(name);
            if(fighter != null){
                fighters.push(fighter);
            }
        }
        return fighters;
    }

    public async void checkAchievements(fight?:BaseFight){
        var strBase = `[color=yellow][b]Achievements unlocked for ${this.name}![/b][/color]\n`;
        var added = await AchievementManager.checkAll(this.user, this, fight);

        if(added.length > 0){
            strBase += added.join("\n");
        }
        else{
            strBase = "";
        }

        return strBase;
    }

    //fight is "mistakenly" set as optional to be compatible with the super.init
    initialize():void {
        this.fightStatus = FightStatus.Initialized;
    }

public string    abstract validateStats() {get; set;}

    get isInDebug():bool{
        if(this.fight != null){
            return this.fight.debug;
        }
        else{
            return false;
        }
    }

    //returns dice score
    roll(int = 1 times,Trigger = Trigger.Roll  event):int {
        this.triggerMods(TriggerMoment.Before, event);
        var result = 0;
        if (times == 1) {
            result = this.dice.roll(GameSettings.diceCount);
        }
        else {
            result = this.dice.roll(GameSettings.diceCount * times);
        }

        if(this.isInDebug && this.fight.forcedDiceRoll > 0){
            result = this.fight.forcedDiceRoll;
        }

        this.triggerMods(TriggerMoment.After, event);
        return result;
    }

    nextRound():void{}

    triggerMods(TriggerMoment moment,Trigger, objFightAction?:any  event):bool {
        bool atLeastOneModWasActivated = false;
        for (var mod of this.modifiers) {
            var message = mod.trigger(moment, event, objFightAction);
            if(message.length > 0){
                this.fight.message.addSpecial(message);
                atLeastOneModWasActivated = true;
            }
        }
        return atLeastOneModWasActivated;
    }

    triggerFeatures<OptionalParameterType>( TriggerMoment moment,Trigger, parameters?:OptionalParameterType  event):bool{
        bool atLeastOneFeatureWasActivated = false;
        for (var feat of this.user.features) {
            var message = feat.trigger(moment, event, parameters);
            if(message.length > 0){
                this.fight.message.addSpecial(message);
                atLeastOneFeatureWasActivated = true;
            }
        }
        return atLeastOneFeatureWasActivated;
    }

    removeMod(string):void { //removes a mod idMod, and also its children. If a children has two parent Ids, then it doesn't remove the mod.
        var index = this.modifiers.findIndex(x => x.idModifier == idMod);
        if (index != -1) {
            this.modifiers[index].remove();
        }
    }

    fightDuration(){
        if(this.fight != null && this.fight.fightLength != null){
            return this.fight.fightLength;
        }
        else{
            return FightLength.Long;
        }
    }

    triggerInsideRing() {
        this.isInTheRing = true;
    }

    triggerOutsideRing() {
        this.isInTheRing = false;
    }

    triggerPermanentInsideRing() {
        this.isInTheRing = false;
        this.canMoveFromOrOffRing = false;
    }

    triggerPermanentOutsideRing() {
        this.triggerOutsideRing();
        this.canMoveFromOrOffRing = false;
    }

public bool):bool    abstract isTechnicallyOut(displayMessage? {get; set;}

    requestDraw() {
        this.wantsDraw = true;
        this.fightStatus = FightStatus.Draw;
    }

    unrequestDraw() {
        this.wantsDraw = false;
        this.fightStatus = FightStatus.Playing;
    }

    isRequestingDraw():bool {
        return this.wantsDraw;
    }

    getStunnedTier():int {
        var stunTier = -1;
        for (var mod of this.modifiers) {
            if (mod.receiver.name == this.name && mod.name == "Stun") {
                stunTier = mod.tier;
            }
        }
        return stunTier;
    }

    isStunned():bool {
        return this.getStunnedTier() >= 0;
    }

    isApplyingHold():bool {
        var isApplyingHold = false;
        for (var mod of this.modifiers) {
            if (mod.receiver.name == this.name && mod.isAHold()) {
                isApplyingHold = true;
            }
        }
        return isApplyingHold;
    }

    isApplyingHoldOfTier():int {
        var tier = -1;
        for (var mod of this.modifiers) {
            if (mod.receiver.name == this.name && mod.isAHold()) {
                tier = mod.tier;
            }
        }
        return tier;
    }

    isInHold():bool {
        var isInHold = false;
        for (var mod of this.modifiers) {
            if (mod.receiver.name == this.name && mod.isAHold()) {
                isInHold = true;
            }
        }
        return isInHold;
    }

    //May have to move
    isInSpecificHold(holdType:string):bool {
        var isInHold = false;
        for (var mod of this.modifiers) {
            if (mod.receiver.name == this.name && mod.isAHold() && mod.name == holdType) {
                isInHold = true;
            }
        }
        return isInHold;
    }

    isInHoldAppliedBy(fighterName:string):bool {
        var isTrue = false;
        for (var mod of this.modifiers) {
            if (mod.receiver.name == fighterName && mod.isAHold()) {
                isTrue = true;
            }
        }
        return isTrue;
    }

    isInHoldOfTier():int {
        var tier = -1;
        for (var mod of this.modifiers) {
            if (mod.receiver.name == this.name && mod.isAHold()) {
                tier = mod.tier;
            }
        }
        return tier;
    }

    releaseHoldsApplied() {
        for (var mod of this.modifiers) {
            if (mod.applier != null && mod.applier.name == this.name && mod.isAHold()) {
                mod.receiver.releaseHoldsAppliedBy(mod.applier.name);
            }
        }
    }

    releaseHoldsAppliedBy(fighterName:string) {
        for (var mod of this.modifiers) {
            if (mod.applier != null && mod.applier.name == fighterName && mod.isAHold()) {
                this.removeMod(mod.idModifier);
            }
        }
    }

    escapeHolds() {
        for (var mod of this.modifiers) {
            if (mod.receiver.name == this.name && mod.isAHold()) {
                this.removeMod(mod.idModifier);
            }
        }
    }

    getListOfActiveModifiers():string{
        var strMods = "";
        for(var mod of this.modifiers){
            strMods += mod.name + ", ";
        }
        strMods = strMods.substring(0, strMods.length - 2);
        return strMods;
    }

    getStylizedName():string {
        var modifierBeginning = "";
        var modifierEnding = "";
        if (this.isTechnicallyOut()) {
            modifierBeginning = `[s]`;
            modifierEnding = `[/s]`;
        }
        else if (!this.isInTheRing) {
            modifierBeginning = `[i]`;
            modifierEnding = `[/i]`;
        }
        return `${modifierBeginning}[b][color=${Team[this.assignedTeam].toLowerCase()}]${this.name}[/color][/b]${modifierEnding}`;
    }

    isInRange(targets:BaseFighterState[]):bool{
        var result = true;
        for(var target of targets){
            if((target.distanceFromRingCenter - this.distanceFromRingCenter) > GameSettings.maximumDistanceToBeConsideredInRange){
                result = false;
            }
        }
        return result;
    }

public string    abstract outputStatus() {get; set;}
}