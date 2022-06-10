using FChatSharpLib.Entities.Plugin.Commands;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.Common.DataContext;
using System.Collections.Generic;
using RendezvousWrestling.Common.Achievements;
using RendezvousWrestling.Common.Actions;
using RendezvousWrestling.Common.Fight;
using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Actions;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Utils;
using RendezvousWrestling.FightSystem.Fight;
using RendezvousWrestling.FightSystem;
using RendezvousWrestling.FightSystem.Modifiers;
using System;
using System.Threading.Tasks;

namespace RendezvousWrestling.Common.Bot
{
    public class PassCommand : BaseActionCommand<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierFactory, RWModifierParameters, RWModifierType, RWUser>

    {
        public override async Task ExecuteCommand(string characterCalling, IEnumerable<string> args, string channel)
        {
            try
            {
                this.Plugin.Fight.PrepareAction(characterCalling, RWActionType.Pass, string.Join(" ", args));
            }
            catch (Exception ex)
            {
                this.Plugin.FChatClient.SendPrivateMessage(string.Format(BaseMessages.commandErrorWithStack, ex.Message, ex.StackTrace), characterCalling);
            }
        }
    }
}
