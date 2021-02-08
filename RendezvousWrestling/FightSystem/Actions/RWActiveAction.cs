using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.Common.Actions;
using RendezvousWrestling.FightSystem.Fight;
using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.FightSystem.Constants;
using RendezvousWrestling.Configuration;

namespace RendezvousWrestling.FightSystem.Actions
{
    public class RWActiveAction : BaseActiveAction<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierFactory, RWModifierParameters, RWModifierType, RWUser>
    {

        public List<int> HpDamageToDefs { get; set; } = new List<int>();
        public List<int> LpDamageToDefs { get; set; } = new List<int>();
        public List<int> FpDamageToDefs { get; set; } = new List<int>();
        public int HpDamageToAtk { get; set; } = 0;
        public int LpDamageToAtk { get; set; } = 0;
        public int FpDamageToAtk { get; set; } = 0;
        public List<int> HpHealToDefs { get; set; } = new List<int>();
        public List<int> LpHealToDefs { get; set; } = new List<int>();
        public List<int> FpHealToDefs { get; set; } = new List<int>();
        public int HpHealToAtk { get; set; } = 0;
        public int LpHealToAtk { get; set; } = 0;
        public int FpHealToAtk { get; set; } = 0;

        public RWActiveAction() : base()
        {

        }

        public RWActiveAction(RWActionType actionType,
                    string name,
                    bool isHold,
                    bool requiresRoll,
                    bool keepActorsTurn,
                    bool singleTarget,
                    bool requiresBeingAlive,
                    bool requiresBeingDead,
                    bool requiresBeingInRing,
                    bool requiresBeingOffRing,
                    bool requiresTier,
                    bool requiresCustomTarget,
                    bool targetMustBeAlive,
                    bool targetMustBeDead,
                    bool targetMustBeInRing,
                    bool targetMustBeOffRing,
                    bool targetMustBeInRange,
                    bool targetMustBeOffRange,
                    bool requiresBeingInHold,
                    bool requiresNotBeingInHold,
                    bool targetMustBeInHold,
                    bool targetMustNotBeInHold,
                    bool usableOnSelf,
                    bool usableOnAllies,
                    bool usableOnEnemies,
                    TriggerEvent trigger,
                    string explanation = null,
                    int? maxTargets = null)
            : base(actionType,
                    name,
                    isHold,
                    requiresRoll,
                    keepActorsTurn,
                    singleTarget,
                    requiresBeingAlive,
                    requiresBeingDead,
                    requiresBeingInRing,
                    requiresBeingOffRing,
                    requiresTier,
                    requiresCustomTarget,
                    targetMustBeAlive,
                    targetMustBeDead,
                    targetMustBeInRing,
                    targetMustBeOffRing,
                    targetMustBeInRange,
                    targetMustBeOffRange,
                    requiresBeingInHold,
                    requiresNotBeingInHold,
                    targetMustBeInHold,
                    targetMustNotBeInHold,
                    usableOnSelf,
                    usableOnAllies,
                    usableOnEnemies,
                    trigger,
                    explanation,
                    maxTargets)
        {

        }



        public int AvgHpDamageToDefs
        {
            get
            {
                if (HpDamageToDefs != null && HpDamageToDefs.Count == 1)
                {
                    return HpDamageToDefs[0];
                }
                else if (HpDamageToDefs != null && HpDamageToDefs.Count > 1)
                {
                    return HpDamageToDefs.Aggregate((a, b) => a + b);
                }
                else
                {
                    return 0;
                }
            }
        }

        public int AvgLpDamageToDefs
        {
            get
            {
                if (LpDamageToDefs != null && LpDamageToDefs.Count == 1)
                {
                    return LpDamageToDefs[0];
                }
                else if (LpDamageToDefs != null && LpDamageToDefs.Count > 1)
                {
                    return LpDamageToDefs.Aggregate((a, b) => a + b);
                }
                else
                {
                    return 0;
                }
            }
        }

        public int AvgFpDamageToDefs
        {
            get
            {
                if (FpDamageToDefs != null && FpDamageToDefs.Count == 1)
                {
                    return FpDamageToDefs[0];
                }
                else if (FpDamageToDefs != null && FpDamageToDefs.Count > 1)
                {
                    return FpDamageToDefs.Aggregate((a, b) => a + b);
                }
                else
                {
                    return 0;
                }
            }
        }

        public int HpDamageToDef
        {
            get
            {
                if (HpDamageToDefs != null && HpDamageToDefs.Count == 1)
                {
                    return HpDamageToDefs[0];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HpDamageToDefs = new List<int>() { value };
            }
        }



        public int LpDamageToDef
        {
            get
            {
                if (LpDamageToDefs != null && LpDamageToDefs.Count == 1)
                {
                    return LpDamageToDefs[0];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                LpDamageToDefs = new List<int>() { value };
            }
        }



        public int FpDamageToDef
        {
            get
            {
                if (FpDamageToDefs != null && FpDamageToDefs.Count == 1)
                {
                    return FpDamageToDefs[0];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                FpDamageToDefs = new List<int>() { value };
            }
        }



        public int HpHealToDef
        {
            get
            {
                if (HpHealToDefs != null && HpHealToDefs.Count == 1)
                {
                    return HpHealToDefs[0];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HpHealToDefs = new List<int>() { value
};
            }
        }



        public int LpHealToDef
        {
            get
            {
                {
                    if (LpHealToDefs != null && LpHealToDefs.Count == 1)
                    {
                        return LpHealToDefs[0];
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            set
            {
                LpHealToDefs = new List<int>() { value };
            }
        }



        public int FpHealToDef
        {
            get
            {
                if (FpHealToDefs != null && FpHealToDefs.Count == 1)
                {
                    return FpHealToDefs[0];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                FpHealToDefs = new List<int>() { value };
            }
        }

        public int AttackFormula(FightTier tier, int targetDef, int roll, int actorAtk)
        {
            int statDiff = 0;
            if (actorAtk - targetDef > 0)
            {
                statDiff = (int)Math.Ceiling((actorAtk - targetDef) / 10m);
            }

            int diceBonus = 0; 
            //TODO FIX BELOW
            //var calculatedBonus = Math.Floor((roll - TierDifficulty[Tiers[tier]]) / 2);
            //if (calculatedBonus > 0)
            //{
            //    diceBonus = calculatedBonus;
            //}

            // this.diceScoreBaseDamage = parseInt(BaseDamage[Tiers[tier]]);
            DiceScoreStatDifference = statDiff;
            DiceScoreBonusPoints = diceBonus;

            return DiceScoreBaseDamage + DiceScoreStatDifference + DiceScoreBonusPoints;
        }

        public override int SpecificRequiredDiceScore
        {
            get
            {
                var scoreRequired = 0;

                if (ActionTier != Tier.None)
                {
                    var name = Enum.GetName(typeof(Tier), ActionTier);
                    var score = (int)Enum.Parse(typeof(TierDifficulty), name);
                    scoreRequired += AddRequiredScoreWithExplanation(score, "TIER");
                }

                scoreRequired += AddRequiredScoreWithExplanation((int)(Action.Globals.difficultyIncreasePerBondageItem * Attacker.NumBondageItemsOnSelf), "BDG");

                //No effects apply if it's a multi-target action. Should we have any?
                if (SingleTarget && Defender != null)
                {
                    scoreRequired += AddRequiredScoreWithExplanation(-(int)(Action.Globals.difficultyIncreasePerBondageItem * Defender.NumBondageItemsOnSelf), "BDG");
                    scoreRequired += AddRequiredScoreWithExplanation((int)Math.Floor((Defender.CurrentDexterity - Attacker.CurrentDexterity) / 15f), "DEXDIFF");

                    if (Defender.Focus >= 0)
                    {
                        scoreRequired += AddRequiredScoreWithExplanation((int)Math.Floor((Defender.Focus - Attacker.Focus) / 15f), "FPDIFF");
                    }
                    if (Defender.Focus < 0)
                    {
                        scoreRequired += AddRequiredScoreWithExplanation((int)Math.Floor(Defender.Focus / 10f) - 1, "FPZERO");
                    }

                    if (Defender.StunnedTier >= (int)RendezvousWrestling.Configuration.Tier.Light)
                    {
                        switch (Defender.StunnedTier)
                        {
                            case (int)RendezvousWrestling.Configuration.Tier.Light:
                                scoreRequired += AddRequiredScoreWithExplanation(-2, "L-STUN");
                                break;
                            case (int)RendezvousWrestling.Configuration.Tier.Medium:
                                scoreRequired += AddRequiredScoreWithExplanation(-4, "M-STUN");
                                break;
                            case (int)RendezvousWrestling.Configuration.Tier.Heavy:
                                scoreRequired += AddRequiredScoreWithExplanation(-6, "H-STUN");
                                break;
                        }
                    }
                }

                return scoreRequired;
            }
        }

        public override void OnMiss()
        {
            var name = Enum.GetName(typeof(Tier), (Tier)ActionTier);
            Attacker.HitFP((int)Enum.Parse(typeof(FocusDamageOnMiss), name));
        }

        public override void ApplyDamage()
        {
            if (HpDamageToDefs.Count > 0)
            {
                for (var i = 0; i < HpDamageToDefs.Count; i++)
                {
                    if (HpDamageToDefs[i] > 0)
                    {
                        Defenders[i].HitHP(HpDamageToDefs[i]);
                    }
                }
            }
            if (LpDamageToDefs.Count > 0)
            {
                for (var i = 0; i < LpDamageToDefs.Count; i++)
                {
                    if (LpDamageToDefs[i] > 0)
                    {
                        Defenders[i].HitLP(LpDamageToDefs[i]);
                    }
                }
            }
            if (FpDamageToDefs.Count > 0)
            {
                for (var i = 0; i < FpDamageToDefs.Count; i++)
                {
                    if (FpDamageToDefs[i] > 0)
                    {
                        Defenders[i].HitFP(FpDamageToDefs[i]);
                    }
                }
            }
            if (HpHealToDefs.Count > 0)
            {
                for (var i = 0; i < HpHealToDefs.Count; i++)
                {
                    if (HpHealToDefs[i] > 0)
                    {
                        Defenders[i].HealHP(HpHealToDefs[i]);
                    }
                }
            }
            if (LpHealToDefs.Count > 0)
            {
                for (var i = 0; i < LpHealToDefs.Count; i++)
                {
                    if (LpHealToDefs[i] > 0)
                    {
                        Defenders[i].HealLP(LpHealToDefs[i]);
                    }
                }
            }
            if (FpHealToDefs.Count > 0)
            {
                for (var i = 0; i < FpHealToDefs.Count; i++)
                {
                    if (FpHealToDefs[i] > 0)
                    {
                        Defenders[i].HealFP(FpHealToDefs[i]);
                    }
                }
            }

            if (HpDamageToAtk > 0)
            {
                Attacker.HitHP(HpDamageToAtk);
            }
            if (LpDamageToAtk > 0)
            {
                Attacker.HitLP(LpDamageToAtk);
            }
            if (FpDamageToAtk > 0)
            {
                Attacker.HitFP(FpDamageToAtk);
            }
            if (HpHealToAtk > 0)
            {
                Attacker.HealHP(HpHealToAtk);
            }
            if (LpHealToAtk > 0)
            {
                Attacker.HealLP(LpHealToAtk);
            }
            if (FpHealToAtk > 0)
            {
                Attacker.HealFP(FpHealToAtk);
            }


            if (AppliedModifiers.Count > 0)
            {
                if (IsHold)
                { //for any holds, do the stacking here
                    var indexOfNewHold = AppliedModifiers.FindIndex(x => x.IsHold);

                    foreach (var defender in Defenders)
                    {
                        //START
                        var existantHoldForDefender = Defender.Modifiers.First(x => x.IsHold);
                        if (existantHoldForDefender != null)
                        {
                            var idOfFormerHold = existantHoldForDefender.Id;
                            foreach (var mod in Defender.Modifiers)
                            {
                                //we updated the children and parent's damage and turns
                                if (mod.Id == idOfFormerHold)
                                {
                                    mod.Name = AppliedModifiers[indexOfNewHold].Name;
                                    mod.TriggeringEvent = AppliedModifiers[indexOfNewHold].TriggeringEvent;
                                    mod.Uses += AppliedModifiers[indexOfNewHold].Uses;
                                    mod.HpDamage += AppliedModifiers[indexOfNewHold].HpDamage;
                                    mod.LustDamage += AppliedModifiers[indexOfNewHold].LustDamage;
                                    mod.FocusDamage += AppliedModifiers[indexOfNewHold].FocusDamage;
                                    //Did not add the dice/escape score modifications, if needed, implement here
                                }
                                else if (mod.IdParentActions != null && mod.IdParentActions.IndexOf(idOfFormerHold) != -1)
                                {
                                    mod.Uses += AppliedModifiers[indexOfNewHold].Uses;
                                }
                            }
                            foreach (var mod in Attacker.Modifiers)
                            {
                                //upDateTime the bonus appliedModifiers length
                                if (mod.IdParentActions != null && mod.IdParentActions.IndexOf(idOfFormerHold) != -1)
                                {
                                    mod.Uses += AppliedModifiers[indexOfNewHold].Uses;
                                }
                            }

                            Fight.Message.addSpecial($"[b][color=red]Hold Stacking![/color][/b] {Defender.GetStylizedName()} will have to suffer this hold for {AppliedModifiers[indexOfNewHold].Uses} more turns, and will also suffer a bit more, as it has added" +
                                             $"{ (AppliedModifiers[indexOfNewHold].HpDamage > 0 ? " -" + AppliedModifiers[indexOfNewHold].HpDamage + " HP per turn " : "")}" +
                                             $"{ (AppliedModifiers[indexOfNewHold].LustDamage > 0 ? " +" + AppliedModifiers[indexOfNewHold].LustDamage + " Lust per turn " : "")}" +
                                             $"{ (AppliedModifiers[indexOfNewHold].FocusDamage > 0 ? " -" + AppliedModifiers[indexOfNewHold].FocusDamage + " Focus per turn" : "")}");
                        }
                        else
                        {
                            foreach (var mod in AppliedModifiers)
                            {
                                if (mod.Receiver.Name == Defender.Name)
                                {
                                    Defender.Modifiers.Add(mod);
                                }
                                else if (mod.Receiver.Name == Attacker.Name)
                                {
                                    Attacker.Modifiers.Add(mod);
                                }
                            }
                        }


                    }
                }
                else
                {
                    foreach (var mod in AppliedModifiers)
                    {
                        if (mod.Receiver == Attacker)
                        {
                            Attacker.Modifiers.Add(mod);
                        }
                        else if (Defenders.FindIndex(x => x.Name == mod.Receiver.Name) != -1)
                        {
                            Defenders.First(x => x.Name == mod.Receiver.Name).Modifiers.Add(mod);
                        }
                    }
                }
            }
        }

        public override void OnHit()
        {
            throw new NotImplementedException();
        }
    }
}