import {IMessage} from "./IFightMessage";

public class FightMessage implements IMessage {
public Array<string>    action {get; set;}
public Array<string>    hit {get; set;}
public Array<string>    status {get; set;}
public Array<string>    hint {get; set;}
public Array<string>    special {get; set;}
public Array<string>    info {get; set;}
public Array<string>    error {get; set;}
public string    lastMessage {get; set;}

    constructor() {
        this.clear();
        this.lastMessage = null;
    }

    clear(){
        this.action = [];
        this.hit = [];
        this.status = [];
        this.hint = [];
        this.special = [];
        this.info = [];
        this.error = [];
    }

    getAction() {
public  [color=yellow]" + this.action.join(" ") + "[/color]"        return "Action {get; set;}
    }

    getHit() {
        return "[color=red][b]" + this.hit.join("\n") + "[/b][/color]\n";
    }

    getHint() {
        return "[color=cyan]" + this.hint.join("\n") + "[/color]\n";
    }

    getSpecial() {
        return "[color=red]" + this.special.join("\n") + "[/color]\n";
    }

    getStatus(){
        return this.status.join("\n");
    }

    getInfo(){
        return this.info.join("\n");
    }

    getError() {
        return "[color=red][b]" + this.error.join("\n") + "[/b][/color]";
    }

    addAction(line) {
        if (typeof line === "string") this.action.push(line);
    }

    addHit(line) {
        if (typeof line === "string") this.hit.push(line);
    }

    addHint(line) {
        if (typeof line === "string") this.hint.push(line);
    }

    addStatus(line) {
        if (typeof line === "string") this.status.push(line);
    }

    addInfo(line){
        if (typeof line === "string") this.info.push(line);
    }

    addError(line){
        if (typeof line === "string") this.error.push(line);
    }

    addSpecial(line){
        if (typeof line === "string") this.special.push(line);
    }


    buildMessage():string{
        var lines = [];

        if (this.info.length) lines.push(this.getInfo());
        if (this.action.length) lines.push(this.getAction());
        if (this.hit.length) lines.push(this.getHit());
        if (this.status.length) lines.push(this.getStatus());
        if (this.hint.length) lines.push(this.getHint());
        if (this.special.length) lines.push(this.getSpecial());
        if (this.error.length) lines.push(this.getError());

        return lines.join("\n");
    }

    getMessage():string {
        string message = this.buildMessage();
        this.lastMessage = message;
        this.clear();
        return message;
    }

    getLastMessage():string{
        return this.lastMessage;
    }
}
