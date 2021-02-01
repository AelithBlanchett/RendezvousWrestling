using System;

public class GameSettings
{
    public static string BotName { get; set; } = "Miss_Spencer";
    public static string PluginName { get; set; } = "nsfw";
    public static string CurrencyName { get; set; } = "tokens";
    public static int CurrentSeason { get; set; } = 1;

    public static int IntOfAvailableTeams { get; set; } = (Enum.GetValues(typeof(Team)).Length - 2);
    public static int DiceSides { get; set; } = 10;
    public static int DiceCount { get; set; } = 2;

    public static bool FeaturesEnabled { get; set; } = true;
    public static int FeaturesMinMatchesDurationCount { get; set; } = 1;
    public static int FeaturesMaxMatchesDurationCount { get; set; } = 10;

    public static bool ModifiersEnabled { get; set; } = true;

    public static double TokensPerLossMultiplier { get; set; } = 0.5; //needs to be < 1 of course
    public static double TokensForWinnerByForfeitMultiplier { get; set; } = 0.5;  //needs to be < 1 of course
    public static int TokensCostToFight { get; set; } = 10;
    public static bool TippingEnabled { get; set; } = true;
    public static int TippingMinimum { get; set; } = 0;

    public static int IntOfDifferentStats { get; set; } = 6;
    public static int IntOfRequiredStatPoints { get; set; } = 230;
    public static int MinStatLimit { get; set; } = 10;
    public static int MaxStatLimit { get; set; } = 100;
    public static int RestatCostInTokens { get; set; } = 5;

    public static int TierRequiredToBreakHold = -1;

    public static int TurnsToWaitBetweenTwoTags { get; set; } = 4;
    public static int RequiredScoreTag { get; set; } = 8;
    public static int RequiredScoreRest { get; set; } = 4;
    public static int MaximumDistanceToBeConsideredInRange { get; set; } = 10;
}