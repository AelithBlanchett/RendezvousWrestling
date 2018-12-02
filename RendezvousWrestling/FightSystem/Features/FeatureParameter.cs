import {BaseFeatureParameter} from "../../Common/Features/BaseFeatureParameter";
import {RWFight} from "../Fight/RWFight";
import {RWFighterState} from "../Fight/RWFighterState";
import {RWAction} from "../Actions/RWAction";

public class FeatureParameter extends BaseFeatureParameter{
public RWFight    fight? {get; set;}
public RWFighterState    fighter? {get; set;}
public RWFighterState    target? {get; set;}
public RWAction    action? {get; set;}
}