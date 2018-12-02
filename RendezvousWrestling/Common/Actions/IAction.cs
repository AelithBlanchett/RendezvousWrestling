interface IAction<FighterState, Modifier> where FighterState : BaseFighterState<Modifier> where Modifier : BaseModifier
{
    void Execute(FighterState attacker,FighterState[]  defenders);
    int requiredDiceScore { get; set; }
    bool isNonTurnSkippingAction { get; set; }
}