import {BaseActiveAction} from "./BaseActiveAction";
import {BaseFight} from "../Fight/BaseFight";
import {BaseFighterState} from "../Fight/BaseFighterState";

public interface IActionFactory<Fight extends BaseFight, FighterState extends BaseFighterState> {
public FighterState, defenders:FighterState[], tier:int  fight):BaseActiveAction    getAction( string actionName,Fight, attacker {get; set;}
}