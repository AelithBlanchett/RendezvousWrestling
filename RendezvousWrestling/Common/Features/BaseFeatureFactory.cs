using AutoMapper;
using Newtonsoft.Json;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;
using System;

public class BaseFeatureFactory<TFightingGame, TAchievement, TActionFactory, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureType, TFight, TFighterState, TFighterStats, TModifier, TModifierParameters, TModifierType, TUser, TFeatureParameters>
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
    where TFeatureType : BaseFeatureType

{

    public TFeature getFeature(TFeatureType featureType, TUser receiver, int uses, string id = null)
    {
        var feature = (TFeature)Activator.CreateInstance(featureType.MatchingType);
        feature.initialize(receiver, uses, id);
        return feature;
    }
}