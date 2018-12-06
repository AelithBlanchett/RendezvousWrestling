using System;
using System.Collections.Generic;

public abstract class BaseFight<FighterState, Modifier> where Modifier : BaseModifier where FighterState : BaseFighterState<Modifier>
{

    public string idFight { get; set; }
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

    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public bool deleted { get; set; } = false;


    public List<BaseActiveAction<BaseFight<FighterState, Modifier>, FighterState, Modifier>> pastActions { get; set; }
    public List<FighterState> fighters { get; set; }

    public string channel { get; set; }
    public FightMessage message { get; set; }
    public FChatSharpLib.BaseBot fChatLibInstance { get; set; }
    public IActionFactory<BaseFight<FighterState, Modifier>, FighterState, Modifier> actionFactory { get; set; }

    public bool debug { get; set; } = false;
    public int forcedDiceRoll { get; set; } = 0;
    public bool diceLess { get; set; } = false;

    public BaseFight(IActionFactory<BaseFight<FighterState, Modifier>, FighterState, Modifier> actionFactory)
    {
        this.idFight = Guid.NewGuid().ToString();
        this.fighters = [];
        this.stage = FightingStages.pick();
        this.fightType = FightType.Classic;
        this.pastActions = [];
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

    public async void leave(string fighterName)
    {
        if (!this.hasStarted)
        {
            var index = this.getFighterIndex(fighterName);
            if (index != -1)
            {
                var fighter = this.fighters[index];
                this.fighters.RemoveAt(index);
            }
        }
    }

    public int join(string fighterName, Team team)
    {
        if (!this.hasStarted)
        {
            if (!this.getFighterByName(fighterName))
            { //find user by its name property instead of comparing objects, which doesn't work.
                FighterState activeFighter = null; //await BaseFighterState.loadFighter(fighterName);//TODO fix this
                if (activeFighter == null)
                {
                    throw new Exception(Messages.errorNotRegistered);
                }
                if (!activeFighter.user.canPayAmount(GameSettings.tokensCostToFight))
                {
                    throw new Exception(string.Format(Messages.errorNotEnoughMoney, [GameSettings.tokensCostToFight.toString()]));
                }
                var areStatsValid = activeFighter.validateStats();
                if (areStatsValid != "")
                {
                    throw new Exception(areStatsValid);
                }
                activeFighter.assignFight(this);
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
                this.fighters.Add(activeFighter);
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
            if (!this.getFighterByName(fighterName))
            {
                this.join(fighterName, Team.White);
            }
            var fighterInFight = this.getFighterByName(fighterName);
            if (fighterInFight.HasValue && !fighterInFight.Value.isReady)
            { //find user by its name property instead of comparing objects, which doesn't work.
                fighterInFight.Value.isReady = true;
                fighterInFight.Value.fightStatus = FightStatus.Ready;
                var fightTypes = Enum.GetNames(typeof(FightType));
                var listOfFightTypes = string.Join(", ", fightTypes);
                listOfFightTypes = listOfFightTypes.Replace(fightType.ToString(), $"[color=green][b]{fightType.ToString()}[/b][/color]");
                var fightDurations = Enum.GetNames(typeof(FightLength));
                var listOfFightDurations = string.Join(", ", fightDurations);
                listOfFightDurations = listOfFightDurations.Replace(this.fightLength.ToString(), $"[color=green][b]{this.fightLength.ToString()}[/b][/color]");
                this.message.addInfo(string.Format(Messages.Ready, [fighterInFight.Value.getStylizedName(), listOfFightTypes, this.requiredTeams.ToString(), listOfFightDurations]));
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
        return (this.isEveryoneReady() && !this.hasStarted && this.getAllOccupiedTeams().length >= this.requiredTeams); //only start if everyone's ready and if the teams are balanced
    }


    //RWFight logic

    public void start()
    {
        this.message.addInfo(string.Format(Messages.startMatchAnnounce, [this.idFight]));
        this.currentTurn = 1;
        this.hasStarted = true;
        this.shufflePlayers(); //random order for teams

        this.message.addInfo(string.Format(Messages.startMatchStageAnnounce, [this.stage]));

        for (var i = 0; i < this.maxPlayersPerTeam; i++)
        { //Prints as much names as there are Team
            var fullStringVS = "[b]";
            foreach (var j in this.getTeamsStillInGame())
            {
                var theFighter = this.getTeam(j)[i];
                if (theFighter != null)
                {
                    fullStringVS = "${fullStringVS} VS ${theFighter.getStylizedName()}";
                }
            }
            fullStringVS = "${fullStringVS}[/b]";
            fullStringVS = fullStringVS.replace(" VS ", "");
            this.message.addInfo(fullStringVS);
        }


        this.reorderFightersByInitiative(this.rollAllDice(Trigger.InitiationRoll));
        this.message.addInfo(string.Format(Messages.startMatchFirstPlayer, [this.currentPlayer.getStylizedName(), this.currentTeamName.toLowerCase(), this.currentTeamName]));
        for (var i = 1; i < this.fighters.length; i++)
        {
            this.message.addInfo(string.Format(Messages.startMatchFollowedBy, [this.fighters[i].getStylizedName(), Team[this.fighters[i].assignedTeam].toLowerCase(), Team[this.fighters[i].assignedTeam]]));
            if (this.fightType == FightType.Tag)
            {
                this.fighters[i].isInTheRing = false;
            }
        }
        if (this.fightType == FightType.Tag)
        { //if it's a tag match, only allow the first player of the next Team
            for (var i = 1; i < this.fighters.length; i++)
            {
                if (this.currentPlayer.assignedTeam != this.fighters[i].assignedTeam)
                {
                    this.fighters[i].isInTheRing = true;
                    break;
                }
            }
        }

        for (var i = 0; i < this.fighters.length; i++)
        {
            this.fighters[i].fightStatus = FightStatus.Playing;
            int fightCost = GameSettings.tokensCostToFight;
            this.fighters[i].user.removeTokens(fightCost, TransactionType.FightStart);
            this.fighters[i].triggerFeatures(TriggerMoment.After, Trigger.InitiationRoll, new BaseFeatureParameter(this, this.fighters[i]));
        }



        this.sendFightMessage();
        this.save();
        this.outputStatus();
    }

    public void requestDraw(string fighterName)
    {
        var fighter = this.getFighterByName(fighterName);
        if (fighter)
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
        if (fighter)
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

    public async void nextTurn()
    {
        this.currentTurn++;

        foreach (var fighter in this.fighters)
        {
            var strAchievements = await fighter.checkAchievements(this);
            if (strAchievements != "")
            {
                this.message.addSpecial(strAchievements);
            }
        }

        if (this.isOver())
        { //Check for the ending
            int tokensToGiveToWinners = TokensPerWin[FightTier[this.getFightTier(this.winnerTeam)]];
            int tokensToGiveToLosers = tokensToGiveToWinners * GameSettings.tokensPerLossMultiplier;
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

        foreach (var fighter in this.fighters)
        {
            fighter.nextRound();
        }
    }

    public bool isOver()
    {
        return this.getTeamsStillInGame().length <= 1;
    }

    public bool isDraw()
    {
        return this.getTeamsStillInGame().length == 0;
    }

    public void waitUntilWaitingForAction()
    {
        //while((!this.hasStarted || !this.waitingForAction || this.currentTurn <= 0) && !this.hasEnded){
        //    await new Promise(resolve => setTimeout(resolve, 1))
        //}
        //return;
    }

    //Fighting info displays

    public void outputStatus()
    {
        this.message.addInfo(string.Format(Messages.outputStatusInfo, [this.currentTurn.toString(), this.currentTeamName.toLowerCase(), this.currentTeamName, this.currentPlayer.getStylizedName()]));

        for (var i = 0; i < this.fighters.length; i++)
        { //Prints as much names as there are Team
            var theFighter = this.fighters[i];
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

    public FighterState currentPlayer
    {
        get
        {
            return this.getAlivePlayers()[this.currentPlayerIndex];
        }
    }

    public FighterState nextPlayer
    {
        get
        {
            return this.getAlivePlayers()[this.currentTurn % this.aliveFighterCount];
        }
    }

    public void setCurrentPlayer(string fighterName)
    {
        var index = this.fighters.FindIndex((x) => x.name == fighterName && !x.isTechnicallyOut());
        if (index != -1 && this.fighters[this.currentPlayerIndex].name != fighterName)
        { //switch positions
            var temp = this.fighters[this.currentPlayerIndex];
            this.fighters[this.currentPlayerIndex] = this.fighters[index];
            this.fighters[index] = temp;
            this.fighters[this.currentPlayerIndex].isInTheRing = true;
            if (this.fighters[index].assignedTeam == this.fighters[this.currentPlayerIndex].assignedTeam && this.fighters[index].isInTheRing == true && this.fightType == FightType.Tag)
            {
                this.fighters[index].isInTheRing = false;
            }
            if (this.fighters[index].assignedTeam != this.fighters[this.currentPlayerIndex].assignedTeam && this.fighters[this.currentPlayerIndex].isInTheRing == true && this.fightType == FightType.Tag)
            {
                this.fighters.filter(x => x.isInTheRing && x.assignedTeam == this.fighters[this.currentPlayerIndex].assignedTeam && x.name != fighterName).forEach(x => x.isInTheRing = false);
            }
            this.message.addInfo(string.Format(Messages.setCurrentPlayerOK, [temp.name, this.fighters[this.currentPlayerIndex].name]));
        }
        else
        {
            this.message.addInfo(Messages.setCurrentPlayerFail)
            }
    }

    //RWFight helpers
    public string currentTeamName
    {
        get
        {
            return Team[this.currentTeam];
        }
    }

    public BaseFighterState[] currentTarget
    {
        get
        {
            return this.currentPlayer.getTargets();
        }
    }

¸public void assignRandomTargetToAllFighters()
    {
        foreach (var fighter in this.getAlivePlayers())
        {
            this.assignRandomTargetToFighter(fighter);
        }
    }

    public void assignRandomTargetToFighter(FighterState fighter)  {
        fighter.targets.Add(this.getRandomFighterNotInTeam(fighter.assignedTeam).name);
    }

    //Dice rolling
    public List<FighterState>  rollAllDice(Trigger triggeringEvent) {
        var arrSortedFightersByInitiative = [];
        for (var player of this.getAlivePlayers()) {
    player.lastDiceRoll = player.roll(10, triggeringEvent);
    arrSortedFightersByInitiative.Add(player);
    this.message.addHint(string.Format(Messages.rollAllDiceEchoRoll, [player.getStylizedName(), player.lastDiceRoll.toString()]));
}

arrSortedFightersByInitiative.sort((a, b):int => {
    return b.lastDiceRoll - a.lastDiceRoll;
});

        return arrSortedFightersByInitiative;
}

public FighterState rollAllGetWinner(TriggertriggeringEvent)  {
        return this.rollAllDice(triggeringEvent)[0];
    }

//Attacks

public voidassignTarget(string fighterName, string name)
{
    var theTarget = this.getFighterByName(name);
    if (theTarget != null)
    {
        this.getFighterByName(fighterName).targets = [theTarget.name];
        this.message.addInfo("Target set to " + theTarget.getStylizedName());
        this.sendFightMessage();
    }
    else
    {
        this.message.addError("Target not found.");
        this.sendFightMessage();
    }
}

public void prepareAction(string attacker, string actionType, bool tierRequired, bool isCustomTargetInsteadOfTier, string args)
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

    if (this.currentPlayer == null || attacker != this.currentPlayer.name)
    {
        throw new Exception(Messages.doActionNotActorsTurn);
    }

    if (!isNaN(int(args)))
    {
        tier = int.Parse(args);
    }

    if (tierRequired && tier == -1)
    {
        throw new Exception($"The tier is required and neither Light, Medium or Heavy was specified. Example: !action Medium");
    }
    if (isCustomTargetInsteadOfTier)
    {
        FighterState customTarget = this.getFighterByName(args);
        if (customTarget == null)
        {
            throw new Exception("The character to tag with is required and wasn't found.");
        }
        else
        {
            this.currentPlayer.targets = [customTarget.name];
        }
    }

    if (!this.getFighterByName(attacker))
    {
        throw new Error("You aren't participating in this fight.");
    }

    //Might need to disable this for self-targetted actions?
    if (this.currentTarget == null || this.currentTarget.length == 0)
    {
        if (this.fighters.filter(x => x.assignedTeam != this.currentPlayer.assignedTeam && x.isInTheRing && !x.isTechnicallyOut()).length == 1)
        {
            this.assignRandomTargetToFighter(this.currentPlayer);
        }
        else
        {
            throw new Error("There are too many possible targets. Please choose one with the '!target characternamehere' command.");
        }
    }

    this.waitingForAction = false;
    var action = this.doAction(actionType, this.currentPlayer, this.currentTarget, tier);
    this.displayDeathMessagesIfNeedBe([action.attacker, ...action.defenders]);
    if (action.keepActorsTurn && action.missed == false)
    {
        this.message.addHint($"[b]This is still your turn ${action.attacker.getStylizedName()}![/b]");
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

public BaseActiveAction doAction(string actionName, FighterState[] attacker, FighterState[]  defenders, int tier ) {
        BaseActiveAction action = this.actionFactory.getAction(actionName, this, attacker, defenders, tier);
action.execute();
        await action.save();
        this.pastActions.Add(action);
        return action;
    }

displayDeathMessagesIfNeedBe(involvedActors:BaseFighterState[])
{
    for (var actor of involvedActors)
    {
        actor.isTechnicallyOut(true);
    }
}

public async void onMatchEnding()
{
    int tokensToGiveToWinners = TokensPerWin[FightTier[this.getFightTier(this.winnerTeam)]];
    int tokensToGiveToLosers = tokensToGiveToWinners * GameSettings.tokensPerLossMultiplier;
    if (this.isDraw())
    {
        this.message.addHit($"DOUBLE KO! Everyone is out! It's over!");
        tokensToGiveToLosers = tokensToGiveToWinners;
    }
    this.outputStatus();

    await this.endFight(tokensToGiveToWinners, tokensToGiveToLosers);
}



isMatchInProgress() :bool{
        return (this.hasStarted && !this.hasEnded);
}

getFightTier(winnerTeam)
{
    var highestWinnerTier = FightTier.Bronze;
    for (var fighter of this.getTeam(winnerTeam))
    {
        if (fighter.user.fightTier() > highestWinnerTier)
        {
            highestWinnerTier = fighter.user.fightTier();
        }
    }

    var lowestLoserTier = -99;
    for (var fighter of this.fighters)
    {
        if (fighter.assignedTeam != winnerTeam)
        {
            if (lowestLoserTier == -99)
            {
                lowestLoserTier = fighter.user.fightTier();
            }
            else if (lowestLoserTier > fighter.user.fightTier())
            {
                lowestLoserTier = fighter.user.fightTier();
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

    return fightTier;
}

public async void forfeit(fighterName:string)
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
        int tokensToGiveToWinners = TokensPerWin[FightTier[this.getFightTier(this.winnerTeam)]] * GameSettings.tokensForWinnerByForfeitMultiplier;
        await this.endFight(tokensToGiveToWinners, 0);
    }
    else
    {
        this.outputStatus();
    }
}

public async void checkForDraw()
{
    var neededDrawFlags = this.getAlivePlayers().length;
    var drawFlags = 0;
    for (var fighter of this.getAlivePlayers())
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
        if (tokensToGive > parseInt(TokensPerWin[FightTier.Bronze]))
        {
            tokensToGive = parseInt(TokensPerWin[FightTier.Bronze]);
        }
        await this.endFight(0, tokensToGive, Team.White); //0 because there isn't a winning Team
    }
    else
    {
        this.message.addInfo(Messages.checkForDrawWaiting);
        this.sendFightMessage();
    }
}

public async void endFight(int tokensToGiveToWinners, int, forceWinner?:Team tokensToGiveToLosers)
{
    this.hasEnded = true;
    this.hasStarted = false;

    if (!forceWinner)
    {
        this.winnerTeam = this.getTeamsStillInGame()[0];
    }
    else
    {
        this.winnerTeam = forceWinner;
    }
    if (this.winnerTeam != Team.White)
    {
        this.message.addInfo(string.Format(Messages.endFightAnnounce, [Team[this.winnerTeam]]));
public  " + FightFinishers.pick())            this.message.addHit("Finisher suggestion { get; set; }
            this.sendFightMessage();
        }

var eloAverageOfWinners = 0;
var intOfWinners = 0;
var intOfLosers = 0;
var eloAverageOfLosers = 0;
public int var eloPointsChangeToWinners {get; set;}
public int var eloPointsChangeToLosers {get; set;}
        for (var fighter of this.fighters) {
    if (fighter.assignedTeam == this.winnerTeam)
    {
        intOfWinners++;
        eloAverageOfWinners += fighter.user.statistics.eloRating;
    }
    else
    {
        intOfLosers++;
        eloAverageOfLosers += fighter.user.statistics.eloRating;
    }
}

eloAverageOfWinners = Math.floor(eloAverageOfWinners / intOfWinners);
eloAverageOfLosers = Math.floor(eloAverageOfLosers / intOfLosers);

var eloResults = EloRating.calculate(eloAverageOfWinners, eloAverageOfLosers);
eloPointsChangeToWinners = eloResults.playerRating - eloAverageOfWinners;
eloPointsChangeToLosers = eloResults.opponentRating - eloAverageOfLosers;

        for (var fighter of this.fighters) {
    if (fighter.assignedTeam == this.winnerTeam)
    {
        fighter.fightStatus = FightStatus.Won;
        this.message.addInfo($"Awarded ${tokensToGiveToWinners} ${GameSettings.currencyName} to ${fighter.getStylizedName()}");
        await fighter.user.giveTokens(tokensToGiveToWinners, TransactionType.FightReward, GameSettings.botName);
        fighter.user.statistics.wins++;
        fighter.user.statistics.winsSeason++;
        fighter.user.statistics.eloRating += eloPointsChangeToWinners;
    }
    else
    {
        if (this.winnerTeam != Team.White)
        {
            fighter.fightStatus = FightStatus.Lost;
            fighter.user.statistics.losses++;
            fighter.user.statistics.lossesSeason++;
            fighter.user.statistics.eloRating += eloPointsChangeToLosers;
        }
        this.message.addInfo($"Awarded ${tokensToGiveToLosers} ${GameSettings.currencyName} to ${fighter.getStylizedName()}");
        await fighter.user.giveTokens(tokensToGiveToLosers, TransactionType.FightReward, GameSettings.botName);
    }
    this.message.addInfo(await fighter.checkAchievements(this));
    await fighter.save();
}

        this.sendFightMessage();

await this.save();
}

reorderFightersByInitiative(arrFightersSortedByInitiative:Array<FighterState>)
{
    var index = 0;
    for (var fighter of arrFightersSortedByInitiative)
    {
        var indexToMoveInFront = this.getFighterIndex(fighter.name);
        var temp = this.fighters[index];
        this.fighters[index] = this.fighters[indexToMoveInFront];
        this.fighters[indexToMoveInFront] = temp;
        index++;
    }
}

getAlivePlayers() :Array<FighterState> {
        var arrPlayers = [];
        for (var player of this.fighters) {
    if (!player.isTechnicallyOut() && player.isInTheRing)
    {
        arrPlayers.Add(player);
    }
}
        return arrPlayers;
}

getFighterByName(name:string) :FighterState {
        FighterState fighter = null;
        for (var player of this.fighters) {
    if (player.name == name)
    {
        fighter = player;
    }
}
        return fighter;
}

getFighterIndex(fighterName:string)
{
    var index = -1;
    for (var i = 0; i < this.fighters.length; i++)
    {
        if (this.fighters[i].name == fighterName)
        {
            index = i;
        }
    }
    return index;
}

getFirstPlayerIDAliveInTeam(Team Teams, int = 0  afterIndex) :int {
        var fullTeam = this.getTeam(Teams);
var index = -1;
        for (var i = afterIndex; i<fullTeam.length; i++) {
            if (fullTeam[i] != null && !fullTeam[i].isTechnicallyOut() && fullTeam[i].isInTheRing) {
                index = i;
            }
        }
        return index;
    }

    shufflePlayers() :void {
        for (var i = 0; i< this.fighters.length - 1; i++) {
            var j = i + Math.floor(Math.random() * (this.fighters.length - i));
var temp = this.fighters[j];
            this.fighters[j] = this.fighters[i];
            this.fighters[i] = temp;
        }
    }

    getTeam(Teams:Team) :Array<FighterState> {
        var teamList = [];
        for (var player of this.fighters) {
    if (player.assignedTeam == Teams)
    {
        teamList.Add(player);
    }
}
        return teamList;
}

getintOfPlayersInTeam(Teams:Team) :int {
        var fullTeamCount = this.getTeam(Teams);
        return fullTeamCount.length;
    }

    getAllOccupiedTeams() :Array<Team> {
        Array<Team> usedTeams = [];
        for (var player of this.fighters) {
    if (usedTeams.IndexOf(player.assignedTeam) == -1)
    {
        usedTeams.Add(player.assignedTeam);
    }
}
        return usedTeams;
}

getAllUsedTeams() :Array<Team> {
        Array<Team> usedTeams = this.getAllOccupiedTeams();

var teamIndex = 0;
        while (usedTeams.length< this.requiredTeams) {
            var teamToAdd = Team[Team[teamIndex]];
            if (usedTeams.IndexOf(teamToAdd) == -1) {
                usedTeams.Add(teamToAdd);
            }
            teamIndex++;
        }
        return usedTeams;
    }

    getTeamsStillInGame() :Array<Team> {
        Array<Team> usedTeams = [];
        for (var player of this.getAlivePlayers()) {
    if (usedTeams.IndexOf(player.assignedTeam) == -1)
    {
        usedTeams.Add(player.assignedTeam);
    }
}
        return usedTeams;
}

getTeamsIdList() :Array<int> {
        var arrResult = [];
        for (var enumMember in Team) {
            var isValueProperty = parseInt(enumMember, 10) >= 0;
            if (isValueProperty) {
                arrResult.Add(enumMember);
            }
        }
        return arrResult;
    }

    getRandomTeam() :Team {
        return this.getTeamsStillInGame()[Utils.getRandomInt(0, this.intOfTeamsInvolved)];
    }

get intOfTeamsInvolved():int {
        return this.getTeamsStillInGame().length;
    }

get intOfPlayersPerTeam():Array<int> {
        var count = Array<int>();
        for (var player of this.fighters) {
    if (count[player.assignedTeam] == null)
    {
        count[player.assignedTeam] = 1;
    }
    else
    {
        count[player.assignedTeam] = count[player.assignedTeam] + 1;
    }
}
        return count;
}

public int maxPlayersPerTeam { get { //returns 0 if there aren't any teams
        var maxCount = 0;
        foreach (var nb in this.intOfPlayersPerTeam) {
            if (nb > maxCount)
            {
                maxCount = nb;
            }
        }
        return maxCount;
    } }

public bool isEveryoneReady() {
        var isEveryoneReady = true;
        foreach (var fighter in this.fighters) {
    if (!fighter.isReady)
    {
        isEveryoneReady = false;
    }
}
        return isEveryoneReady;
}

public Team getAvailableTeam() {
        Team teamToUse = Team.Blue;
var arrPlayersCount = new Dictionary<Team, int>();
var usedTeams = this.getAllUsedTeams();
        foreach (var teamId in usedTeams) {
            arrPlayersCount.add(teamId as Team, this.getintOfPlayersInTeam(Team[Team[teamId]]));
}

var mostPlayersInTeam = Math.max(...arrPlayersCount.values());
var leastPlayersInTeam = Math.min(...arrPlayersCount.values());
var indexOfFirstEmptiestTeam = arrPlayersCount.values().IndexOf(leastPlayersInTeam);

        if (mostPlayersInTeam == leastPlayersInTeam || mostPlayersInTeam == -Infinity || leastPlayersInTeam == Infinity) {
            teamToUse = Team.Blue;
        }
        else {
            teamToUse = Team[Team[indexOfFirstEmptiestTeam]];
        }

        return teamToUse;
    }

    public FighterState getRandomFighter() {
        return this.getAlivePlayers()[Utils.getRandomInt(0, this.getAlivePlayers().length)];
    }

public FighterState getRandomFighterNotInTeam(Team Teams) {
        var tries = 0;
    FighterState fighter;
        while (tries< 99 && (fighter == null || fighter.assignedTeam == null || fighter.assignedTeam == Teams)) {
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
        return this.fighters.length;
    }
}

public int aliveFighterCount
{
    get
    {
        return this.getAlivePlayers().length;
    }
}

public abstract void punishPlayerOnForfeit(FighterState fighter);

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