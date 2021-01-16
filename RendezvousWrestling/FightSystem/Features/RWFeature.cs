using RendezvousWrestling.FightSystem.Achievements;
using System;
using System.Collections.Generic;
using System.Text;

namespace RendezvousWrestling.FightSystem.Features
{
    public abstract class RWFeature : BaseFeature<RWAchievement, RWActionFactory, RWActiveAction, RWFeature, RWFeatureFactory, RWFight, RWFighterState, RWModifier, RWUser, RWFeatureParameter>
    {
        protected RWFeature(string featureType, RWUser receiver, int uses, string id = null) : base(featureType, receiver, uses, id)
        {

        }
    }
}
