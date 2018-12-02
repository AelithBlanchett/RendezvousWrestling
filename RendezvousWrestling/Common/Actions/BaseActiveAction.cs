abstract class BaseActiveAction<Fight, FighterState, Modifier> : BaseAction where Fight : BaseFight<FighterState> where FighterState : BaseFighterState<Modifier> where Modifier : BaseModifier
{

    public Fight Fight { get; set; }

    public FighterState Attacker { get; set; }

    public FighterState[] Defenders { get; set; }

    public int AtTurn { get; set; }
    public int DiceScore { get; set; }
    public int DiceRollRawValue { get; set; }
    public int DiceRollBonusFromStat { get; set; }
    public int DiceScoreBaseDamage { get; set; }
    public int DiceScoreStatDifference { get; set; }
    public int DiceScoreBonusPoints { get; set; }
    public string DifficultyExplanation { get; set; }
    public int DiceRequiredRoll { get; set; }
    public bool Missed { get; set; } = false;

    public Modifier[] AppliedModifiers { get; set; } = [];

    public Trigger Trigger { get; set; }

    public string TemporaryIdAttacker { get; set; }
    public string[] TemporaryIdDefenders { get; set; }
    public string TemporaryIdFight { get; set; }

    public BaseActiveAction(Fight fight,
FighterState attacker,
FighterState[] defenders,
string name,
 int tier,
 bool isHold,
bool requiresRoll,
bool keepActorsTurn,
bool singleTarget,
bool requiresBeingAlive,
bool requiresBeingDead,
bool requiresBeingInRing,
bool requiresBeingOffRing,
bool targetMustBeAlive,
bool targetMustBeDead,
bool targetMustBeInRing,
bool targetMustBeOffRing,
bool targetMustBeInRange,
bool targetMustBeOffRange,
bool requiresBeingInHold,
bool requiresNotBeingInHold,
bool targetMustBeInHold,
bool targetMustNotBeInHold,
bool usableOnSelf,
bool usableOnAllies,
bool usableOnEnemies,
Trigger trigger,
string explanation = null,
                int? maxTargets = null) : base(name,
              tier,
              isHold,
              requiresRoll,
              keepActorsTurn,
              singleTarget,
              requiresBeingAlive,
              requiresBeingDead,
              requiresBeingInRing,
              requiresBeingOffRing,
              targetMustBeAlive,
              targetMustBeDead,
              targetMustBeInRing,
              targetMustBeOffRing,
              targetMustBeInRange,
              targetMustBeOffRange,
              requiresBeingInHold,
              requiresNotBeingInHold,
              targetMustBeInHold,
              targetMustNotBeInHold,
              usableOnSelf,
              usableOnAllies,
              usableOnEnemies,
              trigger,
              explanation,
              maxTargets)
    {
        this.Fight = fight;
        Attacker = attacker;
        Defenders = defenders;
        AtTurn = this.Fight.currentTurn;
        DiceRollRawValue = 0;
        DiceRollBonusFromStat = 0;
        DiceScoreBaseDamage = 0;
        DiceScoreStatDifference = 0;
        DiceScoreBonusPoints = 0;
        DifficultyExplanation = "";
        DiceRequiredRoll = 0;
        Missed = false;
        AppliedModifiers = [];
    }

    public FighterState defender
    {
        get
        {
            if (this.Defenders == null)
            {
                return null;
            }
            if (this.Defenders.Length == 1)
            {
                return this.Defenders[0];
            }
            else
            {
                throw new System.Exception(Messages.errorTooManyDefendersForThisCall);
            }
        }
    }
    execute() :void{
        this.checkRequirements();
        this.triggerBeforeEvent();
        this.announceAction();
        this.diceRequiredRoll = this.requiredDiceScore;
        if(this.fight.diceLess || !this.requiresRoll || this.roll() >= this.diceRequiredRoll){
        this.missed = false;
        this.displayHitMessage();
        this.onHit();
        this.releaseHoldsIfNeeded();
    }
        else{
        this.missed = true;
        this.displayMissMessage();
        this.onMiss();
    }
        this.triggerAfterEvent();
        this.applyDamage();
}

public void abstract applyDamage() { get; set; }

roll() :int{
        this.diceRollRawValue = this.attacker.roll(1);
        this.diceRollBonusFromStat = this.addBonusesToRollFromStats();
        this.diceScore = this.diceRollRawValue + this.diceRollBonusFromStat;
        this.generateRollExplanation();
        return this.diceScore;
    }

addBonusesToRollFromStats() :int{
        return 0;
    }

    get requiredDiceScore():int{
        var scoreRequired = 0;

scoreRequired += this.specificRequiredDiceScore();

        if(scoreRequired <= GameSettings.diceCount){
    scoreRequired = this.addRequiredScoreWithExplanation(GameSettings.diceCount, "MIN");
}

        return scoreRequired;
}

public int abstract specificRequiredDiceScore() { get; set; }

addRequiredScoreWithExplanation(int value, string reason) :int{
        if(value != 0){
public ${Utils.getSignedint(value)}`            this.difficultyExplanation = `${this.difficultyExplanation} ${reason} {get; set;}
        }
        return value;
    }

    generateRollExplanation()
{
public  ${this.diceRollRawValue} + STAT:${this.diceRollBonusFromStat})[/sub]`)        this.fight.message.addHint(`Rolled {getpublic  ${this.diceScore}
[sub] (RLL {get; set;} set;}
public  ${this.diceRequiredRoll}
[sub] (${this.difficultyExplanation})[/sub]`)        this.fight.message.addHint(`Required roll {get; set;}
public ${this.diceScoreBaseDamage} + STA:${this.diceScoreStatDifference} + OVR:${this.diceScoreBonusPoints})[/sub]`)        this.fight.message.addHint(`Damage calculation detail {getpublic[sub](BSE {get; set;}
set;}
    }

    releaseHoldsIfNeeded()
{
    for (var defender of this.defenders)
    {
        if (this.tier == GameSettings.tierRequiredToBreakHold && this.attacker.isInHoldAppliedBy(defender.name))
        {
            this.attacker.releaseHoldsAppliedBy(defender.name);
            this.fight.message.addHit(string.Format(Messages.ForcedHoldRelease, [this.attacker.getStylizedName(), defender.getStylizedName()]));
        }
        else if (this.tier == GameSettings.tierRequiredToBreakHold && defender.isApplyingHold())
        {
            defender.releaseHoldsApplied();
            this.fight.message.addHit(string.Format(Messages.ForcedHoldRelease, [this.attacker.getStylizedName(), defender.getStylizedName()]));
        }
    }
}

checkRequirements() :void{
        if(this.singleTarget && !this.usableOnSelf && this.defenders.length > 1){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.tooManyTargets]));
}
        if(this.requiresBeingAlive && this.attacker.isTechnicallyOut()){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.playerOutOfFight]));
}
        if(this.requiresBeingDead && !this.attacker.isTechnicallyOut()){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.playerStillInFight]));
}
        if(this.requiresBeingInRing && !this.attacker.isInTheRing){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.playerOutOfRing]));
}
        if(this.requiresBeingOffRing && this.attacker.isInTheRing){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.playerOnTheRing]));
}
        if(this.requiresBeingInHold && !this.attacker.isInHold()){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.mustBeStuckInHold]));
}
        if(this.requiresNotBeingInHold && this.attacker.isInHold()){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.mustNotBeStuckInHold]));
}
        if(this.targetMustBeAlive && this.defenders.findIndex(x => x.isTechnicallyOut() == true) != -1){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.targetOutOfFight]));
}
        if(this.targetMustBeDead && this.defenders.findIndex(x => x.isTechnicallyOut() == false) != -1){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.targetNotOutOfFight]));
}
        if(this.targetMustBeInRing && this.defenders.findIndex(x => x.isInTheRing == false) != -1){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.targetOutOfRing]));
}
        if(this.targetMustBeOffRing &&  this.defenders.findIndex(x => x.isInTheRing == true) != -1){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.targetStillInRing]));
}
        if(this.targetMustBeInRange && !this.attacker.isInRange(this.defenders)){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.targetMustBeInRange]));
}
        if(this.targetMustBeOffRange && this.attacker.isInRange(this.defenders)){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.targetMustBeOffRange]));
}
        if(this.targetMustBeInHold && this.defenders.filter(x => x.isInHold()).length != this.defenders.length){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.targetMustBeInHold]));
}
        if(this.targetMustNotBeInHold && this.defenders.filter(x => !x.isInHold()).length != this.defenders.length){
    throw new Error(string.Format(Messages.cantAttackExplanation, [Messages.targetMustNotBeInHold]));
}
        if(!this.usableOnSelf && !(this.usableOnAllies && this.usableOnEnemies)){
    if (!this.usableOnAllies && this.defenders.findIndex(x => x.assignedTeam == this.attacker.assignedTeam) != -1)
    {
        throw new Error(Messages.doActionTargetIsSameTeam);
    }
    if (!this.usableOnEnemies && this.defenders.findIndex(x => x.assignedTeam != this.attacker.assignedTeam) != -1)
    {
        throw new Error(Messages.doActionTargetIsNotSameTeam);
    }
}
}

announceAction() :void{
        if(this.defenders.length){
    this.fight.message.addAction(`${ this.name}
    on ${ this.defenders.map(x => x.getStylizedName()).join(",")}`);
}
        else{
    this.fight.message.addAction(`${ this.name}`);
}
}
public void abstract onHit() { get; set; }

public void abstract onMiss() { get; set; }

displayHitMessage()
{
    string message = (this.explanation != null ? string.Format(this.explanation, Messages.HitMessage[this.attacker.getStylizedName()]) );
    this.fight.message.addHit(message);
}

displayMissMessage()
{
    this.fight.message.addHit(Messages.MissMessage);
}

triggerBeforeEvent() :void{
        this.attacker.triggerMods(TriggerMoment.Before, this.trigger);
        this.attacker.triggerFeatures(TriggerMoment.Before, this.trigger, new BaseFeatureParameter(this.fight, this.attacker, this.defender, this));
        if(this.defender){
    this.defender.triggerFeatures(TriggerMoment.Before, this.trigger, new BaseFeatureParameter(this.fight, this.defender, this.attacker, this));
}
}

triggerAfterEvent() :void{
        this.attacker.triggerMods(TriggerMoment.After, this.trigger);
        this.attacker.triggerFeatures(TriggerMoment.After, this.trigger, new BaseFeatureParameter(this.fight, this.attacker, this.defender, this));
        if(this.defender){
    this.defender.triggerFeatures(TriggerMoment.After, this.trigger, new BaseFeatureParameter(this.fight, this.defender, this.attacker, this));
}

        if(this.isHold){
    this.attacker.triggerMods(TriggerMoment.After, Trigger.GrapplingHold);
    this.attacker.triggerFeatures(TriggerMoment.After, Trigger.GrapplingHold, new BaseFeatureParameter(this.fight, this.attacker, this.defender, this));
    if (this.defender)
    {
        this.defender.triggerFeatures(TriggerMoment.After, Trigger.GrapplingHold, new BaseFeatureParameter(this.fight, this.defender, this.attacker, this));
    }
}
}
}