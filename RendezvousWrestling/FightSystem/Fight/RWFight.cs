using System.Threading.Tasks;

public class RWFight : BaseFight
{ //<RWFighterState>{

    public string test { get; set; }

    public RWFight() : base(null /*new RWActionFactory()*/)
    {
    }

    public override void save()
    {

    }

    public override async Task nextTurn()
    {
        foreach (var fighter in this.fighters)
        {
            //fighter.triggerMods(TriggerMoment.Any, Trigger.TurnChange);
            //if (!fighter.isInHold())
            //{
            //    fighter.healFP(1);
            //}
            //if (fighter.focus < fighter.minFocus())
            //{
            //    fighter.consecutiveTurnsWithoutFocus++;
            //}
            //else
            //{
            //    fighter.consecutiveTurnsWithoutFocus = 0;
            //}
        }
        await base.nextTurn();
    }

    public override void punishPlayerOnForfeit(BaseFighterState fighter)
    {
        //TODO TODO
        //this.message.addHit(string.Format(Messages.forfeitItemApply, [fighter.getStylizedName(), fighter.maxBondageItemsOnSelf().ToString()]));
        //for (var i = 0; i < fighter.maxBondageItemsOnSelf(); i++)
        //{
        //    fighter.modifiers.Add(ModifierFactory.getModifier(ModifierType.Bondage, this, fighter, null));
        //}
        //this.message.addHit(string.Format(Messages.forfeitTooManyItems, [fighter.getStylizedName()]));
        fighter.triggerPermanentOutsideRing();
    }


}