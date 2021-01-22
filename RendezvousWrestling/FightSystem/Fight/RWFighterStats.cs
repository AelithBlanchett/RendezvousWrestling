
using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using RendezvousWrestling.Common.DataContext;

public class RWFighterStats : BaseFighterStats<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierParameters, RWModifierType, RWUser>
{

    public int brawlAtksCount { get; set; }

    public int sexstrikesCount { get; set; }

    public int tagsCount { get; set; }

    public int restCount { get; set; }

    public int subholdCount { get; set; }

    public int sexholdCount { get; set; }

    public int bondageCount { get; set; }

    public int humholdCount { get; set; }

    public int itemPickups { get; set; }

    public int sextoyPickups { get; set; }

    public int degradationCount { get; set; }

    public int forcedWorshipCount { get; set; }

    public int highRiskCount { get; set; }

    public int penetrationCount { get; set; }

    public int stunCount { get; set; }

    public int escapeCount { get; set; }

    public int submitCount { get; set; }

    public int straptoyCount { get; set; }

    public int finishCount { get; set; }

    public int masturbateCount { get; set; }
}