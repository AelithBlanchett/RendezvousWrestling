using RendezvousWrestling.FightSystem.Features;
using System;
using System.Collections.Generic;
using System.Text;

namespace RendezvousWrestling.FightSystem.Achievements
{
    public class RWAchievement : BaseAchievement<RWAchievement, RWActionFactory, RWActiveAction, RWFeature, RWFeatureFactory, RWFight, RWFighterState, RWModifier, RWUser, RWFeatureParameter>
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
