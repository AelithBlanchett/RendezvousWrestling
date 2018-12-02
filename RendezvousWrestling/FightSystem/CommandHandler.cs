//public class CommandHandler extends BaseCommandHandler<RWFight, RWUser, RWFighterState> {

//    private wait(ms)
//{
//    return new Promise(resolve => setTimeout(resolve, ms));
//}

//public async void autoplay(string args, IMsgEvent data)
//{
//    if (this.fChatLibInstance.isUserMaster(data.character))
//    {
//        this.blnAutofight = !this.blnAutofight;
//        if (this.blnAutofight == false)
//        {
//            return;
//        }

//        var availableCommands = Utils.getEnumList(ActionType);
//        var availableTiers = Utils.getEnumList(Tiers);
//        availableTiers.shift();

public  "MyFirstFighterThatDoesntExist", channel: data.channel, message: "!ready"}//        IMsgEvent firstCharData = { character {get; set;}
public  "MySecondFighterThatDoesntExist", channel: data.channel, message: "!ready"}//        IMsgEvent secondCharData = { character {get; set;}



//        while (this.blnAutofight == true)
//        {
//            if (this.fight == undefined || this.fight.hasEnded)
//            {
//                this.fight = new RWFight();
//                this.fight.build(this.fChatLibInstance, this.channel);
//            }
//            if (!this.fight.hasStarted)
//            {
//                await this.ready("", firstCharData);
//                await this.wait(1000);
//                await this.ready("", secondCharData);
//                await this.wait(1000);
//            }

//            await this.wait(1000);

//            if (this.fight.currentPlayer.name == firstCharData.character)
//            {
//                var randomCommand = availableCommands[Utils.getRandomInt(0, availableCommands.length)].toLowerCase();
//                var randomTier = availableTiers[Utils.getRandomInt(0, availableTiers.length)].toLowerCase();
//                await this[randomCommand].apply(this, [randomTier, firstCharData]);
//            }
//            else if (this.fight.currentPlayer.name == secondCharData.character)
//            {
//                var randomCommandTina = availableCommands[Utils.getRandomInt(0, availableCommands.length)].toLowerCase();
//                var randomTierTina = availableTiers[Utils.getRandomInt(0, availableTiers.length)].toLowerCase();
//                await this[randomCommandTina].apply(this, [randomTierTina, secondCharData]);
//            }

//            if (!this.blnAutofight)
//            {
//                break;
//            }
//        }
//    }
//}

//public async void bondage(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.Bondage, false, false, args);
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void brawl(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.Brawl, true, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void degradation(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.Degradation, true, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void escape(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.Escape, false, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void releasehold(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.ReleaseHold, false, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void forcedworship(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.ForcedWorship, true, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void highrisk(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.HighRisk, true, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void riskylewd(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.RiskyLewd, true, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void humhold(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.HumHold, true, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void itempickup(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.ItemPickup, false, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void rest(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.Rest, false, false, args);
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void tease(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.Tease, true, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void sexhold(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.SexHold, true, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void subhold(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.SubHold, true, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void straptoy(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.StrapToy, true, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void sextoypickup(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.SextoyPickup, false, false, args);
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void stun(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.Stun, true, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void tag(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.Tag, false, true, args);
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void submit(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.Submit, false, false, args);
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void finisher(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.Finisher, false, false, args);
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void masturbate(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.Masturbate, true, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void selfdebase(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.SelfDebase, true, false, Utils.stringToEnum(Tiers, args));
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//public async void pass(string args, IMsgEvent data)
//{
//    try
//    {
//        await this.fight.prepareAction(data.character, ActionType.Pass, false, false, args);
//    }
//    catch (ex)
//    {
//        this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandErrorWithStack, [ex.message, ex.stack]), data.character);
//    }
//};

//resetdmg(string args, IMsgEvent data)
//{
//    if (this.fChatLibInstance.isUserMaster(data.character) && this.fight.hasStarted && this.fight.debug)
//    {
//        for (var fighter of this.fight.fighters)
//        {
//            fighter.livesRemaining = fighter.maxLives(); //to prevent ending the fight this way
//            fighter.consecutiveTurnsWithoutFocus = 0; //to prevent ending the fight this way
//            fighter.focus = fighter.initialFocus();
//        }

//        this.fChatLibInstance.sendPrivMessage(`Successfully resplenished ${ args}
//        's HP, LP and FP.`, data.character);
//        }
//}

//sethp(string args, IMsgEvent data)
//{
//    if (this.fChatLibInstance.isUserMaster(data.character) && this.fight.hasStarted && this.fight.debug)
//    {
//        var splitted = args.split(",");
//        try
//        {
//            this.fight.getFighterByName(splitted[0]).hp = parseInt(splitted[1]);
//            this.fChatLibInstance.sendPrivMessage(`Successfully set ${ splitted[0]}
//            's hp to ${splitted[1]}`, data.character);
//            }
//        catch (ex)
//        {
//            this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
//        }
//    }
//}

//setlp(string args, IMsgEvent data)
//{
//    if (this.fChatLibInstance.isUserMaster(data.character) && this.fight.hasStarted && this.fight.debug)
//    {
//        var splitted = args.split(",");
//        try
//        {
//            this.fight.getFighterByName(splitted[0]).lust = parseInt(splitted[1]);
//            this.fChatLibInstance.sendPrivMessage(`Successfully set ${ splitted[0]}
//            's lp to ${splitted[1]}`, data.character);
//            }
//        catch (ex)
//        {
//            this.fChatLibInstance.sendPrivMessage(string.Format(Messages.commandError, ex.message), data.character);
//        }
//    }
//}
//}