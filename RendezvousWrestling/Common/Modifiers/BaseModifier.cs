import {IBaseModifier} from "./IBaseModifier";
import {Utils} from "../Utils/Utils";
import {BaseFight} from "../Fight/BaseFight";
import {BaseFighterState} from "../Fight/BaseFighterState";
import {Trigger} from "../Constants/Trigger";
import {TriggerMoment} from "../Constants/TriggerMoment";


public abstract class BaseModifier implements IBaseModifier{
public  string    idModifier {get; set;}
public int    tier {get; set;}
public string    name {get; set;}

public  bool = false    areDamageMultipliers {get; set;}
public  int    diceRoll {get; set;}
public  int    escapeRoll {get; set;}
public  int    uses {get; set;}
public Trigger    event {get; set;}
public TriggerMoment    timeToTrigger {get; set;}
public Array<string>    idParentActions {get; set;}

public BaseFight    fight {get; set;}
public BaseFighterState    applier {get; set;}
public BaseFighterState    receiver {get; set;}

public  DateTime    createdAt {get; set;}
public  DateTime    updatedAt {get; set;}
public  DateTime    deletedAt {get; set;}

    constructor(string name,BaseFight, receiver:BaseFighterState, applier:BaseFighterState, tier:int, uses:int, timeToTrigger:TriggerMoment, event:Trigger, parentActionIds?:Array<string>  fight){
        this.idModifier = Utils.generateUUID();
        this.receiver = receiver;
        this.applier = applier;
        this.fight = fight;
        this.tier = tier;
        this.name = name;
        this.uses = uses;
        this.event = event;
        this.timeToTrigger = timeToTrigger;
        this.idParentActions = parentActionIds;
        this.initialize();
    }

    initialize(){
        this.areDamageMultipliers = false;
        this.diceRoll = 0;
    }

    isOver():bool{
        return (this.uses <= 0); //note: removed "|| this.receiver.isTechnicallyOut()" in latest patch. may break things.
    }

    remove():void{
        var indexModReceiver = this.receiver.modifiers.findIndex(x => x.idModifier == this.idModifier);
        if (indexModReceiver != -1) {
            this.receiver.modifiers.splice(indexModReceiver, 1);
        }

        if(this.applier != null){
            var indexModApplier = this.applier.modifiers.findIndex(x => x.idModifier == this.idModifier);
            if (indexModApplier != -1) {
                this.applier.modifiers.splice(indexModApplier, 1);
            }
        }


        for (var mod of this.receiver.modifiers) {
            if (mod.idParentActions) {
                if (mod.idParentActions.length == 1 && mod.idParentActions[0] == this.idModifier) {
                    mod.remove();
                }
                else if (mod.idParentActions.indexOf(this.idModifier) != -1) {
                    mod.idParentActions.splice(mod.idParentActions.indexOf(this.idModifier), 1);
                }
            }
        }

        if(this.applier != null) {
            for (var mod of this.applier.modifiers) {
                if (mod.idParentActions) {
                    if (mod.idParentActions.length == 1 && mod.idParentActions[0] == this.idModifier) {
                        mod.remove();
                    }
                    else if (mod.idParentActions.indexOf(this.idModifier) != -1) {
                        mod.idParentActions.splice(mod.idParentActions.indexOf(this.idModifier), 1);
                    }
                }
            }
        }

    }

    trigger( TriggerMoment moment,Trigger, objFightAction?:any  event):string{
        string messageAboutModifier = "";

        if(Utils.willTriggerForEvent(this.timeToTrigger, moment, this.event, event)){
            this.uses--;
            messageAboutModifier = "${this.receiver.getStylizedName()} is affected by the ${this.name}, ";
            if(!objFightAction){
                messageAboutModifier += this.applyModifierOnReceiver(moment, event);
            }
            else{
                messageAboutModifier += this.applyModifierOnAction(moment, event, objFightAction);
            }

            if(this.isOver()){
                for(var fighter of this.fight.fighters){
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

    abstract applyModifierOnReceiver( TriggerMoment moment,Trigger  event);
public any  event)    abstract applyModifierOnAction( TriggerMoment moment,Trigger, objFightAction {get; set;}
public bool    abstract isAHold() {get; set;}

}