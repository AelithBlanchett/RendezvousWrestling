using RendezvousWrestling.Common.DataContext;
using System;
using System.Linq;

public abstract class BaseFeature<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType> : BaseEntity
    where TActionFactory : IActionFactory<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFeature : BaseFeature<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFeatureFactory : IFeatureFactory<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TUser : BaseUser<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFight : BaseFight<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFighterState : BaseFighterState<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TActiveAction : BaseActiveAction<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where OptionalParameterType : BaseFeatureParameter<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TAchievement : BaseAchievement<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TModifier : BaseModifier<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFighterStats : BaseFighterStats<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFightingGame : BaseFightingGame<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
{

    public string Id;
    public string Type;
    public int Uses;
    public bool Permanent;
    public TUser Receiver;
    public DateTime CreatedAt;
    public DateTime UpdatedAt;
    public bool Deleted;

    public BaseFeature()
    {
    }

    public BaseFeature(string featureType, TUser receiver, int uses, string id = null)
    {
        if (id != null)
        {
            Id = id.ToString();
        }
        else
        {
            Id = Guid.NewGuid().ToString();
        }

        Receiver = receiver;

        Type = featureType;
    }

    public bool isExpired()
    {
        if (!this.Permanent)
        {
            if (this.Uses <= 0)
            {
                return true;
            }
        }
        return false;
    }

    public string Trigger(TriggerMoment moment, Trigger @triggeringEvent, OptionalParameterType parameters)
    {
        var triggeredFeatureMessage = this.applyFeature(moment, @triggeringEvent, parameters);
        var wasFeatureTriggered = (triggeredFeatureMessage.Count() > 0);

        string messageAboutFeature = "";

        if (wasFeatureTriggered)
        {
            messageAboutFeature = "${this.receiver.name} is affected by the ${this.type}, ${triggeredFeatureMessage}";
        }

        return messageAboutFeature;
    }

    public abstract int getCost();

    public abstract string applyFeature(TriggerMoment moment, Trigger @triggeringEvent, OptionalParameterType parameters);

}