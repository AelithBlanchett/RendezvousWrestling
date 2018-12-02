import {IBaseModifier} from "../../Common/Modifiers/IBaseModifier";

public interface IModifier extends IBaseModifier{
public  int    hpDamage {get; set;}
public  int    lustDamage {get; set;}
public  int    focusDamage {get; set;}
public  int    hpHeal {get; set;}
public  int    lustHeal {get; set;}
public  int    focusHeal {get; set;}

public  string    sEvent? {get; set;}
public  string    sTimeToTrigger? {get; set;}
}