using System;
using System.Collections.Generic;
using System.Linq;

public abstract class BaseActiveAction<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType> : BaseAction
    where TActionFactory : IActionFactory<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TFeature : BaseFeature<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TFeatureFactory : IFeatureFactory<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TUser : BaseUser<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TFight : BaseFight<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TFighterState : BaseFighterState<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TActiveAction : BaseActiveAction<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where OptionalParameterType : BaseFeatureParameter<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TAchievement : BaseAchievement<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TModifier : BaseModifier<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
{

    public TFight Fight { get; set; }

    public TFighterState Attacker { get; set; }

    public List<TFighterState> Defenders { get; set; }

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

    public List<TModifier> AppliedModifiers { get; set; } = new List<TModifier>();

    public Trigger Trigger { get; set; }

    public string TemporaryIdAttacker { get; set; }
    public string[] TemporaryIdDefenders { get; set; }
    public string TemporaryIdFight { get; set; }

    public BaseActiveAction() : base()
    {
    }

    public BaseActiveAction(TFight fight,
                            TFighterState attacker,
                            List<TFighterState> defenders,
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
        Fight = fight;
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
        AppliedModifiers = new List<TModifier>();
    }

    public TFighterState Defender
    {
        get
        {
            if (this.Defenders == null)
            {
                return null;
            }
            if (this.Defenders.Count() == 1)
            {
                return this.Defenders[0];
            }
            else
            {
                throw new System.Exception(Messages.errorTooManyDefendersForThisCall);
            }
        }
    }
    public void execute()
    {
        this.checkRequirements();
        this.triggerBeforeEvent();
        this.announceAction();
        this.DiceRequiredRoll = this.requiredDiceScore;
        if (this.Fight.diceLess || !this.RequiresRoll || this.roll() >= this.DiceRequiredRoll)
        {
            this.Missed = false;
            this.displayHitMessage();
            this.onHit();
            this.releaseHoldsIfNeeded();
        }
        else
        {
            this.Missed = true;
            this.displayMissMessage();
            this.onMiss();
        }
        this.triggerAfterEvent();
        this.applyDamage();
    }

    public abstract void applyDamage();

    public int roll()
    {
        this.DiceRollRawValue = this.Attacker.roll(1);
        this.DiceRollBonusFromStat = this.addBonusesToRollFromStats();
        this.DiceScore = this.DiceRollRawValue + this.DiceRollBonusFromStat;
        this.GenerateRollExplanation();
        return this.DiceScore;
    }

    public int addBonusesToRollFromStats()
    {
        return 0;
    }

    public override int requiredDiceScore
    {
        get
        {
            var scoreRequired = 0;

            scoreRequired += SpecificRequiredDiceScore;

            if (scoreRequired <= GameSettings.diceCount)
            {
                scoreRequired = this.addRequiredScoreWithExplanation(GameSettings.diceCount, "MIN");
            }

            return scoreRequired;
        }
    }


    public abstract int SpecificRequiredDiceScore { get; }

    public int addRequiredScoreWithExplanation(int value, string reason)
    {
        if (value != 0)
        {
            this.DifficultyExplanation = $"{ this.DifficultyExplanation} { reason}:{ Utils.getSignedNumber(value)}";
        }
        return value;
    }

    public void GenerateRollExplanation()
    {
        this.Fight.message.addHint($"Rolled: { this.DiceScore} [sub] (RLL: {this.DiceRollRawValue} + STAT:{this.DiceRollBonusFromStat})[/sub]");
        this.Fight.message.addHint($"Required roll: {this.DiceRequiredRoll}[sub] ({this.DifficultyExplanation})[/sub]");
        this.Fight.message.addHint("Damage calculation detail: [sub](BSE:${this.diceScoreBaseDamage} + STA:${this.diceScoreStatDifference} + OVR:${this.diceScoreBonusPoints})[/sub]");

    }

    public void releaseHoldsIfNeeded()
    {
        foreach (var defender in this.Defenders)
        {
            if (this.Tier == GameSettings.tierRequiredToBreakHold && this.Attacker.isInHoldAppliedBy(defender.name))
            {
                this.Attacker.releaseHoldsAppliedBy(defender.name);
                this.Fight.message.addHit(string.Format(Messages.ForcedHoldRelease, this.Attacker.getStylizedName(), defender.getStylizedName()));
            }
            else if (this.Tier == GameSettings.tierRequiredToBreakHold && defender.isApplyingHold())
            {
                defender.releaseHoldsApplied();
                this.Fight.message.addHit(string.Format(Messages.ForcedHoldRelease, this.Attacker.getStylizedName(), defender.getStylizedName()));
            }
        }
    }

    public void checkRequirements()
    {
        if (this.SingleTarget && !this.UsableOnSelf && this.Defenders.Count() > 1)
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.tooManyTargets));
        }
        if (this.RequiresBeingAlive && this.Attacker.isTechnicallyOut())
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.playerOutOfFight));
        }
        if (this.RequiresBeingDead && !this.Attacker.isTechnicallyOut())
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.playerStillInFight));
        }
        if (this.RequiresBeingInRing && !this.Attacker.isInTheRing)
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.playerOutOfRing));
        }
        if (this.RequiresBeingOffRing && this.Attacker.isInTheRing)
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.playerOnTheRing));
        }
        if (this.RequiresBeingInHold && !this.Attacker.isInHold())
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.mustBeStuckInHold));
        }
        if (this.RequiresNotBeingInHold && this.Attacker.isInHold())
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.mustNotBeStuckInHold));
        }
        if (this.TargetMustBeAlive && this.Defenders.Any(x => x.isTechnicallyOut() == true))
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.targetOutOfFight));
        }
        if (this.TargetMustBeDead && this.Defenders.Any(x => x.isTechnicallyOut() == false))
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.targetNotOutOfFight));
        }
        if (this.TargetMustBeInRing && this.Defenders.Any(x => x.isInTheRing == false))
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.targetOutOfRing));
        }
        if (this.TargetMustBeOffRing && this.Defenders.Any(x => x.isInTheRing == true))
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.targetStillInRing));
        }
        if (this.TargetMustBeInRange && !this.Attacker.isInRange(this.Defenders as List<TFighterState>))
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.targetMustBeInRange));
        }
        if (this.TargetMustBeOffRange && this.Attacker.isInRange(this.Defenders as List<TFighterState>))
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.targetMustBeOffRange));
        }
        if (this.TargetMustBeInHold && this.Defenders.Where(x => x.isInHold()).Count() != this.Defenders.Count())
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.targetMustBeInHold));
        }
        if (this.TargetMustNotBeInHold && this.Defenders.Where(x => !x.isInHold()).Count() != this.Defenders.Count())
        {
            throw new System.Exception(string.Format(Messages.cantAttackExplanation, Messages.targetMustNotBeInHold));
        }
        if (!this.UsableOnSelf && !(this.UsableOnAllies && this.UsableOnEnemies))
        {
            if (!this.UsableOnAllies && this.Defenders.Any(x => x.assignedTeam == this.Attacker.assignedTeam))
            {
                throw new System.Exception(Messages.doActionTargetIsSameTeam);
            }
            if (!this.UsableOnEnemies && this.Defenders.Any(x => x.assignedTeam != this.Attacker.assignedTeam))
            {
                throw new System.Exception(Messages.doActionTargetIsNotSameTeam);
            }
        }
    }

    public void announceAction()
    {
        if (this.Defenders.Count > 0)
        {
            this.Fight.message.addAction($"{ this.Name} on { string.Join(",", this.Defenders.Select(x => x.getStylizedName()))}");
        }
        else
        {
            this.Fight.message.addAction($"{ this.Name}");
        }
    }
    public abstract void onHit();

    public abstract void onMiss();

    public void displayHitMessage()
    {
        string message = (this.Explanation != null ? string.Format(this.Explanation, this.Attacker.getStylizedName()) : Messages.HitMessage);
        this.Fight.message.addHit(message);
    }

    public void displayMissMessage()
    {
        this.Fight.message.addHit(Messages.MissMessage);
    }

    public void triggerBeforeEvent()
    {
        this.Attacker.triggerMods(TriggerMoment.Before, this.Trigger);
        this.Attacker.triggerFeatures(TriggerMoment.Before, this.Trigger, GetFeatureParameter(this.Fight, this.Attacker, this.Defender, (TActiveAction)this));
        if (this.Defender != null)
        {
            this.Defender.triggerFeatures(TriggerMoment.Before, this.Trigger, GetFeatureParameter(this.Fight, this.Defender, this.Attacker, (TActiveAction)this));
        }
    }

    public OptionalParameterType GetFeatureParameter(TFight fight = null, TFighterState fighter = null, TFighterState target = null, TActiveAction action = null)
    {
        return (OptionalParameterType)new BaseFeatureParameter<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>(fight, fighter, target, action);
    }

    public void triggerAfterEvent()
    {
        this.Attacker.triggerMods(TriggerMoment.After, this.Trigger);
        this.Attacker.triggerFeatures(TriggerMoment.After, this.Trigger, GetFeatureParameter(this.Fight, this.Attacker, this.Defender, (TActiveAction)this));
        if (this.Defender != null)
        {
            this.Defender.triggerFeatures(TriggerMoment.After, this.Trigger, GetFeatureParameter(this.Fight, this.Defender, this.Attacker, (TActiveAction)this));
        }

        if (this.IsHold)
        {
            this.Attacker.triggerMods(TriggerMoment.After, Trigger.GrapplingHold);
            this.Attacker.triggerFeatures(TriggerMoment.After, Trigger.GrapplingHold, GetFeatureParameter(this.Fight, this.Attacker, this.Defender, (TActiveAction)this));
            if (this.Defender != null)
            {
                this.Defender.triggerFeatures(TriggerMoment.After, Trigger.GrapplingHold, GetFeatureParameter(this.Fight, this.Defender, this.Attacker, (TActiveAction)this));
            }
        }
    }

    public void save()
    {
        throw new NotImplementedException();
    }
}