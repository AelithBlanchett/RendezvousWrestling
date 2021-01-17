using RendezvousWrestling.FightSystem.Achievements;
using System;
using System.Collections.Generic;
using System.Text;

namespace RendezvousWrestling.FightSystem.Features
{
    public class RWFeature : BaseFeature<RWAchievement, RWActionFactory, RWActiveAction, RWFeature, RWFeatureFactory, RWFight, RWFighterState, RWModifier, RWUser, RWFeatureParameter>
    {

        public RWFeature() : base()
        {

        }

        public RWFeature(string featureType, RWUser receiver, int uses, string id = null) : base(featureType, receiver, uses, id)
        {

        }

        public override string applyFeature(TriggerMoment moment, Trigger triggeringEvent, RWFeatureParameter parameters)
        {
            throw new NotImplementedException();
        }

        public override int getCost()
        {
            throw new NotImplementedException();
        }
    }
}
