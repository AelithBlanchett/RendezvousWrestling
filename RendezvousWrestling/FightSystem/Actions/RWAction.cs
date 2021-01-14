using System;
using System.Collections.Generic;
using System.Linq;

public abstract class RWAction : BaseActiveAction<RWFight, RWFighterState>
{

    public List<int> hpDamageToDefs { get; set; } = new List<int>();
    public List<int> lpDamageToDefs { get; set; } = new List<int>();
    public List<int> fpDamageToDefs { get; set; } = new List<int>();
    public int hpDamageToAtk { get; set; } = 0;
    public int lpDamageToAtk { get; set; } = 0;
    public int fpDamageToAtk { get; set; } = 0;
    public List<int> hpHealToDefs { get; set; } = new List<int>();
    public List<int> lpHealToDefs { get; set; } = new List<int>();
    public List<int> fpHealToDefs { get; set; } = new List<int>();
    public int hpHealToAtk { get; set; } = 0;
    public int lpHealToAtk { get; set; } = 0;
    public int fpHealToAtk { get; set; } = 0;

    public int diceScoreBaseDamage { get; set; }
    public int diceScoreStatDifference { get; set; }
    public int diceScoreBonusPoints { get; set; }

    public List<BaseModifier> appliedModifiers { get; set; } = new List<BaseModifier>();

    public RWAction(BaseFight fight,
                            BaseFighterState attacker,
                            List<BaseFighterState> defenders,
                            string name,
                             int tier,
                             bool isHold,
                            bool requiresRoll,
                            bool keepActorsTurn,
                            bool singleTarget,
                            bool requiresBeingAlive,
                            bool requiresBeingDead,
                            bool requiresBeingInRing,
                            bool requiresBeingOffRing,
                            bool targetMustBeAlive,
                            bool targetMustBeDead,
                            bool targetMustBeInRing,
                            bool targetMustBeOffRing,
                            bool targetMustBeInRange,
                            bool targetMustBeOffRange,
                            bool requiresBeingInHold,
                            bool requiresNotBeingInHold,
                            bool targetMustBeInHold,
                            bool targetMustNotBeInHold,
                            bool usableOnSelf,
                            bool usableOnAllies,
                            bool usableOnEnemies,
                            Trigger trigger,
                            string explanation = null,
                                            int? maxTargets = null) : base(fight,
                            attacker,
                            defenders,
                            name,
                            tier,
                            isHold,
                            requiresRoll,
                            keepActorsTurn,
                            singleTarget,
                            requiresBeingAlive,
                            requiresBeingDead,
                            requiresBeingInRing,
                            requiresBeingOffRing,
                            targetMustBeAlive,
                            targetMustBeDead,
                            targetMustBeInRing,
                            targetMustBeOffRing,
                            targetMustBeInRange,
                            targetMustBeOffRange,
                            requiresBeingInHold,
                            requiresNotBeingInHold,
                            targetMustBeInHold,
                            targetMustNotBeInHold,
                            usableOnSelf,
                            usableOnAllies,
                            usableOnEnemies,
                            trigger,
                            explanation,
                            maxTargets)
    {

    }

    public int avgHpDamageToDefs
    {
        get
        {
            if (this.hpDamageToDefs != null && this.hpDamageToDefs.Count == 1)
            {
                return this.hpDamageToDefs[0];
            }
            else if (this.hpDamageToDefs != null && this.hpDamageToDefs.Count > 1)
            {
                return this.hpDamageToDefs.Aggregate((a, b) => a + b);
            }
            else
            {
                return 0;
            }
        }
    }

    public int avgLpDamageToDefs
    {
        get
        {
            if (this.lpDamageToDefs != null && this.lpDamageToDefs.Count == 1)
            {
                return this.lpDamageToDefs[0];
            }
            else if (this.lpDamageToDefs != null && this.lpDamageToDefs.Count > 1)
            {
                return this.lpDamageToDefs.Aggregate((a, b) => a + b);
            }
            else
            {
                return 0;
            }
        }
    }

    public int avgFpDamageToDefs
    {
        get
        {
            if (this.fpDamageToDefs != null && this.fpDamageToDefs.Count == 1)
            {
                return this.fpDamageToDefs[0];
            }
            else if (this.fpDamageToDefs != null && this.fpDamageToDefs.Count > 1)
            {
                return this.fpDamageToDefs.Aggregate((a, b) => a + b);
            }
            else
            {
                return 0;
            }
        }
    }

    public int hpDamageToDef
    {
        get
        {
            if (this.hpDamageToDefs != null && this.hpDamageToDefs.Count == 1)
            {
                return this.hpDamageToDefs[0];
            }
            else
            {
                return 0;
            }
        }
        set
        {
            this.hpDamageToDefs = new List<int>() { value };
        }
    }



    public int lpDamageToDef
    {
        get
        {
            if (this.lpDamageToDefs != null && this.lpDamageToDefs.Count == 1)
            {
                return this.lpDamageToDefs[0];
            }
            else
            {
                return 0;
            }
        }
        set
        {
            this.lpDamageToDefs = new List<int>() { value };
        }
    }



    public int fpDamageToDef
    {
        get
        {
            if (this.fpDamageToDefs != null && this.fpDamageToDefs.Count == 1)
            {
                return this.fpDamageToDefs[0];
            }
            else
            {
                return 0;
            }
        }
        set
        {
            this.fpDamageToDefs = new List<int>() { value };
        }
    }



    public int hpHealToDef
    {
        get
        {
            if (this.hpHealToDefs != null && this.hpHealToDefs.Count == 1)
            {
                return this.hpHealToDefs[0];
            }
            else
            {
                return 0;
            }
        }
        set
        {
            this.hpHealToDefs = new List<int>() { value
};
        }
    }



    public int lpHealToDef
    {
        get
        {
            {
                if (this.lpHealToDefs != null && this.lpHealToDefs.Count == 1)
                {
                    return this.lpHealToDefs[0];
                }
                else
                {
                    return 0;
                }
            }
        }
        set
        {
            this.lpHealToDefs = new List<int>() { value };
        }
    }



    public int fpHealToDef
    {
        get
        {
            if (this.fpHealToDefs != null && this.fpHealToDefs.Count == 1)
            {
                return this.fpHealToDefs[0];
            }
            else
            {
                return 0;
            }
        }
        set
        {
            this.fpHealToDefs = new List<int>() { value };
        }
    }

    public int attackFormula(FightTier tier, int targetDef, int roll, int actorAtk)
    {
        int statDiff = 0;
        if (actorAtk - targetDef > 0)
        {
            statDiff = (int)Math.Ceiling((actorAtk - targetDef) / 10m);
        }

        int diceBonus = 0;
        //var calculatedBonus = Math.Floor((roll - TierDifficulty[Tiers[tier]]) / 2);
        //if (calculatedBonus > 0)
        //{
        //    diceBonus = calculatedBonus;
        //}

        // this.diceScoreBaseDamage = parseInt(BaseDamage[Tiers[tier]]);
        this.diceScoreStatDifference = statDiff;
        this.diceScoreBonusPoints = diceBonus;

        return this.diceScoreBaseDamage + this.diceScoreStatDifference + this.diceScoreBonusPoints;
    }

    public override int SpecificRequiredDiceScore
    {
        get
        {
            var scoreRequired = 0;

            if (this.Tier != -1)
            {
                scoreRequired += this.addRequiredScoreWithExplanation(TierDifficulty[Tiers[this.Tier]], "TIER");
            }

            scoreRequired += this.addRequiredScoreWithExplanation((Constants.Fight.Action.Globals.difficultyIncreasePerBondageItem * this.Attacker.bondageItemsOnSelf()), "BDG");

            //No effects apply if it's a multi-target action. Should we have any?
            if (this.SingleTarget && this.Defender)
            {
                scoreRequired += this.addRequiredScoreWithExplanation(-(Constants.Fight.Action.Globals.difficultyIncreasePerBondageItem * this.Defender.bondageItemsOnSelf()), "BDG");
                scoreRequired += this.addRequiredScoreWithExplanation(Math.floor((this.Defender.currentDexterity - this.Attacker.currentDexterity) / 15), "DEXDIFF");

                if (this.Defender.focus >= 0)
                {
                    scoreRequired += this.addRequiredScoreWithExplanation(Math.floor((this.Defender.focus - this.Attacker.focus) / 15), "FPDIFF");
                }
                if (this.Defender.focus < 0)
                {
                    scoreRequired += this.addRequiredScoreWithExplanation(Math.floor(this.Defender.focus / 10) - 1, "FPZERO");
                }

                var DefenderStunnedTier = this.Defender.getStunnedTier();
                if (DefenderStunnedTier >= Tiers.Light)
                {
                    switch (DefenderStunnedTier)
                    {
                        case Tiers.Light:
                            scoreRequired += this.addRequiredScoreWithExplanation(-2, "L-STUN");
                            break;
                        case Tiers.Medium:
                            scoreRequired += this.addRequiredScoreWithExplanation(-4, "M-STUN");
                            break;
                        case Tiers.Heavy:
                            scoreRequired += this.addRequiredScoreWithExplanation(-6, "H-STUN");
                            break;
                    }
                }
            }

            return scoreRequired;
        }
    }

    public override void onMiss()
    {
        this.Attacker.hitFP(FocusDamageOnMiss[Tiers[this.tier]]);
    }

    public override void applyDamage()
    {
        if (this.hpDamageToDefs.Count > 0)
        {
            for (var i = 0; i < this.hpDamageToDefs.Count; i++)
            {
                if (this.hpDamageToDefs[i] > 0)
                {
                    this.Defenders[i].hitHP(this.hpDamageToDefs[i]);
                }
            }
        }
        if (this.lpDamageToDefs.Count > 0)
        {
            for (var i = 0; i < this.lpDamageToDefs.Count; i++)
            {
                if (this.lpDamageToDefs[i] > 0)
                {
                    this.Defenders[i].hitLP(this.lpDamageToDefs[i]);
                }
            }
        }
        if (this.fpDamageToDefs.Count > 0)
        {
            for (var i = 0; i < this.fpDamageToDefs.Count; i++)
            {
                if (this.fpDamageToDefs[i] > 0)
                {
                    this.Defenders[i].hitFP(this.fpDamageToDefs[i]);
                }
            }
        }
        if (this.hpHealToDefs.Count > 0)
        {
            for (var i = 0; i < this.hpHealToDefs.Count; i++)
            {
                if (this.hpHealToDefs[i] > 0)
                {
                    this.Defenders[i].healHP(this.hpHealToDefs[i]);
                }
            }
        }
        if (this.lpHealToDefs.Count > 0)
        {
            for (var i = 0; i < this.lpHealToDefs.Count; i++)
            {
                if (this.lpHealToDefs[i] > 0)
                {
                    this.Defenders[i].healLP(this.lpHealToDefs[i]);
                }
            }
        }
        if (this.fpHealToDefs.Count > 0)
        {
            for (var i = 0; i < this.fpHealToDefs.Count; i++)
            {
                if (this.fpHealToDefs[i] > 0)
                {
                    this.Defenders[i].healFP(this.fpHealToDefs[i]);
                }
            }
        }

        if (this.hpDamageToAtk > 0)
        {
            this.Attacker.hitHP(this.hpDamageToAtk);
        }
        if (this.lpDamageToAtk > 0)
        {
            this.Attacker.hitLP(this.lpDamageToAtk);
        }
        if (this.fpDamageToAtk > 0)
        {
            this.Attacker.hitFP(this.fpDamageToAtk);
        }
        if (this.hpHealToAtk > 0)
        {
            this.Attacker.healHP(this.hpHealToAtk);
        }
        if (this.lpHealToAtk > 0)
        {
            this.Attacker.healLP(this.lpHealToAtk);
        }
        if (this.fpHealToAtk > 0)
        {
            this.Attacker.healFP(this.fpHealToAtk);
        }


        if (this.appliedModifiers.Count > 0)
        {
            if (this.IsHold)
            { //for any holds, do the stacking here
                var indexOfNewHold = this.appliedModifiers.FindIndex(x => x.isAHold());

                foreach (var defender in this.Defenders)
                {
                    //START
                    var indexOfAlreadyExistantHoldForDefender = Defender.modifiers.FindIndex(x => x.isAHold());
                    if (indexOfAlreadyExistantHoldForDefender != -1)
                    {
                        var idOfFormerHold = Defender.modifiers[indexOfAlreadyExistantHoldForDefender].idModifier;
                        foreach (var mod in Defender.modifiers)
                        {
                            //we updated the children and parent's damage and turns
                            if (mod.idModifier == idOfFormerHold)
                            {
                                mod.name = this.appliedModifiers[indexOfNewHold].name;
                                mod.triggeringEvent = this.appliedModifiers[indexOfNewHold].triggeringEvent;
                                mod.uses += this.appliedModifiers[indexOfNewHold].uses;
                                mod.hpDamage += this.appliedModifiers[indexOfNewHold].hpDamage;
                                mod.lustDamage += this.appliedModifiers[indexOfNewHold].lustDamage;
                                mod.focusDamage += this.appliedModifiers[indexOfNewHold].focusDamage;
                                //Did not add the dice/escape score modifications, if needed, implement here
                            }
                            else if (mod.idParentActions && mod.idParentActions.IndexOf(idOfFormerHold) != -1)
                            {
                                mod.uses += this.appliedModifiers[indexOfNewHold].uses;
                            }
                        }
                        foreach (var mod in this.Attacker.modifiers)
                        {
                            //upDateTime the bonus appliedModifiers length
                            if (mod.idParentActions && mod.idParentActions.IndexOf(idOfFormerHold) != -1)
                            {
                                mod.uses += this.appliedModifiers[indexOfNewHold].uses;
                            }
                        }
                        //this.Fight.message.addSpecial($"[b][color=red]Hold Stacking![/color][/b] ${Defender.getStylizedName()} will have to suffer this hold for ${this.appliedModifiers[indexOfNewHold].uses} more turns, and will also suffer a bit more, as it has added
                        //                 ${ (this.appliedModifiers[indexOfNewHold].hpDamage > 0 ? " -" + this.appliedModifiers[indexOfNewHold].hpDamage + " HP per turn " : "")}
                        //                 ${ (this.appliedModifiers[indexOfNewHold].lustDamage > 0 ? " +" + this.appliedModifiers[indexOfNewHold].lustDamage + " Lust per turn " : "")}
                        //                 ${ (this.appliedModifiers[indexOfNewHold].focusDamage > 0 ? " -" + this.appliedModifiers[indexOfNewHold].focusDamage + " Focus per turn" : "")}
                        //");
                    }
                    else
                    {
                        foreach (var mod in this.appliedModifiers)
                        {
                            if (mod.receiver.name == Defender.name)
                            {
                                Defender.modifiers.Add(mod);
                            }
                            else if (mod.receiver.name == this.Attacker.name)
                            {
                                this.Attacker.modifiers.Add(mod);
                            }
                        }
                    }


                }
            }
            else
            {
                foreach (var mod in this.appliedModifiers)
                {
                    if (mod.receiver == this.Attacker)
                    {
                        this.Attacker.modifiers.Add(mod);
                    }
                    else if (this.Defenders.FindIndex(x => x.name == mod.receiver.name) != -1)
                    {
                        this.Defenders.First(x => x.name == mod.receiver.name).modifiers.Add(mod);
                    }
                }
            }
        }
    }

}

public class EmptyAction : RWAction
{

    public EmptyAction(BaseFight fight, BaseFighterState defender, BaseFighterState attacker) : base(fight, attacker, new List<BaseFighterState>() { defender }, "actionName", -1, false, false, false, true, true, false, true, false, true, false, true, false, true, false, false, true, false, true, false, false, true, Trigger.None, "no explanation", 1)
    {


    }

    public override void onHit()
    {

    }
}

public class ActionType
{
    public static string Brawl = "Brawl";
    public static string Tease = "Tease";
    public static string Tag = "Tag";
    public static string Rest = "Rest";
    public static string SubHold = "SubHold";
    public static string SexHold = "SexHold";
    public static string Bondage = "Bondage";
    public static string HumHold = "HumHold";
    public static string ItemPickup = "ItemPickup";
    public static string SextoyPickup = "SextoyPickup";
    public static string Degradation = "Degradation";
    public static string ForcedWorship = "ForcedWorship";
    public static string HighRisk = "HighRisk";
    public static string RiskyLewd = "RiskyLewd";
    public static string Stun = "Stun";
    public static string Escape = "Escape";
    public static string Submit = "Submit";
    public static string StrapToy = "StrapToy";
    public static string Finisher = "Finisher";
    public static string Masturbate = "Masturbate";
    public static string Pass = "Pass";
    public static string ReleaseHold = "ReleaseHold";
    public static string SelfDebase = "SelfDebase";
}

public class ActionExplanation
{
    public static string Tag = "[b][color=red]TAG![/color][/b] %s heads out of the ring!";
    public static string Rest = "[b][color=red]%s rests for a bit![/color][/b]";
    public static string Bondage = "[b][color=red]%s just tied up their opponent a little bit more![/color][/b]";
    public static string ItemPickup = "[b][color=red]%s's picked up item looks like it could it hit hard![/color][/b]";
    public static string SextoyPickup = "[b][color=red]%s is going to have a lot of fun with this sex-toy![/color][/b]";
    public static string Escape = "[b][color=red]%s got away![/color][/b]";
    public static string Submit = "[b][color=red]%s taps out! It's over, it's done![/color][/b]";
    public static string Masturbate = "[b][color=red]%s really needed those strokes apparently![/color][/b]";
    public static string Pass = "[b][color=red]%s passed their turn...[/color][/b]";
    public static string SelfDebase = "[b][color=red]%s is sinking deeper...[/color][/b]";
}