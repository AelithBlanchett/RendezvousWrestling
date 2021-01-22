using AutoMapper;
using Newtonsoft.Json;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Utils;
using System;

namespace RendezvousWrestling.FightSystem.Modifiers
{
    public class RWModifierFactory : BaseModifierFactory<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierParameters, RWModifierType, RWUser>
    {

    }
}