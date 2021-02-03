using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using System;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.FightSystem.Fight;
using RendezvousWrestling.FightSystem.Actions;
using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Features
{
    public class RWFeature : BaseFeature<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierFactory, RWModifierParameters, RWModifierType, RWUser>
    {
        public RWFeature() : base()
        {

        }

        public RWFeature(RWFeatureType featureType, int uses) : base(featureType, uses)
        {

        }

        public override string ApplyFeature(TriggerMoment moment, TriggerEvent triggeringEvent, RWFeatureParameter parameters)
        {
            throw new NotImplementedException();
        }

        public override int Cost => throw new NotImplementedException();
    }
}
