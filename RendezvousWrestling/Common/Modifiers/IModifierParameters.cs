using System.Collections.Generic;

internal interface IModifierParameters
{
    public int tier { get; set; }
    public string name { get; set; }
    public bool areDamageMultipliers { get; set; }
    public int diceRoll { get; set; }
    public int escapeRoll { get; set; }
    public int uses { get; set; }
    public Trigger triggeringEvent { get; set; }
    public TriggerMoment timeToTrigger { get; set; }
    public List<string> idParentActions { get; set; }
}