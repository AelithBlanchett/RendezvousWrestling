using RendezvousWrestling.Common.DataContext;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RendezvousWrestling.Common.Features;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Utils;
using RendezvousWrestling.Common.Achievements;
using RendezvousWrestling.Common.Actions;
using RendezvousWrestling.Common.Configuration;
using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.Common.Fight
{
    public abstract class BaseFighterStats<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser> : BaseEntity
            where TAchievement : BaseAchievement<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TAchievementManager : AchievementManager<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TActionFactory : BaseActionFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TActionType : BaseActionType, new()
            where TActiveAction : BaseActiveAction<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TDataContext : BaseDataContext<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TEntityMapper : BaseEntityMapper<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TFeature : BaseFeature<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TFeatureFactory : BaseFeatureFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TFeatureParameters : BaseFeatureParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TFeatureType : BaseFeatureType, new()
            where TFight : BaseFight<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TFighterState : BaseFighterState<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TFighterStats : BaseFighterStats<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TFightingGame : BaseFightingGame<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>
            where TModifier : BaseModifier<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TModifierFactory : BaseModifierFactory<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TModifierParameters : BaseModifierParameter<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
            where TModifierType : BaseModifierType, new()
            where TUser : BaseUser<TAchievement, TAchievementManager, TActionFactory, TActionType, TActiveAction, TDataContext, TEntityMapper, TFeature, TFeatureFactory, TFeatureParameters, TFeatureType, TFight, TFighterState, TFighterStats, TFightingGame, TModifier, TModifierFactory, TModifierParameters, TModifierType, TUser>, new()
    {

        [Key]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public TUser User { get; set; }

        public int FightsCount { get; set; }
        public int FightsCountCS { get; set; }
        public int Losses { get; set; }
        public int LossesSeason { get; set; }
        public int Wins { get; set; }
        public int WinsSeason { get; set; }
        public int CurrentlyPlaying { get; set; }
        public int CurrentlyPlayingSeason { get; set; }
        public int FightsPendingReady { get; set; }
        public int FightsPendingReadySeason { get; set; }
        public int FightsPendingStart { get; set; }
        public int FightsPendingStartSeason { get; set; }
        public int FightsPendingDraw { get; set; }
        public int FightsPendingDrawSeason { get; set; }
        public Team FavoriteTeam { get; set; }
        public string FavoriteTagPartner { get; set; }
        public int TimesFoughtWithFavoriteTagPartner { get; set; }
        public string Nemesis { get; set; }
        public int LossesAgainstNemesis { get; set; }
        public int AverageDiceRoll { get; set; }
        public int MissedAttacks { get; set; }
        public int ActionsCount { get; set; }
        public int ActionsDefended { get; set; }
        public int MatchesInLast24Hours { get; set; }
        public int MatchesInLast48Hours { get; set; }
        public int EloRating { get; set; } = GameSettings.StartingElo;
        public int GlobalRank { get; set; }
        public int Forfeits { get; set; }
        public int Quits { get; set; }

        public double Winrate
        {
            get
            {
                var winRate = 0.00;
                if (FightsCount > 0 && Wins > 0)
                {
                    winRate = FightsCount / Wins;
                }
                else if (FightsCount > 0 && Losses > 0)
                {
                    winRate = 1 - FightsCount / Losses;
                }
                return winRate;
            }
        }
    }
}