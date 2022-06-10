
using RendezvousWrestling.Common.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.Common.Achievements;
using RendezvousWrestling.Common.Actions;
using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.Common.Fight
{
    public abstract class BaseUser<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser> : BaseEntity
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
        [Required]
        public bool AreStatsPrivate { get; set; } = true;
        [Required]
        public int Tokens { get; set; } = 50;
        public int TokensSpent { get; set; } = 0;

        public virtual List<TAchievement> Achievements { get; set; }
        public TFighterStats Stats { get; set; }
        public virtual List<TFeature> Features { get; set; }
        public virtual List<TFighterState> FighterStates { get; set; }

        [NotMapped]
        public TFeatureFactory FeatureFactory { get; set; }

        public BaseUser()
        {
        }

        public BaseUser(string name)
        {
            Initialize(name);
        }

        public void Initialize(string name)
        {
            Id = name;

            if (Stats == null)
            {
                Stats = new TFighterStats
                {
                    UserId = Id
                };
            }
        }

        public string FeaturesAsString
        {
            get
            {
                var strResult = new List<string>();
                foreach (var feature in Features)
                {
                    string usesLeft;
                    if (feature.Uses > 0)
                    {
                        usesLeft = $" - {feature.Uses} uses left";
                    }
                    else
                    {
                        usesLeft = " - permanent";
                    }
                    strResult.Add($"{feature.Type}{usesLeft}");
                }
                return string.Join(", ", strResult);
            }
        }

        public string AchievementsList
        {
            get
            {
                var strResult = new List<string>();
                foreach (var achievement in Achievements)
                {
                    strResult.Add($"{achievement.DetailedDescription}");
                }
                return string.Join(", ", strResult);
            }
        }

        public void RemoveFeature(TFeatureType type)
        {
            var index = Features.FindIndex(x => x.Type == type);
            if (index != -1)
            {
                Features.RemoveAt(index);
            }
            else
            {
                throw new Exception("You don't have this feature, you can't remove it.");
            }
        }

        public int AddFeature(TFeatureType type, int matches)
        {
            var feature = FeatureFactory.Build(type, (TUser)this);

            if (feature == null)
            {
                throw new Exception($"Feature not found. These are the existing features: {string.Join(", ", new TFeatureType().ListAsString())}");
            }

            if (feature.Cost > 0 && matches == 0)
            {
                throw new Exception("A paid feature requires a specific number of matches.");
            }

            feature.Uses = matches;

            var amountToRemove = feature.Cost * matches;

            if (Tokens - amountToRemove >= 0)
            {
                var index = Features.FindIndex(x => x.Type == type);
                if (index == -1)
                {
                    Features.Add(feature);
                    return amountToRemove;
                }
                else
                {
                    throw new Exception(BaseMessages.cantAddFeatureAlreadyHaveIt);
                }
            }
            else
            {
                throw new Exception($"Not enough tokens.Required: {amountToRemove}.");
            }
        }

        public void ClearFeatures()
        {
            Features = new List<TFeature>();
        }

        public bool HasFeature(TFeatureType featureType)
        {
            return Features.FindIndex(x => x.Type == featureType) != -1;
        }

        public void GiveTokens(int amount, TransactionType transactionType, string fromFighter = "")
        {
            Tokens += amount;
        }

        public void RemoveTokens(int amount, TransactionType transactionType, string fromFighter = "")
        {
            Tokens -= amount;
            TokensSpent += amount;
            if (Tokens < 0)
            {
                Tokens = 0;
            }
        }

        public bool CanPayAmount(int amount)
        {
            return Tokens - amount >= 0;
        }

        public FightTier FightTier
        {
            get
            {
                if (Stats == null)
                {
                    return FightTier.Bronze;
                }
                if (Stats.Wins < (int)FightTierWinRequirements.Silver)
                {
                    return FightTier.Bronze;
                }
                else if (Stats.Wins < (int)FightTierWinRequirements.Gold)
                {
                    return FightTier.Silver;
                }
                else if (Stats.Wins >= (int)FightTierWinRequirements.Gold)
                {
                    return FightTier.Gold;
                }
                else
                {
                    return FightTier.Bronze;
                }
            }
        }

        public abstract string OutputStats();
        public abstract void Restat(List<int> statArray);

    }
}