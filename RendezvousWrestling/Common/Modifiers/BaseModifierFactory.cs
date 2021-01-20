using AutoMapper;
using Newtonsoft.Json;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;
using System;

public class BaseModifierFactory<TFightingGame, TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TModifierParameters, TModifierType, TUser, TFeatureParameters>
    where TActionFactory : IActionFactory<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TFeature : BaseFeature<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TFeatureFactory : IFeatureFactory<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TUser : BaseUser<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TFight : BaseFight<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TFighterState : BaseFighterState<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TActiveAction : BaseActiveAction<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TFeatureParameters : BaseFeatureParameter<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TAchievement : BaseAchievement<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TModifier : BaseModifier<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TFighterStats : BaseFighterStats<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TFightingGame : BaseFightingGame<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, TFeatureParameters>, new()
    where TModifierParameters : BaseModifierParameter<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TModifierParameters, TUser, TFeatureParameters>, new()
    where TEntityMapper : BaseEntityMapper<TFightingGame, TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TModifierParameters, TUser, TFeatureParameters>, new()
    where TModifierType : BaseModifierType

{

    public TModifier getModifier(TModifierType modifierType, TFight fight, TFighterState receiver, TFighterState applier = null, TModifierParameters inputParameters = null)
    {
        var modifier = (TModifier)Activator.CreateInstance(modifierType.MatchingType);
        modifier.initialize(fight, receiver, applier, inputParameters.tier, inputParameters.uses, inputParameters.timeToTrigger, inputParameters.triggeringEvent, inputParameters.idParentActions);
        modifier = (TModifier)new TEntityMapper().Mapper.Map(inputParameters, modifier, typeof(TModifierParameters), typeof(TModifier));
        return modifier;
    }
}