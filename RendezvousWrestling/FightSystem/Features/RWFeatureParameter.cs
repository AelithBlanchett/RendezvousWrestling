using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using System;
public class RWFeatureParameter : BaseFeatureParameter<RendezVousWrestling, RWAchievement, RWActionFactory, RWActiveAction, RWFeature, RWFeatureFactory, RWFight, RWFighterState, RWFighterStats, RWModifier, RWUser, RWFeatureParameter>
{
    public RWFeatureParameter() : base()
    {

    }

    public RWFight fight { get; set; }
    public RWFighterState fighter { get; set; }
    public RWFighterState target { get; set; }
    public RWActiveAction action { get; set; }
}