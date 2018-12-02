enum Trigger {
    MainBarDamage = 1 << 0,
    SecondaryBarDamage = 1 << 1,
    UtilitaryBarDamage = 1 << 2,
    Damage = MainBarDamage | SecondaryBarDamage,
    BarDamage = Damage | UtilitaryBarDamage,

    MainBarHealing = 1 << 3,
    SecondaryBarHealing = 1 << 4,
    UtilitaryBarHealing = 1 << 5,
    Heal = MainBarHealing | SecondaryBarHealing,
    BarHealing = Heal | UtilitaryBarDamage,

    MainBarDepleted = 1 << 6,
    SecondaryBarDepleted = 1 << 7,
    LifeLoss = MainBarDepleted | SecondaryBarDepleted,

    InitiationRoll = 1 << 8,
    SingleRoll = 1 << 9,
    Roll = SingleRoll | InitiationRoll,

    PhysicalAttack = 1 << 10,
    Stun = 1 << 11,
    MagicalAttack = 1 << 12,
    RangedAttack = 1 << 13,
    GrapplingHold = 1 << 14,
    SpecialAttack = 1 << 15,
    Attack = PhysicalAttack | Stun | MagicalAttack | RangedAttack | GrapplingHold,

    Tag = 1 << 16,
    Escape = 1 << 17,
    Rest = 1 << 18,
    Pass = 1 << 19,
    Submit = 1 << 20,
    PassiveAction = Tag | Escape | Rest | Pass,
    AnyAction = PassiveAction | Attack,

    BonusPickup = 1 << 21,

    TurnChange = 1 << 22,
    None = 1 << 23,

    FinishingMove = 1 << 24

    //There's still room for 8 more triggers, but choose them with precaution!
}