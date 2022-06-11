using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using RendezvousWrestling.Common.Achievements;
using RendezvousWrestling.Common.Configuration;
using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Fight;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.Configuration;

namespace RendezvousWrestling.Common.Actions
{
    public abstract class BaseActiveAction<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser> : BaseAction
        where TAchievement : BaseAchievement<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TAchievementManager : AchievementManager<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TActionFactory : BaseActionFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TActionType : BaseActionType<TActionType>, new()
        where TActiveAction : BaseActiveAction<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TDataContext : BaseDataContext<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TEntityMapper : BaseEntityMapper<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeature : BaseFeature<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureFactory : BaseFeatureFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureParameters : BaseFeatureParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureType : BaseFeatureType<TFeatureType>, new()
        where TFight : BaseFight<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFighterState : BaseFighterState<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFighterStats : BaseFighterStats<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFightingGame : BaseFightingGame<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>
        where TModifier : BaseModifier<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TModifierFactory : BaseModifierFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TModifierParameters : BaseModifierParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TModifierType : BaseModifierType<TModifierType>, new()
        where TUser : BaseUser<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public Tier ActionTier { get; set; }

        [NotMapped]
        public TActionType Type { get; set; }

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

        public string TemporaryIdAttacker { get; set; }
        public string[] TemporaryIdDefenders { get; set; }
        public string TemporaryIdFight { get; set; }

        public BaseActiveAction() : base()
        {
        }

        public BaseActiveAction(TActionType actionType,
                    string name,
                    bool isHold,
                    bool requiresRoll,
                    bool keepActorsTurn,
                    bool singleTarget,
                    bool requiresBeingAlive,
                    bool requiresBeingDead,
                    bool requiresBeingInRing,
                    bool requiresBeingOffRing,
                    bool requiresTier,
                    bool requiresCustomTarget,
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
                    TriggerEvent trigger,
                    string explanation = null,
                    int? maxTargets = null)
            : base(name,
                    isHold,
                    requiresRoll,
                    keepActorsTurn,
                    singleTarget,
                    requiresBeingAlive,
                    requiresBeingDead,
                    requiresBeingInRing,
                    requiresBeingOffRing,
                    requiresTier,
                    requiresCustomTarget,
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
            Type = actionType;
        }



        public virtual void Activate(TFight fight,
                                TFighterState attacker,
                                List<TFighterState> defenders,
                                Tier actionTier)
        {
            Fight = fight;
            Attacker = attacker;
            Defenders = defenders;
            ActionTier = actionTier;
            AtTurn = Fight.CurrentTurn;
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
                if (Defenders == null || Defenders.Count == 0)
                {
                    return null;
                }
                if (Defenders.Count == 1)
                {
                    return Defenders[0];
                }
                else
                {
                    throw new Exception(BaseMessages.ErrorTooManyDefendersForThisCall);
                }
            }
        }
        public virtual void Execute()
        {
            CheckRequirements();
            TriggerBeforeEvent();
            AnnounceAction();
            DiceRequiredRoll = RequiredDiceScore;
            if (Fight.DiceLess || !RequiresRoll || Roll() >= DiceRequiredRoll)
            {
                Missed = false;
                DisplayHitMessage();
                OnHit();
                ReleaseHoldsIfNeeded();
            }
            else
            {
                Missed = true;
                DisplayMissMessage();
                OnMiss();
            }
            TriggerAfterEvent();
            ApplyDamage();
        }

        public abstract void ApplyDamage();

        public virtual int Roll()
        {
            DiceRollRawValue = Attacker.Roll(1);
            DiceRollBonusFromStat = AddBonusesToRollFromStats();
            DiceScore = DiceRollRawValue + DiceRollBonusFromStat;
            GenerateRollExplanation();
            return DiceScore;
        }

        public virtual int AddBonusesToRollFromStats()
        {
            return 0;
        }

        public override int RequiredDiceScore
        {
            get
            {
                var scoreRequired = 0;

                scoreRequired += SpecificRequiredDiceScore;

                if (scoreRequired <= GameSettings.DiceCount)
                {
                    scoreRequired = AddRequiredScoreWithExplanation(GameSettings.DiceCount, "MIN");
                }

                return scoreRequired;
            }
        }


        public abstract int SpecificRequiredDiceScore { get; }

        public virtual int AddRequiredScoreWithExplanation(int value, string reason)
        {
            if (value != 0)
            {
                DifficultyExplanation = $"{ DifficultyExplanation} { reason}:{ Utils.Utils.GetSignedNumber(value)}";
            }
            return value;
        }

        public virtual void GenerateRollExplanation()
        {
            Fight.Message.addHint($"Rolled: { DiceScore} [sub] (RLL: {DiceRollRawValue} + STAT:{DiceRollBonusFromStat})[/sub]");
            Fight.Message.addHint($"Required roll: {DiceRequiredRoll}[sub] ({DifficultyExplanation})[/sub]");
            Fight.Message.addHint($"Damage calculation detail: [sub](BSE:{DiceScoreBaseDamage} + STA:{DiceScoreStatDifference} + OVR:{DiceScoreBonusPoints})[/sub]");

        }

        public virtual void ReleaseHoldsIfNeeded()
        {
            foreach (var defender in Defenders)
            {
                if (ActionTier == GameSettings.TierRequiredToBreakHold && Attacker.IsInHoldAppliedBy(defender.Name))
                {
                    Attacker.ReleaseHoldsAppliedBy(defender.Name);
                    Fight.Message.addHit(string.Format(BaseMessages.ForcedHoldRelease, Attacker.GetStylizedName(), defender.GetStylizedName()));
                }
                else if (ActionTier == GameSettings.TierRequiredToBreakHold && defender.IsApplyingHold())
                {
                    defender.ReleaseHoldsApplied();
                    Fight.Message.addHit(string.Format(BaseMessages.ForcedHoldRelease, Attacker.GetStylizedName(), defender.GetStylizedName()));
                }
            }
        }

        public virtual void CheckRequirements()
        {
            if (SingleTarget && !UsableOnSelf && Defenders.Count > 1)
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.tooManyTargets));
            }
            if (RequiresBeingAlive && Attacker.IsTKO)
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.playerOutOfFight));
            }
            if (RequiresBeingDead && !Attacker.IsTKO)
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.playerStillInFight));
            }
            if (RequiresBeingInRing && !Attacker.IsInTheRing)
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.playerOutOfRing));
            }
            if (RequiresBeingOffRing && Attacker.IsInTheRing)
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.playerOnTheRing));
            }
            if (RequiresBeingInHold && !Attacker.IsInHold())
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.mustBeStuckInHold));
            }
            if (RequiresNotBeingInHold && Attacker.IsInHold())
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.mustNotBeStuckInHold));
            }
            if (TargetMustBeAlive && Defenders.Any(x => x.IsTKO == true))
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.targetOutOfFight));
            }
            if (TargetMustBeDead && Defenders.Any(x => x.IsTKO == false))
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.targetNotOutOfFight));
            }
            if (TargetMustBeInRing && Defenders.Any(x => x.IsInTheRing == false))
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.targetOutOfRing));
            }
            if (TargetMustBeOffRing && Defenders.Any(x => x.IsInTheRing == true))
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.targetStillInRing));
            }
            if (TargetMustBeInRange && !Attacker.IsInRange(Defenders as List<TFighterState>))
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.targetMustBeInRange));
            }
            if (TargetMustBeOffRange && Attacker.IsInRange(Defenders as List<TFighterState>))
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.targetMustBeOffRange));
            }
            if (TargetMustBeInHold && Defenders.Where(x => x.IsInHold()).Count() != Defenders.Count)
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.targetMustBeInHold));
            }
            if (TargetMustNotBeInHold && Defenders.Where(x => !x.IsInHold()).Count() != Defenders.Count)
            {
                throw new Exception(string.Format(BaseMessages.cantAttackExplanation, BaseMessages.targetMustNotBeInHold));
            }
            if (!UsableOnSelf && !(UsableOnAllies && UsableOnEnemies))
            {
                if (!UsableOnAllies && Defenders.Any(x => x.AssignedTeam == Attacker.AssignedTeam))
                {
                    throw new Exception(BaseMessages.doActionTargetIsSameTeam);
                }
                if (!UsableOnEnemies && Defenders.Any(x => x.AssignedTeam != Attacker.AssignedTeam))
                {
                    throw new Exception(BaseMessages.doActionTargetIsNotSameTeam);
                }
            }
        }

        public virtual void AnnounceAction()
        {
            if (Defenders.Count > 0)
            {
                Fight.Message.addAction($"{ Name} on { string.Join(",", Defenders.Select(x => x.GetStylizedName()))}");
            }
            else
            {
                Fight.Message.addAction($"{ Name}");
            }
        }
        public abstract void OnHit();

        public abstract void OnMiss();

        public virtual void DisplayHitMessage()
        {
            string message = Explanation != null ? string.Format(Explanation, Attacker.GetStylizedName()) : BaseMessages.HitMessage;
            Fight.Message.addHit(message);
        }

        public virtual void DisplayMissMessage()
        {
            Fight.Message.addHit(BaseMessages.MissMessage);
        }

        public virtual void TriggerBeforeEvent()
        {
            Attacker.TriggerMods(TriggerMoment.Before, Trigger);
            Attacker.TriggerFeatures(TriggerMoment.Before, Trigger, GetFeatureParameter(Fight, Attacker, Defender, (TActiveAction)this));
            if (Defender != null)
            {
                Defender.TriggerFeatures(TriggerMoment.Before, Trigger, GetFeatureParameter(Fight, Defender, Attacker, (TActiveAction)this));
            }
        }

        public virtual TFeatureParameters GetFeatureParameter(TFight fight = null, TFighterState fighter = null, TFighterState target = null, TActiveAction action = null)
        {
            var parameters = new TFeatureParameters();
            parameters.Initialize(fight, fighter, target, action);
            return parameters;
        }

        public virtual void TriggerAfterEvent()
        {
            Attacker.TriggerMods(TriggerMoment.After, Trigger);
            Attacker.TriggerFeatures(TriggerMoment.After, Trigger, GetFeatureParameter(Fight, Attacker, Defender, (TActiveAction)this));
            if (Defender != null)
            {
                Defender.TriggerFeatures(TriggerMoment.After, Trigger, GetFeatureParameter(Fight, Defender, Attacker, (TActiveAction)this));
            }

            if (IsHold)
            {
                Attacker.TriggerMods(TriggerMoment.After, TriggerEvent.GrapplingHold);
                Attacker.TriggerFeatures(TriggerMoment.After, TriggerEvent.GrapplingHold, GetFeatureParameter(Fight, Attacker, Defender, (TActiveAction)this));
                if (Defender != null)
                {
                    Defender.TriggerFeatures(TriggerMoment.After, TriggerEvent.GrapplingHold, GetFeatureParameter(Fight, Defender, Attacker, (TActiveAction)this));
                }
            }
        }
    }
}