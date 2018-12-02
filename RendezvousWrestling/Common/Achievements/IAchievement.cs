import {BaseFighterState} from "../Fight/BaseFighterState";
import {BaseFight} from "../Fight/BaseFight";
import {BaseUser} from "../Fight/BaseUser";

public interface IAchievement{
public BaseFight  activeFighter):bool    meetsRequirements(BaseUser fighter,BaseFighterState, fight {get; set;}
public string    getDetailedDescription() {get; set;}
public int    getReward() {get; set;}
public string    getUniqueShortName() {get; set;}
public string    getName() {get; set;}
}

