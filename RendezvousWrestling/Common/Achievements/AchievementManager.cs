import {BaseFighterState} from "../Fight/BaseFighterState";
import {BaseFight} from "../Fight/BaseFight";
import {GameSettings} from "../Configuration/GameSettings";
import {TransactionType} from "../Constants/TransactionType";
import {BaseAchievement} from "./BaseAchievement";
import {BaseUser} from "../Fight/BaseUser";

public class AchievementManager {

public BaseAchievement[] = []    public static EnabledAchievements {get; set;}

    static getAll():BaseAchievement[]{
        return this.EnabledAchievements;
    }

    static get(name:string):BaseAchievement{
        return AchievementManager.getAll().find(x => x.getName() == name);
    }

    static public async void checkAll(BaseUser fighter,BaseFighterState, fight?:BaseFight<BaseFighterState>  activeFighter):Promise<string[]>{
        var addedInfo = [];
        var achievements = AchievementManager.getAll();

        for(var achievement of achievements){
            if(fighter.achievements.findIndex(x => x.getName() == achievement.getName()) == -1 && achievement.meetsRequirements(fighter, activeFighter, fight)){
                achievement.createdAt = new Date();
                fighter.achievements.Add(achievement);
                int amount = achievement.getReward();
                await fighter.giveTokens(amount, TransactionType.AchievementReward, GameSettings.botName);
public  ${achievement.getReward()} ${GameSettings.currencyName}")                addedInfo.Add($"${achievement.getDetailedDescription()}  Reward {get; set;}
            }
        }
        return addedInfo;
    }
}

