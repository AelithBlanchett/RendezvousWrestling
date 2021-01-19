using RendezvousWrestling.Common.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

public abstract class BaseFighterState<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType> : BaseEntity
    where TActionFactory : IActionFactory<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFeature : BaseFeature<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFeatureFactory : IFeatureFactory<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TUser : BaseUser<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFight : BaseFight<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFighterState : BaseFighterState<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TActiveAction : BaseActiveAction<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where OptionalParameterType : BaseFeatureParameter<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TAchievement : BaseAchievement<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TModifier : BaseModifier<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFighterStats : BaseFighterStats<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFightingGame : BaseFightingGame<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    public Team assignedTeam { get; set; } = Team.White;
    public List<string> targets { get; set; } = new List<string>();
    public bool isReady { get; set; } = false;
    public int lastDiceRoll { get; set; } = 0;
    public bool isInTheRing { get; set; } = true;
    public bool canMoveFromOrOffRing { get; set; } = true;
    public int lastTagTurn { get; set; } = 9999999;
    public bool wantsDraw { get; set; } = false;
    public int distanceFromRingCenter { get; set; }
    public FightStatus fightStatus { get; set; }

    [ForeignKey("Fight")]
    public string FightId { get; set; }
    public TFight Fight { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; }
    public TUser User { get; set; }

    [NotMapped]
    public List<TModifier> modifiers
    {
        get
        {
            return (List<TModifier>)ReceivedModifiers.Union(AppliedModifiers);
        }
    }

    public virtual List<TModifier> ReceivedModifiers { get; set; } = new List<TModifier>();

    public virtual List<TModifier> AppliedModifiers { get; set; } = new List<TModifier>();

    [NotMapped]
    public Dice dice { get; set; }

    [NotMapped]
    public string Name { get { return this.User.Id; } }

    public BaseFighterState()
    {
    }

    public BaseFighterState(TFight fight, TUser fighter)
    {
        this.Fight = fight;
        this.User = fighter;
        this.assignedTeam = Team.White;
        this.targets = null;
        this.isReady = false;

        this.lastDiceRoll = 0;
        this.isInTheRing = true;
        this.canMoveFromOrOffRing = true;
        this.lastTagTurn = 9999999;
        this.distanceFromRingCenter = 0;
        this.wantsDraw = false;;
        this.targets = new List<string>();

        this.dice = new Dice(GameSettings.diceSides);
        this.fightStatus = FightStatus.Idle;
        this.lastDiceRoll = 0;
    }

    public void assignFight(TFight fight)
    {
        this.Fight = fight;
    }

    public List<TFighterState> getTargets()
    {
        var fighters = new List<TFighterState>();
        foreach (var name in this.targets)
        {
            var fighter = this.Fight.getFighterByName(name);
            if (fighter != null)
            {
                fighters.Add(fighter);
            }
        }
        return fighters;
    }

    public string checkAchievements(TFight fight = null)
    {
        var strBase = "[color=yellow][b]Achievements unlocked for ${this.name}![/b][/color]\n";
        var added = AchievementManager<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>.checkAll(this.User, (TFighterState)this, fight);

        if (added.Count > 0)
        {
            strBase += string.Join("\n", added);
        }
        else
        {
            strBase = "";
        }

        return strBase;
    }

    //fight is "mistakenly" set as optional to be compatible with the super.init
    public void initialize()
    {
        this.fightStatus = FightStatus.Initialized;
    }

    public abstract string validateStats();

    public bool isInDebug
    {
        get
        {
            if (this.Fight != null)
            {
                return this.Fight.debug;
            }
            else
            {
                return false;
            }
        }
    }

    //returns dice score
    public int roll(int times = 1, Trigger @triggeringEvent = Trigger.Roll)
    {
        this.triggerMods(TriggerMoment.Before, @triggeringEvent);
        var result = 0;
        if (times == 1)
        {
            result = this.dice.roll(GameSettings.diceCount);
        }
        else
        {
            result = this.dice.roll(GameSettings.diceCount * times);
        }

        if (this.isInDebug && this.Fight.forcedDiceRoll > 0)
        {
            result = this.Fight.forcedDiceRoll;
        }

        this.triggerMods(TriggerMoment.After, @triggeringEvent);
        return result;
    }

    public virtual void nextRound() { }

    public bool triggerMods(TriggerMoment moment, Trigger @triggeringEvent, OptionalParameterType objFightAction = null)
    {
        bool atLeastOneModWasActivated = false;
        foreach (var mod in this.modifiers)
        {
            var message = mod.trigger(moment, @triggeringEvent, objFightAction);
            if (message.Length > 0)
            {
                this.Fight.message.addSpecial(message);
                atLeastOneModWasActivated = true;
            }
        }
        return atLeastOneModWasActivated;
    }


    public void removeMod(string idMod)
    { 
        //removes a mod idMod, and also its children. If a children has two parent Ids, then it doesn't remove the mod.
        var index = this.modifiers.RemoveAll(x => x.Id == idMod);
    }

    public FightLength fightDuration()
    {
        if (this.Fight != null)
        {
            return this.Fight.fightLength;
        }
        else
        {
            return FightLength.Long;
        }
    }

    public void triggerInsideRing()
    {
        this.isInTheRing = true;
    }

    public void triggerOutsideRing()
    {
        this.isInTheRing = false;
    }

    public void triggerPermanentInsideRing()
    {
        this.isInTheRing = false;
        this.canMoveFromOrOffRing = false;
    }

    public void triggerPermanentOutsideRing()
    {
        this.triggerOutsideRing();
        this.canMoveFromOrOffRing = false;
    }

    public abstract bool isTechnicallyOut(bool displayMessage = false);

    public void requestDraw()
    {
        this.wantsDraw = true;
        this.fightStatus = FightStatus.Draw;
    }

    public void unrequestDraw()
    {
        this.wantsDraw = false;
        this.fightStatus = FightStatus.Playing;
    }

    public bool isRequestingDraw()
    {
        return this.wantsDraw;
    }

    public int getStunnedTier()
    {
        var stunTier = -1;
        foreach (var mod in this.modifiers)
        {
            if (mod.Receiver.Name == this.Name && mod.name == "Stun")
            {
                stunTier = mod.tier;
            }
        }
        return stunTier;
    }

    public bool isStunned()
    {
        return this.getStunnedTier() >= 0;
    }

    public bool isApplyingHold()
    {
        var isApplyingHold = false;
        foreach (var mod in this.modifiers)
        {
            if (mod.Receiver.Name == this.Name && mod.isAHold())
            {
                isApplyingHold = true;
            }
        }
        return isApplyingHold;
    }

    public int isApplyingHoldOfTier()
    {
        var tier = -1;
        foreach (var mod in this.modifiers)
        {
            if (mod.Receiver.Name == this.Name && mod.isAHold())
            {
                tier = mod.tier;
            }
        }
        return tier;
    }

    public bool isInHold()
    {
        var isInHold = false;
        foreach (var mod in this.modifiers)
        {
            if (mod.Receiver.Name == this.Name && mod.isAHold())
            {
                isInHold = true;
            }
        }
        return isInHold;
    }

    //May have to move
    public bool isInSpecificHold(string holdType)
    {
        var isInHold = false;
        foreach (var mod in this.modifiers)
        {
            if (mod.Receiver.Name == this.Name && mod.isAHold() && mod.name == holdType)
            {
                isInHold = true;
            }
        }
        return isInHold;
    }

    public bool isInHoldAppliedBy(string fighterName)
    {
        var isTrue = false;
        foreach (var mod in this.modifiers)
        {
            if (mod.Receiver.Name == fighterName && mod.isAHold())
            {
                isTrue = true;
            }
        }
        return isTrue;
    }

    public int isInHoldOfTier()
    {
        var tier = -1;
        foreach (var mod in this.modifiers)
        {
            if (mod.Receiver.Name == this.Name && mod.isAHold())
            {
                tier = mod.tier;
            }
        }
        return tier;
    }

    public void releaseHoldsApplied()
    {
        foreach (var mod in this.modifiers)
        {
            if (mod.Applier != null && mod.Applier.Name == this.Name && mod.isAHold())
            {
                mod.Receiver.releaseHoldsAppliedBy(mod.Applier.Name);
            }
        }
    }

    public void releaseHoldsAppliedBy(string fighterName)
    {
        foreach (var mod in this.modifiers)
        {
            if (mod.Applier != null && mod.Applier.Name == fighterName && mod.isAHold())
            {
                this.removeMod(mod.Id);
            }
        }
    }

    public void escapeHolds()
    {
        foreach (var mod in this.modifiers)
        {
            if (mod.Receiver.Name == this.Name && mod.isAHold())
            {
                this.removeMod(mod.Id);
            }
        }
    }

    public string getListOfActiveModifiers()
    {
        var strMods = "";
        foreach (var mod in this.modifiers)
        {
            strMods += mod.name + ", ";
        }
        strMods = strMods.Substring(0, strMods.Length - 2);
        return strMods;
    }

    public string getStylizedName()
    {
        var modifierBeginning = "";
        var modifierEnding = "";
        if (this.isTechnicallyOut())
        {
            modifierBeginning = "[s]";
            modifierEnding = "[/s]";
        }
        else if (!this.isInTheRing)
        {
            modifierBeginning = "[i]";
            modifierEnding = "[/i]";
        }
        return "${modifierBeginning}[b][color=${Team[this.assignedTeam].ToLower()}]${this.name}[/color][/b]${modifierEnding}";
    }

    public bool isInRange(List<TFighterState> targets)
    {
        var result = true;
        foreach (var target in targets)
        {
            if ((target.distanceFromRingCenter - this.distanceFromRingCenter) > GameSettings.maximumDistanceToBeConsideredInRange)
            {
                result = false;
            }
        }
        return result;
    }

    public abstract string outputStatus();

    public abstract void save();
    public bool triggerFeatures(TriggerMoment before, Trigger trigger, OptionalParameterType baseFeatureParameter)
    {
        bool atLeastOneFeatureWasActivated = false;
        foreach (var feat in this.User.Features)
        {
            var message = feat.Trigger(before, trigger, baseFeatureParameter);
            if (!string.IsNullOrEmpty(message))
            {
                this.Fight.message.addSpecial(message);
                atLeastOneFeatureWasActivated = true;
            }
        }
        return atLeastOneFeatureWasActivated;
    }
}