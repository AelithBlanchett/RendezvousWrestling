using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using System;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.FightSystem.Fight;
using RendezvousWrestling.FightSystem.Actions;

namespace RendezvousWrestling.FightSystem.Achievements
{
    public class RWAchievement : BaseAchievement<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierParameters, RWModifierType, RWUser>
    {
        public RWAchievement() : base()
        {
        }

        public override string getDetailedDescription()
        {
            throw new NotImplementedException();
        }

        public override string getName()
        {
            throw new NotImplementedException();
        }

        public override int getReward()
        {
            throw new NotImplementedException();
        }

        public override string getUniqueShortName()
        {
            throw new NotImplementedException();
        }

        public override bool meetsRequirements(RWUser user, RWFighterState activeFighter, RWFight fight)
        {
            throw new NotImplementedException();
        }
    }
}
