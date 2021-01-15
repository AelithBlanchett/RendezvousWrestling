namespace Fight
{

    public class Globals
    {
        public static decimal tokensPerLossMultiplier { get; set; } = 0.5m; //needs to be < 1 of course
        public static decimal tokensForWinnerByForfeitMultiplier { get; set; } = 0.5m;   //needs to be < 1 of course
        public static int tokensCostToFight { get; set; } = 10;
        //Range
        public static int maximumDistanceToBeConsideredInRange { get; set; } = 10;
    }


}

namespace Action
{
    public class RequiredScore
    {
        public static int Tag { get; set; } = 8;
        public static int Rest { get; set; } = 4;
        public static int BondageBunny { get; set; } = 10;
    }

    public class Globals
    {

        //Tag
        public static decimal turnsToWaitBetweenTwoTags { get; set; } = 4;
        //Bondage
        public static decimal maxBondageItemsOnSelf { get; set; } = 4;
        public static decimal difficultyIncreasePerBondageItem { get; set; } = 2;
        //Focus
        public static decimal maxTurnsWithoutFocus { get; set; } = 6;
        //Holds
        public static decimal initialintOfTurnsForHold { get; set; } = 5;
        public static decimal holdDamageMultiplier { get; set; } = 0.5m;
        //Rest
        public static decimal hpPercentageToHealOnRest { get; set; } = 0.30m;
        public static decimal lpPercentageToHealOnRest { get; set; } = 0.30m;
        public static decimal fpPercentageToHealOnRest { get; set; } = 0.30m;
        //Forced Lewd
        public static decimal forcedWorshipLPMultiplier { get; set; } = 4;
        //HighRisk
        public static decimal multiplierHighRiskAttack { get; set; } = 2;
        //Stun
        public static decimal stunHPDamageMultiplier { get; set; } = 0.33m;
        public static decimal dicePenaltyMultiplierWhileStunned { get; set; } = 2;

        public static decimal passFpDamage { get; set; } = 6;

        public static decimal fpHealOnNextTurn { get; set; } = 2;

        public static decimal tapoutOnlyAfterTurnint { get; set; } = 10;


        //Bonuses
        public static decimal maxTagBonus { get; set; } = 3;

        public static decimal itemPickupUses { get; set; } = 3;
        public static decimal itemPickupBonusDiceScore { get; set; } = 5;
        public static decimal itemPickupDamageMultiplier { get; set; } = 1.5m;

        public static decimal sextoyPickupUses { get; set; } = 3;
        public static decimal sextoyPickupBonusDiceScore { get; set; } = 5;
        public static decimal sextoyPickupDamageMultiplier { get; set; } = 1.5m;

        public static decimal degradationUses { get; set; } = 5;
        public static decimal degradationFocusDamage { get; set; } = 10;
        public static decimal degradationFocusMultiplier { get; set; } = 1.66m;

        public static decimal accuracyForBrawlInsideSubHold { get; set; } = 3;
        public static decimal accuracyForSexStrikeInsideSexHold { get; set; } = 3;
    }
}

public enum BaseDamage
{
    Light = 1,
    Medium = 10,
    Heavy = 20
}

public enum FocusDamageOnMiss
{
    None = 1,
    Light = 3,
    Medium = 6,
    Heavy = 10
}

public enum FocusHealOnHit
{
    None = 1,
    Light = 6,
    Medium = 12,
    Heavy = 18
}

public enum FocusDamageOnHit
{
    Light = 5,
    Medium = 10,
    Heavy = 15
}

public enum StrapToyLPDamagePerTurn
{
    Light = 4,
    Medium = 8,
    Heavy = 12
}

public enum StrapToyDiceRollPenalty
{
    Light = 3,
    Medium = 5,
    Heavy = 7
}

public class FailedHighRiskMultipliers
{
    public static readonly decimal Light = 0.6m;
    public static readonly decimal Medium = 0.5m;
    public static readonly decimal Heavy = 0.4m;
}

public class HighRiskMultipliers
{
    public static readonly decimal Light = 1.3m;
    public static readonly decimal Medium = 1.5m;
    public static readonly decimal Heavy = 1.8m;
}

public enum MasturbateLpDamage
{
    Light = 5,
    Medium = 10,
    Heavy = 20
}

public enum SelfDebaseFpDamage
{
    Light = 8,
    Medium = 16,
    Heavy = 24
}

public enum ModifierType
{
    SubHoldBrawlBonus = 0,
    SubHold = 1,
    SexHoldLustBonus = 2,
    SexHold = 3,
    Bondage = 4,
    HumHold = 5,
    DegradationMalus = 6,
    ItemPickupBonus = 7,
    SextoyPickupBonus = 8,
    Stun = 9,
    StrapToy = 10,
    DummyModifier = 11
}

public class ModifierTypeDescription
{
    public static readonly string SubHoldBrawlBonus = "Accuracy++ on brawl (submission hold)";
    public static readonly string SubHold = "submission hold";
    public static readonly string SexHoldLustBonus = "Accuracy++ on tease (sexual hold)";
    public static readonly string SexHold = "sexual hold";
    public static readonly string Bondage = "bondage items";
    public static readonly string HumHold = "humiliation hold";
    public static readonly string DegradationMalus = "degradation malus";
    public static readonly string ItemPickupBonus = "HP Dmg++ (item pickup)";
    public static readonly string SextoyPickupBonus = "LP Dmg++ (sextoy pickup)";
    public static readonly string Stun = "stun";
    public static readonly string StrapToy = "strapped sex-toy";
    public static readonly string DummyModifier = "unused modifier";
}

public class Feature
{
    public static readonly string KickStart = "Kick Start";
    public static readonly string SexyKickStart = "Sexy Kick Start";
    public static readonly string Sadist = "Sadist";
    public static readonly string CumSlut = "Cum Slut";
    public static readonly string RyonaEnthusiast = "Ryona Enthusiast";
    public static readonly string DomSubLover = "Dom Sub Lover";
    public static readonly string BondageBunny = "Bondage Bunny";
    public static readonly string BondageHandicap = "Bondage Handicap (1 item)";
}

public class FeatureType
{
    public static readonly string KickStart = "Kick Start feature";
    public static readonly string SexyKickStart = "Sexy Kick Start feature";
    public static readonly string Sadist = "Sadist feature";
    public static readonly string CumSlut = "Cum Slut feature";
    public static readonly string RyonaEnthusiast = "Ryona Enthusiast feature";
    public static readonly string DomSubLover = "D/s Lover feature";
    public static readonly string BondageBunny = "Bondage Bunny feature";
    public static readonly string BondageHandicap = "Bondage Handicap feature";
}

public class FeatureEffect
{
    public static readonly string CreateModifier = "creates a modifier";
    public static readonly string DamageTweaker = "changes the action's damage";
}

public enum FeatureCostPerUse
{
    KickStart = 5,
    SexyKickStart = 5,
    Sadist = 0,
    CumSlut = 0,
    RyonaEnthusiast = 0,
    DomSubLover = 0,
    BondageBunny = 0,
    BondageHandicap = 0
}

public class FeatureExplain
{
    public static readonly string KickStart = "They start with an offensive item in their hand, meaning to do more damage.";
    public static readonly string SexyKickStart = "They start with a sextoy in their hand, meaning to do more lust damage.";
    public static readonly string Sadist = "Dealing HP damage to the opponent will deal the same amount divided by two to the wearer's Lust.";
    public static readonly string CumSlut = "Increases all Lust damage done to the wearer by 3.";
    public static readonly string RyonaEnthusiast = "Taking HP damage also increases the wearer's Lust by the same amount divided by two.";
    public static readonly string DomSubLover = "Replaces focus by submissiveness. Purely visual.";
    public static readonly string BondageBunny = "They can be tied up without applying a hold.";
    public static readonly string BondageHandicap = "They start the fight already wearing one bondage item.";
}