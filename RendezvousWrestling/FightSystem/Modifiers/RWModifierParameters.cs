using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Actions;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Fight;
using RendezvousWrestling.FightSystem.Utils;

namespace RendezvousWrestling.FightSystem.Modifiers
{
    public class RWModifierParameters : BaseModifierParameter<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierFactory, RWModifierParameters, RWModifierType, RWUser>
    {
        public int HpDamage { get; set; }
        public int LustDamage { get; set; }
        public int FocusDamage { get; set; }
        public int HpHeal { get; set; }
        public int LustHeal { get; set; }
        public int FocusHeal { get; set; }

        public RWModifierParameters()
        {

        }


    }
}