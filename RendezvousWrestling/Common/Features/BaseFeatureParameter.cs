import {BaseFight} from "../Fight/BaseFight";
import {BaseFighterState} from "../Fight/BaseFighterState";
import {BaseActiveAction} from "../Actions/BaseActiveAction";

public class BaseFeatureParameter{
public BaseFight    fight? {get; set;}
public BaseFighterState    fighter? {get; set;}
public BaseFighterState    target? {get; set;}
public BaseActiveAction    action? {get; set;}

    constructor(BaseFight fight?,BaseFighterState, target?:BaseFighterState, action?:BaseActiveAction  fighter?){
        this.fight = fight;
        this.fighter = fighter;
        this.target = target;
        this.action = action;
    }
}