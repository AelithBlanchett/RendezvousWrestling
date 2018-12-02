interface IAction<FighterState> where FighterState : BaseFighterState
{
    execute(FighterState attacker,FighterState[]  defenders);

public int    requiredDiceScore {get; set;}
public bool    isNonTurnSkippingAction {get; set;}
}