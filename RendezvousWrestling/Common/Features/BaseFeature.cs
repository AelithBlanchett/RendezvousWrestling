using System;
using System.Linq;

public abstract class BaseFeature
{

    public string Id;
    public string Type;
    public int Uses;
    public bool Permanent;
    public BaseUser Receiver;
    public DateTime CreatedAt;
    public DateTime UpdatedAt;
    public bool Deleted;

    public BaseFeature(string featureType, BaseUser receiver, int uses, Guid? id = null)
    {
        if (id.HasValue)
        {
            Id = id.Value.ToString();
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

    public string Trigger<OptionalParameterType>(TriggerMoment moment, Trigger @triggeringEvent, OptionalParameterType parameters)
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

    public abstract string applyFeature<OptionalParameterType>(TriggerMoment moment, Trigger @triggeringEvent, OptionalParameterType parameters);

}