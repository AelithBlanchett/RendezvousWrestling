using System.Collections.Generic;

public interface IActionFactory
{
    BaseActiveAction GetAction(string actionName, BaseFight fight, BaseFighterState attacker, List<BaseFighterState> defenders, int tier);   
}