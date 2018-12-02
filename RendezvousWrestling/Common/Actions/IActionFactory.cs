public interface IActionFactory<Fight, FighterState, Modifier> where Modifier : BaseModifier where FighterState : BaseFighterState<Modifier> where Fight : BaseFight<FighterState, Modifier>
{
    BaseActiveAction<Fight, FighterState, Modifier> GetAction(string actionName, Fight fight, FighterState attacker, FighterState[] defenders, int tier);   
}