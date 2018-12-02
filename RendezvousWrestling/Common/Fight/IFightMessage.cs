using System.Collections.Generic;

public interface IMessage
{
    List<string> Action { get; set; }
    List<string> Hit { get; set; }
    List<string> Status { get; set; }
    List<string> Hint { get; set; }
    List<string> Special { get; set; }
    List<string> Info { get; set; }
    List<string> Error { get; set; }
    string LastMessage { get; set; }
}