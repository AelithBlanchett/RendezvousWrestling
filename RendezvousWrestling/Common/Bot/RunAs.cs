﻿using FChatSharpLib.Entities.Plugin.Commands;
using System.Collections.Generic;
using System.Linq;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Achievements;
using RendezvousWrestling.Common.Actions;
using RendezvousWrestling.Common.Fight;
using System.Threading.Tasks;

namespace RendezvousWrestling.Common.Bot
{
    public class RunAs<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser> : BaseCommand<TFightingGame>
        where TAchievement : BaseAchievement<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TAchievementManager : AchievementManager<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TActionFactory : BaseActionFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TActionType : BaseActionType<TActionType>, new()
        where TActiveAction : BaseActiveAction<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TDataContext : BaseDataContext<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TEntityMapper : BaseEntityMapper<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeature : BaseFeature<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureFactory : BaseFeatureFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureParameters : BaseFeatureParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureType : BaseFeatureType<TFeatureType>, new()
        where TFight : BaseFight<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFighterState : BaseFighterState<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFighterStats : BaseFighterStats<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFightingGame : BaseFightingGame<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>
        where TModifier : BaseModifier<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TModifierFactory : BaseModifierFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TModifierParameters : BaseModifierParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TModifierType : BaseModifierType<TModifierType>, new()
        where TUser : BaseUser<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()

    {

        public override async Task ExecuteCommand(string characterCalling, IEnumerable<string> args, string channel)
        {
            if (Plugin.FChatClient.IsUserAdmin(characterCalling, channel))
            {
                var command = args.First();
                Plugin.ExecuteCommand(Plugin.DebugImpersonatedCharacter, command, args.Skip(1), channel);
            }
        }
    }
}
