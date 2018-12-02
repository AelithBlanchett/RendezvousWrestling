import * as fs from "fs";
import {Utils} from "../Utils/Utils";
import {Team} from "../Constants/Team";


public class GameSettings {
public string = "Miss_Spencer"    public static botName {get; set;}
public string = "nsfw"    public static pluginName {get; set;}
public string = "tokens"    public static currencyName {get; set;}
public int = 1    public static currentSeason {get; set;}

public int = (Utils.getEnumList(Team).length - 2)    public static intOfAvailableTeams {get; set;}
public int = 10    public static diceSides {get; set;}
public int = 2    public static diceCount {get; set;}

public bool = true    public static featuresEnabled {get; set;}
public int = 1    public static featuresMinMatchesDurationCount {get; set;}
public int = 10    public static featuresMaxMatchesDurationCount {get; set;}

public bool = true    public static modifiersEnabled {get; set;}

public  int = 0.5    public static tokensPerLossMultiplier {get; set;} //needs to be < 1 of course
public  int = 0.5    public static tokensForWinnerByForfeitMultiplier {get; set;} //needs to be < 1 of course
public int = 10    public static tokensCostToFight {get; set;}
public bool = true    public static tippingEnabled {get; set;}
public int = 0    public static tippingMinimum {get; set;}

public int = 6    public static intOfDifferentStats {get; set;}
public int = 230    public static intOfRequiredStatPoints {get; set;}
public int = 10    public static minStatLimit {get; set;}
public int = 100    public static maxStatLimit {get; set;}
public int = 5    public static restatCostInTokens {get; set;}
    public static tierRequiredToBreakHold = -1;

public  int = 4    public static turnsToWaitBetweenTwoTags {get; set;}
public  int = 8    public static requiredScoreTag {get; set;}
public  int = 4    public static requiredScoreRest {get; set;}
public  int = 10    public static maximumDistanceToBeConsideredInRange {get; set;}

    static loadConfigFile(configJson:any){
        for(var prop of Object.getOwnPropertyNames(configJson)){
            this[prop] = configJson[prop];
        }
    }

    static getJsonOutput():string{
        any configJson = {};

        for(var prop of Object.getOwnPropertyNames(this)){
            configJson[prop] = this[prop];
        }

        return configJson;
    }
}