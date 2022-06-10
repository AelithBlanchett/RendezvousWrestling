using RendezvousWrestling.Common.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.Common.Achievements;
using RendezvousWrestling.Common.Actions;
using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Common.Configuration;

namespace RendezvousWrestling.Common.Fight
{
    public abstract class BaseFighterState<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser> : BaseEntity
        where TAchievement : BaseAchievement<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TAchievementManager : AchievementManager<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TActionFactory : BaseActionFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TActionType : BaseActionType, new()
        where TActiveAction : BaseActiveAction<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TDataContext : BaseDataContext<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TEntityMapper : BaseEntityMapper<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeature : BaseFeature<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureFactory : BaseFeatureFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureParameters : BaseFeatureParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFeatureType : BaseFeatureType, new()
        where TFight : BaseFight<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFighterState : BaseFighterState<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFighterStats : BaseFighterStats<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TFightingGame : BaseFightingGame<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>
        where TModifier : BaseModifier<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TModifierFactory : BaseModifierFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TModifierParameters : BaseModifierParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
        where TModifierType : BaseModifierType, new()
        where TUser : BaseUser<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public Team AssignedTeam { get; set; } = Team.White;
        public List<string> TargetsAsString { get; set; } = new List<string>();
        public bool IsReady { get; set; } = false;
        public int LastDiceRoll { get; set; }
        public bool IsInTheRing { get; set; } = true;
        public bool CanMoveFromOrOffRing { get; set; } = true;
        public int LastTagTurn { get; set; } = int.MaxValue;
        public bool WantsDraw { get; set; } = false;
        public int DistanceFromRingCenter { get; set; }
        public FightStatus FightStatus { get; set; }

        [Required]
        [ForeignKey("Fight")]
        public string FightId { get; set; }
        public TFight Fight { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public TUser User { get; set; }

        [NotMapped]
        public List<TModifier> Modifiers
        {
            get
            {
                return ReceivedModifiers.Union(AppliedModifiers).ToList();
            }
        }

        public virtual List<TModifier> ReceivedModifiers { get; set; } = new List<TModifier>();

        public virtual List<TModifier> AppliedModifiers { get; set; } = new List<TModifier>();

        [NotMapped]
        public Dice Dice { get; set; }

        [NotMapped]
        public string Name
        {
            get
            {
                return User.Id;
            }
        }

        public BaseFighterState()
        {

        }

        public BaseFighterState(TFight fight, TUser user)
        {
            Initialize(fight, user);
        }

        public List<TFighterState> Targets
        {
            get
            {
                var fighters = new List<TFighterState>();
                foreach (var name in TargetsAsString)
                {
                    var fighter = Fight.GetFighterByName(name);
                    if (fighter != null)
                    {
                        fighters.Add(fighter);
                    }
                }
                return fighters;
            }
        }

        public string CheckAchievements(TFight fight = null)
        {
            var strBase = $"[color=yellow][b]Achievements unlocked for {Name}![/b][/color]\n";
            var added = new TAchievementManager().CheckAll(User, (TFighterState)this, fight);

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
        public virtual void Initialize(TFight fight, TUser user)
        {
            FightStatus = FightStatus.Initialized;
            Fight = fight;
            User = user;
            AssignedTeam = Team.White;
            TargetsAsString = null;
            IsReady = false;

            LastDiceRoll = 0;
            IsInTheRing = true;
            CanMoveFromOrOffRing = true;
            LastTagTurn = int.MaxValue;
            DistanceFromRingCenter = 0;
            WantsDraw = false; ;
            TargetsAsString = new List<string>();

            Dice = new Dice(GameSettings.DiceSides);
            FightStatus = FightStatus.Idle;
            LastDiceRoll = 0;
        }

        public abstract string ValidateStats();

        public bool IsInDebug
        {
            get
            {
                return Fight != null && Fight.Debug;
            }
        }

        //returns dice score
        public int Roll(int times = 1, TriggerEvent @triggeringEvent = TriggerEvent.Roll)
        {
            TriggerMods(TriggerMoment.Before, @triggeringEvent);
            int result = times == 1 ? Dice.roll(GameSettings.DiceCount) : Dice.roll(GameSettings.DiceCount * times);
            if (IsInDebug && Fight.ForcedDiceRoll > 0)
            {
                result = Fight.ForcedDiceRoll;
            }

            TriggerMods(TriggerMoment.After, @triggeringEvent);
            return result;
        }

        public virtual void NextRound() { }

        public bool TriggerMods(TriggerMoment moment, TriggerEvent @triggeringEvent, TFeatureParameters objFightAction = null)
        {
            bool atLeastOneModWasActivated = false;
            foreach (var mod in Modifiers)
            {
                var message = mod.Trigger(moment, @triggeringEvent, objFightAction);
                if (message.Length > 0)
                {
                    Fight.Message.addSpecial(message);
                    atLeastOneModWasActivated = true;
                }
            }
            return atLeastOneModWasActivated;
        }


        public void RemoveMod(string idMod)
        {
            //removes a mod idMod, and also its children. If a children has two parent Ids, then it doesn't remove the mod.
            var index = Modifiers.RemoveAll(x => x.Id == idMod);
        }

        public FightLength FightDuration
        {
            get
            {
                return Fight != null ? Fight.FightLength : FightLength.Long;
            }
        }

        public void TriggerInsideRing()
        {
            IsInTheRing = true;
        }

        public void TriggerOutsideRing()
        {
            IsInTheRing = false;
        }

        public void TriggerPermanentInsideRing()
        {
            IsInTheRing = false;
            CanMoveFromOrOffRing = false;
        }

        public void TriggerPermanentOutsideRing()
        {
            TriggerOutsideRing();
            CanMoveFromOrOffRing = false;
        }

        public abstract bool IsTKO { get; }

        public abstract void DisplayTKOMessage();

        public void RequestDraw()
        {
            WantsDraw = true;
            FightStatus = FightStatus.Draw;
        }

        public void UnrequestDraw()
        {
            WantsDraw = false;
            FightStatus = FightStatus.Playing;
        }

        public bool IsRequestingDraw()
        {
            return WantsDraw;
        }

        public int StunnedTier
        {
            get
            {
                var stunTier = -1;
                foreach (var mod in ReceivedModifiers)
                {
                    if (mod.IsStun)
                    {
                        if (stunTier < mod.Tier)
                        {
                            stunTier = mod.Tier;
                        }
                    }
                }
                return stunTier;
            }
        }

        public bool IsStunned
        {
            get
            {
                return StunnedTier >= 0;
            }
        }

        public bool IsApplyingHold()
        {
            var isApplyingHold = false;
            foreach (var mod in ReceivedModifiers)
            {
                if (mod.IsHold)
                {
                    isApplyingHold = true;
                }
            }
            return isApplyingHold;
        }

        public int TierOfReceivedHold
        {
            get
            {
                var tier = -1;
                foreach (var mod in ReceivedModifiers)
                {
                    if (mod.IsHold)
                    {
                        if (tier < mod.Tier)
                        {
                            tier = mod.Tier;
                        }
                    }
                }
                return tier;
            }
        }

        public bool IsInHold()
        {
            var isInHold = false;
            foreach (var mod in ReceivedModifiers)
            {
                if (mod.IsHold)
                {
                    isInHold = true;
                }
            }
            return isInHold;
        }

        //May have to move
        public bool IsInSpecificHold(TModifierType holdType)
        {
            var isInHold = false;
            foreach (var mod in ReceivedModifiers)
            {
                if (mod.IsHold && mod.Type == holdType)
                {
                    isInHold = true;
                }
            }
            return isInHold;
        }

        public bool IsInHoldAppliedBy(string fighterName)
        {
            var isTrue = false;
            foreach (var mod in ReceivedModifiers)
            {
                if (mod.Applier.Name == fighterName && mod.IsHold)
                {
                    isTrue = true;
                }
            }
            return isTrue;
        }

        public int IsInHoldOfTier
        {
            get
            {
                var tier = -1;
                foreach (var mod in Modifiers)
                {
                    if (mod.Receiver.Name == Name && mod.IsHold)
                    {
                        tier = mod.Tier;
                    }
                }
                return tier;
            }
        }

        public void ReleaseHoldsApplied()
        {
            foreach (var mod in Modifiers)
            {
                if (mod.Applier != null && mod.Applier.Name == Name && mod.IsHold)
                {
                    mod.Receiver.ReleaseHoldsAppliedBy(mod.Applier.Name);
                }
            }
        }

        public void ReleaseHoldsAppliedBy(string fighterName)
        {
            foreach (var mod in ReceivedModifiers)
            {
                if (mod.IsHold && mod.Applier?.Name == fighterName)
                {
                    RemoveMod(mod.Id);
                }
            }
        }

        public void ReleaseAllHolds()
        {
            foreach (var mod in ReceivedModifiers)
            {
                if (mod.IsHold)
                {
                    RemoveMod(mod.Id);
                }
            }
        }

        public string ActiveModifiersAsString
        {
            get
            {
                return string.Join(", ", Modifiers.Select(x => x.Name));
            }
        }

        public string GetStylizedName()
        {
            var modifierBeginning = "";
            var modifierEnding = "";
            if (IsTKO)
            {
                modifierBeginning = "[s]";
                modifierEnding = "[/s]";
            }
            else if (!IsInTheRing)
            {
                modifierBeginning = "[i]";
                modifierEnding = "[/i]";
            }
            return $"{modifierBeginning}[b][color={Enum.GetName(AssignedTeam).ToLower()}]{Name}[/color][/b]{modifierEnding}";
        }

        public bool IsInRange(List<TFighterState> targets)
        {
            var result = true;
            foreach (var target in targets)
            {
                if (target.DistanceFromRingCenter - DistanceFromRingCenter > GameSettings.MaximumDistanceToBeConsideredInRange)
                {
                    result = false;
                }
            }
            return result;
        }

        public abstract string OutputStatus();

        public bool TriggerFeatures(TriggerMoment before, TriggerEvent trigger, TFeatureParameters baseFeatureParameter)
        {
            bool atLeastOneFeatureWasActivated = false;
            foreach (var feat in User.Features)
            {
                var message = feat.Trigger(before, trigger, baseFeatureParameter);
                if (!string.IsNullOrEmpty(message))
                {
                    Fight.Message.addSpecial(message);
                    atLeastOneFeatureWasActivated = true;
                }
            }
            return atLeastOneFeatureWasActivated;
        }
    }
}