using System.Collections.Generic;

public interface IActionFactory<TAction, TFight, TFighterState> where TAction : BaseActiveAction<TFight, TFighterState> where TFight : BaseFight where TFighterState : BaseFighterState
{
    TAction GetAction(int actionType, TFight fight, TFighterState attacker, List<TFighterState> defenders, int tier);   
}