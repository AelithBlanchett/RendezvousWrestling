using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using RendezvousWrestling.FightSystem.Modifiers;
using RendezvousWrestling.FightSystem.Utils;
using System.Collections.Generic;

public class RWModifier : BaseModifier<RWAchievement, RWActionFactory, RWActiveAction, RWEntityMapper, RWFeature, RWFeatureFactory, RWFeatureParameter, RWFeatureType, RWFight, RWFighterState, RWFighterStats, RendezVousWrestling, RWModifier, RWModifierParameters, RWModifierType, RWUser>, IModifierParameters
{
    public RWModifier() : base()
    {

    }

    public RWModifier(RWFight fight, RWFighterState receive, RWFighterState applier, int tier, int uses, TriggerMoment timeToTrigger, Trigger triggeringEvent, List<string> parentActionIds = null) :
        base(fight, receive, applier, tier, uses, timeToTrigger, triggeringEvent, parentActionIds)
    {

    }

    public int hpDamage { get; set; }
    public int lustDamage { get; set; }
    public int focusDamage { get; set; }
    public int hpHeal { get; set; }
    public int lustHeal { get; set; }
    public int focusHeal { get; set; }


    public override bool isAHold()
    {
        //TODO Once modifiers are implemented: return (this.type == RWModifierType.SubHold || this.type == RWModifierType.SexHold || this.type == RWModifierType.HumHold);
        return (this.type == RWModifierType.Bondage || this.type == RWModifierType.Bondage || this.type == RWModifierType.Bondage);
    }

    public override string applyModifierOnReceiver(TriggerMoment moment, Trigger triggeringEvent)
    {
        var messageAboutModifier = "";
        if (this.hpDamage > 0)
        {
            var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.MainBarDamage, triggeringEvent));
            messageAboutModifier += $" losing {this.hpDamage} HP,";
            this.Receiver.hitHP(this.hpDamage, flagTriggerMods);
        }
        if (this.lustDamage > 0)
        {
            var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.SecondaryBarDamage, triggeringEvent));
            messageAboutModifier += $" losing {this.lustDamage} LP,";
            this.Receiver.hitLP(this.lustDamage, flagTriggerMods);
        }
        if (this.focusDamage > 0)
        {
            var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.UtilitaryBarDamage, triggeringEvent));
            messageAboutModifier += $" losing {this.focusDamage} FP,";
            this.Receiver.hitFP(this.focusDamage, flagTriggerMods);
        }
        if (this.hpHeal > 0)
        {
            var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.MainBarHealing, triggeringEvent));
            messageAboutModifier += $" gaining {this.hpHeal} HP,";
            this.Receiver.healHP(this.hpHeal, flagTriggerMods);
        }
        if (this.lustHeal > 0)
        {
            var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.SecondaryBarHealing, triggeringEvent));
            messageAboutModifier += $" gaining {this.lustHeal} LP,";
            this.Receiver.healLP(this.lustHeal, flagTriggerMods);
        }
        if (this.focusHeal > 0)
        {
            var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.UtilitaryBarHealing, triggeringEvent));
            messageAboutModifier += $" gaining {this.focusHeal} FP,";
            this.Receiver.healFP(this.focusHeal, flagTriggerMods);
        }
        if (this.diceRoll != 0)
        {
            this.Receiver.dice.addTmpMod(this.diceRoll, 1);
            if (this.diceRoll > 0)
            {
                messageAboutModifier += $" getting a +{this.diceRoll} bonus for their dice roll,";
            }
            else
            {
                messageAboutModifier += $" getting a {this.diceRoll} penalty for their dice roll,";
            }
        }

        return messageAboutModifier;
    }

    public override string applyModifierOnAction(TriggerMoment moment, Trigger triggeringEvent, dynamic objFightAction)
    {
        var messageAboutModifier = "";
        if (this.hpDamage > 0)
        {
            if (this.areDamageMultipliers)
            {
                objFightAction.hpDamage *= this.hpDamage;
                messageAboutModifier += $" multiplying their attack's HP damage by {this.hpDamage},";
            }
            else
            {
                var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.MainBarDamage, triggeringEvent));
                messageAboutModifier += $" losing {this.hpDamage} HP,";
                this.Receiver.hitHP(this.hpDamage, flagTriggerMods);
            }
        }
        if (this.lustDamage > 0)
        {
            if (this.areDamageMultipliers)
            {
                objFightAction.lustDamage *= this.lustDamage;
                messageAboutModifier += $" multiplying their attack's LP damage by {this.lustDamage},";
            }
            else
            {
                var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.SecondaryBarDamage, triggeringEvent));
                messageAboutModifier += $" losing {this.lustDamage} LP,";
                this.Receiver.hitLP(this.lustDamage, flagTriggerMods);
            }
        }
        if (this.focusDamage > 0)
        {
            if (this.areDamageMultipliers)
            {
                objFightAction.focusDamage *= this.focusDamage;
                messageAboutModifier += $" multiplying their attack's FP damage by {this.focusDamage},";
            }
            else
            {
                var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.UtilitaryBarDamage, triggeringEvent));
                messageAboutModifier += $" losing {this.focusDamage} LP,";
                this.Receiver.hitFP(this.focusDamage, flagTriggerMods);
            }
        }
        if (this.hpHeal > 0)
        {
            if (this.areDamageMultipliers)
            {
                objFightAction.hpHeal *= this.hpHeal;
                messageAboutModifier += $" multiplying their action's HP healing by {this.hpHeal},";
            }
            else
            {
                var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.MainBarHealing, triggeringEvent));
                messageAboutModifier += $" gaining {this.hpHeal} HP,";
                this.Receiver.healHP(this.hpHeal, flagTriggerMods);
            }
        }
        if (this.lustHeal > 0)
        {
            if (this.areDamageMultipliers)
            {
                objFightAction.lustHeal *= this.lustHeal;
                messageAboutModifier += $" multiplying their action's LP healing by {this.lustHeal},";
            }
            else
            {
                var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.SecondaryBarHealing, triggeringEvent));
                messageAboutModifier += $" gaining {this.lustHeal} LP,";
                this.Receiver.healLP(this.lustHeal, flagTriggerMods);
            }
        }
        if (this.focusHeal > 0)
        {
            if (this.areDamageMultipliers)
            {
                objFightAction.focusHeal *= this.focusHeal;
                messageAboutModifier += $" multiplying their action's FP healing by {this.focusHeal},";
            }
            else
            {
                var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.UtilitaryBarHealing, triggeringEvent));
                messageAboutModifier += $" gaining {this.focusHeal} LP,";
                this.Receiver.healFP(this.focusHeal, flagTriggerMods);
            }
        }
        if (this.diceRoll != 0)
        {
            objFightAction.diceScore += this.diceRoll;
            if (this.diceRoll > 0)
            {
                messageAboutModifier += $" getting a +{this.diceRoll} bonus for their dice roll,";
            }
            else
            {
                messageAboutModifier += $" getting a {this.diceRoll} penalty for their dice roll,";
            }
        }

        return messageAboutModifier;
    }
}