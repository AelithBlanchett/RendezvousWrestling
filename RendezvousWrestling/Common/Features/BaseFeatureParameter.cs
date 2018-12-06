public class BaseFeatureParameter<ActiveAction, Fight, FighterState, Modifier> where ActiveAction : BaseActiveAction<Fight, FighterState, Modifier> where Fight : BaseFight<FighterState, Modifier> where FighterState : BaseFighterState<Modifier> where Modifier : BaseModifier{
public Fight fight {get; set;}
public FighterState fighter {get; set;}
public FighterState target {get; set;}
public ActiveAction action {get; set;}

    public BaseFeatureParameter(Fight fight = null, FighterState fighter = null, FighterState target = null, ActiveAction action = null){
        this.fight = fight;
        this.fighter = fighter;
        this.target = target;
        this.action = action;
    }
}