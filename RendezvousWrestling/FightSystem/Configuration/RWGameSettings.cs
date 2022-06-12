using RendezvousWrestling.Common.Configuration;

namespace RendezvousWrestling.FightSystem.Configuration
{
    public class RWGameSettings : GameSettings
    {

        public static decimal DegradationFocusMultiplier { get; set; } = 1.66m;
        public static int RequiredScoreForBondageAgainstBondageBunny { get; set; } = 10;
        public static int MaxBondageItemsOnSelf { get; set; } = 4;
        public static int MaxTurnsWithoutFocus { get; set; } = 6;

        public static int InitialintOfTurnsForHold { get; set; } = 5;
        public static decimal HoldDamageMultiplier { get; set; } = 0.5m;

        public static decimal HpPercentageToHealOnRest { get; set; } = 0.3m;
        public static decimal LpPercentageToHealOnRest { get; set; } = 0.3m;
        public static decimal FpPercentageToHealOnRest { get; set; } = 0.3m;

        public static int ForcedWorshipLPMultiplier { get; set; } = 4;

        public static int MultiplierHighRiskAttack { get; set; } = 2;

        public static decimal StunHPDamageMultiplier { get; set; } = 0.33m;
        public static int DicePenaltyMultiplierWhileStunned { get; set; } = 2;

        public static int PassFpDamage { get; set; } = 10;

        public static int FpHealOnNextTurn { get; set; } = 2;

        public static int TapoutOnlyAfterTurnint { get; set; } = 10;
        public static int MinFocus { get; set; } = 0;
    }
}