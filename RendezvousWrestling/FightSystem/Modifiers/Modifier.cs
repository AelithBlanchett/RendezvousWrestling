using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using System.Collections.Generic;

public class RWModifier : BaseModifier<RWAchievement, RWActionFactory, RWActiveAction, RWFeature, RWFeatureFactory, RWFight, RWFighterState, RWModifier, RWUser, RWFeatureParameter>
{
    public RWModifier() : base()
    {

    }

    public RWModifier(string name, RWFight fight, RWFighterState receive, RWFighterState applier, int tier, int uses, TriggerMoment timeToTrigger, Trigger triggeringEvent, List<string> parentActionIds = null) :
        base(name, fight, receive, applier, tier, uses, timeToTrigger, triggeringEvent, parentActionIds)
    {

    }

    public  int    hpDamage {get; set;}
public  int    lustDamage {get; set;}
public  int    focusDamage {get; set;}
public  int    hpHeal {get; set;}
public  int    lustHeal {get; set;}
public  int    focusHeal {get; set;}

public RWFight    fight {get; set;}
public RWFighterState    applier {get; set;}
public RWFighterState    receiver {get; set;}


    public override bool isAHold() {
        return (this.type == (int)ModifierType.SubHold || this.type == (int)ModifierType.SexHold || this.type == (int)ModifierType.HumHold);
    }

    public override string applyModifierOnReceiver( TriggerMoment moment,Trigger triggeringEvent){
        var messageAboutModifier = "";
        if(this.hpDamage > 0){
            var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.MainBarDamage, triggeringEvent));
            messageAboutModifier += " losing ${this.hpDamage} HP,";
            this.receiver.hitHP(this.hpDamage, flagTriggerMods);
        }
        if(this.lustDamage > 0){
            var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.SecondaryBarDamage, triggeringEvent));
            messageAboutModifier += " losing ${this.lustDamage} LP,";
            this.receiver.hitLP(this.lustDamage, flagTriggerMods);
        }
        if(this.focusDamage > 0){
            var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.UtilitaryBarDamage, triggeringEvent));
            messageAboutModifier += " losing ${this.focusDamage} FP,";
            this.receiver.hitFP(this.focusDamage, flagTriggerMods);
        }
        if(this.hpHeal > 0){
            var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.MainBarHealing, triggeringEvent));
            messageAboutModifier += " gaining ${this.hpHeal} HP,";
            this.receiver.healHP(this.hpHeal, flagTriggerMods);
        }
        if(this.lustHeal > 0){
            var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.SecondaryBarHealing, triggeringEvent));
            messageAboutModifier += " gaining ${this.lustHeal} LP,";
            this.receiver.healLP(this.lustHeal, flagTriggerMods);
        }
        if(this.focusHeal > 0){
            var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.UtilitaryBarHealing, triggeringEvent));
            messageAboutModifier += " gaining ${this.focusHeal} FP,";
            this.receiver.healFP(this.focusHeal, flagTriggerMods);
        }
        if(this.diceRoll != 0){
            this.receiver.dice.addTmpMod(this.diceRoll,1);
            if(this.diceRoll > 0){
                messageAboutModifier += " getting a +${this.diceRoll} bonus for their dice roll,";
            }
            else{
                messageAboutModifier += " getting a ${this.diceRoll} penalty for their dice roll,";
            }
        }

        return messageAboutModifier;
    }

    public override string applyModifierOnAction( TriggerMoment moment, Trigger triggeringEvent, dynamic objFightAction)
    {
        var messageAboutModifier = "";
        if(this.hpDamage > 0){
            if(this.areDamageMultipliers){
                objFightAction.hpDamage *= this.hpDamage;
                messageAboutModifier += " multiplying their attack's HP damage by ${this.hpDamage},";
            }
            else{
                var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.MainBarDamage, triggeringEvent));
                messageAboutModifier += " losing ${this.hpDamage} HP,";
                this.receiver.hitHP(this.hpDamage, flagTriggerMods);
            }
        }
        if(this.lustDamage > 0){
            if(this.areDamageMultipliers){
                objFightAction.lustDamage *= this.lustDamage;
                messageAboutModifier += " multiplying their attack's LP damage by ${this.lustDamage},";
            }
            else {
                var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.SecondaryBarDamage, triggeringEvent));
                messageAboutModifier += " losing ${this.lustDamage} LP,";
                this.receiver.hitLP(this.lustDamage, flagTriggerMods);
            }
        }
        if(this.focusDamage > 0){
            if(this.areDamageMultipliers){
                objFightAction.focusDamage *= this.focusDamage;
                messageAboutModifier += " multiplying their attack's FP damage by ${this.focusDamage},";
            }
            else {
                var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.UtilitaryBarDamage, triggeringEvent));
                messageAboutModifier += " losing ${this.focusDamage} LP,";
                this.receiver.hitFP(this.focusDamage, flagTriggerMods);
            }
        }
        if(this.hpHeal > 0){
            if(this.areDamageMultipliers){
                objFightAction.hpHeal *= this.hpHeal;
                messageAboutModifier += " multiplying their action's HP healing by ${this.hpHeal},";
            }
            else{
                var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.MainBarHealing, triggeringEvent));
                messageAboutModifier += " gaining ${this.hpHeal} HP,";
                this.receiver.healHP(this.hpHeal, flagTriggerMods);
            }
        }
        if(this.lustHeal > 0){
            if(this.areDamageMultipliers){
                objFightAction.lustHeal *= this.lustHeal;
                messageAboutModifier += " multiplying their action's LP healing by ${this.lustHeal},";
            }
            else {
                var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.SecondaryBarHealing, triggeringEvent));
                messageAboutModifier += " gaining ${this.lustHeal} LP,";
                this.receiver.healLP(this.lustHeal, flagTriggerMods);
            }
        }
        if(this.focusHeal > 0){
            if(this.areDamageMultipliers){
                objFightAction.focusHeal *= this.focusHeal;
                messageAboutModifier += " multiplying their action's FP healing by ${this.focusHeal},";
            }
            else {
                var flagTriggerMods = !(Utils.willTriggerForEvent(TriggerMoment.Any, TriggerMoment.Any, Trigger.UtilitaryBarHealing, triggeringEvent));
                messageAboutModifier += " gaining ${this.focusHeal} LP,";
                this.receiver.healFP(this.focusHeal, flagTriggerMods);
            }
        }
        if(this.diceRoll != 0){
            objFightAction.diceScore += this.diceRoll;
            if(this.diceRoll > 0){
                messageAboutModifier += " getting a +${this.diceRoll} bonus for their dice roll,";
            }
            else{
                messageAboutModifier += " getting a ${this.diceRoll} penalty for their dice roll,";
            }
        }

        return messageAboutModifier;
    }
}