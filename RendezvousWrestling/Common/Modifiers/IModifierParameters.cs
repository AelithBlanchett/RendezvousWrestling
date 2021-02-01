using RendezvousWrestling.Common.Constants;
using System.Collections.Generic;

internal interface IModifierParameters
{
    public int Tier { get; set; }
    public string Name { get; set; }
    public bool AreDamageMultipliers { get; set; }
    public int DiceRoll { get; set; }
    public int EscapeRoll { get; set; }
    public int Uses { get; set; }
    public TriggerEvent TriggeringEvent { get; set; }
    public TriggerMoment TimeToTrigger { get; set; }
    public List<string> IdParentActions { get; set; }
}