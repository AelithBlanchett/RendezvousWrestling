using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using System;
using System.Collections.Generic;
using System.Linq;

public class RWActiveAction : BaseActiveAction<RendezVousWrestling, RWAchievement, RWActionFactory, RWActiveAction, RWFeature, RWFeatureFactory, RWFight, RWFighterState, RWFighterStats, RWModifier, RWUser, RWFeatureParameter>
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

    public List<RWModifier> appliedModifiers { get; set; } = new List<RWModifier>();

    public RWActiveAction() : base()
    {

    }

    public RWActiveAction(RWFight fight,
                            RWFighterState attacker,
                            List<RWFighterState> defenders,
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
                var name = Enum.GetName(typeof(Tiers), ((Tiers)this.Tier));
                var score = (int)Enum.Parse(typeof(TierDifficulty), name);
                scoreRequired += this.addRequiredScoreWithExplanation(score, "TIER");
            }

            scoreRequired += this.addRequiredScoreWithExplanation((int)(Action.Globals.difficultyIncreasePerBondageItem * this.Attacker.bondageItemsOnSelf()), "BDG");

            //No effects apply if it's a multi-target action. Should we have any?
            if (this.SingleTarget && this.Defender != null)
            {
                scoreRequired += this.addRequiredScoreWithExplanation(-(int)(Action.Globals.difficultyIncreasePerBondageItem * this.Defender.bondageItemsOnSelf()), "BDG");
                scoreRequired += this.addRequiredScoreWithExplanation((int)Math.Floor((this.Defender.currentDexterity - this.Attacker.currentDexterity) / 15f), "DEXDIFF");

                if (this.Defender.focus >= 0)
                {
                    scoreRequired += this.addRequiredScoreWithExplanation((int)Math.Floor((this.Defender.focus - this.Attacker.focus) / 15f), "FPDIFF");
                }
                if (this.Defender.focus < 0)
                {
                    scoreRequired += this.addRequiredScoreWithExplanation((int)Math.Floor(this.Defender.focus / 10f) - 1, "FPZERO");
                }

                var DefenderStunnedTier = this.Defender.getStunnedTier();
                if (DefenderStunnedTier >= (int)Tiers.Light)
                {
                    switch (DefenderStunnedTier)
                    {
                        case (int)Tiers.Light:
                            scoreRequired += this.addRequiredScoreWithExplanation(-2, "L-STUN");
                            break;
                        case (int)Tiers.Medium:
                            scoreRequired += this.addRequiredScoreWithExplanation(-4, "M-STUN");
                            break;
                        case (int)Tiers.Heavy:
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
        var name = Enum.GetName(typeof(Tiers), ((Tiers)this.Tier));
        this.Attacker.hitFP((int)Enum.Parse(typeof(FocusDamageOnMiss), name));
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
                    var existantHoldForDefender = Defender.modifiers.First(x => x.isAHold());
                    if (existantHoldForDefender != null)
                    {
                        var idOfFormerHold = existantHoldForDefender.Id;
                        foreach (var mod in Defender.modifiers)
                        {
                            //we updated the children and parent's damage and turns
                            if (mod.Id == idOfFormerHold)
                            {
                                mod.name = this.appliedModifiers[indexOfNewHold].name;
                                mod.triggeringEvent = this.appliedModifiers[indexOfNewHold].triggeringEvent;
                                mod.uses += this.appliedModifiers[indexOfNewHold].uses;
                                mod.hpDamage += this.appliedModifiers[indexOfNewHold].hpDamage;
                                mod.lustDamage += this.appliedModifiers[indexOfNewHold].lustDamage;
                                mod.focusDamage += this.appliedModifiers[indexOfNewHold].focusDamage;
                                //Did not add the dice/escape score modifications, if needed, implement here
                            }
                            else if (mod.idParentActions != null && mod.idParentActions.IndexOf(idOfFormerHold) != -1)
                            {
                                mod.uses += this.appliedModifiers[indexOfNewHold].uses;
                            }
                        }
                        foreach (var mod in this.Attacker.modifiers)
                        {
                            //upDateTime the bonus appliedModifiers length
                            if (mod.idParentActions != null && mod.idParentActions.IndexOf(idOfFormerHold) != -1)
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
                            if (mod.Receiver.Name == Defender.Name)
                            {
                                Defender.modifiers.Add(mod);
                            }
                            else if (mod.Receiver.Name == this.Attacker.Name)
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
                    if (mod.Receiver == this.Attacker)
                    {
                        this.Attacker.modifiers.Add(mod);
                    }
                    else if (this.Defenders.FindIndex(x => x.Name == mod.Receiver.Name) != -1)
                    {
                        this.Defenders.First(x => x.Name == mod.Receiver.Name).modifiers.Add(mod);
                    }
                }
            }
        }
    }

    public override void onHit()
    {
        throw new NotImplementedException();
    }
}

public class EmptyAction : RWActiveAction
{

    public EmptyAction(RWFight fight, RWFighterState defender, RWFighterState attacker) : base(fight, attacker, new List<RWFighterState>() { defender }, "actionName", -1, false, false, false, true, true, false, true, false, true, false, true, false, true, false, false, true, false, true, false, false, true, Trigger.None, "no explanation", 1)
    {


    }

    public override void onHit()
    {

    }
}

public enum ActionType
{
    Brawl = 0,
    Tease = 1,
    Tag = 2,
    Rest = 3,
    SubHold = 4,
    SexHold = 5,
    Bondage = 6,
    HumHold = 7,
    ItemPickup = 8,
    SextoyPickup = 9,
    Degradation = 10,
    ForcedWorship = 11,
    HighRisk = 12,
    RiskyLewd = 13,
    Stun = 14,
    Escape = 15,
    Submit = 16,
    StrapToy = 17,
    Finisher = 18,
    Masturbate = 19,
    Pass = 20,
    ReleaseHold = 21,
    SelfDebase = 22
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