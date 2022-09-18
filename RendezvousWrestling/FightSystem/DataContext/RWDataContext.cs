using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Utils;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Fight;
using RendezvousWrestling.FightSystem.Actions;
using RendezvousWrestling.FightSystem;
using Microsoft.Extensions.Configuration;
using Volo.Abp.DependencyInjection;

namespace RendezvousWrestling.Common.DataContext
{
    public class RWDataContext : BaseDataContext<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierFactory, RWModifierParameters, RWModifierType, RWUser>, ITransientDependency
    {
        public RWDataContext() : base(null)
        {

        }

        public RWDataContext(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
