using RendezvousWrestling.Common.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.Common.Achievements;
using RendezvousWrestling.Common.Actions;
using RendezvousWrestling.Common.Fight;
using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using System.Linq;

namespace RendezvousWrestling.Common.Modifiers
{
    public abstract class BaseModifier<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser> : BaseEntity, IModifier, IModifierParameters
        where TAchievement : BaseAchievement<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TAchievementManager : AchievementManager<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TActionFactory : BaseActionFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TActionType : BaseActionType<TActionType>, new()
        where TActiveAction : BaseActiveAction<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TDataContext : BaseDataContext<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TEntityMapper : BaseEntityMapper<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeature : BaseFeature<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureFactory : BaseFeatureFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureParameters : BaseFeatureParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureType : BaseFeatureType<TFeatureType>, new()
        where TFight : BaseFight<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFighterState : BaseFighterState<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFighterStats : BaseFighterStats<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFightingGame : BaseFightingGame<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>
        where TModifier : BaseModifier<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TModifierFactory : BaseModifierFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TModifierParameters : BaseModifierParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TModifierType : BaseModifierType<TModifierType>, new()
        where TUser : BaseUser<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        //Parameters
        public Tier Tier { get; set; }
        public List<string> IdParentActions { get; set; }


        [NotMapped]
        public virtual TModifierType Type { get; set; }
        public virtual string Name { get; set; }
        public virtual bool AreDamageMultipliers { get; set; } = false;
        public virtual int DiceRoll { get; set; }
        public virtual int EscapeRoll { get; set; }
        public virtual int Uses { get; set; }
        public virtual TriggerEvent TriggeringEvent { get; set; }
        public virtual TriggerMoment TimeToTrigger { get; set; }

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

        public virtual void Initialize(TModifierType modifierType, string name, TriggerMoment timeToTrigger = TriggerMoment.Never, TriggerEvent triggeringEvent = TriggerEvent.None)
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
            if (Receiver.Modifiers.Any(x => x.Id == Id))
            {
                Receiver.RemoveMod(Id);
            }

            if (Applier != null)
            {
                if (Applier.Modifiers.Any(x => x.Id == Id))
                {
                    Applier.RemoveMod(Id);
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

            if (Utils.GlobalUtils.WillTriggerForEvent(TimeToTrigger, moment, TriggeringEvent, triggeringEvent))
            {
                Uses--;
                messageAboutModifier = $"{Receiver.GetStylizedName()} is affected by the {Name},";
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