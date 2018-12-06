import "reflect-metadata";
import {Utils} from "./Utils/Utils";
import {BaseFighterState} from "./Fight/BaseFighterState";
import {IFChatLib} from "fchatlib/dist/src/Interfaces/IFChatLib";
import {IMsgEvent} from "fchatlib/dist/src/Interfaces/IMsgEvent";
import {Messages} from "./Constants/Messages";
import {Team} from "./Constants/Team";
import {GameSettings} from "./Configuration/GameSettings";
import {Parser} from "./Utils/Parser";
import {BaseFight} from "./Fight/BaseFight";
import {FightLength} from "./Constants/FightLength";
import {FightType} from "./Constants/FightType";
import {TransactionType} from "./Constants/TransactionType";
import {BaseUser} from "./Fight/BaseUser";
import {Connection, createConnection, EntityManager} from "typeorm";

public class BaseCommandHandler<TFight extends BaseFight, TUser extends BaseUser, TFighterState extends BaseFighterState> {
public new () => TFight    Fight {get; set;}
public new () => TUser    User {get; set;}
public new () => TFighterState    FighterState {get; set;}

public IFChatLib    fChatLibInstance {get; set;}
public string    channel {get; set;}
public TFight    fight {get; set;}


public bool = false    blnAutofight {get; set;}
public string = "Tina Armstrong"    debugImpersonatedCharacter {get; set;}

    constructor( { new (...args: any[]): TFight } fight, { new ( any[]): TUser } ...args, fighterState: { new ( any[]): TFighterState } ...args, fChatLib:IFChatLib, chan:string  user) {
        this.Fight = fight;
        this.User = user;
        this.FighterState = fighterState;
        this.fChatLibInstance = fChatLib;
        this.channel = chan;
        this.fight = new this.Fight();
        this.fight.build(fChatLib, chan);
        //this.fChatLibInstance.addPrivateMessageListener(privMsgEventHandler);
    }

    public async void database():Promise<EntityManager>{
        var connection = await createConnection();
        return connection.manager;
    }

    public async void impersonate(string args,IMsgEvent  data) {
        if (this.fChatLibInstance.isUserMaster(data.character)) {
            this.debugImpersonatedCharacter = args;
        }
    }

    public async void runas(string args,IMsgEvent  data) {
        if (this.fChatLibInstance.isUserMaster(data.character)) {
            var splits = args.split(" ");
            var command = splits[0];
            splits.shift();
            var commandArgs = splits.join(" ");
            var impersonatedData = data;
            impersonatedData.character = this.debugImpersonatedCharacter;
            this[command].apply(this, [commandArgs, impersonatedData]);
        }
    }

    public async void addfeature(string args,IMsgEvent  data) {
        var parsedFeatureArgs = Parser.parseArgs(2, [typeof("").toString(), typeof(1).toString()], args);
        TUser fighter = await (await this.database()).findOne(this.User, data.character);
        if (fighter != undefined) {
            try {
                var cost = fighter.addFeature(parsedFeatureArgs[0], parsedFeatureArgs[1]);
                await fighter.removeTokens(cost, TransactionType.Feature);
                await fighter.save();
                this.fChatLibInstance.sendPrivMessage($"[color=green]Success! Feature added.[/color]", fighter.name);
            }
            catch (ex) {
                this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), fighter.name);
            }
        }
        else {
            this.fChatLibInstance.sendPrivMessage(Messages.errorNotRegistered, data.character);
        }
    };

    public async void getfeatureslist(string args,IMsgEvent  data) {
        TUser fighter = await (await this.database()).findOne(this.User, data.character);
        if (fighter != undefined) {
            try {
                this.fChatLibInstance.sendPrivMessage("Usage: !addFeature myFeature OR !addFeature myFeature 2 (with 2 being the int of fights you want)." +
public  " + fighter.featureFactory.getExistingFeatures().join(", "), data.character)                    "\n[/color]Available features {get; set;}
            }
            catch (ex) {
                this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), fighter.name);
            }
        }
        else {
            this.fChatLibInstance.sendPrivMessage(Messages.errorNotRegistered, data.character);
        }

    };

    public async void restat(string args,IMsgEvent  data) {
        var parserPassed = Parser.checkIfValidStats(args, GameSettings.intOfRequiredStatPoints, GameSettings.intOfDifferentStats, GameSettings.minStatLimit, GameSettings.maxStatLimit);
        if(parserPassed != ""){
            this.fChatLibInstance.sendPrivMessage($"[color=red]${parserPassed}[/color]", data.character);
            return;
        }

        TUser fighter = await (await this.database()).findOne(this.User, data.character);

        if (fighter != undefined) {
            if(fighter.canPayAmount(GameSettings.restatCostInTokens)) {
                try {
                    Array<int> arrParam = [];

                    for(var nbr of args.split(",")){
                        arrParam.Add(parseInt(nbr));
                    }

                    var cost = GameSettings.restatCostInTokens;
                    await fighter.removeTokens(cost, TransactionType.Restat);
                    fighter.restat(arrParam);
                    await fighter.save();
                    this.fChatLibInstance.sendPrivMessage(Messages.statChangeSuccessful, fighter.name);
                }
                catch (ex) {
                    this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), fighter.name);
                }

            }
            else{
                this.fChatLibInstance.sendPrivMessage(string.Format(Messages.errorNotEnoughMoney, [GameSettings.restatCostInTokens.toString()]), data.character);
            }



        }
        else {
            this.fChatLibInstance.sendPrivMessage(Messages.errorNotRegistered, data.character);
        }
    };

    public async void clearfeatures(string args,IMsgEvent  data) {
        TUser fighter = await (await this.database()).findOne(this.User, data.character);

        if (fighter != undefined) {
            fighter.areStatsPrivate = false;
            try {
                fighter.clearFeatures();
                await fighter.save();
                this.fChatLibInstance.sendPrivMessage($"[color=green]You successfully removed all your features.[/color]", fighter.name);
            }
            catch (ex) {
                this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
            }
        }
        else {
            this.fChatLibInstance.sendPrivMessage(Messages.errorNotRegistered, data.character);
        }
    };

    //admin commands

    debugmode(string args,IMsgEvent  data) {
        if (this.fChatLibInstance.isUserMaster(data.character) && this.fight.hasStarted) {
            this.fight.debug = !this.fight.debug;
            this.fChatLibInstance.sendPrivMessage($"Debug mode is now set to ${this.fight.debug}", data.character);
        }
    }

    setdicescore(string args,IMsgEvent  data) {
        if (this.fChatLibInstance.isUserMaster(data.character) && this.fight.hasStarted) {
            this.fight.forcedDiceRoll = parseInt(args);
            this.fChatLibInstance.sendPrivMessage($"Dice score is now automatically set to ${this.fight.debug}", data.character);
        }
    }

    exec(string args,IMsgEvent  data) {
        if (this.fChatLibInstance.isUserMaster(data.character)) {
            try{
                eval(args);
            }
            catch(ex){
                this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
            }
        }
    }

    pause(string args,IMsgEvent  data) {
        if (this.fChatLibInstance.isUserMaster(data.character) && this.isInFight(data.character, true)) {
            this.fight = new this.Fight();
            this.fight.build(this.fChatLibInstance, this.channel);
            this.fChatLibInstance.sendMessage($"Successfully saved and stored the match for later. The ring is available now!", this.channel);
        }
        else {
            this.fChatLibInstance.sendPrivMessage($"[color=red]You're not ${this.fChatLibInstance.config.master}![/color]", data.character);
        }
    }

    status(string args,IMsgEvent  data) {
        if (this.fight == undefined || this.fight.hasEnded || !this.fight.hasStarted) {
            this.fChatLibInstance.sendPrivMessage("There is no match going on right now.", data.character);
        }
        else {
            this.fight.resendFightMessage();
        }
    };

    public async void getstats(string args,IMsgEvent  data) {
        if (args == "") {
            args = data.character;
        }

        TUser fighter = await (await this.database()).findOne(this.User, data.character);

        if (fighter != undefined && (fighter.name == data.character || (fighter.name == data.character && !fighter.areStatsPrivate) || this.fChatLibInstance.isUserChatOP(data.character, data.channel))) {
            this.fChatLibInstance.sendPrivMessage(fighter.outputStats(), data.character);
        }
        else {
            this.fChatLibInstance.sendPrivMessage(Messages.errorStatsPrivate, data.character);
        }
    };

    public async void hidemystats(string args,IMsgEvent  data) {
        TUser fighter = await (await this.database()).findOne(this.User, data.character);
        if (fighter != undefined) {
            fighter.areStatsPrivate = false;
            try {
                await fighter.save();
                this.fChatLibInstance.sendPrivMessage("[color=green]You stats are now private.[/color]", data.character);
            }
            catch (ex) {
                this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
            }
        }
        else {
            this.fChatLibInstance.sendPrivMessage(Messages.errorNotRegistered, data.character);
        }
    };

    howtostart(string args,IMsgEvent  data) {
        this.fChatLibInstance.sendPrivMessage(Messages.startupGuide, data.character);
    }

    public async void join(string args,IMsgEvent  data) {
        if (this.fight == undefined || this.fight.hasEnded) {
            this.fight = new this.Fight();
            this.fight.build(this.fChatLibInstance, this.channel);
        }
        var chosenTeam = Parser.join(args);
        try {
            int assignedTeam = await this.fight.join(data.character, chosenTeam);
            this.fChatLibInstance.sendMessage($"[color=green]${data.character} stepped into the ring for the [color=${Team[assignedTeam]}]${Team[assignedTeam]}[/color] team! Waiting for everyone to be !ready.[/color]", this.channel);
        }
        catch (err) {
            this.fChatLibInstance.sendMessage("[color=red]" + err.message + "[/color]", this.channel);
        }
    };

    public async void leave(string args,IMsgEvent  data) {
        if (this.fight == undefined || this.fight.hasEnded) {
            this.fChatLibInstance.sendMessage("[color=red]There is no fight in progress. You must either do !forfeit or !draw to leave the fight.[/color]", this.channel);
            return false;
        }
        if (this.fight.hasStarted) {
            this.fChatLibInstance.sendMessage("[color=red]There is already a fight in progress. You must either do !forfeit or !draw to leave the fight.[/color]", this.channel);
            return false;
        }

        TUser fighter = await (await this.database()).findOne(this.User, data.character);

        if (fighter != undefined) {
            if (this.fight.leave(data.character)) { //else, the match starts!
                this.fChatLibInstance.sendMessage("[color=green]You are now out of the fight.[/color]", this.channel);
            }
            else {
                this.fChatLibInstance.sendMessage("[color=red]You have already left the fight.[/color]", this.channel);
            }
        }
        else {
            this.fChatLibInstance.sendMessage(Messages.errorNotRegistered, this.channel);
        }
    };

    //TODO fix this
    // public async void loadmylastfight(string args,IMsgEvent  data) {
    //     if (this.fight == undefined || this.fight.hasEnded || !this.fight.hasStarted) {
    //         try {
    //             if (args) {
    //                 TFight fight = await (await this.database()).find(this.Fight, data.character);
    //                 var theFight = new this.Fight();
    //                 await theFight.load(data.character);
    //                 if(theFight != null){
    //                     this.fight = theFight;
    //                     this.fight.build(this.fChatLibInstance, this.channel);
    //                     this.fight.outputStatus();
    //                 }
    //                 else{
    //                     this.fChatLibInstance.sendMessage("[color=red]Your latest fight doesn't exist or is already finished.[/color]", this.channel);
    //                 }
    //             }
    //             else {
    //                 this.fChatLibInstance.sendMessage("[color=red]Wrong idFight. It must be specified.[/color]", this.channel);
    //             }
    //         }
    //         catch (ex) {
    //             this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.stack), data.character);
    //         }
    //     }
    //     else {
    //         this.fChatLibInstance.sendMessage(Messages.errorFightAlreadyInProgress, this.channel);
    //     }
    // };

    public async void loadfight(string args,IMsgEvent  data) {
        if (this.fight == undefined || this.fight.hasEnded || !this.fight.hasStarted) {
            try {
                if (args) {
                    TFight theFight = await (await this.database()).findOne(this.Fight, args);
                    if(theFight != null && (this.fChatLibInstance.isUserChatOP(data.character, data.channel) || theFight.fighters.FindIndex(x => x.name == data.character) != -1)){
                        this.fight = theFight;
                        this.fight.build(this.fChatLibInstance, this.channel);
                        this.fight.outputStatus();
                    }
                    else{
                        this.fChatLibInstance.sendMessage("[color=red]No fight is associated with this idAction/user, or you don't have the rights to access it.[/color]", this.channel);
                    }
                }
                else {
                    this.fChatLibInstance.sendMessage("[color=red]Wrong idFight. It must be specified.[/color]", this.channel);
                }
            }
            catch (ex) {
                this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.stack), data.character);
            }
        }
        else {
            this.fChatLibInstance.sendMessage(Messages.errorFightAlreadyInProgress, this.channel);
        }
    };

    public async void ready(string args,IMsgEvent  data) {
        if (this.fight.hasStarted) {
            this.fChatLibInstance.sendMessage(Messages.errorFightAlreadyInProgress, this.channel);
            return false;
        }
        if (this.fight == undefined || this.fight.hasEnded) {
            this.fight = new this.Fight();
            this.fight.build(this.fChatLibInstance, this.channel);
        }

        try{
            bool result = await this.fight.setFighterReady(data.character);
            if (!result) { //else, the match starts!
                this.fChatLibInstance.sendMessage(Messages.errorAlreadyReady, this.channel);
            }
        }
        catch (ex) {
            this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
        }
    };

    public async void register(string args,IMsgEvent  data) {
        TUser fighter = await (await this.database()).findOne(this.User, data.character);

        if (fighter == null) {
            var parserPassed = Parser.checkIfValidStats(args, GameSettings.intOfRequiredStatPoints, GameSettings.intOfDifferentStats, GameSettings.minStatLimit, GameSettings.maxStatLimit);
            if(parserPassed != ""){
                this.fChatLibInstance.sendPrivMessage($"[color=red]${parserPassed}[/color]", data.character);
                return;
            }
            Array<int> arrParam = [];

            for(var nbr of args.split(",")){
                arrParam.Add(parseInt(nbr));
            }

            try {
                var newFighter = new this.User();
                newFighter.name = data.character;
                newFighter.restat(arrParam);
                await newFighter.save();
                this.fChatLibInstance.sendPrivMessage(Messages.registerWelcomeMessage, data.character);
            }
            catch (ex) {
                this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
            }
        }
        else {
            this.fChatLibInstance.sendPrivMessage(Messages.errorAlreadyRegistered, data.character);
        }
    };

    public async void givetokens(string args,IMsgEvent  data) {
        if (this.fChatLibInstance.isUserMaster(data.character)) {
            var parsedArgs = Parser.tipPlayer(args);
            if (parsedArgs.message != null) {
                this.fChatLibInstance.sendPrivMessage( !tip character 10[/color]" "[color=red]The parameters for this command are wrong. " + parsedArgs.message + "\nExample, data.character);
                return;
            }

            TUser fighterReceiving = await (await this.database()).findOne(this.User, data.character);

            try {
                if (fighterReceiving != null) {
                    int amount = parsedArgs.amount;
                    await fighterReceiving.giveTokens(amount, TransactionType.DonationFromAdmin, data.character);
                    await fighterReceiving.save();
                    this.fChatLibInstance.sendPrivMessage($"[color=green]You have successfully given ${fighterReceiving.name} ${amount} tokens.[/color]", data.character);
                    this.fChatLibInstance.sendPrivMessage($"[color=green]You've just received ${amount} tokens from ${data.character} ![/color]", fighterReceiving.name);
                }
                else{
                    this.fChatLibInstance.sendPrivMessage(Messages.errorRecipientOrSenderNotFound, data.character);
                }
            }
            catch (ex) {
                this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
            }
        }

    };

    public async void tip(string args,IMsgEvent  data) {
        var parsedArgs = Parser.tipPlayer(args);
        if (parsedArgs.message != null) {
            this.fChatLibInstance.sendPrivMessage( !tip character 10[/color]" "[color=red]The parameters for this command are wrong. " + parsedArgs.message + "\nExample, data.character);
            return;
        }

        TUser fighterGiving = await (await this.database()).findOne(this.User, data.character);
        TUser fighterReceiving = await (await this.database()).findOne(this.User, parsedArgs.player);

        try {
            if (fighterGiving != null && fighterReceiving != null) {
                int amount = parsedArgs.amount;
                if(fighterGiving.canPayAmount(amount)){
                    await fighterGiving.removeTokens(amount, TransactionType.Tip);
                    await fighterReceiving.giveTokens(amount, TransactionType.Tip, fighterGiving.name);
                    await fighterGiving.save();
                    await fighterReceiving.save();
                    this.fChatLibInstance.sendPrivMessage($"[color=green]You have successfully given ${fighterReceiving.name} ${amount} tokens.[/color]", data.character);
                    this.fChatLibInstance.sendPrivMessage($"[color=green]You've just received ${amount} tokens from ${fighterGiving.name} for your... services.[/color]", fighterReceiving.name);
                    if(fighterReceiving.name == "Miss_Spencer"){
                        if(amount <= 5){
                            this.fChatLibInstance.sendPrivMessage(//i.imgur.com/3b7r7qk.jpg]Thanks for the tip♥[/url]" "[url=http, data.character);
                        }
                        else {
                            this.fChatLibInstance.sendPrivMessage(//i.imgur.com/fLpZ1IN.png]All those coins? For me?~[/url]" "[url=http, data.character);
                        }
                    }
                }
                else{
                    this.fChatLibInstance.sendPrivMessage(string.Format(Messages.errorNotEnoughMoney, [amount.toString()]), data.character);
                }
            }
            else{
                this.fChatLibInstance.sendPrivMessage(Messages.errorRecipientOrSenderNotFound, data.character);
            }
        }
        catch (ex) {
            this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
        }
    };

    public async void removefeature(string args,IMsgEvent  data) {
        var parsedFeatureArgs = Parser.parseArgs(1, [typeof("").toString()], args);

        try {
            TUser fighter = await (await this.database()).findOne(this.User, data.character);

            if (fighter != null) {
                fighter.removeFeature(parsedFeatureArgs[0]);
                await fighter.save();
                this.fChatLibInstance.sendPrivMessage($"[color=green]You successfully removed that feature.[/color]", fighter.name);
            }
        }
        catch (ex) {
            this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
        }
    };

    public async void stats(string args,IMsgEvent  data) {
        TUser fighter = await (await this.database()).findOne(this.User, data.character);

        if (fighter != null) {
            this.fChatLibInstance.sendPrivMessage(fighter.outputStats(), fighter.name);
        }
        else {
            this.fChatLibInstance.sendPrivMessage(Messages.errorNotRegistered, data.character);
        }
    };

    public async void statsforprofile(string args,IMsgEvent  data) {
        TUser fighter = await (await this.database()).findOne(this.User, data.character);

        if (fighter != null) {
            this.fChatLibInstance.sendPrivMessage($"[noparse]${fighter.outputStats()}[/noparse]", fighter.name);
        }
        else {
            this.fChatLibInstance.sendPrivMessage(Messages.errorNotRegistered, data.character);
        }
    };

    public async void fighttype(string args,IMsgEvent  data) {
        FightType parsedFT = Parser.setFightType(args);
        if (parsedFT == -1) {
            var fightTypes = Utils.getEnumList(FightType);
            this.fChatLibInstance.sendMessage( ${fightTypes.join(" "[color=red]Fight Type not found. Types, !fighttype classic[/color]", this.channel  ")}. Example);
            return;
        }

        TUser fighter = await (await this.database()).findOne(this.User, data.character);

        if (fighter != null) {
            this.fight.setFightType(args);
        }
        else {
            this.fChatLibInstance.sendPrivMessage(Messages.errorNotRegistered, data.character);
        }
    };

    public async void fightlength(string args,IMsgEvent  data) {
        FightLength parsedFD = Parser.setFightLength(args);
        if (parsedFD == -1) {
            var fightDurations = Utils.getEnumList(FightLength);
            this.fChatLibInstance.sendMessage( ${fightDurations.join(" "[color=red]Fight Length not found. Types, !fightlength Long[/color]", this.channel  ")}. Example);
            return;
        }

        TUser fighter = await (await this.database()).findOne(this.User, data.character);

        if (fighter != null) {
            this.fight.setFightLength(parsedFD);
        }
        else {
            this.fChatLibInstance.sendPrivMessage(Messages.errorNotRegistered, data.character);
        }
    };

    public async void usedice(string args,IMsgEvent  data) {
        if (this.fChatLibInstance.isUserChatOP(data.character, data.channel)) {
            var flag = (args.toLowerCase().IndexOf("no") != -1);
            this.fight.setDiceLess(flag);
            return;
        }

        TUser fighter = await (await this.database()).findOne(this.User, data.character);

        if (fighter != null) {
            var flag = (args.toLowerCase().IndexOf("no") != -1);
            this.fight.setDiceLess(flag);
        }
        else {
            this.fChatLibInstance.sendPrivMessage(Messages.errorNotRegistered, data.character);
        }
    };

    public async void teamscount(string args,IMsgEvent  data) {
        int parsedTeams = Parser.setTeamsCount(args);
        if (parsedTeams <= 1) {
            this.fChatLibInstance.sendMessage("[color=red]The int of teams involved must be a numeral higher than 1 and lower or equal than 10.[/color]", this.channel);
            return;
        }

        TUser fighter = await (await this.database()).findOne(this.User, data.character);

        if (fighter != null) {
            this.fight.setTeamsCount(parsedTeams);
        }
        else {
            this.fChatLibInstance.sendPrivMessage(Messages.errorNotRegistered, data.character);
        }
    };

    public async void unhidemystats(string args,IMsgEvent  data) {
        TUser fighter = await (await this.database()).findOne(this.User, data.character);

        if (fighter != null) {
            fighter.areStatsPrivate = false;
            try {
                await fighter.save();
                this.fChatLibInstance.sendPrivMessage("[color=green]You stats are now public.[/color]", data.character);
            }
            catch (ex) {
                this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
            }
        }
        else {
            this.fChatLibInstance.sendPrivMessage(Messages.errorNotRegistered, data.character);
        }
    };

    //Attacks placed in FightSystem/CommandHandler

    public async void resetfight(string args,IMsgEvent  data) {
        if (this.fChatLibInstance.isUserChatOP(data.character, data.channel)) {
            if(this.fight && this.fight.idFight){
                this.fight.deleted = true;
                await this.fight.save();
            }
            this.fight = new this.Fight();
            this.fight.build(this.fChatLibInstance, this.channel);
            this.fChatLibInstance.sendMessage("The fight has been ended.", data.channel);
        }
        else {
            this.fChatLibInstance.sendPrivMessage("[color=red]You're not an operator for this channel.[/color]", data.character);
        }
    };

    public async void forfeit(string args,IMsgEvent  data) {
        if (!this.isInFight(data.character, true)) {
            return;
        }
        if (args != "" && !this.fChatLibInstance.isUserChatOP(data.character, data.channel)) {
            this.fChatLibInstance.sendPrivMessage("[color=red]You're not an operator for this channel. You can't force someone to forfeit.[/color]", data.character);
            return false;
        }
        if (args == "") {
            args = data.character;
        }

        try {
            await this.fight.forfeit(args);
        }
        catch (ex) {
            this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
        }
    };

    public async void draw(string args,IMsgEvent  data) {
        if (!this.isInFight(data.character, true)) {
            return;
        }
        try {
            this.fight.requestDraw(data.character);
            await this.fight.checkForDraw();
        }
        catch (ex) {
            this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
        }
    };

    public async void undraw(string args,IMsgEvent  data) {
        if (!this.isInFight(data.character, true)) {
            return;
        }
        try {
            this.fight.unrequestDraw(data.character);
        }
        catch (ex) {
            this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
        }
    };

    target(string args,IMsgEvent  data) {
        if (!this.isInFight(data.character, true)) {
            return;
        }
        try {
            if (this.fight.getFighterByName(data.character)) {
                this.fight.assignTarget(data.character, args);
            }
        }
        catch (ex) {
            this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
        }
    };

    private isFightGoingOn(string character,bool = false, displayIfFight:bool = false  displayIfNoFight):bool{
        var result = false;
        if(this.fight == undefined || !this.fight.hasStarted || this.fight.hasEnded){
            if(displayIfNoFight){
                this.fChatLibInstance.sendPrivMessage("[color=red]There isn't any fight going on.[/color]", character);
            }
            result = false;
        }
        else{
            if(displayIfFight){
                this.fChatLibInstance.sendPrivMessage("[color=red]There's already a fight going on.[/color]", character);
            }
            result = true;
        }

        return result;
    }

    private isInFight(string character,bool = false, displayIfInFight:bool = false  displayIfNotInFight):bool{
        if (this.isFightGoingOn(character, false, false) || (this.fight.fighters != null && this.fight.fighters.FindIndex(x => x.name == character) == -1)) {
            if(displayIfNotInFight){
                this.fChatLibInstance.sendPrivMessage("[color=red]There isn't any fight going on, or you're not participating in it.[/color]", character);
            }
            return false;
        }
        else{
            if(displayIfInFight){
                this.fChatLibInstance.sendPrivMessage("[color=red]You're participating in this fight.[/color]", character);
            }
            return true;
        }
    }


}

// class PrivateCommandHandler {
public IFChatLib//     fChatLibInstance {get; set;}
//
//     constructor(fChatLib) {
//         this.fChatLibInstance = fChatLib;
//     }
//
//     clearfeatures = BaseCommandHandler.prototype.clearfeatures;
//     debugmode = BaseCommandHandler.prototype.debugmode;
//     setdicescore = BaseCommandHandler.prototype.setdicescore;
//     resetdmg = BaseCommandHandler.prototype.resetdmg;
//     exec = BaseCommandHandler.prototype.exec;
//     runas = BaseCommandHandler.prototype.runas;
//     getstats = BaseCommandHandler.prototype.getstats;
//     hidemystats = BaseCommandHandler.prototype.hidemystats;
//     howtostart = BaseCommandHandler.prototype.howtostart;
//     stats = BaseCommandHandler.prototype.stats;
//     register = BaseCommandHandler.prototype.register;
//     //removestat = BaseCommandHandler.prototype.removestat;
//     removefeature = BaseCommandHandler.prototype.removefeature;
//     unhidemystats = BaseCommandHandler.prototype.unhidemystats;
//     restat = BaseCommandHandler.prototype.restat;
//     statsforprofile = BaseCommandHandler.prototype.statsforprofile;
// }

// var privMsgEventHandler = function (data) {
//
//     var privHandler = new PrivateCommandHandler(parent);
//
//     var opts = {
//         command: String(data.message.split(' ')[0]).replace('!', '').trim().toLowerCase(),
//         argument: data.message.substring(String(data.message.split(' ')[0]).length).trim()
//     };
//
//     if (typeof privHandler[opts.command] === 'function') {
//         privHandler[opts.command](opts.argument, data);
//     }
// };