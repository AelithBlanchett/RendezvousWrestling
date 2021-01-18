
using RendezvousWrestling.FightSystem.Achievements;
using RendezvousWrestling.FightSystem.Features;
using System;
using System.Collections.Generic;

public class RWActionFactory : IActionFactory<RendezVousWrestling, RWAchievement, RWActionFactory, RWActiveAction, RWFeature, RWFeatureFactory, RWFight, RWFighterState, RWFighterStats, RWModifier, RWUser, RWFeatureParameter>
{
    public RWActionFactory() : base()
    {

    }
    public RWActiveAction action { get; set; }
    public RWActiveAction GetAction(string actionType, RWFight fight, RWFighterState attacker, List<RWFighterState> defenders, int tier)
    {
        if(!Enum.TryParse(typeof(ActionType), actionType, out var parsedActionType)) //TODO THIS PROBABLY ISNT WORKING!!!
        {
            throw new Exception($"The action ${actionType} doesn't exist!");
        }

        switch (parsedActionType)
        {
            //case ActionType.Brawl:
            //    action = new ActionBrawl(fight, attacker, defenders, tier);
            //    break;
            //case ActionType.Tease:
            //    action = new ActionTease(fight, attacker, defenders, tier);
            //    break;
            //case ActionType.Degradation:
            //    action = new ActionDegradation(fight, attacker, defenders, tier);
            //    break;
            //case ActionType.HighRisk:
            //    action = new ActionHighRisk(fight, attacker, defenders, tier);
            //    break;
            //case ActionType.RiskyLewd:
            //    action = new ActionRiskyLewd(fight, attacker, defenders, tier);
            //    break;
            //case ActionType.SubHold:
            //    action = new ActionSubHold(fight, attacker, defenders, tier);
            //    break;
            //case ActionType.SexHold:
            //    action = new ActionSexHold(fight, attacker, defenders, tier);
            //    break;
            //case ActionType.HumHold:
            //    action = new ActionHumHold(fight, attacker, defenders, tier);
            //    break;
            //case ActionType.Stun:
            //    action = new ActionStun(fight, attacker, defenders, tier);
            //    break;
            //case ActionType.ForcedWorship:
            //    action = new ActionForcedWorship(fight, attacker, defenders, tier);
            //    break;
            //case ActionType.StrapToy:
            //    action = new ActionStrapToy(fight, attacker, defenders, tier);
            //    break;
            //case ActionType.ItemPickup:
            //    action = new ActionItemPickup(fight, attacker, defenders);
            //    break;
            //case ActionType.SextoyPickup:
            //    action = new ActionSextoyPickup(fight, attacker, defenders);
            //    break;
            //case ActionType.SelfDebase:
            //    action = new ActionSelfDebase(fight, attacker, defenders, tier);
            //    break;
            //case ActionType.Masturbate:
            //    action = new ActionMasturbate(fight, attacker, defenders, tier);
            //    break;
            //case ActionType.Escape:
            //    action = new ActionEscape(fight, attacker, defenders);
            //    break;
            //case ActionType.ReleaseHold:
            //    action = new ActionReleaseHold(fight, attacker, defenders);
            //    break;
            //case ActionType.Rest:
            //    action = new ActionRest(fight, attacker, defenders);
            //    break;
            //case ActionType.Submit:
            //    action = new ActionSubmit(fight, attacker, defenders);
            //    break;
            //case ActionType.Finisher:
            //    action = new ActionFinisher(fight, attacker, defenders);
            //    break;
            //case ActionType.Tag:
            //    action = new ActionTag(fight, attacker, defenders);
            //    break;
            //case ActionType.Bondage:
            //    action = new ActionBondage(fight, attacker, defenders);
            //    break;
            case ActionType.Pass:
                action = new ActionPass(fight, attacker, defenders);
                break;
            default:
                throw new Exception($"The action ${actionType} doesn't exist!");
        }

        return action;
    }
}