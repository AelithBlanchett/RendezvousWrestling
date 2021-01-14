public class BaseFeatureParameter<TFight, TFighterState, TAction> where TFight : BaseFight where TFighterState : BaseFighterState where TAction : BaseActiveAction<TFight, TFighterState>
{
    public TFight fight { get; set; }
    public TFighterState fighter { get; set; }
    public TFighterState target { get; set; }
    public TAction action { get; set; }

    public BaseFeatureParameter(TFight fight = null, TFighterState fighter = null, TFighterState target = null, TAction action = null)
    {
        this.fight = fight;
        this.fighter = fighter;
        this.target = target;
        this.action = action;
    }
}