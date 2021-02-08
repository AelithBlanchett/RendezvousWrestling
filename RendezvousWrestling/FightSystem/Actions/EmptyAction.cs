using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.FightSystem.Actions;

public class EmptyAction : RWActiveAction
{

    public EmptyAction()
    {
        Initialize("Empty", false, false, false, true, true, false, true, false, false, false, true, false, true, false, true, false, false, true, false, true, false, false, true, TriggerEvent.None, "no explanation", 1);

    }

    public override void OnHit()
    {

    }
}
