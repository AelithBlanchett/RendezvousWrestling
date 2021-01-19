using RendezvousWrestling.Common.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class BaseModifier<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType> : BaseEntity
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

    public int tier { get; set; }

    public int type { get; set; }
    public string name { get; set; }

    public bool areDamageMultipliers { get; set; } = false;
    public int diceRoll { get; set; }
    public int escapeRoll { get; set; }
    public int uses { get; set; }
    public Trigger triggeringEvent { get; set; }
    public TriggerMoment timeToTrigger { get; set; }
    public List<string> idParentActions { get; set; }

    [ForeignKey("Fight")]
    public string FightId { get; set; }
    public TFight Fight { get; set; }

    [ForeignKey("Applier")]
    public string ApplierId { get; set; }
    public TFighterState Applier { get; set; }

    [ForeignKey("Receiver")]
    public string ReceiverId { get; set; }
    public TFighterState Receiver { get; set; }

    public BaseModifier()
    {

    }

    public BaseModifier(string name, TFight fight, TFighterState receive, TFighterState applier, int tier, int uses, TriggerMoment timeToTrigger, Trigger triggeringEvent, List<string> parentActionIds = null)
    {
        this.Id = Guid.NewGuid().ToString();
        this.Receiver = Receiver;
        this.Applier = applier;
        this.Fight = fight;
        this.tier = tier;
        this.name = name;
        this.uses = uses;
        this.triggeringEvent = triggeringEvent;
        this.timeToTrigger = timeToTrigger;
        this.idParentActions = parentActionIds;
        this.initialize();
    }

    public void initialize()
    {
        this.areDamageMultipliers = false;
        this.diceRoll = 0;
    }

    public bool isOver()
    {
        return (this.uses <= 0); //note: removed "|| this.receiver.isTechnicallyOut()" in latest patch. may break things.
    }

    public void remove()
    {
        var indexModReceiver = this.Receiver.modifiers.FindIndex(x => x.Id == this.Id);
        if (indexModReceiver != -1)
        {
            this.Receiver.modifiers.RemoveAt(indexModReceiver);
        }

        if (this.Applier != null)
        {
            var indexModApplier = this.Applier.modifiers.FindIndex(x => x.Id == this.Id);
            if (indexModApplier != -1)
            {
                this.Applier.modifiers.RemoveAt(indexModApplier);
            }
        }


        foreach (var mod in this.Receiver.modifiers)
        {
            if (mod.idParentActions != null)
            {
                if (mod.idParentActions.Count == 1 && mod.idParentActions[0] == this.Id)
                {
                    mod.remove();
                }
                else if (mod.idParentActions.IndexOf(this.Id) != -1)
                {
                    mod.idParentActions.RemoveAt(mod.idParentActions.IndexOf(this.Id));
                }
            }
        }

        if (this.Applier != null)
        {
            foreach (var mod in this.Applier.modifiers)
            {
                if (mod.idParentActions != null)
                {
                    if (mod.idParentActions.Count == 1 && mod.idParentActions[0] == this.Id)
                    {
                        mod.remove();
                    }
                    else if (mod.idParentActions.IndexOf(this.Id) != -1)
                    {
                        mod.idParentActions.RemoveAt(mod.idParentActions.IndexOf(this.Id));
                    }
                }
            }
        }

    }

    public string trigger(TriggerMoment moment, Trigger triggeringEvent, dynamic objFightAction = null)
    {
        string messageAboutModifier = "";

        if (Utils.willTriggerForEvent(this.timeToTrigger, moment, this.triggeringEvent, triggeringEvent))
        {
            this.uses--;
            messageAboutModifier = "${this.receiver.getStylizedName()} is affected by the ${this.name}, ";
            if (!objFightAction)
            {
                messageAboutModifier += this.applyModifierOnReceiver(moment, triggeringEvent);
            }
            else
            {
                messageAboutModifier += this.applyModifierOnAction(moment, triggeringEvent, objFightAction);
            }

            if (this.isOver())
            {
                foreach (var fighter in this.Fight.Fighters)
                {
                    fighter.removeMod(this.Id);
                }
                messageAboutModifier += " and it is now expired.";
            }
            else
            {
                messageAboutModifier += " still effective for ${this.uses} more turns.";
            }

            this.Fight.message.addSpecial(messageAboutModifier);
        }

        return messageAboutModifier;
    }

    public abstract string applyModifierOnReceiver(TriggerMoment moment, Trigger triggeringEvent);
    public abstract string applyModifierOnAction(TriggerMoment moment, Trigger triggeringEvent, dynamic objFightAction);
    public abstract bool isAHold();

}