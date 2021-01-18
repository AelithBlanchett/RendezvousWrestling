//public bool = false    blnAutofight {get; set;}


//    public async void addfeature(string args,IMsgEvent  data) {
//        var parsedFeatureArgs = Parser.parseArgs(2, [typeof("").ToString(), typeof(1).ToString()], args);
//        TUser fighter = await (await this.database()).findOne(this.User, characterCalling);
//        if (fighter != null) {
//            try {
//                var cost = fighter.addFeature(parsedFeatureArgs[0], parsedFeatureArgs[1]);
//                await fighter.removeTokens(cost, TransactionType.Feature);
//                await fighter.save();
//                this.Plugin.FChatClient.SendPrivateMessage($"[color=green]Success! Feature added.[/color]", fighter.name);
//            }
//            catch (Exception ex) {
//                this.Plugin.FChatClient.SendPrivateMessage(string.Format(Messages.commandError, ex.Message), fighter.name);
//            }
//        }
//        else {
//            this.Plugin.FChatClient.SendPrivateMessage(Messages.errorNotRegistered, characterCalling);
//        }
//    };

//    public async void getfeatureslist(string args,IMsgEvent  data) {
//        TUser fighter = await (await this.database()).findOne(this.User, characterCalling);
//        if (fighter != null) {
//            try {
//                this.Plugin.FChatClient.SendPrivateMessage("Usage: !addFeature myFeature OR !addFeature myFeature 2 (with 2 being the int of fights you want)." +
//public  " + fighter.featureFactory.getExistingFeatures().join(", "), characterCalling)                    "\n[/color]Available features {get; set;}
//            }
//            catch (Exception ex) {
//                this.Plugin.FChatClient.SendPrivateMessage(string.Format(Messages.commandError, ex.Message), fighter.name);
//            }
//        }
//        else {
//            this.Plugin.FChatClient.SendPrivateMessage(Messages.errorNotRegistered, characterCalling);
//        }

//    };

//    public async void clearfeatures(string args,IMsgEvent  data) {
//        TUser fighter = await (await this.database()).findOne(this.User, characterCalling);

//        if (fighter != null) {
//            fighter.areStatsPrivate = false;
//            try {
//                fighter.clearFeatures();
//                await fighter.save();
//                this.Plugin.FChatClient.SendPrivateMessage($"[color=green]You successfully removed all your features.[/color]", fighter.name);
//            }
//            catch (Exception ex) {
//                this.Plugin.FChatClient.SendPrivateMessage(string.Format(Messages.commandError, ex.Message), characterCalling);
//            }
//        }
//        else {
//            this.Plugin.FChatClient.SendPrivateMessage(Messages.errorNotRegistered, characterCalling);
//        }
//    };



//    //TODO fix this
//    // public async void loadmylastfight(string args,IMsgEvent  data) {
//    //     if (this.Plugin.Fight == null || this.Plugin.Fight.hasEnded || !this.Plugin.Fight.hasStarted) {
//    //         try {
//    //             if (args) {
//    //                 TFight fight = await (await this.database()).find(this.Plugin.Fight, characterCalling);
//    //                 var theFight = new TFight();
//    //                 await theFight.load(characterCalling);
//    //                 if(theFight != null){
//    //                     this.Plugin.Fight = theFight;
//    //                     this.Plugin.Fight.build(this.Plugin.FChatClient, channel);
//    //                     this.Plugin.Fight.outputStatus();
//    //                 }
//    //                 else{
//    //                     this.Plugin.FChatClient.SendMessageInChannel("[color=red]Your latest fight doesn't exist or is already finished.[/color]", channel);
//    //                 }
//    //             }
//    //             else {
//    //                 this.Plugin.FChatClient.SendMessageInChannel("[color=red]Wrong idFight. It must be specified.[/color]", channel);
//    //             }
//    //         }
//    //         catch (Exception ex) {
//    //             this.Plugin.FChatClient.SendPrivateMessage(string.Format(Messages.commandError, ex.stack), characterCalling);
//    //         }
//    //     }
//    //     else {
//    //         this.Plugin.FChatClient.SendMessageInChannel(Messages.errorFightAlreadyInProgress, channel);
//    //     }
//    // };

//    public async void givetokens(string args,IMsgEvent  data) {
//        if (this.Plugin.FChatClient.IsUserMaster(characterCalling)) {
//            var parsedArgs = Parser.tipPlayer(args);
//            if (parsedArgs.message != null) {
//                this.Plugin.FChatClient.SendPrivateMessage( !tip character 10[/color]" "[color=red]The parameters for this command are wrong. " + parsedArgs.message + "\nExample, characterCalling);
//                return;
//            }

//            TUser fighterReceiving = await (await this.database()).findOne(this.User, characterCalling);

//            try {
//                if (fighterReceiving != null) {
//                    int amount = parsedArgs.amount;
//                    await fighterReceiving.giveTokens(amount, TransactionType.DonationFromAdmin, characterCalling);
//                    await fighterReceiving.save();
//                    this.Plugin.FChatClient.SendPrivateMessage($"[color=green]You have successfully given ${fighterReceiving.name} ${amount} tokens.[/color]", characterCalling);
//                    this.Plugin.FChatClient.SendPrivateMessage($"[color=green]You've just received ${amount} tokens from ${characterCalling} ![/color]", fighterReceiving.name);
//                }
//                else{
//                    this.Plugin.FChatClient.SendPrivateMessage(Messages.errorRecipientOrSenderNotFound, characterCalling);
//                }
//            }
//            catch (Exception ex) {
//                this.Plugin.FChatClient.SendPrivateMessage(string.Format(Messages.commandError, ex.Message), characterCalling);
//            }
//        }

//    };

//    public async void tip(string args,IMsgEvent  data) {
//        var parsedArgs = Parser.tipPlayer(args);
//        if (parsedArgs.message != null) {
//            this.Plugin.FChatClient.SendPrivateMessage( !tip character 10[/color]" "[color=red]The parameters for this command are wrong. " + parsedArgs.message + "\nExample, characterCalling);
//            return;
//        }

//        TUser fighterGiving = await (await this.database()).findOne(this.User, characterCalling);
//        TUser fighterReceiving = await (await this.database()).findOne(this.User, parsedArgs.player);

//        try {
//            if (fighterGiving != null && fighterReceiving != null) {
//                int amount = parsedArgs.amount;
//                if(fighterGiving.canPayAmount(amount)){
//                    await fighterGiving.removeTokens(amount, TransactionType.Tip);
//                    await fighterReceiving.giveTokens(amount, TransactionType.Tip, fighterGiving.name);
//                    await fighterGiving.save();
//                    await fighterReceiving.save();
//                    this.Plugin.FChatClient.SendPrivateMessage($"[color=green]You have successfully given ${fighterReceiving.name} ${amount} tokens.[/color]", characterCalling);
//                    this.Plugin.FChatClient.SendPrivateMessage($"[color=green]You've just received ${amount} tokens from ${fighterGiving.name} for your... services.[/color]", fighterReceiving.name);
//                    if(fighterReceiving.name == "Miss_Spencer"){
//                        if(amount <= 5){
//                            this.Plugin.FChatClient.SendPrivateMessage(//i.imgur.com/3b7r7qk.jpg]Thanks for the tip♥[/url]" "[url=http, characterCalling);
//                        }
//                        else {
//                            this.Plugin.FChatClient.SendPrivateMessage(//i.imgur.com/fLpZ1IN.png]All those coins? For me?~[/url]" "[url=http, characterCalling);
//                        }
//                    }
//                }
//                else{
//                    this.Plugin.FChatClient.SendPrivateMessage(string.Format(Messages.errorNotEnoughMoney, [amount.ToString()]), characterCalling);
//                }
//            }
//            else{
//                this.Plugin.FChatClient.SendPrivateMessage(Messages.errorRecipientOrSenderNotFound, characterCalling);
//            }
//        }
//        catch (Exception ex) {
//            this.Plugin.FChatClient.SendPrivateMessage(string.Format(Messages.commandError, ex.Message), characterCalling);
//        }
//    };

//    public async void removefeature(string args,IMsgEvent  data) {
//        var parsedFeatureArgs = Parser.parseArgs(1, [typeof("").ToString()], args);

//        try {
//            TUser fighter = await (await this.database()).findOne(this.User, characterCalling);

//            if (fighter != null) {
//                fighter.removeFeature(parsedFeatureArgs[0]);
//                await fighter.save();
//                this.Plugin.FChatClient.SendPrivateMessage($"[color=green]You successfully removed that feature.[/color]", fighter.name);
//            }
//        }
//        catch (Exception ex) {
//            this.Plugin.FChatClient.SendPrivateMessage(string.Format(Messages.commandError, ex.Message), characterCalling);
//        }
//    };


//}

//// class PrivateCommandHandler {
//public IFChatLib//     fChatLibInstance {get; set;}
////
////     constructor(fChatLib) {
////         this.Plugin.FChatClient = fChatLib;
////     }
////
////     clearfeatures = BaseCommandHandler.prototype.clearfeatures;
////     debugmode = BaseCommandHandler.prototype.debugmode;
////     setdicescore = BaseCommandHandler.prototype.setdicescore;
////     resetdmg = BaseCommandHandler.prototype.resetdmg;
////     exec = BaseCommandHandler.prototype.exec;
////     runas = BaseCommandHandler.prototype.runas;
////     getstats = BaseCommandHandler.prototype.getstats;
////     hidemystats = BaseCommandHandler.prototype.hidemystats;
////     howtostart = BaseCommandHandler.prototype.howtostart;
////     stats = BaseCommandHandler.prototype.stats;
////     register = BaseCommandHandler.prototype.register;
////     //removestat = BaseCommandHandler.prototype.removestat;
////     removefeature = BaseCommandHandler.prototype.removefeature;
////     unhidemystats = BaseCommandHandler.prototype.unhidemystats;
////     restat = BaseCommandHandler.prototype.restat;
////     statsforprofile = BaseCommandHandler.prototype.statsforprofile;
//// }

//// var privMsgEventHandler = function (data) {
////
////     var privHandler = new PrivateCommandHandler(parent);
////
////     var opts = {
////         command: String(data.message.split(' ')[0]).replace('!', '').trim().ToLower(),
////         argument: data.message.substring(String(data.message.split(' ')[0]).Count).trim()
////     };
////
////     if (typeof privHandler[opts.command] === 'function') {
////         privHandler[opts.command](opts.argument, data);
////     }
//// };