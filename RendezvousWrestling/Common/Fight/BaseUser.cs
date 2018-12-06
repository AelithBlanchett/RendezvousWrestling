
using System;
using System.Collections.Generic;

public abstract class BaseUser
{
    public string Name { get; set; } = "";
    public bool AreStatsPrivate { get; set; } = true;
    public int Tokens { get; set; } = 50;
    public int TokensSpent { get; set; } = 0;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Deleted { get; set; } = false;

    public List<BaseAchievement> Achievements { get; set; }
    public BaseFighterStats Statistics { get; set; }
    public List<BaseFeature> Features { get; set; }
    //public List<BaseFighterState<Modifier>>    FightStates {get; set;}

    public IFeatureFactory FeatureFactory { get; set; }

    public BaseUser(string name, IFeatureFactory featureFactory)
    {
        Name = name;
        FeatureFactory = featureFactory;
    }

    public string getFeaturesList()
    {
        var strResult = [];
        foreach (var feature in Features)
        {
            var usesLeft = "";
            if (feature.Uses > 0)
            {
                usesLeft = " - ${feature.uses} uses left";
            }
            else
            {
                usesLeft = " - permanent";
            }
            strResult.Add($"${feature.Type}${usesLeft}");
        }
        return strResult.join(", ");
    }

    public string getAchievementsList()
    {
        var strResult = new List<string>();
        foreach (var achievement in this.Achievements)
        {
            strResult.Add($"${achievement.getDetailedDescription()}");
        }
        return string.Join(", ", strResult);
    }

    public void removeFeature(string type)
    {
        var index = this.Features.FindIndex(x => x.type == type);
        if (index != -1)
        {
            this.Features.RemoveAt(index);
        }
        else
        {
            throw new Exception("You don't have this feature, you can't remove it.");
        }
    }

    public int addFeature(string type, int matches)
    {
        var feature = this.FeatureFactory.getFeature(type, this, matches);

        if (feature == null)
        {
            throw new Exception("Feature not found.These are the existing features: ${ this.featureFactory.getExistingFeatures().join(',') }");
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
        this.Features = new List<BaseFeature>();
    }

    public bool hasFeature(string featureType)
    {
        return this.Features.FindIndex(x => x.Type == featureType) != -1;
    }

    public void giveTokens(int amount, TransactionType transactionType, string fromFighter = "")
    {
        this.Tokens += amount;
        this.saveTokenTransaction(this.Name, amount, transactionType, fromFighter);
    }

    public void removeTokens(int amount, TransactionType transactionType, string fromFighter = "")
    {
        this.Tokens -= amount;
        this.TokensSpent += amount;
        if (this.Tokens < 0)
        {
            this.Tokens = 0;
        }
        this.saveTokenTransaction(this.Name, amount, transactionType, fromFighter);
    }

    public bool canPayAmount(int amount)
    {
        return (this.Tokens - amount >= 0);
    }

    public FightTier getFightTier()
    {
        if (this.Statistics == null)
        {
            return FightTier.Bronze;
        }
        if (this.Statistics.wins < (int)FightTierWinRequirements.Silver)
        {
            return FightTier.Bronze;
        }
        else if (this.Statistics.wins < (int)FightTierWinRequirements.Gold)
        {
            return FightTier.Silver;
        }
        else if (this.Statistics.wins >= (int)FightTierWinRequirements.Gold)
        {
            return FightTier.Gold;
        }
        else
        {
            return FightTier.Bronze;
        }
    }

    public abstract string outputStats();
    public abstract void restat(int[] statArray);
    public abstract void saveTokenTransaction(string idFighter, int amount, TransactionType type, string fromFighter = null);

}