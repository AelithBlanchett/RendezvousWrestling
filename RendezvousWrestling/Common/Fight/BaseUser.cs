
using RendezvousWrestling.Common.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;

public abstract class BaseUser<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>
    where TAchievement : BaseAchievement<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TAchievementManager : AchievementManager<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TActionFactory : BaseActionFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TActionType : BaseActionType, new()
    where TActiveAction : BaseActiveAction<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TEntityMapper : BaseEntityMapper<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFeature : BaseFeature<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFeatureFactory : BaseFeatureFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFeatureParameters : BaseFeatureParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFeatureType : BaseFeatureType, new()
    where TFight : BaseFight<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFighterState : BaseFighterState<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFighterStats : BaseFighterStats<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFightingGame : BaseFightingGame<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TModifier : BaseModifier<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TModifierParameters : BaseModifierParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TModifierType : BaseModifierType, new()
    where TUser : BaseUser<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
{
    [Key]
    public string Id { get; set; } = "";
    public bool AreStatsPrivate { get; set; } = true;
    public int Tokens { get; set; } = 50;
    public int TokensSpent { get; set; } = 0;

    public virtual List<TAchievement> Achievements { get; set; }
    public TFighterStats Stats { get; set; }
    public virtual List<TFeature> Features { get; set; }
    public virtual List<TFighterState> FighterStates {get; set;}

    [NotMapped]
    public TFeatureFactory FeatureFactory { get; set; }
    
    public BaseUser()
    {
    }

    public BaseUser(string name)
    {
        Id = name;
    }

    public string getFeaturesList()
    {
        var strResult = new List<string>();
        foreach (var feature in Features)
        {
            var usesLeft = "";
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

    public string getAchievementsList()
    {
        var strResult = new List<string>();
        foreach (var achievement in this.Achievements)
        {
            strResult.Add($"{achievement.getDetailedDescription()}");
        }
        return string.Join(", ", strResult);
    }

    public void removeFeature(TFeatureType type)
    {
        var index = this.Features.FindIndex(x => x.Type == type);
        if (index != -1)
        {
            this.Features.RemoveAt(index);
        }
        else
        {
            throw new Exception("You don't have this feature, you can't remove it.");
        }
    }

    public int addFeature(TFeatureType type, int matches)
    {
        var feature = this.FeatureFactory.getFeature(type, (TUser)this, matches);

        if (feature == null)
        {
            throw new Exception($"Feature not found. These are the existing features: {string.Join(", ", new TFeatureType().ListAsString())}");
        }

        if (feature.getCost() > 0 && matches == 0)
        {
            throw new Exception("A paid feature requires a specific number of matches.");
        }

        var amountToRemove = feature.getCost() * matches;

        if (this.Tokens - amountToRemove >= 0)
        {
            var index = this.Features.FindIndex(x => x.Type == type);
            if (index == -1)
            {
                this.Features.Add(feature);
                return amountToRemove;
            }
            else
            {
                throw new Exception(Messages.cantAddFeatureAlreadyHaveIt);
            }
        }
        else
        {
            throw new Exception($"Not enough tokens.Required: {amountToRemove}.");
        }
    }

    public void clearFeatures()
    {
        this.Features = new List<TFeature>();
    }

    public bool hasFeature(TFeatureType featureType)
    {
        return this.Features.FindIndex(x => x.Type == featureType) != -1;
    }

    public void giveTokens(int amount, TransactionType transactionType, string fromFighter = "")
    {
        this.Tokens += amount;
        this.saveTokenTransaction(this.Id, amount, transactionType, fromFighter);
    }

    public void removeTokens(int amount, TransactionType transactionType, string fromFighter = "")
    {
        this.Tokens -= amount;
        this.TokensSpent += amount;
        if (this.Tokens < 0)
        {
            this.Tokens = 0;
        }
        this.saveTokenTransaction(this.Id, amount, transactionType, fromFighter);
    }

    public bool canPayAmount(int amount)
    {
        return (this.Tokens - amount >= 0);
    }

    public FightTier getFightTier()
    {
        if (this.Stats == null)
        {
            return FightTier.Bronze;
        }
        if (this.Stats.wins < (int)FightTierWinRequirements.Silver)
        {
            return FightTier.Bronze;
        }
        else if (this.Stats.wins < (int)FightTierWinRequirements.Gold)
        {
            return FightTier.Silver;
        }
        else if (this.Stats.wins >= (int)FightTierWinRequirements.Gold)
        {
            return FightTier.Gold;
        }
        else
        {
            return FightTier.Bronze;
        }
    }

    public abstract string outputStats();
    public abstract void restat(List<int> statArray);
    public abstract void saveTokenTransaction(string idFighter, int amount, TransactionType type, string fromFighter = null);

}