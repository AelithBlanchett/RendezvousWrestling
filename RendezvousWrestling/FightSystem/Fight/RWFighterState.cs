
using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using System;
using System.Collections.Generic;
using RendezvousWrestling.Common.DataContext;

public class RWFighterState : BaseFighterState<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierParameters, RWModifierType, RWUser>
{

    public int hp { get; set; } = 0;
    public int lust { get; set; } = 0;
    public int livesRemaining { get; set; } = 0;
    public int focus { get; set; } = 0;
    public int consecutiveTurnsWithoutFocus { get; set; }

    public int startingPower { get; set; }
    public int startingSensuality { get; set; }
    public int startingToughness { get; set; }
    public int startingEndurance { get; set; }
    public int startingDexterity { get; set; }
    public int startingWillpower { get; set; }
    public int powerDelta { get; set; }
    public int sensualityDelta { get; set; }
    public int toughnessDelta { get; set; }
    public int enduranceDelta { get; set; }
    public int dexterityDelta { get; set; }
    public int willpowerDelta { get; set; }

    public int hpDamageLastRound { get; set; } = 0;
    public int lpDamageLastRound { get; set; } = 0;
    public int fpDamageLastRound { get; set; } = 0;
    public int hpHealLastRound { get; set; } = 0;
    public int lpHealLastRound { get; set; } = 0;
    public int fpHealLastRound { get; set; } = 0;
    public int heartsDamageLastRound { get; set; } = 0;
    public int orgasmsDamageLastRound { get; set; } = 0;
    public int heartsHealLastRound { get; set; } = 0;
    public int orgasmsHealLastRound { get; set; } = 0;

    public RWFighterState() : base()
    {

    }

    public RWFighterState(RWFight fight, RWUser user) : base(fight, user)
    {

        this.startingToughness = user.toughness;
        this.startingEndurance = user.endurance;
        this.startingWillpower = user.willpower;
        this.startingSensuality = user.sensuality;
        this.startingPower = user.power;
        this.startingDexterity = user.dexterity;

        this.hp = this.hpPerHeart();
        this.lust = 0;
        this.livesRemaining = this.maxLives();
        this.focus = this.initialFocus();
        this.consecutiveTurnsWithoutFocus = 0;

        this.powerDelta = 0;
        this.sensualityDelta = 0;
        this.toughnessDelta = 0;
        this.enduranceDelta = 0;
        this.dexterityDelta = 0;
        this.willpowerDelta = 0;

        this.hpDamageLastRound = 0;
        this.lpDamageLastRound = 0;
        this.fpDamageLastRound = 0;
        this.hpHealLastRound = 0;
        this.lpHealLastRound = 0;
        this.fpHealLastRound = 0;
        this.heartsDamageLastRound = 0;
        this.orgasmsDamageLastRound = 0;
        this.heartsHealLastRound = 0;
        this.orgasmsHealLastRound = 0;
    }

    public int initialFocus()
    {
        return this.maxFocus();
    }

    public int maxFocus()
    {
        return 30 + this.focusResistance();
    }

    public decimal totalHp()
    {
        var hp = 130m;
        if (this.currentToughness > 10)
        {
            hp += (this.currentToughness - 10);
        }
        switch (this.fightDuration())
        {
            case FightLength.Epic:
                hp = hp * 1.33m;
                break;
            case FightLength.Long:
                hp = hp * 1.00m;
                break;
            case FightLength.Medium:
                hp = hp * 0.66m;
                break;
            case FightLength.Short:
                hp = hp * 0.33m;
                break;
        }
        return hp;
    }

    public int hpPerHeart()
    {
        return (int)Math.Ceiling(this.totalHp() / this.maxLives() * 1m);
    }

    public decimal totalLust()
    {
        decimal lust = 130m;
        if (this.currentEndurance > 10)
        {
            lust += (this.currentEndurance - 10);
        }
        switch (this.fightDuration())
        {
            case FightLength.Epic:
                lust = lust * 1.33m;
                break;
            case FightLength.Long:
                lust = lust * 1.00m;
                break;
            case FightLength.Medium:
                lust = lust * 0.66m;
                break;
            case FightLength.Short:
                lust = lust * 0.33m;
                break;
        }
        return lust;
    }

    public int lustPerOrgasm()
    {
        return (int)Math.Ceiling(this.totalLust() / this.maxLives() * 1m);
    }

    public int maxLives()
    {
        var maxLives = -1;
        switch (this.fightDuration())
        {
            case FightLength.Epic:
                maxLives = 4;
                break;
            case FightLength.Long:
                maxLives = 3;
                break;
            case FightLength.Medium:
                maxLives = 2;
                break;
            case FightLength.Short:
                maxLives = 1;
                break;
        }
        return maxLives;
    }

    public int minFocus()
    {
        return 0;
    }

    public int focusResistance()
    {
        var resistance = 30;
        if (this.currentWillpower > 10)
        {
            resistance += (this.currentWillpower - 10);
        }
        return resistance;
    }

    public int maxBondageItemsOnSelf()
    {
        var maxBondageItemsOnSelf = -1;
        switch (this.fightDuration())
        {
            case FightLength.Epic:
                maxBondageItemsOnSelf = 5;
                break;
            case FightLength.Long:
                maxBondageItemsOnSelf = 4;
                break;
            case FightLength.Medium:
                maxBondageItemsOnSelf = 3;
                break;
            case FightLength.Short:
                maxBondageItemsOnSelf = 2;
                break;
        }
        return maxBondageItemsOnSelf;
    }

    public string getStatsInString()
    {
        return $"{this.User.power},{this.User.sensuality},{this.User.toughness},{this.User.endurance},{this.User.dexterity},{this.User.willpower}";
    }

    //fight is "mistakenly" set as optional to be compatible with the super.init
    public override void initialize()
    {
        base.initialize();
        this.startingToughness = this.User.toughness;
        this.startingEndurance = this.User.endurance;
        this.startingWillpower = this.User.willpower;
        this.startingSensuality = this.User.sensuality;
        this.startingPower = this.User.power;
        this.startingDexterity = this.User.dexterity;

        this.hp = this.hpPerHeart();
        this.lust = 0;
        this.livesRemaining = this.maxLives();
        this.focus = this.initialFocus();

        this.powerDelta = 0;
        this.sensualityDelta = 0;
        this.toughnessDelta = 0;
        this.enduranceDelta = 0;
        this.dexterityDelta = 0;
        this.willpowerDelta = 0;
    }

    public override string validateStats()
    {
        var statsInString = this.getStatsInString().Split(",");
        return Parser.checkIfValidStats(statsInString, GameSettings.intOfRequiredStatPoints, GameSettings.intOfDifferentStats, GameSettings.minStatLimit, GameSettings.maxStatLimit);
    }

    public int currentPower
    {
        get
        {
            return this.startingPower + this.powerDelta;
        }
        set
        {
            this.powerDelta += value;
        }

    }


    public int currentSensuality
    {
        get
        {
            return this.startingSensuality + this.sensualityDelta;
        }
        set
        {
            this.sensualityDelta += value;
        }
    }



    public int currentToughness
    {
        get
        {
            return this.startingToughness + this.toughnessDelta;
        }
        set
        {
            this.toughnessDelta += value;
        }
    }




    public int currentEndurance
    {
        get
        {
            return this.startingEndurance + this.enduranceDelta;
        }
        set
        {
            this.enduranceDelta += value;
        }
    }



    public int currentDexterity
    {
        get
        {
            return this.startingDexterity + this.dexterityDelta;
        }
        set
        {
            this.dexterityDelta += value;
        }
    }



    public int currentWillpower
    {
        get
        {
            return this.startingWillpower + this.willpowerDelta;
        }
        set
        {
            this.willpowerDelta += value;
        }
    }



    public int livesDamageLastRound
    {
        get
        {
            return this.heartsDamageLastRound + this.orgasmsDamageLastRound;
        }
    }

    public int livesHealLastRound
    {
        get
        {
            return this.heartsHealLastRound + this.orgasmsHealLastRound;
        }
    }

    public string displayRemainingLives
    {
        get
        {
            var str = "";
            for (var i = 1; i <= this.maxLives(); i++)
            {
                if (i < this.livesRemaining)
                {
                    str += "❤️";
                }
                else if (i == this.livesRemaining)
                {
                    str += "💓";
                }
                else
                {
                    str += "🖤";
                }
            }
            return str;
        }
    }

    public override void nextRound()
    {
        base.nextRound();
        this.hpDamageLastRound = 0;
        this.lpDamageLastRound = 0;
        this.fpDamageLastRound = 0;
        this.hpHealLastRound = 0;
        this.lpHealLastRound = 0;
        this.fpHealLastRound = 0;

        this.heartsDamageLastRound = 0;
        this.orgasmsDamageLastRound = 0;
        this.heartsHealLastRound = 0;
        this.orgasmsHealLastRound = 0;
    }

    public void healHP(decimal hp, bool triggerMods = true)
    {
        hp = (int)Math.Floor(hp);
        if (hp < 1)
        {
            hp = 1;
        }
        if (triggerMods)
        {
            this.triggerMods(TriggerMoment.Before, Trigger.MainBarHealing);
        }
        if (this.hp + hp > this.hpPerHeart())
        {
            hp = this.hpPerHeart() - this.hp; //reduce the int if it overflows the bar
        }
        this.hp += (int)hp;
        this.hpHealLastRound += (int)hp;
        if (triggerMods)
        {
            this.triggerMods(TriggerMoment.After, Trigger.MainBarHealing);
        }
    }

    public void healLP(decimal lust, bool triggerMods = true)
    {
        lust = (int)Math.Floor(lust);
        if (lust < 1)
        {
            lust = 1;
        }
        if (triggerMods)
        {
            this.triggerMods(TriggerMoment.Before, Trigger.SecondaryBarHealing);
        }
        if (this.lust - lust < 0)
        {
            lust = this.lust; //reduce the int if it overflows the bar
        }
        this.lust -= (int)lust;
        this.lpHealLastRound += (int)lust;
        if (triggerMods)
        {
            this.triggerMods(TriggerMoment.After, Trigger.SecondaryBarHealing);
        }
    }

    public void healFP(int focus, bool triggerMods = true)
    {
        focus = (int)Math.Floor(focus * 1m);
        if (focus < 1)
        {
            focus = 1;
        }
        if (triggerMods)
        {
            this.triggerMods(TriggerMoment.Before, Trigger.UtilitaryBarHealing);
        }
        if (this.focus + focus > this.maxFocus())
        {
            focus = this.maxFocus() - this.focus; //reduce the int if it overflows the bar
        }
        this.focus += focus;
        this.fpHealLastRound += focus;
        if (triggerMods)
        {
            this.triggerMods(TriggerMoment.After, Trigger.UtilitaryBarHealing);
        }
    }

    public void hitHP(int hp, bool triggerMods = true)
    {
        hp = (int)Math.Floor(hp * 1m);
        if (hp < 1)
        {
            hp = 1;
        }
        if (triggerMods)
        {
            this.triggerMods(TriggerMoment.Before, Trigger.MainBarDamage);
        }
        this.hp -= hp;
        this.hpDamageLastRound += hp;
        if (this.hp <= 0)
        {
            this.triggerMods(TriggerMoment.Before, Trigger.MainBarDepleted);
            this.hp = 0;
            //this.heartsRemaining--;
            this.livesRemaining--;
            this.heartsDamageLastRound += 1;
            this.Fight.message.addHit($"[b][color=red]Heart broken![/color][/b] {this.Name} has {this.livesRemaining} lives left.");
            if (this.livesRemaining > 0)
            {
                this.hp = this.hpPerHeart();
            }
            else if (this.livesRemaining == 1)
            {
                this.Fight.message.addHit($"[b][color=red]Last life[/color][/b] for {this.Name}!");
            }
            this.triggerMods(TriggerMoment.After, Trigger.MainBarDepleted);
        }
        if (triggerMods)
        {
            this.triggerMods(TriggerMoment.After, Trigger.MainBarDamage);
        }
    }

    public void hitLP(int lust, bool triggerMods = true)
    {
        lust = (int)Math.Floor(lust * 1m);
        if (lust < 1)
        {
            lust = 1;
        }
        if (triggerMods)
        {
            this.triggerMods(TriggerMoment.Before, Trigger.SecondaryBarDamage);
        }
        this.lust += lust;
        this.lpDamageLastRound += lust;
        if (this.lust >= this.lustPerOrgasm())
        {
            this.triggerMods(TriggerMoment.Before, Trigger.SecondaryBarDepleted);
            this.lust = 0;
            //this.orgasmsRemaining--;
            this.livesRemaining--;
            this.orgasmsDamageLastRound += 1;
            this.Fight.message.addHit($"[b][color=pink]Orgasm on the mat![/color][/b] {this.Name} has {this.livesRemaining} lives left.");
            this.lust = 0;
            if (triggerMods)
            {
                this.triggerMods(TriggerMoment.After, Trigger.SecondaryBarDepleted);
            }
            if (this.livesRemaining == 1)
            {
                this.Fight.message.addHit($"[b][color=red]Last life[/color][/b] for {this.Name}!");
            }
        }
        this.triggerMods(TriggerMoment.After, Trigger.SecondaryBarDamage);
    }

    public void hitFP(int focusDamage, bool triggerMods = true)
    {
        if (focusDamage <= 0)
        {
            return;
        }
        focusDamage = (int)Math.Floor(focusDamage * 1m);
        if (triggerMods)
        {
            this.triggerMods(TriggerMoment.Before, Trigger.UtilitaryBarDamage);
        }
        this.focus -= focusDamage;
        this.fpDamageLastRound += focusDamage;
        if (triggerMods)
        {
            this.triggerMods(TriggerMoment.After, Trigger.UtilitaryBarDamage);
        }
    }

    public bool isDead(bool displayMessage = false)
    {
        var condition = (this.livesRemaining == 0);
        if (condition && displayMessage)
        {
            this.Fight.message.addHit($"{this.getStylizedName()} couldn't take it anymore! They're out!");
        }
        return condition;
    }

    public bool isSexuallyExhausted(bool displayMessage = false)
    {
        var condition = (this.livesRemaining == 0);
        if (condition && displayMessage)
        {
            this.Fight.message.addHit($"{this.getStylizedName()} got wrecked sexually! They're out!");
        }
        return condition;
    }

    public bool isBroken(bool displayMessage = false)
    {
        //var condition = (this.consecutiveTurnsWithoutFocus >= RWGameSettings.maxTurnsWithoutFocus);
        //TODO 
        var condition = false;
        if (condition && displayMessage)
        {
            this.Fight.message.addHit($"{this.getStylizedName()} completely lost their focus! They're out!");
        }
        return condition;
    }

    public bool isCompletelyBound(bool displayMessage = false)
    {
        var condition = (this.bondageItemsOnSelf() >= this.maxBondageItemsOnSelf());
        if (condition && displayMessage)
        {
            this.Fight.message.addHit($"{this.getStylizedName()} is completely bound! They're out!");
        }
        return condition;
    }

    public override void save()
    {
        //throw new NotImplementedException();
    }

    public override bool isTechnicallyOut(bool displayMessage = false)
    {
        switch (this.Fight.fightType)
        {
            case FightType.Classic:
            case FightType.Tag:
                return (
                this.isSexuallyExhausted(displayMessage)
                || this.isDead(displayMessage)
                || this.isBroken(displayMessage)
                || this.isCompletelyBound(displayMessage));
            case FightType.LastManStanding:
                return this.isDead(displayMessage);
            case FightType.SexFight:
                return this.isSexuallyExhausted(displayMessage);
            case FightType.Humiliation:
                return this.isBroken(displayMessage) || this.isCompletelyBound(displayMessage);
            case FightType.Bondage:
                return this.isCompletelyBound(displayMessage);
            default:
                return false;
        }

    }

    public int bondageItemsOnSelf()
    {
        var bondageModCount = 0;
        foreach (var mod in this.modifiers)
        {
            if (mod.type == RWModifierType.Bondage)
            {
                bondageModCount++;
            }
        }
        return bondageModCount;
    }

    public override string outputStatus()
    {
        //TODO : Once DomSubLover is implemented, replace .Bondage with .DomSubLover
        //this.User.hasFeature(RWFeatureType.Bondage) >>>>> this.User.hasFeature(RWFeatureType.DomSubLover)
        var nameLine = $"{this.getStylizedName()}:";
        var hpLine = $"  [color=yellow]hit points: {this.hp}{((this.hpDamageLastRound > 0 || this.hpHealLastRound > 0) ? $"{(((-this.hpDamageLastRound + this.hpHealLastRound) < 0) ? "[color=red]" : "[color=green]")} ({Utils.getSignedNumber(-this.hpDamageLastRound + this.hpHealLastRound)})[/color]" : "")}|{this.hpPerHeart()}[/color] ";
        var lpLine = $"  [color=pink]lust points: {this.lust}{((this.lpDamageLastRound > 0 || this.lpHealLastRound > 0) ? $"{ (((-this.lpDamageLastRound + this.lpHealLastRound) < 0) ? "[color=red]" : "[color=green]")} ({Utils.getSignedNumber(this.lpDamageLastRound - this.lpHealLastRound)})[/color]" : "")}|{ this.lustPerOrgasm()}[/color] ";
        var livesLine = $"  [color=red]lives: {this.displayRemainingLives}{((this.orgasmsDamageLastRound > 0 || this.orgasmsHealLastRound > 0) ? $"{ (((-this.orgasmsDamageLastRound + this.orgasmsHealLastRound) < 0) ? "[color=red]" : "[color=green]")} ({Utils.getSignedNumber(-this.orgasmsDamageLastRound + this.orgasmsHealLastRound)} orgasm(s))[/color]" : "")}{ ((this.heartsDamageLastRound > 0 || this.heartsHealLastRound > 0) ? $"{ (((-this.heartsDamageLastRound + this.heartsHealLastRound) < 0) ? "[color=red]" : "[color=green]")} ({ Utils.getSignedNumber(-this.heartsDamageLastRound + this.heartsHealLastRound)} heart(s))[/color]" : "")} ({this.livesRemaining}|{this.maxLives()})[/color] ";
        var focusLine = $"  [color=orange]{(this.User.hasFeature(RWFeatureType.Bondage) ? "submissiveness" : "focus")}:[/color] [b][color={ (this.focus <= 0 ? "red" : "orange")}]{this.focus}[/color][/b]{(((this.fpDamageLastRound > 0 || this.fpHealLastRound > 0) && (this.fpDamageLastRound - this.fpHealLastRound != 0)) ? $"{ (((-this.fpDamageLastRound + this.fpHealLastRound) < 0) ? "[color=red]" : "[color=green]")} ({ Utils.getSignedNumber(-this.fpDamageLastRound + this.fpHealLastRound)})[/color]" : "")}|[color=green]{this.maxFocus()}[/color]";
        var turnsFocusLine = $"  [color=orange]turns {(this.User.hasFeature(RWFeatureType.Bondage) ? "being too submissive" : "without focus")}: {this.consecutiveTurnsWithoutFocus}|{ RWGameSettings.maxTurnsWithoutFocus}[/color]";
        var bondageLine = $"  [color=purple]bondage items {this.bondageItemsOnSelf()}|{ RWGameSettings.maxBondageItemsOnSelf}[/color] ";
        var modifiersLine = $"  [color=cyan]affected by: {this.getListOfActiveModifiers()}[/color] ";
        var targetLine = $"  [color=red]target(s): " +((this.targets != null && this.targets.Count > 0) ? $"{ string.Join(", ", this.targets)}" : "None set yet! (!targets charactername)") + "[/color]";

        return $"{nameLine.PadLeft(50, '-')} {hpLine} {lpLine} {livesLine} {focusLine} {turnsFocusLine} {bondageLine} {(this.getListOfActiveModifiers().Length > 0 ? modifiersLine : "")} {targetLine}";
    }
}