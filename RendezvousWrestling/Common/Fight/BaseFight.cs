using RendezvousWrestling.Common.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;

public abstract class BaseFight<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierParameters, TModifierType, TUser> : BaseEntity
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

    public int requiredTeams { get; set; }
    public bool hasStarted { get; set; } = false;
    public bool hasEnded { get; set; } = false;
    public string stage { get; set; }
    public int currentTurn { get; set; }
    public FightType fightType { get; set; }
    public Team winnerTeam { get; set; }
    public int season { get; set; }
    public bool waitingForAction { get; set; } = true;
    public FightLength fightLength { get; set; } = FightLength.Long;

    [NotMapped]
    public virtual List<TActiveAction> pastActions { get; set; }
    public virtual List<TFighterState> Fighters { get; set; }

    public string channel { get; set; }

    [NotMapped]
    public FightMessage message { get; set; }
    [NotMapped]
    public FChatSharpLib.BaseBot fChatLibInstance { get; set; }
    [NotMapped]
    public TActionFactory actionFactory { get; set; }

    public bool debug { get; set; } = false;
    public int forcedDiceRoll { get; set; } = 0;
    public bool diceLess { get; set; } = false;

    public BaseFight()
    {
        this.actionFactory = new TActionFactory();
        this.Id = Guid.NewGuid().ToString();
        this.Fighters = new List<TFighterState>();
        this.stage = FightingStages.pick();
        this.fightType = FightType.Classic;
        this.pastActions = new List<TActiveAction>();
        this.winnerTeam = Team.White;
        this.currentTurn = 0;
        this.season = GameSettings.currentSeason;
        this.requiredTeams = 2;
        this.diceLess = false;
        this.fightLength = FightLength.Long;
        this.actionFactory = actionFactory;
        this.message = new FightMessage();
    }

    public void build(FChatSharpLib.BaseBot fChatLibInstance, string channel)
    {
        this.fChatLibInstance = fChatLibInstance;
        this.channel = channel;
    }

    public void sendFightMessage()
    {
        this.fChatLibInstance.SendMessageInChannel(this.message.getMessage(), this.channel);
    }

    public void resendFightMessage()
    {
        this.fChatLibInstance.SendMessageInChannel(this.message.getLastMessage(), this.channel);
    }

    public void setTeamsCount(int intNewTeamsCount)
    {
        if (intNewTeamsCount >= 2)
        {
            this.requiredTeams = intNewTeamsCount;
            this.message.addInfo(Messages.changeMinTeamsInvolvedInFightOK);
        }
        else
        {
            this.message.addInfo(Messages.changeMinTeamsInvolvedInFightFail);
        }
        this.sendFightMessage();
    }

    public void setDiceLess(bool bln)
    {
        if (!this.hasStarted && !this.hasEnded)
        {
            this.diceLess = bln;
            this.message.addInfo(string.Format(Messages.setDiceLess, (bln ? "NOT " : "")));
        }
        else
        {
            this.message.addInfo(Messages.setDiceLessFail);
        }
        this.sendFightMessage();
    }

    public void setFightLength(FightLength fightDuration)
    {
        if (!this.hasStarted && !this.hasEnded)
        {
            this.fightLength = fightDuration;
            this.message.addInfo(string.Format(Messages.setFightLength, Enum.GetName(typeof(FightLength), fightDuration)));
        }
        else
        {
            this.message.addInfo(Messages.setFightLengthFail);
        }
        this.sendFightMessage();
    }

    public void setFightType(string type)
    {
        if (!this.hasStarted && !this.hasEnded)
        {
            var fightTypesList = Enum.GetNames(typeof(FightType));
            var foundAskedType = false;
            foreach (var fightTypeId in fightTypesList)
            {
                if (type.ToLower() == fightTypeId.ToLower())
                {
                    this.fightType = (FightType)Enum.Parse(typeof(FightType), fightTypeId);
                    //TODO this.message.addInfo(Messages["setFightType"+ fightTypeId]);
                    foundAskedType = true;
                    break;
                }
            }
            if (!foundAskedType)
            {
                this.fightType = FightType.Classic;
                this.message.addInfo(Messages.setFightTypeNotFound);
            }
        }
        else
        {
            this.message.addInfo(Messages.setFightTypeFail);
        }
        this.sendFightMessage();
    }

    //Pre-fight utils

    public bool leave(string fighterName)
    {
        if (!this.hasStarted)
        {
            var index = this.getFighterIndex(fighterName);
            if (index != -1)
            {
                var fighter = this.Fighters[index];
                this.Fighters.RemoveAt(index);
                return true;
            }
        }

        return false;
    }

    public Team join(string fighterName, Team team)
    {
        if (!this.hasStarted)
        {
            if (this.getFighterByName(fighterName) == null)
            { //find user by its name property instead of comparing objects, which doesn't work.
                TFighterState activeFighter = null; //await BaseFighterState.loadFighter(fighterName); //TODO DATABASE
                if (activeFighter == null)
                {
                    throw new Exception(Messages.errorNotRegistered);
                }
                if (!activeFighter.User.canPayAmount(GameSettings.tokensCostToFight))
                {
                    throw new Exception(string.Format(Messages.errorNotEnoughMoney, GameSettings.tokensCostToFight.ToString()));
                }
                var areStatsValid = activeFighter.validateStats();
                if (areStatsValid != "")
                {
                    throw new Exception(areStatsValid);
                }
                activeFighter.assignFight((TFight)this);
                activeFighter.initialize();
                activeFighter.fightStatus = FightStatus.Joined;
                if (team != Team.White)
                {
                    activeFighter.assignedTeam = team;
                }
                else
                {
                    team = this.getAvailableTeam();
                    activeFighter.assignedTeam = team;
                }
                this.Fighters.Add(activeFighter);
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

    public bool setFighterReady(string fighterName)
    {
        if (!this.hasStarted)
        {
            if (this.getFighterByName(fighterName) == null)
            {
                this.join(fighterName, Team.White);
            }
            var fighterInFight = this.getFighterByName(fighterName);
            if (fighterInFight != null && !fighterInFight.isReady)
            { //find user by its name property instead of comparing objects, which doesn't work.
                fighterInFight.isReady = true;
                fighterInFight.fightStatus = FightStatus.Ready;
                var fightTypes = Enum.GetNames(typeof(FightType));
                var listOfFightTypes = string.Join(", ", fightTypes);
                listOfFightTypes = listOfFightTypes.Replace(fightType.ToString(), $"[color=green][b]{fightType.ToString()}[/b][/color]");
                var fightDurations = Enum.GetNames(typeof(FightLength));
                var listOfFightDurations = string.Join(", ", fightDurations);
                listOfFightDurations = listOfFightDurations.Replace(this.fightLength.ToString(), $"[color=green][b]{this.fightLength.ToString()}[/b][/color]");
                this.message.addInfo(string.Format(Messages.Ready, fighterInFight.getStylizedName(), listOfFightTypes, this.requiredTeams.ToString(), listOfFightDurations));
                this.sendFightMessage();
                if (this.canStart())
                {
                    this.start();
                }
                return true;
            }
        }
        return false;
    }

    public bool canStart()
    {
        return (this.isEveryoneReady() && !this.hasStarted && this.getAllOccupiedTeams().Count >= this.requiredTeams); //only start if everyone's ready and if the teams are balanced
    }


    //RWFight logic

    public void start()
    {
        this.message.addInfo(string.Format(Messages.startMatchAnnounce, this.Id));
        this.currentTurn = 1;
        this.hasStarted = true;
        //TODO this.shufflePlayers(); //random order for teams

        this.message.addInfo(string.Format(Messages.startMatchStageAnnounce, this.stage));

        for (var i = 0; i < this.maxPlayersPerTeam; i++)
        { //Prints as much names as there are Team
            var fullStringVS = "[b]";
            foreach (var j in this.getTeamsStillInGame())
            {
                var theFighter = this.getTeam(j)[i];
                if (theFighter != null)
                {
                    fullStringVS = $"{fullStringVS} VS {theFighter.getStylizedName()}";
                }
            }
            fullStringVS = $"{fullStringVS}[/b]";
            fullStringVS = fullStringVS.Replace(" VS ", "");
            this.message.addInfo(fullStringVS);
        }


        this.reorderFightersByInitiative(this.rollAllDice(Trigger.InitiationRoll));
        this.message.addInfo(string.Format(Messages.startMatchFirstPlayer, this.currentPlayer.getStylizedName(), this.currentTeamName.ToLower(), this.currentTeamName));
        for (var i = 1; i < this.Fighters.Count; i++)
        {
            this.message.addInfo(string.Format(Messages.startMatchFollowedBy, this.Fighters[i].getStylizedName(), this.Fighters[i].assignedTeam.ToString().ToLower(), this.Fighters[i].assignedTeam.ToString().ToLower()));
            if (this.fightType == FightType.Tag)
            {
                this.Fighters[i].isInTheRing = false;
            }
        }
        if (this.fightType == FightType.Tag)
        { //if it's a tag match, only allow the first player of the next Team
            for (var i = 1; i < this.Fighters.Count; i++)
            {
                if (this.currentPlayer.assignedTeam != this.Fighters[i].assignedTeam)
                {
                    this.Fighters[i].isInTheRing = true;
                    break;
                }
            }
        }

        for (var i = 0; i < this.Fighters.Count; i++)
        {
            this.Fighters[i].fightStatus = FightStatus.Playing;
            int fightCost = GameSettings.tokensCostToFight;
            this.Fighters[i].User.removeTokens(fightCost, TransactionType.FightStart);
            this.Fighters[i].triggerFeatures(TriggerMoment.After, Trigger.InitiationRoll, GetFeatureParameter((TFight)this, this.Fighters[i]));
        }



        this.sendFightMessage();
        this.save();
        this.outputStatus();
    }

    private TFeatureParameters GetFeatureParameter(TFight fight = null, TFighterState fighter = null, TFighterState target = null, TActiveAction action = null)
    {
        var parameters = new TFeatureParameters();
        parameters.initialize(fight, fighter, target, action);
        return parameters;
    }

    public void requestDraw(string fighterName)
    {
        var fighter = this.getFighterByName(fighterName);
        if (fighter != null)
        {
            if (!fighter.isRequestingDraw())
            {
                fighter.requestDraw();
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

    public void unrequestDraw(string fighterName)
    {
        var fighter = this.getFighterByName(fighterName);
        if (fighter != null)
        {
            if (fighter.isRequestingDraw())
            {
                fighter.unrequestDraw();
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

    public virtual void nextTurn()
    {
        this.currentTurn++;

        foreach (var fighter in this.Fighters)
        {
            var strAchievements = fighter.checkAchievements((TFight)this);
            if (strAchievements != "")
            {
                this.message.addSpecial(strAchievements);
            }
        }

        if (this.isOver())
        { //Check for the ending
            int tokensToGiveToWinners = (int)Enum.Parse(typeof(TokensPerWin), this.getFightTier(this.winnerTeam).ToString());
            int tokensToGiveToLosers = (int)(tokensToGiveToWinners * GameSettings.tokensPerLossMultiplier);
            if (this.isDraw())
            {
                this.message.addHit($"DOUBLE KO! Everyone is out! It's over!");
                tokensToGiveToLosers = tokensToGiveToWinners;
            }
            this.outputStatus();
            this.endFight(tokensToGiveToWinners, tokensToGiveToLosers);
        }
        else
        {
            this.save();
            this.waitingForAction = true;
            this.outputStatus();
        }

        foreach (var fighter in this.Fighters)
        {
            fighter.nextRound();
        }
    }

    public bool isOver()
    {
        return this.getTeamsStillInGame().Count <= 1;
    }

    public bool isDraw()
    {
        return this.getTeamsStillInGame().Count == 0;
    }

    //Fighting info displays

    public void outputStatus()
    {
        this.message.addInfo(string.Format(Messages.outputStatusInfo, this.currentTurn.ToString(), this.currentTeamName.ToLower(), this.currentTeamName, this.currentPlayer.getStylizedName()));

        for (var i = 0; i < this.Fighters.Count; i++)
        { //Prints as much names as there are Team
            var theFighter = this.Fighters[i];
            if (theFighter != null)
            {
                this.message.addStatus(theFighter.outputStatus());
            }
        }

        this.sendFightMessage();
    }

    public Team currentTeam
    {
        get
        {
            return this.getAlivePlayers()[(this.currentTurn - 1) % this.aliveFighterCount].assignedTeam;
        }
    }

    public Team nextTeamToPlay
    {
        get
        {
            return this.getAlivePlayers()[this.currentTurn % this.aliveFighterCount].assignedTeam;
        }
    }

    public int currentPlayerIndex
    {
        get
        {
            var curTurn = 1;
            if (this.currentTurn > 0)
            {
                curTurn = this.currentTurn - 1;
            }
            return curTurn % this.aliveFighterCount;
        }
    }

    public TFighterState currentPlayer
    {
        get
        {
            return this.getAlivePlayers()[this.currentPlayerIndex];
        }
    }

    public TFighterState nextPlayer
    {
        get
        {
            return this.getAlivePlayers()[this.currentTurn % this.aliveFighterCount];
        }
    }

    public void setCurrentPlayer(string fighterName)
    {
        var index = this.Fighters.FindIndex((x) => x.Name == fighterName && !x.isTechnicallyOut());
        if (index != -1 && this.Fighters[this.currentPlayerIndex].Name != fighterName)
        { //switch positions
            var temp = this.Fighters[this.currentPlayerIndex];
            this.Fighters[this.currentPlayerIndex] = this.Fighters[index];
            this.Fighters[index] = temp;
            this.Fighters[this.currentPlayerIndex].isInTheRing = true;
            if (this.Fighters[index].assignedTeam == this.Fighters[this.currentPlayerIndex].assignedTeam && this.Fighters[index].isInTheRing == true && this.fightType == FightType.Tag)
            {
                this.Fighters[index].isInTheRing = false;
            }
            if (this.Fighters[index].assignedTeam != this.Fighters[this.currentPlayerIndex].assignedTeam && this.Fighters[this.currentPlayerIndex].isInTheRing == true && this.fightType == FightType.Tag)
            {
                this.Fighters.Where(x => x.isInTheRing && x.assignedTeam == this.Fighters[this.currentPlayerIndex].assignedTeam && x.Name != fighterName).ToList().ForEach(x => x.isInTheRing = false);
            }
            this.message.addInfo(string.Format(Messages.setCurrentPlayerOK, temp.Name, this.Fighters[this.currentPlayerIndex].Name));
        }
        else
        {
            this.message.addInfo(Messages.setCurrentPlayerFail);
        }
    }

    //RWFight helpers
    public string currentTeamName
    {
        get
        {
            return currentTeam.ToString();
        }
    }

    public List<TFighterState> currentTarget
    {
        get
        {
            return currentPlayer.getTargets();
        }
    }

    public void assignRandomTargetToAllFighters()
    {
        foreach (var fighter in this.getAlivePlayers())
        {
            this.assignRandomTargetToFighter(fighter);
        }
    }

    public void assignRandomTargetToFighter(TFighterState fighter)
    {
        fighter.targets.Add(this.getRandomFighterNotInTeam(fighter.assignedTeam).Name);
    }

    //Dice rolling
    public List<TFighterState> rollAllDice(Trigger triggeringEvent)
    {
        var arrSortedFightersByInitiative = new List<TFighterState>();
        foreach (var player in this.getAlivePlayers())
        {
            player.lastDiceRoll = player.roll(10, triggeringEvent);
            arrSortedFightersByInitiative.Add(player);
            this.message.addHint(string.Format(Messages.rollAllDiceEchoRoll, player.getStylizedName(), player.lastDiceRoll.ToString()));
        }

        arrSortedFightersByInitiative.Sort((a, b) =>
        {
            return b.lastDiceRoll - a.lastDiceRoll;
        });

        return arrSortedFightersByInitiative;
    }

    public TFighterState rollAllGetWinner(Trigger triggeringEvent)
    {
        return this.rollAllDice(triggeringEvent)[0];
    }

    //Attacks

    public void assignTarget(string fighterName, string name)
    {
        var theTarget = this.getFighterByName(name);
        if (theTarget != null)
        {
            this.getFighterByName(fighterName).targets = new List<string>() { theTarget.Name };
            this.message.addInfo("Target set to " + theTarget.getStylizedName());
            this.sendFightMessage();
        }
        else
        {
            this.message.addError("Target not found.");
            this.sendFightMessage();
        }
    }

    public async void prepareAction(string attacker, TActionType actionType, bool tierRequired, bool isCustomTargetInsteadOfTier, string args)
    {
        var tier = -1;
        if (!this.isMatchInProgress())
        {
            throw new Exception("There isn't any fight going on.");
        }

        if (!this.waitingForAction)
        {
            throw new Exception(Messages.lastActionStillProcessing);
        }

        if (this.currentPlayer == null || attacker != this.currentPlayer.Name)
        {
            throw new Exception(Messages.doActionNotActorsTurn);
        }

        int.TryParse(args, out tier);

        if (tierRequired && tier == -1)
        {
            throw new Exception($"The tier is required and neither Light, Medium or Heavy was specified. Example: !action Medium");
        }
        if (isCustomTargetInsteadOfTier)
        {
            TFighterState customTarget = this.getFighterByName(args);
            if (customTarget == null)
            {
                throw new Exception("The character to tag with is required and wasn't found.");
            }
            else
            {
                this.currentPlayer.targets = new List<string>() { customTarget.Name };
            }
        }

        if (this.getFighterByName(attacker) == null)
        {
            throw new Exception("You aren't participating in this fight.");
        }

        //Might need to disable this for self-targetted actions?
        if (this.currentTarget == null || this.currentTarget.Count() == 0)
        {
            if (this.Fighters.Where(x => x.assignedTeam != this.currentPlayer.assignedTeam && x.isInTheRing && !x.isTechnicallyOut()).Count() == 1)
            {
                this.assignRandomTargetToFighter(this.currentPlayer);
            }
            else
            {
                throw new Exception("There are too many possible targets. Please choose one with the '!target characternamehere' command.");
            }
        }

        this.waitingForAction = false;
        var action = this.doAction(actionType, this.currentPlayer, this.currentTarget, tier);
        var allInvolvedActors = new List<TFighterState>();
        allInvolvedActors.Add(action.Attacker);
        allInvolvedActors.AddRange(action.Defenders);
        this.displayDeathMessagesIfNeedBe(allInvolvedActors);
        if (action.KeepActorsTurn && action.Missed == false)
        {
            this.message.addHint($"[b]This is still your turn {action.Attacker.getStylizedName()}![/b]");
            this.sendFightMessage();
            this.waitingForAction = true;
        }
        else if (!this.isOver())
        {
            this.nextTurn();
        }
        else
        {
            this.onMatchEnding();
        }
    }

    public TActiveAction doAction(TActionType actionType, TFighterState attacker, List<TFighterState> defenders, int tier)
    {
        var action = this.actionFactory.GetAction(actionType, (TFight)this, attacker, defenders, tier);
        action.execute();
        action.save();
        this.pastActions.Add(action);
        return action;
    }

    public void displayDeathMessagesIfNeedBe(List<TFighterState> involvedActors)
    {
        foreach (var actor in involvedActors)
        {
            actor.isTechnicallyOut(true);
        }
    }

    public void onMatchEnding()
    {
        int tokensToGiveToWinners = (int)Enum.Parse(typeof(TokensPerWin), this.getFightTier(this.winnerTeam).ToString());
        int tokensToGiveToLosers = (int)(tokensToGiveToWinners * GameSettings.tokensPerLossMultiplier);
        if (this.isDraw())
        {
            this.message.addHit($"DOUBLE KO! Everyone is out! It's over!");
            tokensToGiveToLosers = tokensToGiveToWinners;
        }
        this.outputStatus();

        this.endFight(tokensToGiveToWinners, tokensToGiveToLosers);
    }



    public bool isMatchInProgress()
    {
        return (this.hasStarted && !this.hasEnded);
    }

    public FightTier getFightTier(Team winnerTeam)
    {
        var highestWinnerTier = (int)FightTier.Bronze;
        foreach (var fighter in this.getTeam(winnerTeam))
        {
            if ((int)fighter.User.getFightTier() > highestWinnerTier)
            {
                highestWinnerTier = (int)fighter.User.getFightTier();
            }
        }

        var lowestLoserTier = -99;
        foreach (var fighter in this.Fighters)
        {
            if (fighter.assignedTeam != winnerTeam)
            {
                if (lowestLoserTier == -99)
                {
                    lowestLoserTier = (int)fighter.User.getFightTier();
                }
                else if (lowestLoserTier > (int)fighter.User.getFightTier())
                {
                    lowestLoserTier = (int)fighter.User.getFightTier();
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

    public void forfeit(string fighterName)
    {
        var fighter = this.getFighterByName(fighterName);
        if (fighter != null)
        {
            if (!fighter.isTechnicallyOut())
            {
                fighter.fightStatus = FightStatus.Forfeited;
                this.punishPlayerOnForfeit(fighter);
            }
            else
            {
                this.message.addError(Messages.forfeitAlreadyOut);
                this.sendFightMessage();
                return;
            }
        }
        else
        {
            this.message.addInfo($"You are not participating in the match. OH, and that message should NEVER happen.");
            this.sendFightMessage();
            return;
        }
        this.sendFightMessage();
        if (this.isOver())
        {
            int tokensToGiveToWinners = (int)((int)Enum.Parse(typeof(TokensPerWin), this.getFightTier(this.winnerTeam).ToString()) * GameSettings.tokensForWinnerByForfeitMultiplier);
            this.endFight(tokensToGiveToWinners, 0);
        }
        else
        {
            this.outputStatus();
        }
    }

    public void checkForDraw()
    {
        var neededDrawFlags = this.getAlivePlayers().Count;
        var drawFlags = 0;
        foreach (var fighter in this.getAlivePlayers())
        {
            if (fighter.wantsDraw)
            {
                drawFlags++;
            }
        }
        if (neededDrawFlags == drawFlags)
        {
            this.message.addInfo(Messages.checkForDrawOK);
            this.sendFightMessage();
            int tokensToGive = this.currentTurn;
            int tokensMax = (int)(Enum.Parse(typeof(TokensPerWin), nameof(FightTier.Bronze)));
            if (tokensToGive > tokensMax)
            {
                tokensToGive = tokensMax;
            }
            this.endFight(0, tokensToGive, Team.White); //0 because there isn't a winning Team
        }
        else
        {
            this.message.addInfo(Messages.checkForDrawWaiting);
            this.sendFightMessage();
        }
    }

    public void endFight(int tokensToGiveToWinners, int tokensToGiveToLosers, Team? forceWinner = null)
    {
        this.hasEnded = true;
        this.hasStarted = false;

        if (!forceWinner.HasValue)
        {
            this.winnerTeam = this.getTeamsStillInGame()[0];
        }
        else
        {
            this.winnerTeam = forceWinner.Value;
        }
        if (this.winnerTeam != Team.White)
        {
            this.message.addInfo(string.Format(Messages.endFightAnnounce, this.winnerTeam));
            this.message.addHit("Finisher suggestion: " + FightFinishers.pick());
            this.sendFightMessage();
        }

        var eloAverageOfWinners = 0;
        var intOfWinners = 0;
        var intOfLosers = 0;
        var eloAverageOfLosers = 0;
        int eloPointsChangeToWinners;
        int eloPointsChangeToLosers;
        foreach (var fighter in this.Fighters)
        {
            if (fighter.assignedTeam == this.winnerTeam)
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

        dynamic eloResults = new Exception();//TODO!!!  EloRating.calculate(eloAverageOfWinners, eloAverageOfLosers);
        eloPointsChangeToWinners = eloResults.playerRating - eloAverageOfWinners;
        eloPointsChangeToLosers = eloResults.opponentRating - eloAverageOfLosers;

        foreach (var fighter in this.Fighters)
        {
            if (fighter.assignedTeam == this.winnerTeam)
            {
                fighter.fightStatus = FightStatus.Won;
                this.message.addInfo($"Awarded {tokensToGiveToWinners} {GameSettings.currencyName} to {fighter.getStylizedName()}");
                fighter.User.giveTokens(tokensToGiveToWinners, TransactionType.FightReward, GameSettings.botName);
                fighter.User.Stats.wins++;
                fighter.User.Stats.winsSeason++;
                fighter.User.Stats.eloRating += eloPointsChangeToWinners;
            }
            else
            {
                if (this.winnerTeam != Team.White)
                {
                    fighter.fightStatus = FightStatus.Lost;
                    fighter.User.Stats.losses++;
                    fighter.User.Stats.lossesSeason++;
                    fighter.User.Stats.eloRating += eloPointsChangeToLosers;
                }
                this.message.addInfo($"Awarded {tokensToGiveToLosers} {GameSettings.currencyName} to {fighter.getStylizedName()}");
                fighter.User.giveTokens(tokensToGiveToLosers, TransactionType.FightReward, GameSettings.botName);
            }
            this.message.addInfo(fighter.checkAchievements((TFight)this));
            fighter.save();
        }

        this.sendFightMessage();

        this.save();
    }

    public void reorderFightersByInitiative(List<TFighterState> arrFightersSortedByInitiative)
    {
        var index = 0;
        foreach (var fighter in arrFightersSortedByInitiative)
        {
            var indexToMoveInFront = this.getFighterIndex(fighter.Name);
            var temp = this.Fighters[index];
            this.Fighters[index] = this.Fighters[indexToMoveInFront];
            this.Fighters[indexToMoveInFront] = temp;
            index++;
        }
    }

    public List<TFighterState> getAlivePlayers()
    {
        var arrPlayers = new List<TFighterState>();
        foreach (var player in this.Fighters)
        {
            if (!player.isTechnicallyOut() && player.isInTheRing)
            {
                arrPlayers.Add(player);
            }
        }
        return arrPlayers;
    }

    public TFighterState getFighterByName(string name)
    {
        TFighterState fighter = null;
        foreach (var player in this.Fighters)
        {
            if (player.Name == name)
            {
                fighter = player;
            }
        }
        return fighter;
    }

    public int getFighterIndex(string fighterName)
    {
        var index = -1;
        for (var i = 0; i < this.Fighters.Count; i++)
        {
            if (this.Fighters[i].Name == fighterName)
            {
                index = i;
            }
        }
        return index;
    }

    public int getFirstPlayerIDAliveInTeam(Team Teams, int afterIndex = 0)
    {
        var fullTeam = this.getTeam(Teams);
        var index = -1;
        for (var i = afterIndex; i < fullTeam.Count; i++)
        {
            if (fullTeam[i] != null && !fullTeam[i].isTechnicallyOut() && fullTeam[i].isInTheRing)
            {
                index = i;
            }
        }
        return index;
    }

    public List<TFighterState> getTeam(Team teamToSearch)
    {
        var teamList = new List<TFighterState>();
        foreach (var player in this.Fighters)
        {
            if (player.assignedTeam == teamToSearch)
            {
                teamList.Add(player);
            }
        }
        return teamList;
    }

    public int getNumberOfPlayersInTeam(Team teamToSearch)
    {
        var fullTeamCount = this.getTeam(teamToSearch);
        return fullTeamCount.Count;
    }

    public List<Team> getAllOccupiedTeams()
    {
        List<Team> usedTeams = new List<Team>();
        foreach (var player in this.Fighters)
        {
            if (usedTeams.IndexOf(player.assignedTeam) == -1)
            {
                usedTeams.Add(player.assignedTeam);
            }
        }
        return usedTeams;
    }

    public List<Team> getAllUsedTeams()
    {
        List<Team> usedTeams = this.getAllOccupiedTeams();

        var teamIndex = 0;
        while (usedTeams.Count < this.requiredTeams)
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

    public List<Team> getTeamsStillInGame()
    {
        List<Team> usedTeams = new List<Team>();
        foreach (var player in this.getAlivePlayers())
        {
            if (usedTeams.IndexOf(player.assignedTeam) == -1)
            {
                usedTeams.Add(player.assignedTeam);
            }
        }
        return usedTeams;
    }

    public Team getRandomTeam()
    {
        return this.getTeamsStillInGame()[Utils.getRandomInt(0, this.numberOfTeamsInvolved)];
    }

    public int numberOfTeamsInvolved
    {
        get
        {
            return this.getTeamsStillInGame().Count;
        }
    }

    public Dictionary<Team, int> numberOfPlayersPerTeam
    {
        get
        {
            var count = new Dictionary<Team, int>();
            foreach (var player in this.Fighters)
            {
                if (!count.ContainsKey(player.assignedTeam))
                {
                    count.Add(player.assignedTeam, 1);
                }
                else
                {
                    count[player.assignedTeam]++;
                }
            }
            return count;
        }
    }

    public int maxPlayersPerTeam
    {
        get
        { //returns 0 if there aren't any teams
            var maxCount = 0;
            foreach (var nb in this.numberOfPlayersPerTeam)
            {
                if (nb.Value > maxCount)
                {
                    maxCount = nb.Value;
                }
            }
            return maxCount;
        }
    }

    public bool isEveryoneReady()
    {
        var isEveryoneReady = true;
        foreach (var fighter in this.Fighters)
        {
            if (!fighter.isReady)
            {
                isEveryoneReady = false;
            }
        }
        return isEveryoneReady;
    }

    public Team getAvailableTeam()
    {
        Team teamToUse = Team.Blue;
        var arrPlayersCount = new Dictionary<Team, int>();
        var usedTeams = this.getAllUsedTeams();
        foreach (var teamId in usedTeams)
        {
            arrPlayersCount.Add(teamId, this.getNumberOfPlayersInTeam(teamId));
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

    public TFighterState getRandomFighter()
    {
        return this.getAlivePlayers()[Utils.getRandomInt(0, this.getAlivePlayers().Count)];
    }

    public TFighterState getRandomFighterNotInTeam(Team Teams)
    {
        var tries = 0;
        TFighterState fighter = null;
        while (tries < 99 && (fighter == null || fighter.assignedTeam == Team.White || fighter.assignedTeam == Teams))
        {
            fighter = this.getRandomFighter();
            tries++;
        }
        return fighter;
    }

    //Misc. shortcuts
    public int fighterCount
    {
        get
        {
            return this.Fighters.Count;
        }
    }

    public int aliveFighterCount
    {
        get
        {
            return this.getAlivePlayers().Count;
        }
    }

    public abstract void punishPlayerOnForfeit(TFighterState fighter);
    public abstract void save();

}

public enum FightStatus
{
    Idle = -2,
    Initialized = -1,
    Lost = 0,
    Won = 1,
    Playing = 2,
    Forfeited = 3,
    Joined = 4,
    Ready = 5,
    Draw = 6
}