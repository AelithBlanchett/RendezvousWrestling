using System;
using System.Collections.Generic;
using System.Linq;

public class AchievementManager<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>
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

    public static TAchievement[] EnabledAchievements { get; set; } = new TAchievement[0];

    public static TAchievement[] getAll(){
        return EnabledAchievements;
    }

    public static TAchievement get(string name){
        return getAll().FirstOrDefault(x => x.getName() == name);
    }

    public static List<string> checkAll(TUser fighter, TFighterState activeFighter, TFight fight = null){
        var addedInfo = new List<string>();
        var achievements = getAll();

        foreach(var achievement in achievements){
            if(fighter.Achievements.FindIndex(x => x.getName() == achievement.getName()) == -1 && achievement.meetsRequirements(fighter, activeFighter, fight)){
                achievement.CreatedAt = DateTime.Now;
                fighter.Achievements.Add(achievement);
                int amount = achievement.getReward();
                fighter.giveTokens(amount, TransactionType.AchievementReward, GameSettings.botName);
                addedInfo.Add($"{ achievement.getDetailedDescription()} Reward: { achievement.getReward()} { GameSettings.currencyName}");
            }
        }
        return addedInfo;
    }
}

