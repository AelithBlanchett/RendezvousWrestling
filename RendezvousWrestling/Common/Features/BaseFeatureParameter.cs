public class BaseFeatureParameter
{
    public BaseFight fight { get; set; }
    public BaseFighterState fighter { get; set; }
    public BaseFighterState target { get; set; }
    public BaseActiveAction action { get; set; }

    public BaseFeatureParameter(BaseFight fight = null, BaseFighterState fighter = null, BaseFighterState target = null, BaseActiveAction action = null)
    {
        this.fight = fight;
        this.fighter = fighter;
        this.target = target;
        this.action = action;
    }
}