using RendezvousWrestling.Common.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.Common.Achievements;
using RendezvousWrestling.Common.Actions;
using RendezvousWrestling.Common;
using RendezvousWrestling.Common.Fight;
using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.Common.Modifiers
{
    public abstract class BaseModifier<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser> : BaseEntity, IModifier, IModifierParameters
        where TAchievement : BaseAchievement<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TAchievementManager : AchievementManager<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TActionFactory : BaseActionFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TActionType : BaseActionType, new()
        where TActiveAction : BaseActiveAction<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TDataContext : BaseDataContext<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TEntityMapper : BaseEntityMapper<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TFeature : BaseFeature<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureFactory : BaseFeatureFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureParameters : BaseFeatureParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureType : BaseFeatureType, new()
        where TFight : BaseFight<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TFighterState : BaseFighterState<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TFighterStats : BaseFighterStats<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TFightingGame : BaseFightingGame<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TModifier : BaseModifier<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TModifierParameters : BaseModifierParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
        where TModifierType : BaseModifierType, new()
        where TUser : BaseUser<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser>, new()
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        //Parameters
        public int Tier { get; set; }
        [NotMapped]
        public TModifierType Type { get; set; }
        public string Name { get; set; }
        public bool AreDamageMultipliers { get; set; } = false;
        public int DiceRoll { get; set; }
        public int EscapeRoll { get; set; }
        public int Uses { get; set; }
        public TriggerEvent TriggeringEvent { get; set; }
        public TriggerMoment TimeToTrigger { get; set; }
        public List<string> IdParentActions { get; set; }


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

        public BaseModifier(TModifierType modifierType, string name, TriggerMoment timeToTrigger, TriggerEvent triggeringEvent)
        {
            Initialize(modifierType, name, timeToTrigger, triggeringEvent);
        }

        public void Initialize(TModifierType modifierType, string name, TriggerMoment timeToTrigger, TriggerEvent triggeringEvent)
        {
            Id = Guid.NewGuid().ToString();
            Type = modifierType;
            Name = name;
            TriggeringEvent = triggeringEvent;
            TimeToTrigger = timeToTrigger;
        }

        public void Activate(TFight fight, TFighterState receiver, TFighterState applier, TModifierParameters inputParameters)
        {
            Receiver = receiver;
            Applier = applier;
            Fight = fight;

            new TEntityMapper().Mapper.Map(inputParameters, this, typeof(TModifierParameters), typeof(TModifier));

            AreDamageMultipliers = false;
            DiceRoll = 0;
        }

        public bool IsOver()
        {
            return Uses <= 0; //note: removed "|| this.receiver.isTechnicallyOut()" in latest patch. may break things.
        }

        public void Remove()
        {
            var indexModReceiver = Receiver.Modifiers.FindIndex(x => x.Id == Id);
            if (indexModReceiver != -1)
            {
                Receiver.Modifiers.RemoveAt(indexModReceiver);
            }

            if (Applier != null)
            {
                var indexModApplier = Applier.Modifiers.FindIndex(x => x.Id == Id);
                if (indexModApplier != -1)
                {
                    Applier.Modifiers.RemoveAt(indexModApplier);
                }
            }


            foreach (var mod in Receiver.Modifiers)
            {
                if (mod.IdParentActions != null)
                {
                    if (mod.IdParentActions.Count == 1 && mod.IdParentActions[0] == Id)
                    {
                        mod.Remove();
                    }
                    else if (mod.IdParentActions.IndexOf(Id) != -1)
                    {
                        mod.IdParentActions.RemoveAt(mod.IdParentActions.IndexOf(Id));
                    }
                }
            }

            if (Applier != null)
            {
                foreach (var mod in Applier.Modifiers)
                {
                    if (mod.IdParentActions != null)
                    {
                        if (mod.IdParentActions.Count == 1 && mod.IdParentActions[0] == Id)
                        {
                            mod.Remove();
                        }
                        else if (mod.IdParentActions.IndexOf(Id) != -1)
                        {
                            mod.IdParentActions.RemoveAt(mod.IdParentActions.IndexOf(Id));
                        }
                    }
                }
            }

        }

        public string Trigger(TriggerMoment moment, TriggerEvent triggeringEvent, TFeatureParameters objFightAction = null)
        {
            string messageAboutModifier = "";

            if (Utils.Utils.WillTriggerForEvent(TimeToTrigger, moment, TriggeringEvent, triggeringEvent))
            {
                Uses--;
                messageAboutModifier = $"{Receiver.GetStylizedName()} is affected by the {Name}, ";
                if (objFightAction == null) //not sure about this one
                {
                    messageAboutModifier += ApplyModifierOnReceiver(moment, triggeringEvent);
                }
                else
                {
                    messageAboutModifier += ApplyModifierOnAction(moment, triggeringEvent, objFightAction);
                }

                if (IsOver())
                {
                    foreach (var fighter in Fight.Fighters)
                    {
                        fighter.RemoveMod(Id);
                    }
                    messageAboutModifier += " and it is now expired.";
                }
                else
                {
                    messageAboutModifier += $" still effective for {Uses} more turns.";
                }

                Fight.Message.addSpecial(messageAboutModifier);
            }

            return messageAboutModifier;
        }

        public abstract string ApplyModifierOnReceiver(TriggerMoment moment, TriggerEvent triggeringEvent);
        public abstract string ApplyModifierOnAction(TriggerMoment moment, TriggerEvent triggeringEvent, dynamic objFightAction);

        public bool IsStun { get; set; }
        public bool IsHold { get; set; }

    }
}