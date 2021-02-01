using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Achievements;
using RendezvousWrestling.FightSystem.Fight;
using RendezvousWrestling.FightSystem.Actions;

namespace RendezvousWrestling.FightSystem.Achievements
{
    public class RWAchievementManager : AchievementManager<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierParameters, RWModifierType, RWUser>
    {
    }
}
