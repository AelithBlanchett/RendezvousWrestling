using FChatSharpLib;
using Microsoft.Extensions.Options;
using RendezvousWrestling.Common;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Actions;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Fight;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using System.Collections.Generic;
using Volo.Abp.DependencyInjection;

namespace RendezvousWrestling.FightSystem
{
    public class RendezVousWrestlingGame : BaseFightingGame<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierFactory, RWModifierParameters, RWModifierType, RWUser>, ISingletonDependency
    {
        public override IOptions<RendezvousWrestlingPluginOptions> PluginOptions { get; }

        public RendezVousWrestlingGame(IOptions<RendezvousWrestlingPluginOptions> pluginOptions, RemoteBotController fChatClient) : base(pluginOptions, fChatClient)
        {
            PluginOptions = pluginOptions;
            Run();
        }
    }
}