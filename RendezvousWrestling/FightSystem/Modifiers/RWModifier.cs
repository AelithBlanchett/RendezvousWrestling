using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Utils;
using RendezvousWrestling.Common.DataContext;
using RendezvousWrestling.FightSystem.Fight;
using RendezvousWrestling.FightSystem.Actions;
using RendezvousWrestling.Common.Modifiers;
using RendezvousWrestling.Common.Constants;

namespace RendezvousWrestling.FightSystem.Modifiers
{
    public class RWModifier : BaseModifier<RWAchievement, RWAchievementManager, RWActionFactory, RWActionType, RWActiveAction, RWDataContext, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestlingGame, RWModifier, RWModifierFactory, RWModifierParameters, RWModifierType, RWUser>, IModifierParameters
    {
        public RWModifier() : base()
        {

        }

        public int HpDamage { get; set; }
        public int LustDamage { get; set; }
        public int FocusDamage { get; set; }
        public int HpHeal { get; set; }
        public int LustHeal { get; set; }
        public int FocusHeal { get; set; }

        public override string ApplyModifierOnReceiver(TriggerMoment moment, TriggerEvent triggeringEvent)
        {
            var messageAboutModifier = "";
            if (HpDamage > 0)
            {
                var flagTriggerMods = !Common.Utils.GlobalUtils.WillTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, TriggerEvent.MainBarDamage, triggeringEvent);
                messageAboutModifier += $" losing {HpDamage} HP,";
                Receiver.HitHP(HpDamage, flagTriggerMods);
            }
            if (LustDamage > 0)
            {
                var flagTriggerMods = !Common.Utils.GlobalUtils.WillTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, TriggerEvent.SecondaryBarDamage, triggeringEvent);
                messageAboutModifier += $" losing {LustDamage} LP,";
                Receiver.HitLP(LustDamage, flagTriggerMods);
            }
            if (FocusDamage > 0)
            {
                var flagTriggerMods = !Common.Utils.GlobalUtils.WillTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, TriggerEvent.UtilitaryBarDamage, triggeringEvent);
                messageAboutModifier += $" losing {FocusDamage} FP,";
                Receiver.HitFP(FocusDamage, flagTriggerMods);
            }
            if (HpHeal > 0)
            {
                var flagTriggerMods = !Common.Utils.GlobalUtils.WillTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, TriggerEvent.MainBarHealing, triggeringEvent);
                messageAboutModifier += $" gaining {HpHeal} HP,";
                Receiver.HealHP(HpHeal, flagTriggerMods);
            }
            if (LustHeal > 0)
            {
                var flagTriggerMods = !Common.Utils.GlobalUtils.WillTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, TriggerEvent.SecondaryBarHealing, triggeringEvent);
                messageAboutModifier += $" gaining {LustHeal} LP,";
                Receiver.HealLP(LustHeal, flagTriggerMods);
            }
            if (FocusHeal > 0)
            {
                var flagTriggerMods = !Common.Utils.GlobalUtils.WillTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, TriggerEvent.UtilitaryBarHealing, triggeringEvent);
                messageAboutModifier += $" gaining {FocusHeal} FP,";
                Receiver.HealFP(FocusHeal, flagTriggerMods);
            }
            if (DiceRoll != 0)
            {
                Receiver.Dice.addTmpMod(DiceRoll, 1);
                if (DiceRoll > 0)
                {
                    messageAboutModifier += $" getting a +{DiceRoll} bonus for their dice roll,";
                }
                else
                {
                    messageAboutModifier += $" getting a {DiceRoll} penalty for their dice roll,";
                }
            }

            return messageAboutModifier;
        }

        public override string ApplyModifierOnAction(TriggerMoment moment, TriggerEvent triggeringEvent, dynamic objFightAction)
        {
            var messageAboutModifier = "";
            if (HpDamage > 0)
            {
                if (AreDamageMultipliers)
                {
                    objFightAction.hpDamage *= HpDamage;
                    messageAboutModifier += $" multiplying their attack's HP damage by {HpDamage},";
                }
                else
                {
                    var flagTriggerMods = !Common.Utils.GlobalUtils.WillTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, TriggerEvent.MainBarDamage, triggeringEvent);
                    messageAboutModifier += $" losing {HpDamage} HP,";
                    Receiver.HitHP(HpDamage, flagTriggerMods);
                }
            }
            if (LustDamage > 0)
            {
                if (AreDamageMultipliers)
                {
                    objFightAction.lustDamage *= LustDamage;
                    messageAboutModifier += $" multiplying their attack's LP damage by {LustDamage},";
                }
                else
                {
                    var flagTriggerMods = !Common.Utils.GlobalUtils.WillTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, TriggerEvent.SecondaryBarDamage, triggeringEvent);
                    messageAboutModifier += $" losing {LustDamage} LP,";
                    Receiver.HitLP(LustDamage, flagTriggerMods);
                }
            }
            if (FocusDamage > 0)
            {
                if (AreDamageMultipliers)
                {
                    objFightAction.focusDamage *= FocusDamage;
                    messageAboutModifier += $" multiplying their attack's FP damage by {FocusDamage},";
                }
                else
                {
                    var flagTriggerMods = !Common.Utils.GlobalUtils.WillTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, TriggerEvent.UtilitaryBarDamage, triggeringEvent);
                    messageAboutModifier += $" losing {FocusDamage} LP,";
                    Receiver.HitFP(FocusDamage, flagTriggerMods);
                }
            }
            if (HpHeal > 0)
            {
                if (AreDamageMultipliers)
                {
                    objFightAction.hpHeal *= HpHeal;
                    messageAboutModifier += $" multiplying their action's HP healing by {HpHeal},";
                }
                else
                {
                    var flagTriggerMods = !Common.Utils.GlobalUtils.WillTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, TriggerEvent.MainBarHealing, triggeringEvent);
                    messageAboutModifier += $" gaining {HpHeal} HP,";
                    Receiver.HealHP(HpHeal, flagTriggerMods);
                }
            }
            if (LustHeal > 0)
            {
                if (AreDamageMultipliers)
                {
                    objFightAction.lustHeal *= LustHeal;
                    messageAboutModifier += $" multiplying their action's LP healing by {LustHeal},";
                }
                else
                {
                    var flagTriggerMods = !Common.Utils.GlobalUtils.WillTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, TriggerEvent.SecondaryBarHealing, triggeringEvent);
                    messageAboutModifier += $" gaining {LustHeal} LP,";
                    Receiver.HealLP(LustHeal, flagTriggerMods);
                }
            }
            if (FocusHeal > 0)
            {
                if (AreDamageMultipliers)
                {
                    objFightAction.focusHeal *= FocusHeal;
                    messageAboutModifier += $" multiplying their action's FP healing by {FocusHeal},";
                }
                else
                {
                    var flagTriggerMods = !Common.Utils.GlobalUtils.WillTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, TriggerEvent.UtilitaryBarHealing, triggeringEvent);
                    messageAboutModifier += $" gaining {FocusHeal} LP,";
                    Receiver.HealFP(FocusHeal, flagTriggerMods);
                }
            }
            if (DiceRoll != 0)
            {
                objFightAction.diceScore += DiceRoll;
                if (DiceRoll > 0)
                {
                    messageAboutModifier += $" getting a +{DiceRoll} bonus for their dice roll,";
                }
                else
                {
                    messageAboutModifier += $" getting a {DiceRoll} penalty for their dice roll,";
                }
            }

            return messageAboutModifier;
        }
    }
}