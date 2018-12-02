using System;

public abstract class BaseFeature{

    public Guid Id;
    public string Type;
    public int Uses;
    public bool Permanent;
    public BaseUser Receiver;
    public DateTime CreatedAt;
    public DateTime UpdatedAt;
    public bool Deleted;

    public BaseFeature(string featureType, BaseUser receiver, int uses, Guid? id = null) {
        if(id.HasValue){
            Id = id.Value;
        }
        else{
            Id = Guid.NewGuid();
        }

        Receiver = receiver;

        Type = featureType;
    }

    public bool isExpired(){
        if(!this.permanent){
            if(this.uses <= 0){
                return true;
            }
        }
        return false;
    }

    public string Trigger<OptionalParameterType>(TriggerMoment moment, Trigger @event, OptionalParameterType parameters = null){
        var triggeredFeatureMessage = this.applyFeature(moment, event, parameters);
        var wasFeatureTriggered = (triggeredFeatureMessage.length > 0);

        string messageAboutFeature = "";

        if(wasFeatureTriggered){
            messageAboutFeature = "${this.receiver.name} is affected by the ${this.type}, ${triggeredFeatureMessage}";
        }

        return messageAboutFeature;
    }

public int    abstract getCost() {get; set;}

    abstract applyFeature<OptionalParameterType>( TriggerMoment moment,Trigger, parameters?:OptionalParameterType  event):string

}