using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using RendezvousWrestling.Common.DataContext;

namespace RendezvousWrestling.FightSystem.Features
{
    public class RWFeature : BaseFeature<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierParameters, RWModifierType, RWUser>
    {
        public RWFeature() : base()
        {

        }

        public RWFeature(RWUser receiver, int uses) : base(receiver, uses)
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
