
public class ActionBondage : RWAction {

    constructor(RWFight fight,RWFighterState, defenders:RWFighterState[]  attacker) {
        super(fight,
            attacker,
            defenders,
            ActionType.Bondage,
            Tiers.None,
            false, //isHold
            true,  //requiresRoll
            false, //keepActorsTurn
            true,  //singleTarget
            true,  //requiresBeingAlive
            false, //requiresBeingDead
            true,  //requiresBeingInRing
            false, //requiresBeingOffRing
            true,  //targetMustBeAlive
            false, //targetMustBeDead
            true, //targetMustBeInRing
            false,  //targetMustBeOffRing
            true, //targetMustBeInRange
            false, //targetMustBeOffRange
            false, //requiresBeingInHold,
            false, //requiresNotBeingInHold,
            true, //targetMustBeInHold,
            false, //targetMustNotBeInHold,
            true, //usableOnSelf
            false,  //usableOnAllies
            false, //usableOnEnemies
            Trigger.SpecialAttack,
            ActionExplanation[ActionType.Bondage]);
    }

    addBonusesToRollFromStats():int{
        return Math.ceil(this.attacker.currentSensuality / 10);
    }

    get requiredDiceScore():int{
        if(this.defender.isInHold()){
            this.requiresRoll = false;
        }
        if(this.defender.user.hasFeature(FeatureType.BondageBunny)){
            return RWGameSettings.RequiredScoreForBondageAgainstBondageBunny;
        }
        return super.requiredDiceScore;
    }

    onHit(): void {
        this.fpHealToAtk += FocusHealOnHit[Tiers[Tiers.Heavy]];
        this.fpDamageToDef += FocusDamageOnHit[Tiers[Tiers.Heavy]];
        var bdModifier = ModifierFactory.getModifier(ModifierType.Bondage, this.fight, this.defender, this.attacker);
        this.appliedModifiers.Add(bdModifier);
    }
}