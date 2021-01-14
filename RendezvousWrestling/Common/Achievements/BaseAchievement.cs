using System;

public abstract class BaseAchievement
{

    public string AchievementId { get; set; }

    public DateTime CreatedAt { get; set; }

    public BaseUser User { get; set; }

    public abstract string getDetailedDescription();

    public abstract string getName();

    public abstract decimal getReward();

    public abstract string getUniqueShortName();

    public abstract bool meetsRequirements(BaseUser user, BaseFighterState activeFighter, BaseFight fight);

}