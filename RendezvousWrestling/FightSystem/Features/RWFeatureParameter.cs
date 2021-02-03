using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Utils;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.FightSystem.Fight;
using RendezvousWrestling.FightSystem.Actions;

namespace RendezvousWrestling.FightSystem.Features
{
    public class RWFeatureParameter : BaseFeatureParameter<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierFactory, RWModifierParameters, RWModifierType, RWUser>
    {
        public RWFeatureParameter() : base()
        {

        }
    }
}