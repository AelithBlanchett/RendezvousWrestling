using System;
using System.Collections.Generic;
using System.Linq;

public class AchievementManager {

    public static BaseAchievement[] EnabledAchievements { get; set; } = new BaseAchievement[0];

    public static BaseAchievement[] getAll(){
        return EnabledAchievements;
    }

    public static BaseAchievement get(string name){
        return AchievementManager.getAll().FirstOrDefault(x => x.getName() == name);
    }

    public static List<string> checkAll(BaseUser fighter, BaseFighterState activeFighter, BaseFight fight = null){
        var addedInfo = new List<string>();
        var achievements = AchievementManager.getAll();

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

