using System;

public abstract class BaseAction
{

    public string IdAction { get; set; }
    public string Name { get; set; }
    public int Tier { get; set; }
    public bool IsHold { get; set; }
    public bool RequiresRoll { get; set; }
    public bool KeepActorsTurn { get; set; }
    public string Explanation { get; set; }

    public bool SingleTarget { get; set; }
    public int? MaxTargets { get; set; }

    public bool RequiresBeingAlive { get; set; }
    public bool RequiresBeingDead { get; set; }
    public bool RequiresBeingInRing { get; set; }
    public bool RequiresBeingOffRing { get; set; }

    public bool TargetMustBeAlive { get; set; }
    public bool TargetMustBeDead { get; set; }
    public bool TargetMustBeInRing { get; set; }
    public bool TargetMustBeOffRing { get; set; }

    public bool TargetMustBeInRange { get; set; }
    public bool TargetMustBeOffRange { get; set; }

    public bool RequiresBeingInHold { get; set; }
    public bool RequiresNotBeingInHold { get; set; }
    public bool TargetMustBeInHold { get; set; }
    public bool TargetMustNotBeInHold { get; set; }

    public bool UsableOnSelf { get; set; }
    public bool UsableOnAllies { get; set; }
    public bool UsableOnEnemies { get; set; }

    public Trigger Trigger { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public BaseAction()
    {

    }

    public BaseAction(string name,
                int tier,
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
                Trigger trigger,
                string explanation = null,
                int? maxTargets = null)
    {
        IdAction = Guid.NewGuid().ToString();
        Name = name;
        Tier = tier;
        IsHold = isHold;
        RequiresRoll = requiresRoll;
        KeepActorsTurn = keepActorsTurn;
        SingleTarget = singleTarget;
        RequiresBeingAlive = requiresBeingAlive;
        RequiresBeingDead = requiresBeingDead;
        TargetMustBeAlive = targetMustBeAlive;
        TargetMustBeDead = targetMustBeDead;
        RequiresBeingInRing = requiresBeingInRing;
        TargetMustBeInRing = targetMustBeInRing;
        TargetMustBeInRange = targetMustBeInRange;
        TargetMustBeOffRange = targetMustBeOffRange;
        RequiresBeingOffRing = requiresBeingOffRing;
        TargetMustBeOffRing = targetMustBeOffRing;
        RequiresBeingInHold = requiresBeingInHold;
        RequiresNotBeingInHold = requiresNotBeingInHold;
        TargetMustBeInHold = targetMustBeInHold;
        TargetMustNotBeInHold = targetMustNotBeInHold;
        UsableOnSelf = usableOnSelf;
        UsableOnAllies = usableOnAllies;
        UsableOnEnemies = usableOnEnemies;
        Trigger = trigger;
        Explanation = explanation;
        MaxTargets = maxTargets;
        CreatedAt = DateTime.Now;
    }

    public abstract int requiredDiceScore { get; }

}