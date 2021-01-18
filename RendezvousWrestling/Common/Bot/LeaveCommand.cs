using FChatSharpLib.Entities.Plugin.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RendezvousWrestling.Common.Bot
{
    public class LeaveCommand<TFightingGame, TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType> : BaseCommand<TFightingGame>
    where TActionFactory : IActionFactory<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TFeature : BaseFeature<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TFeatureFactory : IFeatureFactory<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TUser : BaseUser<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TFight : BaseFight<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TFighterState : BaseFighterState<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TActiveAction : BaseActiveAction<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where OptionalParameterType : BaseFeatureParameter<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TAchievement : BaseAchievement<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TModifier : BaseModifier<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()
    where TFightingGame : BaseFightingGame<TAchievement, TActionFactory, TActiveAction, TFeature, TFeatureFactory, TFight, TFighterState, TModifier, TUser, OptionalParameterType>, new()

    {
        public override void ExecuteCommand(string characterCalling, IEnumerable<string> args, string channel)
        {
            if (this.Plugin.Fight == null || this.Plugin.Fight.hasEnded)
            {
                this.Plugin.FChatClient.SendMessageInChannel("[color=red]There is no fight in progress. You must either do !forfeit or !draw to leave the fight.[/color]", channel);
                return;
            }
            if (this.Plugin.Fight.hasStarted)
            {
                this.Plugin.FChatClient.SendMessageInChannel("[color=red]There is already a fight in progress. You must either do !forfeit or !draw to leave the fight.[/color]", channel);
                return;
            }

            TUser fighter = new TUser(); // await(await this.database()).findOne(this.User, characterCalling); // TODO DATABASE

            if (fighter != null)
            {
                if (this.Plugin.Fight.leave(characterCalling))
                { //else, the match starts!
                    this.Plugin.FChatClient.SendMessageInChannel("[color=green]You are now out of the fight.[/color]", channel);
                }
                else
                {
                    this.Plugin.FChatClient.SendMessageInChannel("[color=red]You have already left the fight.[/color]", channel);
                }
            }
            else
            {
                this.Plugin.FChatClient.SendMessageInChannel(Messages.errorNotRegistered, channel);
            }
        }
    }
}
