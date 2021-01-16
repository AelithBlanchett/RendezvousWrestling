

    

    

//    public class KickStart : BaseFeature{

//public int = 1.5        readonly hpDamageMultiplier {get; set;}

//        constructor(RWUser receiver,int, id?:string  uses){
//            super(FeatureType.KickStart, receiver, uses, id);
//        }

//        getCost():int{
//            return this.uses * 5;
//        }

//        applyFeature( TriggerMoment moment,Trigger, parameters?:BaseFeatureParameter  triggeringEvent):string{
//            if(Utils.willTriggerForEvent(moment, TriggerMoment.After, triggeringEvent, Trigger.InitiationRoll)){
//                if(parameters.fighter != null){
//                    var modifier = ModifierFactory.getModifier(ModifierType.ItemPickupBonus, 1}  parameters.fight, parameters.fighter, null,{uses);
//                    parameters.fighter.modifiers.Add(modifier);
//                    return "multiplying their damage by ${this.hpDamageMultiplier}!"
//                }
//            }
//            return "";
//        }
//    }

//    public class Sadist : BaseFeature
//{

//public int = 0.5        readonly lpDamageFromHpMultiplier {get; set;}

//        constructor(RWUser receiver,int, id?:string  uses){
//            super(FeatureType.Sadist, receiver, uses, id);
//        }

//        getCost():int{
//            return this.uses * 5;
//        }

//        applyFeature( TriggerMoment moment,Trigger, parameters?:FeatureParameter  triggeringEvent):string{
//            if(Utils.willTriggerForEvent(moment, TriggerMoment.After, triggeringEvent, Trigger.Attack)){
//                if(parameters.action.attacker.name == this.receiver.name && parameters.action.avgHpDamageToDefs > 0){
//                    parameters.action.lpDamageToAtk = Math.floor(parameters.action.avgHpDamageToDefs * this.lpDamageFromHpMultiplier);
//                    return "returning some of the HP damage dealt for a total of ${this.lpDamageFromHpMultiplier}LP!"
//                }

//            }
//            return "";
//        }
//    }

//    public class CumSlut extends BaseFeature{

//public int = 3        readonly additionalLPDamage {get; set;}

//        constructor(RWUser receiver,int, id?:string  uses){
//            super(FeatureType.CumSlut, receiver, uses, id);
//        }

//        getCost():int{
//            return this.uses * 5;
//        }

//        applyFeature( TriggerMoment moment,Trigger, parameters?:FeatureParameter  triggeringEvent):string{
//            if(Utils.willTriggerForEvent(moment, TriggerMoment.After, triggeringEvent, Trigger.Attack)){
//                if(parameters.action.attacker.name == this.receiver.name && parameters.action.lpDamageToAtk > 0){
//                    parameters.action.lpDamageToAtk += this.additionalLPDamage;
//                    return "dealing more LP Damage (+${this.additionalLPDamage}LP)";
//                }
//                else if(parameters.action.avgLpDamageToDefs > 0){
//                    var defenderIndex = parameters.action.defenders.FindIndex(x => x.name == this.receiver.name);
//                    if(defenderIndex != -1){
//                        parameters.action.lpDamageToDefs[defenderIndex] += this.additionalLPDamage;
//                    }
//                    return "dealing more LP Damage (+${this.additionalLPDamage}LP)";
//                }

//            }
//            return "";
//        }
//    }

//    public class RyonaEnthusiast extends BaseFeature{

//public int = 0.5        readonly lpDamageFromHpMultiplier {get; set;}

//        constructor(RWUser receiver,int, id?:string  uses){
//            super(FeatureType.RyonaEnthusiast, receiver, uses, id);
//        }

//        getCost():int{
//            return this.uses * 5;
//        }

//        applyFeature( TriggerMoment moment,Trigger, parameters?:FeatureParameter  triggeringEvent):string{
//            if(Utils.willTriggerForEvent(moment, TriggerMoment.After, triggeringEvent, Trigger.Attack)){
//                if(parameters.action.avgHpDamageToDefs > 0){
//                    var addedLPs = 0;
//                    var defenderIndex = parameters.action.defenders.FindIndex(x => x.name == this.receiver.name);
//                    if(defenderIndex != -1){
//                        addedLPs = (parameters.action.hpDamageToDefs[defenderIndex] * this.lpDamageFromHpMultiplier);
//                        parameters.action.lpDamageToDefs[defenderIndex] += addedLPs;
//                    }
//                    return "converting some of the HP damage to LP! (+${addedLPs}LP)";
//                }

//            }
//            return "";
//        }
//    }

