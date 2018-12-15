
public class RookieAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(user != null){
            flag = (user.statistics.fightsCount >= 1);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Participate in your first fight!";
    }

    getReward(): int {
        return 3.5;
    }

    getUniqueShortName(): string {
        return "Rookie";
    }

    getName():string{
        return RookieAchievement.name;
    }
}

public class FiveFightsAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(user != null){
            flag = (user.statistics.fightsCount >= 5);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Participate in 5 Fights";
    }

    getReward(): int {
        return 25;
    }

    getUniqueShortName(): string {
        return "The 5th";
    }

    getName():string{
        return FiveFightsAchievement.name;
    }
}

public class TenFightsAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(user != null){
            flag = (user.statistics.fightsCount >= 10);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Participate in 10 Fights";
    }

    getReward(): int {
        return 50;
    }

    getUniqueShortName(): string {
        return "Ten and counting";
    }

    getName():string{
        return TenFightsAchievement.name;
    }
}

public class TwentyFightsAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(user != null){
            flag = (user.statistics.fightsCount >= 20);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Participate in 10 Fights";
    }

    getReward(): int {
        return 75;
    }

    getUniqueShortName(): string {
        return "20/20";
    }

    getName():string{
        return TwentyFightsAchievement.name;
    }
}

public class FortyFightsAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(user != null){
            flag = (user.statistics.fightsCount >= 40);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Participate in 40 Fights";
    }

    getReward(): int {
        return 100;
    }

    getUniqueShortName(): string {
        return "40 and still fighting";
    }

    getName():string{
        return FortyFightsAchievement.name;
    }
}

public class WinookieAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(user != null){
            flag = (user.statistics.wins >= 1);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Win your first fight!";
    }

    getReward(): int {
        return 5;
    }

    getUniqueShortName(): string {
        return "Win-ookie";
    }

    getName():string{
        return WinookieAchievement.name;
    }
}

public class WinFiveFightsAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(user != null){
            flag = (user.statistics.wins >= 5);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Win 5 Fights";
    }

    getReward(): int {
        return 25;
    }

    getUniqueShortName(): string {
        return "Taking Five";
    }

    getName():string{
        return WinFiveFightsAchievement.name;
    }
}

public class WinTenFightsAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(user != null){
            flag = (user.statistics.wins >= 10);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Participate in 10 Fights";
    }

    getReward(): int {
        return 50;
    }

    getUniqueShortName(): string {
        return "Ten-acious";
    }

    getName():string{
        return WinTenFightsAchievement.name;
    }
}

public class WinTwentyFightsAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(user != null){
            flag = (user.statistics.wins >= 20);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Win 20 Fights";
    }

    getReward(): int {
        return 100;
    }

    getUniqueShortName(): string {
        return "Barely Legal";
    }

    getName():string{
        return WinTwentyFightsAchievement.name;
    }
}

public class WinThirtyFightsAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(user != null){
            flag = (user.statistics.wins >= 30);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Win 30 Fights";
    }

    getReward(): int {
        return 150;
    }

    getUniqueShortName(): string {
        return "Thirty for more";
    }

    getName():string{
        return WinThirtyFightsAchievement.name;
    }
}

public class WinFortyFightsAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(user != null){
            flag = (user.statistics.wins >= 40);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Win 40 Fights";
    }

    getReward(): int {
        return 200;
    }

    getUniqueShortName(): string {
        return "40 in the coffin";
    }

    getName():string{
        return WinFortyFightsAchievement.name;
    }
}

public class ReachSilverAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(user != null){
            flag = (user.fightTier() >= FightTier.Silver);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Reached Silver Tier";
    }

    getReward(): int {
        return 50;
    }

    getUniqueShortName(): string {
        return "Silvera";
    }

    getName():string{
        return ReachSilverAchievement.name;
    }
}

public class ReachGoldAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(user != null){
            flag = (user.fightTier() >= FightTier.Gold);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Reached Gold Tier";
    }

    getReward(): int {
        return 100;
    }

    getUniqueShortName(): string {
        return "Gold-lust";
    }

    getName():string{
        return ReachGoldAchievement.name;
    }
}

public class LongFightAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(fight != null){
            flag = (fight.currentTurn >= 20);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Participate in a fight lasting more than 20 turns";
    }

    getReward(): int {
        return 5;
    }

    getUniqueShortName(): string {
        return "Long-ing";
    }

    getName():string{
        return LongFightAchievement.name;
    }
}

public class SeasonOneAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(fight != null){
            flag = (fight.season == 1);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Participate in a fight during the first season";
    }

    getReward(): int {
        return 5;
    }

    getUniqueShortName(): string {
        return "A New Hope";
    }

    getName():string{
        return SeasonOneAchievement.name;
    }
}

public class DoubleKOAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight<BaseFighterState>  BaseActiveFighter?): bool {
        var flag = false;
        if(fight != null){
            flag = (fight.isDraw() == true);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Finish a match with a double-KO";
    }

    getReward(): int {
        return 25;
    }

    getUniqueShortName(): string {
        return "Newton's Third Law";
    }

    getName():string{
        return DoubleKOAchievement.name;
    }
}

public class SomeSeriousLuckAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: BaseFight  activeFighter?): bool {
        var flag = false;
        if(activeFighter != null){
            flag = (activeFighter.lastDiceRoll >= 20 && activeFighter.lastDiceRoll <= 40);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Roll 20 (or more)";
    }

    getReward(): int {
        return 7.5;
    }

    getUniqueShortName(): string {
        return "Some Serious Luck";
    }

    getName():string{
        return SomeSeriousLuckAchievement.name;
    }
}

public class CumFestAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: RWFight  BaseActiveFighter?): bool {
        var flag = false;
        if(fight != null){
            flag = (fight.fighters.filter(x => x.orgasmsDamageLastRound == 1).Count >= 2);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Have two players cum on the same round";
    }

    getReward(): int {
        return 7.5;
    }

    getUniqueShortName(): string {
        return "Cum Festival";
    }

    getName():string{
        return CumFestAchievement.name;
    }
}

public class OneMoveTwoStonesAchievement extends BaseAchievement{
public  DateTime    createdAt {get; set;}

    meetsRequirements( BaseUser user, BaseFighterState, fight?: RWFight  BaseActiveFighter?): bool {
        var flag = false;
        if(fight != null){
            flag = (fight.fighters.filter(x => x.heartsDamageLastRound == 1).Count >= 2);
        }
        return flag;
    }

    getDetailedDescription(): string {
        return "Have two players lose a heart on the same round";
    }

    getReward(): int {
        return 7.5;
    }

    getUniqueShortName(): string {
        return "One Move Two Stones";
    }

    getName():string{
        return OneMoveTwoStonesAchievement.name;
    }
}

//The three dots replace the foreach=>push(achievement)
AchievementManager.EnabledAchievements.Add(...
    [
        new RookieAchievement(),
        new FiveFightsAchievement(),
        new TenFightsAchievement(),
        new TwentyFightsAchievement(),
        new FortyFightsAchievement(),
        new WinookieAchievement(),
        new WinFiveFightsAchievement(),
        new WinTenFightsAchievement(),
        new WinTwentyFightsAchievement(),
        new WinThirtyFightsAchievement(),
        new WinFortyFightsAchievement(),
        new ReachSilverAchievement(),
        new ReachGoldAchievement(),
        new LongFightAchievement(),
        new SeasonOneAchievement(),
        new DoubleKOAchievement(),
        new SomeSeriousLuckAchievement(),
        new CumFestAchievement(),
        new OneMoveTwoStonesAchievement()
    ]
);