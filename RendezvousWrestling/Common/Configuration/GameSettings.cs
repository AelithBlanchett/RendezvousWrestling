using System;

public class GameSettings
{
    public static string botName { get; set; } = "Miss_Spencer";
    public static string pluginName { get; set; } = "nsfw";
    public static string currencyName { get; set; } = "tokens";
    public static int currentSeason { get; set; } = 1;

    public static int intOfAvailableTeams { get; set; } = (Enum.GetValues(typeof(Team)).Length -2);
    public static int diceSides { get; set; } = 10;
    public static int diceCount { get; set; } = 2;

    public static bool featuresEnabled { get; set; } = true;
    public static int featuresMinMatchesDurationCount { get; set; } = 1;
    public static int featuresMaxMatchesDurationCount { get; set; } = 10;

    public static bool modifiersEnabled { get; set; } = true;

    public static double tokensPerLossMultiplier { get; set; } = 0.5; //needs to be < 1 of course
    public static double tokensForWinnerByForfeitMultiplier { get; set; } = 0.5;  //needs to be < 1 of course
    public static int tokensCostToFight { get; set; } = 10;
    public static bool tippingEnabled { get; set; } = true;
    public static int tippingMinimum { get; set; } = 0;

    public static int intOfDifferentStats { get; set; } = 6;
    public static int intOfRequiredStatPoints { get; set; } = 230;
    public static int pminStatLimit { get; set; } = 10;
    public static int maxStatLimit { get; set; } = 100;
    public static int restatCostInTokens { get; set; } = 5;
    public static int tierRequiredToBreakHold = -1;

    public static int turnsToWaitBetweenTwoTags { get; set; } = 4;
    public static int requiredScoreTag { get; set; } = 8;
    public static int requiredScoreRest { get; set; } = 4;
    public static int maximumDistanceToBeConsideredInRange { get; set; } = 10;

    //TODO CONFIG FILE LOADING
    public static void loadConfigFile(dynamic configJson)
    {
        //for (var prop of Object.getOwnPropertyNames(configJson))
        //{
        //    this[prop] = configJson[prop];
        //}
    }

    //static getJsonOutput() :string{
    //        any configJson = { };

    //        for(var prop of Object.getOwnPropertyNames(this)){
    //    configJson[prop] = this[prop];
    //}

    //        return configJson;
    //}
}