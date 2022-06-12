
using System.Collections.Generic;

public class FightMessage : IMessage
{
    public List<string> Action { get; set; }
    public List<string> Hit { get; set; }
    public List<string> Status { get; set; }
    public List<string> Hint { get; set; }
    public List<string> Special { get; set; }
    public List<string> Info { get; set; }
    public List<string> Error { get; set; }
    public string LastMessage { get; set; }

    public FightMessage()
    {
        clear();
        LastMessage = null;
    }

    void clear()
    {
        Action = new List<string>();
        Hit = new List<string>();
        Status = new List<string>();
        Hint = new List<string>();
        Special = new List<string>();
        Info = new List<string>();
        Error = new List<string>();
    }

    public string getAction()
    {
        return "Action: [color=yellow]" + string.Join("\n", Action) + "[/color]";
    }

    public string getHit()
    {
        return "[color=red][b]" + string.Join("\n", Hit) + "[/b][/color]\n";
    }

    public string getHint()
    {
        return "[color=cyan]" + string.Join("\n", Hint) + "[/color]\n";
    }

    public string getSpecial()
    {
        return "[color=red]" + string.Join("\n", Special) + "[/color]\n";
    }

    public string getStatus()
    {
        return string.Join("\n", Status);
    }

    public string getInfo()
    {
        return string.Join("\n", Info);
    }

    public string getError()
    {
        return "[color=red][b]" + string.Join("\n", Error) + "[/b][/color]";
    }

    public void addAction(string line)
    {
        if (!string.IsNullOrWhiteSpace(line)) Action.Add(line);
    }

    public void addHit(string line)
    {
        if (!string.IsNullOrWhiteSpace(line)) Hit.Add(line);
    }

    public void addHint(string line)
    {
        if (!string.IsNullOrWhiteSpace(line)) Hint.Add(line);
    }

    public void addStatus(string line)
    {
        if (!string.IsNullOrWhiteSpace(line)) Status.Add(line);
    }

    public void AddInfo(string line)
    {
        if (!string.IsNullOrWhiteSpace(line)) Info.Add(line);
    }

    public void addError(string line)
    {
        if (!string.IsNullOrWhiteSpace(line)) Error.Add(line);
    }

    public void addSpecial(string line)
    {
        if (!string.IsNullOrWhiteSpace(line)) Special.Add(line);
    }


    public string buildMessage()
    {
        var lines = new List<string>();

        if (Info.Count > 0) lines.Add(getInfo());
        if (Action.Count > 0) lines.Add(getAction());
        if (Hit.Count > 0) lines.Add(getHit());
        if (Status.Count > 0) lines.Add(getStatus());
        if (Hint.Count > 0) lines.Add(getHint());
        if (Special.Count > 0) lines.Add(getSpecial());
        if (Error.Count > 0) lines.Add(getError());

        return string.Join("\n", lines);
    }

    public string getMessage()
    {
        string message = buildMessage();
        LastMessage = message;
        clear();
        return message;
    }

    public string getLastMessage()
    {
        return LastMessage;
    }
}
