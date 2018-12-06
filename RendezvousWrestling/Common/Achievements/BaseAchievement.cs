using System;

public abstract class BaseAchievement
{

    public string AchievementId { get; set; }

    public DateTime CreatedAt { get; set; }

    public BaseUser User { get; set; }

    public abstract string getDetailedDescription();

    public abstract string getName();

    public abstract int getReward();

    public abstract string getUniqueShortName();

    public abstract bool meetsRequirements(BaseUser user, BaseFighterState<BaseModifier> activeFighter, BaseFight<BaseFighterState<BaseModifier>, BaseModifier> fight);

}