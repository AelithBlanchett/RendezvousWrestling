using RendezvousWrestling.Common.Configuration;
using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using System;
using System.Linq;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionFinisher : RWActiveAction
    {

        public ActionFinisher() : base(
                RWActionType.Finisher,
                nameof(ActionType.Finisher), //Name
                false, //isHold
            true,  //requiresRoll
            false, //keepActorsTurn
            true,  //singleTarget
            true,  //requiresBeingAlive
            false, //requiresBeingDead
            true,  //requiresBeingInRing
            false, //requiresBeingOffRing
                false,  //requiresTier
                false, //requiresCustomTarget
            true,  //targetMustBeAlive
            false, //targetMustBeDead
            true, //targetMustBeInRing
            false,  //targetMustBeOffRing
            true, //targetMustBeInRange
            false, //targetMustBeOffRange
            false, //requiresBeingInHold,
            false, //requiresNotBeingInHold,
            false, //targetMustBeInHold,
            false, //targetMustNotBeInHold,
            false, //usableOnSelf
            false,  //usableOnAllies
            true, //usableOnEnemies
                TriggerEvent.FinishingMove,
                ActionExplanation.Finisher)
        {

        }

        public override int AddBonusesToRollFromStats()
        {
            return base.AddBonusesToRollFromStats() + (int)Math.Ceiling(this.Attacker.CurrentWillpower / 20m);
        }

        public override int SpecificRequiredDiceScore => base.SpecificRequiredDiceScore + AddRequiredScoreWithExplanation(6, "FIN"); //TODO: Check if we really need to call the base

        public override void CheckRequirements()
        {
            base.CheckRequirements();
            if ((this.Defender.LivesRemaining > 1 && this.Defender.ConsecutiveTurnsWithoutFocus < RWGameSettings.MaxTurnsWithoutFocus - 2))
            {
                throw new Exception($"You can't finish your opponent right now. They must have only one life left, or it must at least be their {RWGameSettings.MaxTurnsWithoutFocus - 2}th turn without focus.");
            }
        }

        public override void OnHit()
        {
            this.Defender.TriggerPermanentOutsideRing();
            this.Fight.Message.addHit(string.Format(BaseMessages.finishMessage, this.Defender.GetStylizedName()));
        }

        public override void OnMiss()
        {
            this.FpDamageToAtk += GetIntValueForEnumByTier(typeof(FocusDamageOnMiss), Tier.Heavy);
            this.Fight.Message.addHit(string.Format(BaseMessages.finishFailMessage, this.Attacker.GetStylizedName()));
            this.ApplyDamage();
        }


    }
}