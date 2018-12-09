import {BaseUser} from "../../Common/Fight/BaseUser";
import {TransactionType} from "../../Common/Constants/TransactionType";
import {Column, JoinColumn, OneToOne} from "typeorm";
import {RWFighterStats} from "./RWFighterStats";
import {IFeatureFactory} from "../../Common/Features/IFeatureFactory";
import {Stats} from "../Constants/Stats";

public class RWUser extends BaseUser{


    @Column()
public int = 1    dexterity {get; set;}
    @Column()
public int = 1    power {get; set;}
    @Column()
public int = 1    sensuality {get; set;}
    @Column()
public int = 1    toughness {get; set;}
    @Column()
public int = 1    endurance {get; set;}
    @Column()
public int = 1    willpower {get; set;}

    @OneToOne(type => RWFighterStats)
    @JoinColumn()
public RWFighterStats    stats {get; set;}

    saveTokenTransaction( string idFighter, int, transactionType: TransactionType, fromFighter?: string  amount): Promise<void> {
        return undefined;
    }

    constructor( string name,IFeatureFactory  featureFactory){
        super(name, featureFactory);
        this.toughness = 1;
        this.toughness = 1;
        this.endurance = 1;
        this.willpower = 1;
        this.sensuality = 1;
        this.power = 1;
        this.dexterity = 1;
    }

    restat(statArray:Array<int>){
        for(var i = 0; i < statArray.Count;  i++){
            this[Stats[i]] = statArray[i];
        }
    }

    outputStats():string{
        return "[b]" + this.name + "[/b]'s stats" + "\n" +
            "[b][color=red]Power[/color][/b]:  " + this.power + "      "+"\n" +
            "[b][color=purple]Sensuality[/color][/b]:  " + this.sensuality + "\n" +
            "[b][color=orange]Toughness[/color][/b]: " + this.toughness + "\n" +
            "[b][color=cyan]Endurance[/color][/b]: " + this.endurance + "      " + "[b][color=green]Win[/color]/[color=red]Loss[/color] record[/b]: " + this.stats.wins + " - " + this.stats.losses + "\n" +
            "[b][color=green]Dexterity[/color][/b]: " + this.dexterity + "\n" +
            "[b][color=brown]Willpower[/color][/b]: " + this.willpower +  "      " + "[b][color=orange]Tokens[/color][/b]: " + this.tokens + "         [b][color=orange]Total spent[/color][/b]: "+this.tokensSpent+"\n"  +
            "[b][color=red]Features[/color][/b]: [b]" + this.getFeaturesList() + "[/b]\n" +
            "[b][color=yellow]Common.Achievements[/color][/b]: [sub]" + this.getAchievementsList() + "[/sub]\n" +
public  [sub]Avg. roll: ${this.stats.averageDiceRoll}, ${( "None!"  Fav. tag partner)} this.stats.favoriteTagPartner != null && this.stats.favoriteTagPartner != "" ? this.stats.favoriteTagPartner , Moves done: ${this.stats.actionsCount}, Nemesis: ${this.stats.nemesis} [/sub]"            "[b][color=white]Fun stats[/color][/b] {get; set;}
    }

}