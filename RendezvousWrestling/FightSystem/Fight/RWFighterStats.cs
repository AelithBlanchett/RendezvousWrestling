
using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.FightSystem.Actions;
using RendezvousWrestling.Common.Fight;

namespace RendezvousWrestling.FightSystem.Fight
{
    public class RWFighterStats : BaseFighterStats<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierFactory, RWModifierParameters, RWModifierType, RWUser>
    {

        public int BrawlAtksCount { get; set; }

        public int SexstrikesCount { get; set; }

        public int TagsCount { get; set; }

        public int RestCount { get; set; }

        public int SubholdCount { get; set; }

        public int SexholdCount { get; set; }

        public int BondageCount { get; set; }

        public int HumholdCount { get; set; }

        public int ItemPickups { get; set; }

        public int SextoyPickups { get; set; }

        public int DegradationCount { get; set; }

        public int ForcedWorshipCount { get; set; }

        public int HighRiskCount { get; set; }

        public int PenetrationCount { get; set; }

        public int StunCount { get; set; }

        public int EscapeCount { get; set; }

        public int SubmitCount { get; set; }

        public int StraptoyCount { get; set; }

        public int FinishCount { get; set; }

        public int MasturbateCount { get; set; }
    }
}