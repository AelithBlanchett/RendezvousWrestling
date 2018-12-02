import {IActionFactory} from "../../Common/Actions/IActionFactory";
import {ActionType, RWAction} from "./RWAction";
import {ActionTag} from "./ActionTag";
import {RWFight} from "../Fight/RWFight";
import {RWFighterState} from "../Fight/RWFighterState";
import {ActionBrawl} from "./ActionBrawl";
import {ActionTease} from "./ActionTease";
import {ActionHighRisk} from "./ActionHighRisk";
import {ActionRiskyLewd} from "./ActionRiskyLewd";
import {ActionRest} from "./ActionRest";
import {ActionSubHold} from "./ActionSubHold";
import {ActionEscape} from "./ActionEscape";
import {ActionSexHold} from "./ActionSexHold";
import {ActionHumHold} from "./ActionHumHold";
import {ActionItemPickup} from "./ActionItemPickup";
import {ActionSextoyPickup} from "./ActionSextoyPickup";
import {ActionBondage} from "./ActionBondage";
import {ActionStun} from "./ActionStun";
import {ActionForcedWorship} from "./ActionForcedWorship";
import {ActionReleaseHold} from "./ActionReleaseHold";
import {ActionDegradation} from "./ActionDegradation";
import {ActionStrapToy} from "./ActionStrapToy";
import {ActionSubmit} from "./ActionSubmit";
import {ActionFinisher} from "./ActionFinisher";
import {ActionPass} from "./ActionPass";
import {ActionSelfDebase} from "./ActionSelfDebase";
import {ActionMasturbate} from "./ActionMasturbate";
import {Tiers} from "../Constants/Tiers";

public class RWActionFactory implements IActionFactory<RWFight, RWFighterState> {
    getAction( string actionName,RWFight, attacker:RWFighterState, defenders:RWFighterState[], tier:Tiers  fight): RWAction {
public RWAction        var action {get; set;}
        switch(actionName){
            case ActionType.Brawl:
                action = new ActionBrawl(fight, attacker, defenders, tier);
                break;
            case ActionType.Tease:
                action = new ActionTease(fight, attacker, defenders, tier);
                break;
            case ActionType.Degradation:
                action = new ActionDegradation(fight, attacker, defenders, tier);
                break;
            case ActionType.HighRisk:
                action = new ActionHighRisk(fight, attacker, defenders, tier);
                break;
            case ActionType.RiskyLewd:
                action = new ActionRiskyLewd(fight, attacker, defenders, tier);
                break;
            case ActionType.SubHold:
                action = new ActionSubHold(fight, attacker, defenders, tier);
                break;
            case ActionType.SexHold:
                action = new ActionSexHold(fight, attacker, defenders, tier);
                break;
            case ActionType.HumHold:
                action = new ActionHumHold(fight, attacker, defenders, tier);
                break;
            case ActionType.Stun:
                action = new ActionStun(fight, attacker, defenders, tier);
                break;
            case ActionType.ForcedWorship:
                action = new ActionForcedWorship(fight, attacker, defenders, tier);
                break;
            case ActionType.StrapToy:
                action = new ActionStrapToy(fight, attacker, defenders, tier);
                break;
            case ActionType.ItemPickup:
                action = new ActionItemPickup(fight, attacker, defenders);
                break;
            case ActionType.SextoyPickup:
                action = new ActionSextoyPickup(fight, attacker, defenders);
                break;
            case ActionType.SelfDebase:
                action = new ActionSelfDebase(fight, attacker, defenders, tier);
                break;
            case ActionType.Masturbate:
                action = new ActionMasturbate(fight, attacker, defenders, tier);
                break;
            case ActionType.Escape:
                action = new ActionEscape(fight, attacker, defenders);
                break;
            case ActionType.ReleaseHold:
                action = new ActionReleaseHold(fight, attacker, defenders);
                break;
            case ActionType.Rest:
                action = new ActionRest(fight, attacker, defenders);
                break;
            case ActionType.Submit:
                action = new ActionSubmit(fight, attacker, defenders);
                break;
            case ActionType.Finisher:
                action = new ActionFinisher(fight, attacker, defenders);
                break;
            case ActionType.Tag:
                action = new ActionTag(fight, attacker, defenders);
                break;
            case ActionType.Bondage:
                action = new ActionBondage(fight, attacker, defenders);
                break;
            case ActionType.Pass:
                action = new ActionPass(fight, attacker, defenders);
                break;
            default:
                throw new Error(`The ${actionName} action doesn't exist!`);
        }

        return action;
    }
}