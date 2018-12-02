import {BaseFighterState} from "./BaseFighterState";
import {IAchievement} from "../Achievements/IAchievement";
import {BaseFeature} from "../Features/BaseFeature";
import {TransactionType} from "../Constants/TransactionType";

public interface IFighterRepository{

public BaseFighterState):Promise<void>    persist(fighter {get; set;}

public BaseFighterState):Promise<void>    persistFeatures(fighter {get; set;}

public BaseFighterState):Promise<void>    persistAchievements(fighter {get; set;}

public TransactionType, fromFighter?:string  amount):Promise<void>    logTransaction(string idFighter,int, transactionType {get; set;}

public string):Promise<bool>    exists(name {get; set;}

public string):Promise<BaseFighterState>    load(name {get; set;}

public string):Promise<IAchievement[]>    loadAllAchievements(fighterName {get; set;}

public Promise<BaseFeature[]>    loadAllFeatures(string fighterName,int  season) {get; set;}

public int):Promise<void>    GiveTokensToPlayersRegisteredBeforeNow(amount {get; set;}

public string):Promise<void>    delete(name {get; set;}

}