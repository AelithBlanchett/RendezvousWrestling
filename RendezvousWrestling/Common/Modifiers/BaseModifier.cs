using RendezvousWrestling.Common.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;

public abstract class BaseModifier<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser> : BaseEntity, IModifier, IModifierParameters
    where TAchievement : BaseAchievement<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TAchievementManager : AchievementManager<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TActionFactory : BaseActionFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TActionType : BaseActionType, new()
    where TActiveAction : BaseActiveAction<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TEntityMapper : BaseEntityMapper<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFeature : BaseFeature<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFeatureFactory : BaseFeatureFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFeatureParameters : BaseFeatureParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFeatureType : BaseFeatureType, new()
    where TFight : BaseFight<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFighterState : BaseFighterState<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFighterStats : BaseFighterStats<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TFightingGame : BaseFightingGame<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TModifier : BaseModifier<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TModifierParameters : BaseModifierParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    where TModifierType : BaseModifierType, new()
    where TUser : BaseUser<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    //Parameters
    public int tier { get; set; }
    public TModifierType type { get; set; }
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

    public BaseModifier(TFight fight, TFighterState receive, TFighterState applier, int tier, int uses, TriggerMoment timeToTrigger, Trigger triggeringEvent, List<string> parentActionIds = null)
    {
        this.initialize(fight, receive, applier, tier, uses, timeToTrigger, triggeringEvent, parentActionIds);
    }

    public void initialize(TFight fight, TFighterState receive, TFighterState applier, int tier, int uses, TriggerMoment timeToTrigger, Trigger triggeringEvent, List<string> parentActionIds = null)
    {
        this.Id = Guid.NewGuid().ToString();
        this.Receiver = Receiver;
        this.Applier = applier;
        this.Fight = fight;
        this.tier = tier;
        //TODO NAME WAS REMOVED!!!!!!!!!!!!!!!!!!!!!!!!
        this.uses = uses;
        this.triggeringEvent = triggeringEvent;
        this.timeToTrigger = timeToTrigger;
        this.idParentActions = parentActionIds;

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
            messageAboutModifier = $"{this.Receiver.getStylizedName()} is affected by the {this.name}, ";
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
                messageAboutModifier += $" still effective for {this.uses} more turns.";
            }

            this.Fight.message.addSpecial(messageAboutModifier);
        }

        return messageAboutModifier;
    }

    public abstract string applyModifierOnReceiver(TriggerMoment moment, Trigger triggeringEvent);
    public abstract string applyModifierOnAction(TriggerMoment moment, Trigger triggeringEvent, dynamic objFightAction);
    public abstract bool isAHold();

}