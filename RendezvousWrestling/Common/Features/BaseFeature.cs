using System;
using System.Linq;

public abstract class BaseFeature<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>
    where TActionFactory : IActionFactory<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TFeature : BaseFeature<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TFeatureFactory : IFeatureFactory<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TUser : BaseUser<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TFight : BaseFight<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TFighterState : BaseFighterState<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TActiveAction : BaseActiveAction<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where OptionalParameterType : BaseFeatureParameter<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TAchievement : BaseAchievement<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TModifier : BaseModifier<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
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