import {GameSettings} from "../Configuration/GameSettings";


//TODO: use knex to create tables on the fly
public class SQL {
public  string = GameSettings.pluginName + "_fights"    public static fightTableName {get; set;}
public  string = GameSettings.pluginName + "_fightfighters"    public static fightFightersTableName {get; set;}
public  string = GameSettings.pluginName + "_fighters_features"    public static fightersFeaturesTableName {get; set;}
public  string = GameSettings.pluginName + "_fighters_achievements"    public static fightersAchievementsTableName {get; set;}
public  string = GameSettings.pluginName + "_fighters_transactions"    public static fightersTransactionsTableName {get; set;}
public  string = GameSettings.pluginName + "_fighters"    public static fightersTableName {get; set;}
public  string = GameSettings.pluginName + "_v_fighters"    public static fightersViewName {get; set;}
public  string = GameSettings.pluginName + "_actions"    public static actionTableName {get; set;}
public  string = GameSettings.pluginName + "_activefighters"    public static activeFightersTableName {get; set;}
public  string = GameSettings.pluginName + "_constants"    public static constantsTableName {get; set;}
public  string = GameSettings.pluginName + "_modifiers"    public static modifiersTableName {get; set;}
public  string = "currentSeason"    public static currentSeasonKeyName {get; set;}
}