
public class RWGameSettings : GameSettings
{

    public static decimal degradationFocusMultiplier { get; set; } = 1.66m;
    public static int RequiredScoreForBondageAgainstBondageBunny { get; set; } = 10;
    public static int maxBondageItemsOnSelf { get; set; } = 4;
    public static int maxTurnsWithoutFocus { get; set; } = 6;

    public static int initialintOfTurnsForHold { get; set; } = 5;
    public static int holdDamageMultiplier { get; set; } = 0;

    public static int hpPercentageToHealOnRest { get; set; } = 0;
    public static int lpPercentageToHealOnRest { get; set; } = 0;
    public static int fpPercentageToHealOnRest { get; set; } = 0;

    public static int forcedWorshipLPMultiplier { get; set; } = 4;

    public static int multiplierHighRiskAttack { get; set; } = 2;

    public static decimal stunHPDamageMultiplier { get; set; } = 0.33m;
    public static int dicePenaltyMultiplierWhileStunned { get; set; } = 2;

    public static int passFpDamage { get; set; } = 1;

    public static int fpHealOnNextTurn { get; set; } = 2;

    public static int tapoutOnlyAfterTurnint { get; set; } = 10;
}