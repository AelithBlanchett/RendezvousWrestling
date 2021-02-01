using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using RendezvousWrestling.Common.Achievements;
using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Fight;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;

namespace RendezvousWrestling.Common.Actions
{
    public abstract class BaseActiveAction<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser> : BaseAction
        where TAchievement : BaseAchievement<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TAchievementManager : AchievementManager<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TActionFactory : BaseActionFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TActionType : BaseActionType, new()
        where TActiveAction : BaseActiveAction<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TDataContext : BaseDataContext<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TEntityMapper : BaseEntityMapper<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TFeature : BaseFeature<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureFactory : BaseFeatureFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureParameters : BaseFeatureParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureType : BaseFeatureType, new()
        where TFight : BaseFight<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TFighterState : BaseFighterState<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TFighterStats : BaseFighterStats<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TFightingGame : BaseFightingGame<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TModifier : BaseModifier<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TModifierParameters : BaseModifierParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TModifierType : BaseModifierType, new()
        where TUser : BaseUser<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public int Tier { get; set; }

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



        public void Activate(TFight fight,
                                TFighterState attacker,
                                List<TFighterState> defenders,
                                int tier)
        {
            Fight = fight;
            Attacker = attacker;
            Defenders = defenders;
            Tier = tier;
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
                if (Defenders == null)
                {
                    return null;
                }
                if (Defenders.Count == 1)
                {
                    return Defenders[0];
                }
                else
                {
                    throw new Exception(Messages.ErrorTooManyDefendersForThisCall);
                }
            }
        }
        public void Execute()
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

        public int Roll()
        {
            DiceRollRawValue = Attacker.Roll(1);
            DiceRollBonusFromStat = AddBonusesToRollFromStats();
            DiceScore = DiceRollRawValue + DiceRollBonusFromStat;
            GenerateRollExplanation();
            return DiceScore;
        }

        public int AddBonusesToRollFromStats()
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

        public int AddRequiredScoreWithExplanation(int value, string reason)
        {
            if (value != 0)
            {
                DifficultyExplanation = $"{ DifficultyExplanation} { reason}:{ Utils.Utils.GetSignedNumber(value)}";
            }
            return value;
        }

        public void GenerateRollExplanation()
        {
            Fight.Message.addHint($"Rolled: { DiceScore} [sub] (RLL: {DiceRollRawValue} + STAT:{DiceRollBonusFromStat})[/sub]");
            Fight.Message.addHint($"Required roll: {DiceRequiredRoll}[sub] ({DifficultyExplanation})[/sub]");
            Fight.Message.addHint($"Damage calculation detail: [sub](BSE:{DiceScoreBaseDamage} + STA:{DiceScoreStatDifference} + OVR:{DiceScoreBonusPoints})[/sub]");

        }

        public void ReleaseHoldsIfNeeded()
        {
            foreach (var defender in Defenders)
            {
                if (Tier == GameSettings.TierRequiredToBreakHold && Attacker.IsInHoldAppliedBy(defender.Name))
                {
                    Attacker.ReleaseHoldsAppliedBy(defender.Name);
                    Fight.Message.addHit(string.Format(Messages.ForcedHoldRelease, Attacker.GetStylizedName(), defender.GetStylizedName()));
                }
                else if (Tier == GameSettings.TierRequiredToBreakHold && defender.IsApplyingHold())
                {
                    defender.ReleaseHoldsApplied();
                    Fight.Message.addHit(string.Format(Messages.ForcedHoldRelease, Attacker.GetStylizedName(), defender.GetStylizedName()));
                }
            }
        }

        public void CheckRequirements()
        {
            if (SingleTarget && !UsableOnSelf && Defenders.Count > 1)
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.tooManyTargets));
            }
            if (RequiresBeingAlive && Attacker.IsTKO)
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.playerOutOfFight));
            }
            if (RequiresBeingDead && !Attacker.IsTKO)
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.playerStillInFight));
            }
            if (RequiresBeingInRing && !Attacker.IsInTheRing)
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.playerOutOfRing));
            }
            if (RequiresBeingOffRing && Attacker.IsInTheRing)
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.playerOnTheRing));
            }
            if (RequiresBeingInHold && !Attacker.IsInHold())
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.mustBeStuckInHold));
            }
            if (RequiresNotBeingInHold && Attacker.IsInHold())
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.mustNotBeStuckInHold));
            }
            if (TargetMustBeAlive && Defenders.Any(x => x.IsTKO == true))
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.targetOutOfFight));
            }
            if (TargetMustBeDead && Defenders.Any(x => x.IsTKO == false))
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.targetNotOutOfFight));
            }
            if (TargetMustBeInRing && Defenders.Any(x => x.IsInTheRing == false))
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.targetOutOfRing));
            }
            if (TargetMustBeOffRing && Defenders.Any(x => x.IsInTheRing == true))
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.targetStillInRing));
            }
            if (TargetMustBeInRange && !Attacker.IsInRange(Defenders as List<TFighterState>))
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.targetMustBeInRange));
            }
            if (TargetMustBeOffRange && Attacker.IsInRange(Defenders as List<TFighterState>))
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.targetMustBeOffRange));
            }
            if (TargetMustBeInHold && Defenders.Where(x => x.IsInHold()).Count() != Defenders.Count)
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.targetMustBeInHold));
            }
            if (TargetMustNotBeInHold && Defenders.Where(x => !x.IsInHold()).Count() != Defenders.Count)
            {
                throw new Exception(string.Format(Messages.cantAttackExplanation, Messages.targetMustNotBeInHold));
            }
            if (!UsableOnSelf && !(UsableOnAllies && UsableOnEnemies))
            {
                if (!UsableOnAllies && Defenders.Any(x => x.AssignedTeam == Attacker.AssignedTeam))
                {
                    throw new Exception(Messages.doActionTargetIsSameTeam);
                }
                if (!UsableOnEnemies && Defenders.Any(x => x.AssignedTeam != Attacker.AssignedTeam))
                {
                    throw new Exception(Messages.doActionTargetIsNotSameTeam);
                }
            }
        }

        public void AnnounceAction()
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

        public void DisplayHitMessage()
        {
            string message = Explanation != null ? string.Format(Explanation, Attacker.GetStylizedName()) : Messages.HitMessage;
            Fight.Message.addHit(message);
        }

        public void DisplayMissMessage()
        {
            Fight.Message.addHit(Messages.MissMessage);
        }

        public void TriggerBeforeEvent()
        {
            Attacker.TriggerMods(TriggerMoment.Before, Trigger);
            Attacker.TriggerFeatures(TriggerMoment.Before, Trigger, GetFeatureParameter(Fight, Attacker, Defender, (TActiveAction)this));
            if (Defender != null)
            {
                Defender.TriggerFeatures(TriggerMoment.Before, Trigger, GetFeatureParameter(Fight, Defender, Attacker, (TActiveAction)this));
            }
        }

        public TFeatureParameters GetFeatureParameter(TFight fight = null, TFighterState fighter = null, TFighterState target = null, TActiveAction action = null)
        {
            var parameters = new TFeatureParameters();
            parameters.Initialize(fight, fighter, target, action);
            return parameters;
        }

        public void TriggerAfterEvent()
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

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}