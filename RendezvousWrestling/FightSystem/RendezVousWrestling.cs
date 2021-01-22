using RendezvousWrestling.Common.Bot;
using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using System.Collections.Generic;

public class RendezVousWrestling : BaseFightingGame<RWAchievement, RWActionFactory, RWActiveAction, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestling, RWModifier, RWModifierParameters, RWModifierType, RWUser>
{
    public RendezVousWrestling() : base()
    {

    }

    public RendezVousWrestling(string channel) : base(channel)
    {
    }

    public RendezVousWrestling(List<string> channels) : base(channels)
    {
    }

    public RendezVousWrestling(bool debug) : base(debug)
    {
    }

    public RendezVousWrestling(string channel, bool debug = false) : base(channel, debug)
    {
    }

    public RendezVousWrestling(IEnumerable<string> channels, bool debug = false) : base(channels, debug)
    {
    }
}