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
using RendezvousWrestling.Common;
using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.Common.Fight
{
    public abstract class BaseFight<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser> : BaseEntity
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

        public int RequiredTeams { get; set; }
        public bool HasStarted { get; set; }
        public bool HasEnded { get; set; }
        public string Stage { get; set; }
        public int CurrentTurn { get; set; }
        public FightType FightType { get; set; }
        public Team WinnerTeam { get; set; }
        public int Season { get; set; }
        public bool WaitingForAction { get; set; } = true;
        public FightLength FightLength { get; set; } = FightLength.Long;

        [NotMapped]
        public virtual List<TActiveAction> PastActions { get; set; }
        public virtual List<TFighterState> Fighters { get; set; }

        public string Channel { get; set; }

        [NotMapped]
        public FightMessage Message { get; set; }
        [NotMapped]
        public TFightingGame FightingGame { get; set; }
        [NotMapped]
        public FChatSharpLib.BaseBot FChatLibInstance { get; set; }
        [NotMapped]
        public TActionFactory ActionFactory { get; set; }
        [NotMapped]
        public TActionFactory ModifierFactory { get; set; }
        [NotMapped]
        public TFeatureFactory FeatureFactory { get; set; }

        public bool Debug { get; set; }
        public int ForcedDiceRoll { get; set; }
        public bool DiceLess { get; set; } = false;

        public BaseFight()
        {
            ActionFactory = new TActionFactory();
            Id = Guid.NewGuid().ToString();
            Fighters = new List<TFighterState>();
            Stage = FightingStages.pick();
            FightType = FightType.Classic;
            PastActions = new List<TActiveAction>();
            WinnerTeam = Team.White;
            CurrentTurn = 0;
            Season = GameSettings.CurrentSeason;
            RequiredTeams = 2;
            DiceLess = false;
            FightLength = FightLength.Long;
            Message = new FightMessage();
        }

        public void Activate(TFightingGame fightingGame, FChatSharpLib.BaseBot fChatLibInstance, string channel)
        {
            FightingGame = fightingGame;
            FChatLibInstance = fChatLibInstance;
            Channel = channel;
        }

        public void SendFightMessage()
        {
            FChatLibInstance.SendMessageInChannel(Message.getMessage(), Channel);
        }

        public void ResendFightMessage()
        {
            FChatLibInstance.SendMessageInChannel(Message.getLastMessage(), Channel);
        }

        public void SetTeamsCount(int newTeamsCount)
        {
            if (newTeamsCount >= 2)
            {
                RequiredTeams = newTeamsCount;
                Message.AddInfo(Messages.changeMinTeamsInvolvedInFightOK);
            }
            else
            {
                Message.AddInfo(Messages.changeMinTeamsInvolvedInFightFail);
            }
            SendFightMessage();
        }

        public void SetDiceLess(bool diceless)
        {
            if (!HasStarted && !HasEnded)
            {
                DiceLess = diceless;
                Message.AddInfo(string.Format(Messages.setDiceLess, diceless ? "NOT " : ""));
            }
            else
            {
                Message.AddInfo(Messages.setDiceLessFail);
            }
            SendFightMessage();
        }

        public void SetFightLength(FightLength fightDuration)
        {
            if (!HasStarted && !HasEnded)
            {
                FightLength = fightDuration;
                Message.AddInfo(string.Format(Messages.SetFightLength, Enum.GetName(typeof(FightLength), fightDuration)));
            }
            else
            {
                Message.AddInfo(Messages.setFightLengthFail);
            }
            SendFightMessage();
        }

        public void SetFightType(string type)
        {
            if (!HasStarted && !HasEnded)
            {
                var fightTypesList = Enum.GetNames(typeof(FightType));
                var foundAskedType = false;
                foreach (var fightTypeId in fightTypesList)
                {
                    if (type.ToLower() == fightTypeId.ToLower())
                    {
                        FightType = (FightType)Enum.Parse(typeof(FightType), fightTypeId);
                        switch (FightType)
                        {
                            case FightType.Classic:
                                Message.AddInfo(Messages.setFightTypeClassic);
                                break;
                            case FightType.Tag:
                                Message.AddInfo(Messages.setFightTypeTag);
                                break;
                            case FightType.LastManStanding:
                                Message.AddInfo(Messages.setFightTypeLMS);
                                break;
                            case FightType.SexFight:
                                Message.AddInfo(Messages.setFightTypeSexFight);
                                break;
                            case FightType.Humiliation:
                                Message.AddInfo(Messages.setFightTypeHMatch);
                                break;
                            case FightType.Bondage:
                                Message.AddInfo(Messages.setFightTypeBondageMatch);
                                break;
                            case FightType.Submission:
                                Message.AddInfo(Messages.setFightTypeSubmission);
                                break;
                            default:
                                break;
                        }
                        foundAskedType = true;
                        break;
                    }
                }
                if (!foundAskedType)
                {
                    FightType = FightType.Classic;
                    Message.AddInfo(Messages.SetFightTypeNotFound);
                }
            }
            else
            {
                Message.AddInfo(Messages.SetFightTypeFail);
            }
            SendFightMessage();
        }

        //Pre-fight utils

        public bool Leave(string fighterName)
        {
            if (!HasStarted)
            {
                return Fighters.RemoveAll(x => x.UserId == fighterName) > 0;
            }

            return false;
        }

        public Team Join(string fighterName, Team team)
        {
            if (!HasStarted)
            {
                if (GetFighterByName(fighterName) == null)
                { //find user by its name property instead of comparing objects, which doesn't work.
                    TFighterState activeFighter = null; //await BaseFighterState.loadFighter(fighterName); //TODO DATABASE
                    if (activeFighter == null)
                    {
                        throw new Exception(Messages.ErrorNotRegistered);
                    }
                    if (!activeFighter.User.CanPayAmount(GameSettings.TokensCostToFight))
                    {
                        throw new Exception(string.Format(Messages.errorNotEnoughMoney, GameSettings.TokensCostToFight.ToString()));
                    }
                    var areStatsValid = activeFighter.ValidateStats();
                    if (areStatsValid != "")
                    {
                        throw new Exception(areStatsValid);
                    }
                    activeFighter.AssignFight((TFight)this);
                    activeFighter.Initialize();
                    activeFighter.FightStatus = FightStatus.Joined;
                    if (team != Team.White)
                    {
                        activeFighter.AssignedTeam = team;
                    }
                    else
                    {
                        team = FirstAvailableTeam;
                        activeFighter.AssignedTeam = team;
                    }
                    Fighters.Add(activeFighter);
                    return team;
                }
                else
                {
                    throw new Exception("You have already joined the fight.");
                }
            }
            else
            {
                throw new Exception("The fight has already started");
            }
        }

        public bool SetFighterReady(string fighterName)
        {
            if (!HasStarted)
            {
                if (GetFighterByName(fighterName) == null)
                {
                    Join(fighterName, Team.White);
                }
                var fighterInFight = GetFighterByName(fighterName);
                if (fighterInFight != null && !fighterInFight.IsReady)
                { //find user by its name property instead of comparing objects, which doesn't work.
                    fighterInFight.IsReady = true;
                    fighterInFight.FightStatus = FightStatus.Ready;
                    var fightTypes = Enum.GetNames(typeof(FightType));
                    var listOfFightTypes = string.Join(", ", fightTypes);
                    listOfFightTypes = listOfFightTypes.Replace(FightType.ToString(), $"[color=green][b]{FightType}[/b][/color]");
                    var fightDurations = Enum.GetNames(typeof(FightLength));
                    var listOfFightDurations = string.Join(", ", fightDurations);
                    listOfFightDurations = listOfFightDurations.Replace(FightLength.ToString(), $"[color=green][b]{FightLength}[/b][/color]");
                    Message.AddInfo(string.Format(Messages.Ready, fighterInFight.GetStylizedName(), listOfFightTypes, RequiredTeams.ToString(), listOfFightDurations));
                    SendFightMessage();
                    if (CanStart())
                    {
                        Start();
                    }
                    return true;
                }
            }
            return false;
        }

        public bool CanStart()
        {
            return IsEveryoneReady&& !HasStarted && AllOccupiedTeamsList.Count >= RequiredTeams; //only start if everyone's ready and if the teams are balanced
        }


        //RWFight logic

        public void Start()
        {
            Message.AddInfo(string.Format(Messages.startMatchAnnounce, Id));
            CurrentTurn = 1;
            HasStarted = true;
            Fighters = Utils.Utils.ShuffleArray(Fighters); //random order for teams

            Message.AddInfo(string.Format(Messages.startMatchStageAnnounce, Stage));

            for (var i = 0; i < MaxPlayersPerTeam; i++)
            { //Prints as much names as there are Team
                var fullStringVS = "[b]";
                foreach (var j in TeamsStillInGame)
                {
                    var theFighter = GetTeam(j)[i];
                    if (theFighter != null)
                    {
                        fullStringVS = $"{fullStringVS} VS {theFighter.GetStylizedName()}";
                    }
                }
                fullStringVS = $"{fullStringVS}[/b]";
                fullStringVS = fullStringVS.Replace(" VS ", "");
                Message.AddInfo(fullStringVS);
            }


            ReorderFightersByInitiative(RollAllDice(TriggerEvent.InitiationRoll));
            Message.AddInfo(string.Format(Messages.startMatchFirstPlayer, CurrentPlayer.GetStylizedName(), CurrentTeamName.ToLower(), CurrentTeamName));
            for (var i = 1; i < Fighters.Count; i++)
            {
                Message.AddInfo(string.Format(Messages.startMatchFollowedBy, Fighters[i].GetStylizedName(), Fighters[i].AssignedTeam.ToString().ToLower(), Fighters[i].AssignedTeam.ToString().ToLower()));
                if (FightType == FightType.Tag)
                {
                    Fighters[i].IsInTheRing = false;
                }
            }
            if (FightType == FightType.Tag)
            { //if it's a tag match, only allow the first player of the next Team
                for (var i = 1; i < Fighters.Count; i++)
                {
                    if (CurrentPlayer.AssignedTeam != Fighters[i].AssignedTeam)
                    {
                        Fighters[i].IsInTheRing = true;
                        break;
                    }
                }
            }

            for (var i = 0; i < Fighters.Count; i++)
            {
                Fighters[i].FightStatus = FightStatus.Playing;
                int fightCost = GameSettings.TokensCostToFight;
                Fighters[i].User.RemoveTokens(fightCost, TransactionType.FightStart);
                Fighters[i].TriggerFeatures(TriggerMoment.After, TriggerEvent.InitiationRoll, GetFeatureParameter((TFight)this, Fighters[i]));
            }



            SendFightMessage();
            OutputStatus();
        }

        private static TFeatureParameters GetFeatureParameter(TFight fight = null, TFighterState fighter = null, TFighterState target = null, TActiveAction action = null)
        {
            var parameters = new TFeatureParameters();
            parameters.Initialize(fight, fighter, target, action);
            return parameters;
        }

        public void RequestDraw(string fighterName)
        {
            var fighter = GetFighterByName(fighterName);
            if (fighter != null)
            {
                if (!fighter.IsRequestingDraw())
                {
                    fighter.RequestDraw();
                }
                else
                {
                    throw new Exception("You already have requested a draw.");
                }
            }
            else
            {
                throw new Exception("You aren't in this fight.");
            }
        }

        public void UnrequestDraw(string fighterName)
        {
            var fighter = GetFighterByName(fighterName);
            if (fighter != null)
            {
                if (fighter.IsRequestingDraw())
                {
                    fighter.UnrequestDraw();
                }
                else
                {
                    throw new Exception("You already have requested a draw.");
                }
            }
            else
            {
                throw new Exception("You aren't in this fight.");
            }
        }

        public virtual void NextTurn()
        {
            CurrentTurn++;

            foreach (var fighter in Fighters)
            {
                var strAchievements = fighter.CheckAchievements((TFight)this);
                if (strAchievements != "")
                {
                    Message.addSpecial(strAchievements);
                }
            }

            if (IsOver)
            { //Check for the ending
                int tokensToGiveToWinners = (int)Enum.Parse(typeof(TokensPerWin), GetHighestQualifyingFightTier(WinnerTeam).ToString());
                int tokensToGiveToLosers = (int)(tokensToGiveToWinners * GameSettings.TokensPerLossMultiplier);
                if (IsDraw)
                {
                    Message.addHit($"DOUBLE KO! Everyone is out! It's over!");
                    tokensToGiveToLosers = tokensToGiveToWinners;
                }
                OutputStatus();
                EndFight(tokensToGiveToWinners, tokensToGiveToLosers);
            }
            else
            {
                WaitingForAction = true;
                OutputStatus();
            }

            foreach (var fighter in Fighters)
            {
                fighter.NextRound();
            }
        }

        public bool IsOver
        {
            get
            {
                return TeamsStillInGame.Count <= 1;
            }
        }

        public bool IsDraw
        {
            get
            {
                return TeamsStillInGame.Count == 0;
            }
        }

        //Fighting info displays

        public void OutputStatus()
        {
            Message.AddInfo(string.Format(Messages.outputStatusInfo, CurrentTurn.ToString(), CurrentTeamName.ToLower(), CurrentTeamName, CurrentPlayer.GetStylizedName()));

            for (var i = 0; i < Fighters.Count; i++)
            { //Prints as much names as there are Team
                var theFighter = Fighters[i];
                if (theFighter != null)
                {
                    Message.addStatus(theFighter.OutputStatus());
                }
            }

            SendFightMessage();
        }

        [NotMapped]
        public Team CurrentTeam
        {
            get
            {
                return AlivePlayers[(CurrentTurn - 1) % AliveFighterCount].AssignedTeam;
            }
        }

        [NotMapped]
        public Team NextTeamToPlay
        {
            get
            {
                return AlivePlayers[CurrentTurn % AliveFighterCount].AssignedTeam;
            }
        }

        [NotMapped]
        public int CurrentPlayerIndex
        {
            get
            {
                var curTurn = 1;
                if (CurrentTurn > 0)
                {
                    curTurn = CurrentTurn - 1;
                }
                return curTurn % AliveFighterCount;
            }
        }

        [NotMapped]
        public TFighterState CurrentPlayer
        {
            get
            {
                return AlivePlayers[CurrentPlayerIndex];
            }
        }

        [NotMapped]
        public TFighterState NextPlayer
        {
            get
            {
                return AlivePlayers[CurrentTurn % AliveFighterCount];
            }
        }

        public void SetCurrentPlayer(string fighterName)
        {
            var index = Fighters.FindIndex((x) => x.Name == fighterName && !x.IsTKO);
            if (index != -1 && Fighters[CurrentPlayerIndex].Name != fighterName)
            { //switch positions
                var temp = Fighters[CurrentPlayerIndex];
                Fighters[CurrentPlayerIndex] = Fighters[index];
                Fighters[index] = temp;
                Fighters[CurrentPlayerIndex].IsInTheRing = true;
                if (Fighters[index].AssignedTeam == Fighters[CurrentPlayerIndex].AssignedTeam && Fighters[index].IsInTheRing == true && FightType == FightType.Tag)
                {
                    Fighters[index].IsInTheRing = false;
                }
                if (Fighters[index].AssignedTeam != Fighters[CurrentPlayerIndex].AssignedTeam && Fighters[CurrentPlayerIndex].IsInTheRing == true && FightType == FightType.Tag)
                {
                    Fighters.Where(x => x.IsInTheRing && x.AssignedTeam == Fighters[CurrentPlayerIndex].AssignedTeam && x.Name != fighterName).ToList().ForEach(x => x.IsInTheRing = false);
                }
                Message.AddInfo(string.Format(Messages.setCurrentPlayerOK, temp.Name, Fighters[CurrentPlayerIndex].Name));
            }
            else
            {
                Message.AddInfo(Messages.setCurrentPlayerFail);
            }
        }

        //RWFight helpers
        [NotMapped]
        public string CurrentTeamName
        {
            get
            {
                return CurrentTeam.ToString();
            }
        }

        [NotMapped]
        public List<TFighterState> CurrentTarget
        {
            get
            {
                return CurrentPlayer.Targets;
            }
        }

        public void AssignRandomTargetToAllFighters()
        {
            foreach (var fighter in AlivePlayers)
            {
                AssignRandomTargetToFighter(fighter);
            }
        }

        public void AssignRandomTargetToFighter(TFighterState fighter)
        {
            fighter.TargetsAsString.Add(GetRandomFighterNotInTeam(fighter.AssignedTeam).Name);
        }

        //Dice rolling
        public List<TFighterState> RollAllDice(TriggerEvent triggeringEvent)
        {
            var arrSortedFightersByInitiative = new List<TFighterState>();
            foreach (var player in AlivePlayers)
            {
                player.LastDiceRoll = player.Roll(10, triggeringEvent);
                arrSortedFightersByInitiative.Add(player);
                Message.addHint(string.Format(Messages.rollAllDiceEchoRoll, player.GetStylizedName(), player.LastDiceRoll.ToString()));
            }

            arrSortedFightersByInitiative.Sort((a, b) =>
            {
                return b.LastDiceRoll - a.LastDiceRoll;
            });

            return arrSortedFightersByInitiative;
        }

        public TFighterState RollAllAndReturnWinner(TriggerEvent triggeringEvent)
        {
            return RollAllDice(triggeringEvent)[0];
        }

        //Attacks

        public void AssignTarget(string fighterName, string name)
        {
            var theTarget = GetFighterByName(name);
            if (theTarget != null)
            {
                GetFighterByName(fighterName).TargetsAsString = new List<string>() { theTarget.Name };
                Message.AddInfo("Target set to " + theTarget.GetStylizedName());
                SendFightMessage();
            }
            else
            {
                Message.addError("Target not found.");
                SendFightMessage();
            }
        }

        public void PrepareAction(string attacker, TActionType actionType, bool tierRequired, bool isCustomTargetInsteadOfTier, string args)
        {
            var tier = -1;
            if (!IsMatchInProgress())
            {
                throw new Exception("There isn't any fight going on.");
            }

            if (!WaitingForAction)
            {
                throw new Exception(Messages.lastActionStillProcessing);
            }

            if (CurrentPlayer == null || attacker != CurrentPlayer.Name)
            {
                throw new Exception(Messages.doActionNotActorsTurn);
            }

            
            if (tierRequired && (!int.TryParse(args, out tier) || tier == -1))
            {
                throw new Exception($"The tier is required and neither Light, Medium or Heavy was specified. Example: !action Medium");
            }

            if (isCustomTargetInsteadOfTier)
            {
                TFighterState customTarget = GetFighterByName(args);
                if (customTarget != null)
                {
                    CurrentPlayer.TargetsAsString = new List<string>() { customTarget.Name };
                }
                else
                {
                    throw new Exception("The character to tag with is required and wasn't found.");
                }
            }

            if (GetFighterByName(attacker) == null)
            {
                throw new Exception("You aren't participating in this fight.");
            }

            //Might need to disable this for self-targetted actions?
            if (CurrentTarget == null || CurrentTarget.Count == 0)
            {
                if (Fighters.Where(x => x.AssignedTeam != CurrentPlayer.AssignedTeam && x.IsInTheRing && !x.IsTKO).Count() == 1)
                {
                    AssignRandomTargetToFighter(CurrentPlayer);
                }
                else
                {
                    throw new Exception("There are too many possible targets. Please choose one with the '!target characternamehere' command.");
                }
            }

            WaitingForAction = false;
            var action = DoAction(actionType, CurrentPlayer, CurrentTarget, tier);
            var allInvolvedActors = new List<TFighterState>
            {
                action.Attacker
            };
            allInvolvedActors.AddRange(action.Defenders);
            DisplayDeathMessagesIfNeedBe(allInvolvedActors);
            if (action.KeepActorsTurn && action.Missed == false)
            {
                Message.addHint($"[b]This is still your turn {action.Attacker.GetStylizedName()}![/b]");
                SendFightMessage();
                WaitingForAction = true;
            }
            else if (!IsOver)
            {
                NextTurn();
            }
            else
            {
                OnMatchEnding();
            }
        }

        public TActiveAction DoAction(TActionType actionType, TFighterState attacker, List<TFighterState> defenders, int tier)
        {
            var action = ActionFactory.Build(actionType, (TFight)this, attacker, defenders, tier);
            action.Execute();
            action.Save();
            PastActions.Add(action);
            return action;
        }

        public void DisplayDeathMessagesIfNeedBe(List<TFighterState> involvedActors)
        {
            foreach (var actor in involvedActors)
            {
                if (actor.IsTKO)
                {
                    actor.DisplayTKOMessage();
                }
            }
        }

        public void OnMatchEnding()
        {
            int tokensToGiveToWinners = (int)Enum.Parse(typeof(TokensPerWin), GetHighestQualifyingFightTier(WinnerTeam).ToString());
            int tokensToGiveToLosers = (int)(tokensToGiveToWinners * GameSettings.TokensPerLossMultiplier);
            if (IsDraw)
            {
                Message.addHit($"DOUBLE KO! Everyone is out! It's over!");
                tokensToGiveToLosers = tokensToGiveToWinners;
            }
            OutputStatus();

            EndFight(tokensToGiveToWinners, tokensToGiveToLosers);
        }



        public bool IsMatchInProgress()
        {
            return HasStarted && !HasEnded;
        }

        public FightTier GetHighestQualifyingFightTier(Team winnerTeam)
        {
            var highestWinnerTier = (int)FightTier.Bronze;
            foreach (var fighter in GetTeam(winnerTeam))
            {
                if ((int)fighter.User.FightTier > highestWinnerTier)
                {
                    highestWinnerTier = (int)fighter.User.FightTier;
                }
            }

            var lowestLoserTier = -99;
            foreach (var fighter in Fighters)
            {
                if (fighter.AssignedTeam != winnerTeam)
                {
                    if (lowestLoserTier == -99)
                    {
                        lowestLoserTier = (int)fighter.User.FightTier;
                    }
                    else if (lowestLoserTier > (int)fighter.User.FightTier)
                    {
                        lowestLoserTier = (int)fighter.User.FightTier;
                    }
                }
            }

            //If the loser was weaker, the fight fightTier matches the winner's fightTier
            //if the weakest wrestler was equal or more powerful, the fight fightTier matches the loser's fightTier
            var fightTier = highestWinnerTier;
            if (lowestLoserTier >= highestWinnerTier)
            {
                fightTier = lowestLoserTier;
            }

            return (FightTier)fightTier;
        }

        public void Forfeit(string fighterName)
        {
            var fighter = GetFighterByName(fighterName);
            if (fighter != null)
            {
                if (!fighter.IsTKO)
                {
                    fighter.FightStatus = FightStatus.Forfeited;
                    PunishPlayerOnForfeit(fighter);
                }
                else
                {
                    Message.addError(Messages.forfeitAlreadyOut);
                    SendFightMessage();
                    return;
                }
            }
            else
            {
                Message.AddInfo($"You are not participating in the match. OH, and that message should NEVER happen.");
                SendFightMessage();
                return;
            }
            SendFightMessage();
            if (IsOver)
            {
                int tokensToGiveToWinners = (int)((int)Enum.Parse(typeof(TokensPerWin), GetHighestQualifyingFightTier(WinnerTeam).ToString()) * GameSettings.TokensForWinnerByForfeitMultiplier);
                EndFight(tokensToGiveToWinners, 0);
            }
            else
            {
                OutputStatus();
            }
        }

        public void CheckForDraw()
        {
            var neededDrawFlags = AlivePlayers.Count;
            var drawFlags = 0;
            foreach (var fighter in AlivePlayers)
            {
                if (fighter.WantsDraw)
                {
                    drawFlags++;
                }
            }
            if (neededDrawFlags == drawFlags)
            {
                Message.AddInfo(Messages.CheckForDrawOK);
                SendFightMessage();
                int tokensToGive = CurrentTurn;
                int tokensMax = (int)Enum.Parse(typeof(TokensPerWin), nameof(FightTier.Bronze));
                if (tokensToGive > tokensMax)
                {
                    tokensToGive = tokensMax;
                }
                EndFight(0, tokensToGive, Team.White); //0 because there isn't a winning Team
            }
            else
            {
                Message.AddInfo(Messages.CheckForDrawWaiting);
                SendFightMessage();
            }
        }

        public void EndFight(int tokensToGiveToWinners, int tokensToGiveToLosers, Team? forceWinner = null)
        {
            HasEnded = true;
            HasStarted = false;

            if (!forceWinner.HasValue)
            {
                WinnerTeam = TeamsStillInGame[0];
            }
            else
            {
                WinnerTeam = forceWinner.Value;
            }
            if (WinnerTeam != Team.White)
            {
                Message.AddInfo(string.Format(Messages.endFightAnnounce, WinnerTeam));
                Message.addHit("Finisher suggestion: " + FightFinishers.pick());
                SendFightMessage();
            }

            var eloAverageOfWinners = 0;
            var intOfWinners = 0;
            var intOfLosers = 0;
            var eloAverageOfLosers = 0;
            int eloPointsChangeToWinners;
            int eloPointsChangeToLosers;
            foreach (var fighter in Fighters)
            {
                if (fighter.AssignedTeam == WinnerTeam)
                {
                    intOfWinners++;
                    eloAverageOfWinners += fighter.User.Stats.eloRating;
                }
                else
                {
                    intOfLosers++;
                    eloAverageOfLosers += fighter.User.Stats.eloRating;
                }
            }

            eloAverageOfWinners = (int)Math.Floor((double)eloAverageOfWinners / intOfWinners);
            eloAverageOfLosers = (int)Math.Floor((double)eloAverageOfLosers / intOfLosers);

            var beforeEloAverageOfWinners = eloAverageOfWinners;
            var beforeEloAverageOfLosers = eloAverageOfLosers;

            CalculateELO(ref eloAverageOfWinners, ref eloAverageOfLosers);
            eloPointsChangeToWinners = beforeEloAverageOfWinners - eloAverageOfWinners;
            eloPointsChangeToLosers = beforeEloAverageOfLosers - eloAverageOfLosers;

            foreach (var fighter in Fighters)
            {
                if (fighter.AssignedTeam == WinnerTeam)
                {
                    fighter.FightStatus = FightStatus.Won;
                    Message.AddInfo($"Awarded {tokensToGiveToWinners} {GameSettings.CurrencyName} to {fighter.GetStylizedName()}");
                    fighter.User.GiveTokens(tokensToGiveToWinners, TransactionType.FightReward, GameSettings.BotName);
                    fighter.User.Stats.wins++;
                    fighter.User.Stats.winsSeason++;
                    fighter.User.Stats.eloRating += eloPointsChangeToWinners;
                }
                else
                {
                    if (WinnerTeam != Team.White)
                    {
                        fighter.FightStatus = FightStatus.Lost;
                        fighter.User.Stats.losses++;
                        fighter.User.Stats.lossesSeason++;
                        fighter.User.Stats.eloRating += eloPointsChangeToLosers;
                    }
                    Message.AddInfo($"Awarded {tokensToGiveToLosers} {GameSettings.CurrencyName} to {fighter.GetStylizedName()}");
                    fighter.User.GiveTokens(tokensToGiveToLosers, TransactionType.FightReward, GameSettings.BotName);
                }
                Message.AddInfo(fighter.CheckAchievements((TFight)this));
            }

            SendFightMessage();
        }

        static double ExpectationToWin(int playerOneRating, int playerTwoRating)
        {
            return 1 / (1 + Math.Pow(10, (playerTwoRating - playerOneRating) / 400.0));
        }

        static void CalculateELO(ref int winnerRating, ref int loserRating)
        {
            int eloK = 32;

            int delta = (int)(eloK * (1 - ExpectationToWin(winnerRating, loserRating)));

            winnerRating += delta;
            loserRating -= delta;
        }

        public void ReorderFightersByInitiative(List<TFighterState> arrFightersSortedByInitiative)
        {
            var index = 0;
            foreach (var fighter in arrFightersSortedByInitiative)
            {
                var indexToMoveInFront = GetFighterIndex(fighter.Name);
                var temp = Fighters[index];
                Fighters[index] = Fighters[indexToMoveInFront];
                Fighters[indexToMoveInFront] = temp;
                index++;
            }
        }

        public List<TFighterState> AlivePlayers
        {
            get
            {
                var arrPlayers = new List<TFighterState>();
                foreach (var player in Fighters)
                {
                    if (!player.IsTKO && player.IsInTheRing)
                    {
                        arrPlayers.Add(player);
                    }
                }
                return arrPlayers;
            }
        }

        public TFighterState GetFighterByName(string name)
        {
            TFighterState fighter = null;
            foreach (var player in Fighters)
            {
                if (player.Name == name)
                {
                    fighter = player;
                }
            }
            return fighter;
        }

        public int GetFighterIndex(string fighterName)
        {
            return Fighters.FindIndex(x => x.Name == fighterName);
        }

        public int GetFirstPlayerIDAliveInTeam(Team Teams, int afterIndex = 0)
        {
            var fullTeam = GetTeam(Teams);
            var index = -1;
            for (var i = afterIndex; i < fullTeam.Count; i++)
            {
                if (fullTeam[i] != null && !fullTeam[i].IsTKO && fullTeam[i].IsInTheRing)
                {
                    index = i;
                }
            }
            return index;
        }

        public List<TFighterState> GetTeam(Team teamToSearch)
        {
            var teamList = new List<TFighterState>();
            foreach (var player in Fighters)
            {
                if (player.AssignedTeam == teamToSearch)
                {
                    teamList.Add(player);
                }
            }
            return teamList;
        }

        public int GetNumberOfPlayersInTeam(Team teamToSearch)
        {
            var fullTeamCount = GetTeam(teamToSearch);
            return fullTeamCount.Count;
        }

        public List<Team> AllOccupiedTeamsList
        {
            get
            {
                List<Team> usedTeams = new List<Team>();
                foreach (var player in Fighters)
                {
                    if (usedTeams.IndexOf(player.AssignedTeam) == -1)
                    {
                        usedTeams.Add(player.AssignedTeam);
                    }
                }
                return usedTeams;
            }
        }

        public List<Team> AllUsedTeams
        {
            get
            {
                List<Team> usedTeams = AllOccupiedTeamsList;

                var teamIndex = 0;
                while (usedTeams.Count < RequiredTeams)
                {
                    var teamToAdd = (Team)teamIndex;
                    if (usedTeams.IndexOf(teamToAdd) == -1)
                    {
                        usedTeams.Add(teamToAdd);
                    }
                    teamIndex++;
                }
                return usedTeams;
            }
        }

        public List<Team> TeamsStillInGame
        {
            get
            {
                List<Team> usedTeams = new List<Team>();
                foreach (var player in AlivePlayers)
                {
                    if (usedTeams.IndexOf(player.AssignedTeam) == -1)
                    {
                        usedTeams.Add(player.AssignedTeam);
                    }
                }
                return usedTeams;
            }
        }

        public Team RandomTeam
        {
            get
            {
                return TeamsStillInGame[Utils.Utils.GetRandomInt(0, NumberOfTeamsInvolved)];
            }
        }

        public int NumberOfTeamsInvolved
        {
            get
            {
                return TeamsStillInGame.Count;
            }
        }

        public Dictionary<Team, int> NumberOfPlayersPerTeam
        {
            get
            {
                var count = new Dictionary<Team, int>();
                foreach (var player in Fighters)
                {
                    if (!count.ContainsKey(player.AssignedTeam))
                    {
                        count.Add(player.AssignedTeam, 1);
                    }
                    else
                    {
                        count[player.AssignedTeam]++;
                    }
                }
                return count;
            }
        }

        public int MaxPlayersPerTeam
        {
            get
            { //returns 0 if there aren't any teams
                var maxCount = 0;
                foreach (var nb in NumberOfPlayersPerTeam)
                {
                    if (nb.Value > maxCount)
                    {
                        maxCount = nb.Value;
                    }
                }
                return maxCount;
            }
        }

        public bool IsEveryoneReady
        {
            get
            {
                var isEveryoneReady = true;
                foreach (var fighter in Fighters)
                {
                    if (!fighter.IsReady)
                    {
                        isEveryoneReady = false;
                    }
                }
                return isEveryoneReady;
            }
        }

        public Team FirstAvailableTeam
        {
            get
            {
                Team teamToUse = Team.Blue;
                var arrPlayersCount = new Dictionary<Team, int>();
                var usedTeams = AllUsedTeams;
                foreach (var teamId in usedTeams)
                {
                    arrPlayersCount.Add(teamId, GetNumberOfPlayersInTeam(teamId));
                }

                var mostPlayersInTeam = arrPlayersCount.Values.Max();
                var leastPlayersInTeam = arrPlayersCount.Values.Min();
                var firstEmptiestTeam = arrPlayersCount.FirstOrDefault(x => x.Value == leastPlayersInTeam);

                if (mostPlayersInTeam == leastPlayersInTeam || mostPlayersInTeam == int.MinValue || leastPlayersInTeam == int.MaxValue)
                {
                    teamToUse = Team.Blue;
                }
                else
                {
                    teamToUse = firstEmptiestTeam.Key;
                }

                return teamToUse;
            }
        }

        public TFighterState RandomFighter
        {
            get
            {
                return AlivePlayers[Utils.Utils.GetRandomInt(0, AlivePlayers.Count)];
            }
        }

        public TFighterState GetRandomFighterNotInTeam(Team team)
        {
            var tries = 0;
            TFighterState fighter = null;
            while (tries < 99 && (fighter == null || fighter.AssignedTeam == Team.White || fighter.AssignedTeam == team))
            {
                fighter = RandomFighter;
                tries++;
            }
            return fighter;
        }

        //Misc. shortcuts
        public int FighterCount
        {
            get
            {
                return Fighters.Count;
            }
        }

        public int AliveFighterCount
        {
            get
            {
                return AlivePlayers.Count;
            }
        }

        public abstract void PunishPlayerOnForfeit(TFighterState fighter);

    }
}