using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Achievements;
using RendezvousWrestling.FightSystem.Fight;
using RendezvousWrestling.FightSystem.Actions;
using System.Collections.Generic;
using System.Linq;

namespace RendezvousWrestling.FightSystem.Achievements
{
    public class RWAchievementManager : AchievementManager<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierFactory, RWModifierParameters, RWModifierType, RWUser>
    {
        public override ICollection<RWAchievement> GetAllEnabledAchievements()
        {
            return base.GetAllEnabledAchievements().Union(new List<RWAchievement>()
            {
                new RookieAchievement()
            }).ToList();
        }
    }
}
