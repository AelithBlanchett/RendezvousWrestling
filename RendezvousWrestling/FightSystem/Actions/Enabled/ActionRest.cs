using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.FightSystem.Configuration;
using RendezvousWrestling.FightSystem.Features;
using System;

namespace RendezvousWrestling.FightSystem.Actions.Enabled
{
    public class ActionRest : RWActiveAction
    {

        public ActionRest() : base(
                RWActionType.Rest,
                nameof(ActionType.Rest), //Name
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
            true, //usableOnSelf
            false,  //usableOnAllies
            false, //usableOnEnemies
                TriggerEvent.Rest,
                ActionExplanation.Rest)
        {

        }

        public override void OnHit()
        {
            this.HpHealToAtk += (int)(this.Attacker.HpPerHeart * RWGameSettings.HpPercentageToHealOnRest);
            this.LpHealToAtk += (int)(this.Attacker.LustPerOrgasm * RWGameSettings.LpPercentageToHealOnRest);
            this.FpHealToAtk += (int)(this.Attacker.MaxFocus * RWGameSettings.FpPercentageToHealOnRest);
        }

        public override int AddBonusesToRollFromStats()
        {
            return base.AddBonusesToRollFromStats() + (int)Math.Ceiling(this.Attacker.CurrentDexterity / 10m);
        }

        public override int RequiredDiceScore => RWGameSettings.RequiredScoreRest;
    }
}