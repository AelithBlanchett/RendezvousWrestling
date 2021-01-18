using FChatSharpLib.Entities.Plugin.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RendezvousWrestling.Common.Bot
{
    public class RestatCommand<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType> : BaseCommand<TFightingGame>
    where TActionFactory : IActionFactory<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFeature : BaseFeature<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFeatureFactory : IFeatureFactory<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TUser : BaseUser<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFight : BaseFight<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFighterState : BaseFighterState<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TActiveAction : BaseActiveAction<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where OptionalParameterType : BaseFeatureParameter<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TAchievement : BaseAchievement<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TModifier : BaseModifier<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFighterStats : BaseFighterStats<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()
    where TFightingGame : BaseFightingGame<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TFighterStats, TModifier, TUser, OptionalParameterType>, new()

    {
        public override void ExecuteCommand(string characterCalling, IEnumerable<string> args, string channel)
        {
            var parserPassed = Parser.checkIfValidStats(args, GameSettings.intOfRequiredStatPoints, GameSettings.intOfDifferentStats, GameSettings.minStatLimit, GameSettings.maxStatLimit);
            if (parserPassed != "")
            {
                this.Plugin.FChatClient.SendPrivateMessage($"[color=red]${parserPassed}[/color]", characterCalling);
                return;
            }

            TUser fighter = new TUser(); // await(await this.database()).findOne(this.User, characterCalling); //TODO DATABASe

            if (fighter != null)
            {
                if (fighter.canPayAmount(GameSettings.restatCostInTokens))
                {
                    try
                    {
                        var arrParam = new List<int>() { };

                        foreach (var nbr in args)
                        {
                            arrParam.Add(int.Parse(nbr));
                        }

                        var cost = GameSettings.restatCostInTokens;
                        fighter.removeTokens(cost, TransactionType.Restat);
                        fighter.restat(arrParam);
                        //await fighter.save(); //TODO DATABASE
                        this.Plugin.FChatClient.SendPrivateMessage(Messages.statChangeSuccessful, fighter.Name);
                    }
                    catch (Exception ex)
                    {
                        this.Plugin.FChatClient.SendPrivateMessage(string.Format(Messages.commandError, ex.Message), fighter.Name);
                    }

                }
                else
                {
                    this.Plugin.FChatClient.SendPrivateMessage(string.Format(Messages.errorNotEnoughMoney, GameSettings.restatCostInTokens.ToString()), characterCalling);
                }



            }
            else
            {
                this.Plugin.FChatClient.SendPrivateMessage(Messages.errorNotRegistered, characterCalling);
            }
        }
    }
}
