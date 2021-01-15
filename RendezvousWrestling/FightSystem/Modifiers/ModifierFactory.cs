using System;

public class ModifierFactory{

    public static dynamic checkAndInitializeDefaultValues(int indexOfSearchedModifier,string modifierName, dynamic parameters){
        if(!Enum.TryParse(typeof(ModifierType), modifierName, out var modifier)){
            throw new Exception("This modifier doesn't exist in the ModifierType list.");
        }

        if(parameters == null){
            parameters = {};
        }

        //Merges the properties found in the json config file with our custom parameters object
        Utils.mergeFromTo(modifiersList[indexOfSearchedModifier], parameters);

        parameters.type = ModifierType[modifierName];
        parameters.tier = parameters.tier || Tiers.None;
        parameters.hpDamage = parameters.hpDamage || 0;
        parameters.lustDamage = parameters.lustDamage || 0;
        parameters.focusDamage = parameters.focusDamage || 0;
        parameters.diceRoll = parameters.diceRoll || 0;
        parameters.escapeRoll = parameters.escapeRoll || 0;
        parameters.uses = parameters.uses || 0;
        parameters.areDamageMultipliers = false;

        //Convert textual triggeringEvent to its equivalent in the code
        var eventFound = false;

        if(parameters.sEvent != null){
            var listOfEvents = Utils.getEnumList(Trigger);
            for(var trigger in listOfEvents){
                if(listOfEvents[trigger].ToLower() == parameters.sEvent.ToLower()){
                    parameters.triggeringEvent = Trigger[listOfEvents[trigger]];
                    eventFound = true;
                }
            }
        }

        if(!eventFound){
            parameters.triggeringEvent = Trigger.None;
        }

        //Convert textual timeToTrigger to its equivalent in the code
        var timeToTriggerFound = false;

        if(parameters.sTimeToTrigger != null){
            var listOfEvents = Utils.getEnumList(TriggerMoment);
            for(var trigger in listOfEvents){
                if(listOfEvents[trigger].ToLower() == parameters.sTimeToTrigger.ToLower()){
                    parameters.timeToTrigger = TriggerMoment[listOfEvents[trigger]];
                    timeToTriggerFound = true;
                }
            }
        }

        if(!timeToTriggerFound){
            parameters.timeToTrigger = TriggerMoment.Never;
        }

        return parameters;
    }

    public static RWModifier getModifier(ModifierType modifierName,BaseFight fight, BaseFighterState receiver, BaseFighterState applier = null, dynamic inputParameters = null ){
        Modifier modifier = null;
        if(inputParameters == null){
            inputParameters = {};
        }

        var modifierTypes = Utils.getStringEnumList(ModifierType);
        var realModifierName = "";

        for(var simpleName of modifierTypes){
            if(ModifierType[simpleName] == modifierName){
                realModifierName = simpleName;
                break;
            }
        }

        if(realModifierName == ""){
            throw new Error("This modifier wasn't found in the ModifierType list.");
        }

        var indexOfSearchedModifier = (<any>modifiersList).FindIndex(x => x.name.ToLower() == realModifierName.ToLower());
        if(indexOfSearchedModifier != -1){
            inputParameters = ModifierFactory.checkAndInitializeDefaultValues(indexOfSearchedModifier, realModifierName, inputParameters);
            modifier = new Modifier(modifierName, fight, receiver, applier , inputParameters.tier, inputParameters.uses, inputParameters.timeToTrigger, inputParameters.triggeringEvent, inputParameters.parentIds);
            modifier.hpDamage = inputParameters.hpDamage;
            modifier.lustDamage = inputParameters.lustDamage;
            modifier.areDamageMultipliers = inputParameters.focusDamage;
            modifier.diceRoll = inputParameters.diceRoll;
            modifier.escapeRoll = inputParameters.escapeRoll;
            modifier.areDamageMultipliers = inputParameters.areDamageMultipliers;
        }

        if(modifier == null){
            throw new Error($"The modifier ${realModifierName} couldn't be initialized. Make sure it exists in the modifiers file.")
        }

        return modifier;
    }
}