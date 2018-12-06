using System;
using System.Collections.Generic;

public abstract class BaseModifier : IBaseModifier{
public  string    idModifier {get; set;}
public int    tier {get; set;}
public string    name {get; set;}

    public bool areDamageMultipliers { get; set; } = false;
public  int    diceRoll {get; set;}
public  int    escapeRoll {get; set;}
public  int    uses {get; set;}
public Trigger triggeringEvent { get; set;}
public TriggerMoment    timeToTrigger {get; set;}
public List<string>    idParentActions {get; set;}

public BaseFight<BaseFighterState<BaseModifier>, BaseModifier>    fight {get; set;}
public BaseFighterState<BaseModifier>    applier {get; set;}
public BaseFighterState<BaseModifier> receiver {get; set;}

public  DateTime    createdAt {get; set;}
public  DateTime    updatedAt {get; set;}
public  DateTime    deletedAt {get; set;}

    public BaseModifer(string name, BaseFight<BaseFighterState<BaseModifier>, BaseModifier> fight, BaseFighterState<BaseModifier> receive, BaseFighterState<BaseModifier> applier, int tier, int uses, TriggerMoment timeToTrigger, Trigger triggeringEvent, List<string> parentActionIds = null){
        this.idModifier = Guid.NewGuid().ToString();
        this.receiver = receiver;
        this.applier = applier;
        this.fight = fight;
        this.tier = tier;
        this.name = name;
        this.uses = uses;
        this.triggeringEvent = triggeringEvent;
        this.timeToTrigger = timeToTrigger;
        this.idParentActions = parentActionIds;
        this.initialize();
    }

    public void initialize(){
        this.areDamageMultipliers = false;
        this.diceRoll = 0;
    }

    public bool isOver(){
        return (this.uses <= 0); //note: removed "|| this.receiver.isTechnicallyOut()" in latest patch. may break things.
    }

    public void remove(){
        var indexModReceiver = this.receiver.modifiers.FindIndex(x => x.idModifier == this.idModifier);
        if (indexModReceiver != -1) {
            this.receiver.modifiers.RemoveAt(indexModReceiver);
        }

        if(this.applier != null){
            var indexModApplier = this.applier.modifiers.FindIndex(x => x.idModifier == this.idModifier);
            if (indexModApplier != -1) {
                this.applier.modifiers.RemoveAt(indexModApplier);
            }
        }


        foreach (var mod in this.receiver.modifiers) {
            if (mod.idParentActions != null) {
                if (mod.idParentActions.Count == 1 && mod.idParentActions[0] == this.idModifier) {
                    mod.remove();
                }
                else if (mod.idParentActions.IndexOf(this.idModifier) != -1) {
                    mod.idParentActions.RemoveAt(mod.idParentActions.IndexOf(this.idModifier));
                }
            }
        }

        if(this.applier != null) {
            foreach (var mod in this.applier.modifiers) {
                if (mod.idParentActions != null) {
                    if (mod.idParentActions.Count == 1 && mod.idParentActions[0] == this.idModifier) {
                        mod.remove();
                    }
                    else if (mod.idParentActions.IndexOf(this.idModifier) != -1) {
                        mod.idParentActions.RemoveAt(mod.idParentActions.IndexOf(this.idModifier));
                    }
                }
            }
        }

    }

    public string trigger( TriggerMoment moment,Trigger triggeringEvent, dynamic objFightAction = null){
        string messageAboutModifier = "";

        if(Utils.willTriggerForEvent(this.timeToTrigger, moment, this.triggeringEvent, triggeringEvent)){
            this.uses--;
            messageAboutModifier = "${this.receiver.getStylizedName()} is affected by the ${this.name}, ";
            if(!objFightAction){
                messageAboutModifier += this.applyModifierOnReceiver(moment, triggeringEvent);
            }
            else{
                messageAboutModifier += this.applyModifierOnAction(moment, triggeringEvent, objFightAction);
            }

            if(this.isOver()){
                foreach(var fighter in this.fight.fighters){
                    fighter.removeMod(this.idModifier);
                }
                messageAboutModifier += " and it is now expired.";
            }
            else{
                messageAboutModifier += " still effective for ${this.uses} more turns.";
            }

            this.fight.message.addSpecial(messageAboutModifier);
        }

        return messageAboutModifier;
    }

    public abstract string applyModifierOnReceiver( TriggerMoment moment,Trigger  triggeringEvent);
public abstract string applyModifierOnAction( TriggerMoment moment,Trigger triggeringEvent, dynamic objFightAction);
public abstract bool isAHold();

}