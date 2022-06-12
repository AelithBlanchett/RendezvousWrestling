using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Fight;
using RendezvousWrestling.FightSystem.Actions;
using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Fight
{
    public class RWFight : BaseFight<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierFactory, RWModifierParameters, RWModifierType, RWUser>
    {

        public RWFight() : base()
        {
        }

        public override void NextTurn()
        {
            foreach (var fighter in Fighters)
            {
                fighter.TriggerMods(TriggerMoment.Any, TriggerEvent.TurnChange);
                if (!fighter.IsInHold())
                {
                    fighter.HealFP(1);
                }
                if (fighter.Focus < fighter.MinFocus)
                {
                    fighter.ConsecutiveTurnsWithoutFocus++;
                }
                else
                {
                    fighter.ConsecutiveTurnsWithoutFocus = 0;
                }
            }
            base.NextTurn();
        }

        public override void PunishPlayerOnForfeit(RWFighterState fighter)
        {
            Message.addHit(string.Format(BaseMessages.forfeitItemApply, fighter.GetStylizedName(), fighter.MaxBondageItemsOnSelf.ToString()));
            for (var i = 0; i < fighter.MaxBondageItemsOnSelf; i++)
            {
                fighter.AddModifier(ModifierFactory.Build(RWModifierType.Bondage, this, fighter, null));
            }
            Message.addHit(string.Format(BaseMessages.forfeitTooManyItems, fighter.GetStylizedName()));
            fighter.TriggerPermanentOutsideRing();
        }


    }
}