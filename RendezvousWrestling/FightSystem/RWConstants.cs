public namespace Fight {

    public class Globals {
public  int = 0.5        public static tokensPerLossMultiplier {get; set;} //needs to be < 1 of course
public  int = 0.5        public static tokensForWinnerByForfeitMultiplier {get; set;} //needs to be < 1 of course
public int = 10        public static tokensCostToFight {get; set;}
        //Range
public  int = 10        public static maximumDistanceToBeConsideredInRange {get; set;}
    }

    public namespace Action {
        public class RequiredScore{
public  int = 8            public static Tag {get; set;}
public  int = 4            public static Rest {get; set;}
public  int = 10            public static BondageBunny {get; set;}
        }

        public class Globals{

            //Tag
public  int = 4            public static turnsToWaitBetweenTwoTags {get; set;}
            //Bondage
public  int = 4            public static maxBondageItemsOnSelf {get; set;}
public  int = 2            public static difficultyIncreasePerBondageItem {get; set;}
            //Focus
public  int = 6            public static maxTurnsWithoutFocus {get; set;}
            //Holds
public  int = 5            public static initialintOfTurnsForHold {get; set;}
public  int = 0.5            public static holdDamageMultiplier {get; set;}
            //Rest
public  int = 0.30            public static hpPercentageToHealOnRest {get; set;}
public  int = 0.30            public static lpPercentageToHealOnRest {get; set;}
public  int = 0.30            public static fpPercentageToHealOnRest {get; set;}
            //Forced Lewd
public  int = 4            public static forcedWorshipLPMultiplier {get; set;}
            //HighRisk
public  int = 2            public static multiplierHighRiskAttack {get; set;}
            //Stun
public  int = 0.33            public static stunHPDamageMultiplier {get; set;}
public  int = 2            public static dicePenaltyMultiplierWhileStunned {get; set;}

public  int = 6            public static passFpDamage {get; set;}

public  int = 2            public static fpHealOnNextTurn {get; set;}

public int = 10            public static tapoutOnlyAfterTurnint {get; set;}


            //Bonuses
public  int = 3            public static maxTagBonus {get; set;}

public  int = 3            public static itemPickupUses {get; set;}
public  int = 5            public static itemPickupBonusDiceScore {get; set;}
public  int = 1.5            public static itemPickupDamageMultiplier {get; set;}

public int = 3            public static sextoyPickupUses {get; set;}
public  int = 5            public static sextoyPickupBonusDiceScore {get; set;}
public  int = 1.5            public static sextoyPickupDamageMultiplier {get; set;}

public  int = 5            public static degradationUses {get; set;}
public  int = 10            public static degradationFocusDamage {get; set;}
public  int = 1.66            public static degradationFocusMultiplier {get; set;}

public  int = 3            public static accuracyForBrawlInsideSubHold {get; set;}
public  int = 3            public static accuracyForSexStrikeInsideSexHold {get; set;}
        }
    }
}

public enum BaseDamage {
    Light = 1,
    Medium = 10,
    Heavy = 20
}

public enum FocusDamageOnMiss {
    None = 1,
    Light = 3,
    Medium = 6,
    Heavy = 10
}

public enum FocusHealOnHit {
    None = 1,
    Light = 6,
    Medium = 12,
    Heavy = 18
}

public enum FocusDamageOnHit {
    Light = 5,
    Medium = 10,
    Heavy = 15
}

public enum StrapToyLPDamagePerTurn {
    Light = 4,
    Medium = 8,
    Heavy = 12
}

public enum StrapToyDiceRollPenalty {
    Light = 3,
    Medium = 5,
    Heavy = 7
}

public enum FailedHighRiskMultipliers {
    Light = 0.6,
    Medium = 0.5,
    Heavy = 0.4
}

public enum HighRiskMultipliers {
    Light = 1.3,
    Medium = 1.5,
    Heavy = 1.8
}

public enum MasturbateLpDamage {
    Light = 5,
    Medium = 10,
    Heavy = 20
}

public enum SelfDebaseFpDamage {
    Light = 8,
    Medium = 16,
    Heavy = 24
}

public enum ModifierType {
    SubHoldBrawlBonus = "Accuracy++ on brawl (submission hold)",
    SubHold = "submission hold",
    SexHoldLustBonus = "Accuracy++ on tease (sexual hold)",
    SexHold = "sexual hold",
    Bondage = "bondage items",
    HumHold = "humiliation hold",
    DegradationMalus = "degradation malus",
    ItemPickupBonus = "HP Dmg++ (item pickup)",
    SextoyPickupBonus = "LP Dmg++ (sextoy pickup)",
    Stun = "stun",
    StrapToy = "strapped sex-toy",
    DummyModifier = "unused modifier"
}

public class Feature {
    static KickStart = "Kick Start";
    static SexyKickStart = "Sexy Kick Start";
    static Sadist = "Sadist";
    static CumSlut = "Cum Slut";
    static RyonaEnthusiast = "Ryona Enthusiast";
    static DomSubLover = "Dom Sub Lover";
    static BondageBunny = "Bondage Bunny";
    static BondageHandicap = "Bondage Handicap (1 item)";
}

public enum FeatureType {
    KickStart = "Kick Start feature",
    SexyKickStart = "Sexy Kick Start feature",
    Sadist = "Sadist feature",
    CumSlut = "Cum Slut feature",
    RyonaEnthusiast = "Ryona Enthusiast feature",
    DomSubLover = "D/s Lover feature",
    BondageBunny = "Bondage Bunny feature",
    BondageHandicap = "Bondage Handicap feature"
}

public enum FeatureEffect {
    CreateModifier = "creates a modifier",
    DamageTweaker = "changes the action's damage"
}

public enum FeatureCostPerUse {
    KickStart = 5,
    SexyKickStart = 5,
    Sadist = 0,
    CumSlut = 0,
    RyonaEnthusiast = 0,
    DomSubLover = 0,
    BondageBunny = 0,
    BondageHandicap = 0
}

public class FeatureExplain {
    static KickStart = "They start with an offensive item in their hand, meaning to do more damage.";
    static SexyKickStart = "They start with a sextoy in their hand, meaning to do more lust damage.";
    static Sadist = "Dealing HP damage to the opponent will deal the same amount divided by two to the wearer's Lust.";
    static CumSlut = "Increases all Lust damage done to the wearer by 3.";
    static RyonaEnthusiast = "Taking HP damage also increases the wearer's Lust by the same amount divided by two.";
    static DomSubLover = "Replaces focus by submissiveness. Purely visual.";
    static BondageBunny = "They can be tied up without applying a hold.";
    static BondageHandicap = "They start the fight already wearing one bondage item.";
}