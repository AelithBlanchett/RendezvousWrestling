import * as fs from "fs";
import {GameSettings} from "../../Common/Configuration/GameSettings";
import {Utils} from "../../Common/Utils/Utils";
import {Team} from "../../Common/Constants/Team";


public class RWGameSettings extends GameSettings {

public  int = 1.66    public static degradationFocusMultiplier {get; set;}
public  int = 10    public static RequiredScoreForBondageAgainstBondageBunny {get; set;}
public  int = 4    public static maxBondageItemsOnSelf {get; set;}
public  int = 6    public static maxTurnsWithoutFocus {get; set;}
    //Holds
public  int = 5    public static initialintOfTurnsForHold {get; set;}
public  int = 0.5    public static holdDamageMultiplier {get; set;}
    //Rest
public  int = 0.30    public static hpPercentageToHealOnRest {get; set;}
public  int = 0.30    public static lpPercentageToHealOnRest {get; set;}
public  int = 0.30    public static fpPercentageToHealOnRest {get; set;}
    //Forced Lewd
public  int = 4    public static forcedWorshipLPMultiplier {get; set;}
    //HighRisk
public  int = 2    public static multiplierHighRiskAttack {get; set;}
    //Stun
public  int = 0.33    public static stunHPDamageMultiplier {get; set;}
public  int = 2    public static dicePenaltyMultiplierWhileStunned {get; set;}

public  int = 10    public static passFpDamage {get; set;}

public  int = 2    public static fpHealOnNextTurn {get; set;}

public int = 10    public static tapoutOnlyAfterTurnint {get; set;}
}