using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using System;
using System.Collections.Generic;
using System.Text;
using RendezvousWrestling.FightSystem.Utils;
using RendezvousWrestling.FightSystem.Modifiers;

namespace RendezvousWrestling.Common.DataContext
{
    public class RWDataContext : BaseDataContext<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierParameters, RWModifierType, RWUser>
    {
        
    }
}
