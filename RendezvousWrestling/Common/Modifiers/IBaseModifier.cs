import {Trigger} from "../Constants/Trigger";
import {BaseFighterState} from "../Fight/BaseFighterState";
import {BaseFight} from "../Fight/BaseFight";
import {TriggerMoment} from "../Constants/TriggerMoment";

public interface IBaseModifier{
public  string    idModifier {get; set;}
public int    tier {get; set;}
public string    name {get; set;}
public  BaseFighterState    applier {get; set;}
public  BaseFighterState    receiver {get; set;}
public  bool    areDamageMultipliers {get; set;}
public  int    diceRoll {get; set;}
public  int    escapeRoll {get; set;}
public  int    uses {get; set;}
public Trigger    event {get; set;}
public TriggerMoment    timeToTrigger {get; set;}
public  Array<string>    idParentActions {get; set;}

public  Date    createdAt {get; set;}
public  Date    updatedAt {get; set;}
public  Date    deletedAt {get; set;}

public BaseFight    fight {get; set;}

public bool    isOver() {get; set;}
public void    remove() {get; set;}
public any  event):void    trigger( TriggerMoment moment,Trigger, objFightAction? {get; set;}
public void    applyModifierOnReceiver( TriggerMoment moment,Trigger  event) {get; set;}
public any  event):void    applyModifierOnAction( TriggerMoment moment,Trigger, objFightAction {get; set;}
}