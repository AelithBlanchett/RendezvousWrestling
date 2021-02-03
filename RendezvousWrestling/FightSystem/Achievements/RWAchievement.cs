using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using System;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.FightSystem.Fight;
using RendezvousWrestling.FightSystem.Actions;
using RendezvousWrestling.Common.Achievements;

namespace RendezvousWrestling.FightSystem.Achievements
{
    public class RWAchievement : BaseAchievement<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierFactory, RWModifierParameters, RWModifierType, RWUser>
    {
        public RWAchievement() : base()
        {
        }

        public override string DetailedDescription => throw new NotImplementedException();

        public override string Name => throw new NotImplementedException();

        public override int Reward => throw new NotImplementedException();

        public override string UniqueShortName => throw new NotImplementedException();

        public override bool MeetsRequirements(RWUser user, RWFighterState activeFighter, RWFight fight)
        {
            throw new NotImplementedException();
        }
    }
}
