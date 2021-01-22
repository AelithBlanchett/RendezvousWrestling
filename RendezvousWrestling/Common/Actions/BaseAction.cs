using RendezvousWrestling.Common.DataContext;
using System;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class BaseAction : BaseEntity
{

    [NotMapped]
    public string Name { get; set; }
    [NotMapped]
    public int Tier { get; set; }
    [NotMapped]
    public bool IsHold { get; set; }
    [NotMapped]
    public bool RequiresRoll { get; set; }
    [NotMapped]
    public bool KeepActorsTurn { get; set; }
    [NotMapped]
    public string Explanation { get; set; }
    [NotMapped]
    public bool SingleTarget { get; set; }
    [NotMapped]
    public int? MaxTargets { get; set; }

    [NotMapped]
    public bool RequiresBeingAlive { get; set; }
    [NotMapped]
    public bool RequiresBeingDead { get; set; }
    [NotMapped]
    public bool RequiresBeingInRing { get; set; }
    [NotMapped]
    public bool RequiresBeingOffRing { get; set; }

    [NotMapped]
    public bool TargetMustBeAlive { get; set; }
    [NotMapped]
    public bool TargetMustBeDead { get; set; }
    [NotMapped]
    public bool TargetMustBeInRing { get; set; }
    [NotMapped]
    public bool TargetMustBeOffRing { get; set; }
    [NotMapped]
    public bool TargetMustBeInRange { get; set; }
    [NotMapped]
    public bool TargetMustBeOffRange { get; set; }
    [NotMapped]
    public bool RequiresBeingInHold { get; set; }
    [NotMapped]
    public bool RequiresNotBeingInHold { get; set; }
    [NotMapped]
    public bool TargetMustBeInHold { get; set; }
    [NotMapped]
    public bool TargetMustNotBeInHold { get; set; }

    [NotMapped]
    public bool UsableOnSelf { get; set; }
    [NotMapped]
    public bool UsableOnAllies { get; set; }
    [NotMapped]
    public bool UsableOnEnemies { get; set; }
    [NotMapped]
    public Trigger Trigger { get; set; }

    public BaseAction()
    {

    }

    [NotMapped]
    public abstract int requiredDiceScore { get; }

    public void initialize(string name,
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
    }

}