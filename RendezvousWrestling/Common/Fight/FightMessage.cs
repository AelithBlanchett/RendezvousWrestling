
using System.Collections.Generic;

public class FightMessage : IMessage {
public List<string>    Action {get; set;}
public List<string>    Hit {get; set;}
public List<string>    Status {get; set;}
public List<string>    Hint {get; set;}
public List<string>    Special {get; set;}
public List<string>    Info {get; set;}
public List<string>    Error {get; set;}
public string    LastMessage {get; set;}

    public FightMessage() {
        this.clear();
        this.LastMessage = null;
    }

    void clear(){
        Action = new List<string>();
        Hit = new List<string>();
        Status = new List<string>();
        Hint = new List<string>();
        Special = new List<string>();
        Info = new List<string>();
        Error = new List<string>();
    }

    public string getAction() {
        return "Action :[color=yellow]" + string.Join("\n", Action) + "[/color]"; 
    }

    public string getHit() {
        return "[color=red][b]" + string.Join("\n", Hit) + "[/b][/color]\n";
    }

    public string getHint() {
        return "[color=cyan]" + string.Join("\n", Hint) + "[/color]\n";
    }

    public string getSpecial() {
        return "[color=red]" + string.Join("\n", Special) + "[/color]\n";
    }

    public string getStatus(){
        return string.Join("\n", Status);
    }

    public string getInfo(){
        return string.Join("\n", Info);
    }

    public string getError() {
        return "[color=red][b]" + string.Join("\n", Error) + "[/b][/color]";
    }

    public void addAction(string line)
    {
        if(!string.IsNullOrWhiteSpace(line)) this.Action.Add(line);
    }

    public void addHit(string line)
    {
        if(!string.IsNullOrWhiteSpace(line)) this.Hit.Add(line);
    }

    public void addHint(string line)
    {
        if(!string.IsNullOrWhiteSpace(line)) this.Hint.Add(line);
    }

    public void addStatus(string line) {
        if(!string.IsNullOrWhiteSpace(line)) this.Status.Add(line);
    }

    public void addInfo(string line)
    {
        if(!string.IsNullOrWhiteSpace(line)) this.Info.Add(line);
    }

    public void addError(string line)
    {
        if(!string.IsNullOrWhiteSpace(line)) this.Error.Add(line);
    }

    public void addSpecial(string line){
        if(!string.IsNullOrWhiteSpace(line)) this.Special.Add(line);
    }


    public string buildMessage(){
        var lines = new List<string>();

        if (Info.Count > 0) lines.Add(this.getInfo());
        if (Action.Count > 0) lines.Add(this.getAction());
        if (Hit.Count > 0) lines.Add(this.getHit());
        if (Status.Count > 0) lines.Add(this.getStatus());
        if (Hint.Count > 0) lines.Add(this.getHint());
        if (Special.Count > 0) lines.Add(this.getSpecial());
        if (Error.Count > 0) lines.Add(this.getError());

        return string.Join("\n", lines);
    }

    public string getMessage() {
        string message = this.buildMessage();
        this.LastMessage = message;
        this.clear();
        return message;
    }

    public string getLastMessage(){
        return this.LastMessage;
    }
}
