using RendezvousWrestling.Common;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Actions;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Fight;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using System.Collections.Generic;

namespace RendezvousWrestling.FightSystem
{
    public class RendezVousWrestlingGame : BaseFightingGame<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierFactory, RWModifierParameters, RWModifierType, RWUser>
    {
        public RendezVousWrestlingGame() : base()
        {

        }

        public RendezVousWrestlingGame(string channel) : base(channel)
        {
        }

        public RendezVousWrestlingGame(List<string> channels) : base(channels)
        {
        }

        public RendezVousWrestlingGame(bool debug) : base(debug)
        {
        }

        public RendezVousWrestlingGame(string channel, bool debug = false) : base(channel, debug)
        {
        }

        public RendezVousWrestlingGame(IEnumerable<string> channels, bool debug = false) : base(channels, debug)
        {
        }
    }
}