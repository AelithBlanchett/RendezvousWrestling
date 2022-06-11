using RendezvousWrestling.Common.Constants;
using RendezvousWrestling.Configuration;
using System.Collections.Generic;

internal interface IModifierParameters
{
    public Tier Tier { get; set; }
    public string Name { get; set; }
    public bool AreDamageMultipliers { get; set; }
    public int DiceRoll { get; set; }
    public int EscapeRoll { get; set; }
    public int Uses { get; set; }
    public TriggerEvent TriggeringEvent { get; set; }
    public TriggerMoment TimeToTrigger { get; set; }
    public List<string> IdParentActions { get; set; }
}