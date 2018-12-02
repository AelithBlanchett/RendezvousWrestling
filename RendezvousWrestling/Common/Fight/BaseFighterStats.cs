import {Column, Entity, OneToOne, PrimaryColumn, PrimaryGeneratedColumn, RelationOptions} from "typeorm";
import {Team} from "../Constants/Team";

public abstract class BaseFighterStats{

    @PrimaryGeneratedColumn()
public string    statsId {get; set;}
    @Column()
public int    fightsCount {get; set;}
    @Column()
public int    fightsCountCS {get; set;}
    @Column()
public int    losses {get; set;}
    @Column()
public int    lossesSeason {get; set;}
    @Column()
public int    wins {get; set;}
    @Column()
public int    winsSeason {get; set;}
    @Column()
public int    currentlyPlaying {get; set;}
    @Column()
public int    currentlyPlayingSeason {get; set;}
    @Column()
public int    fightsPendingReady {get; set;}
    @Column()
public int    fightsPendingReadySeason {get; set;}
    @Column()
public int    fightsPendingStart {get; set;}
    @Column()
public int    fightsPendingStartSeason {get; set;}
    @Column()
public int    fightsPendingDraw {get; set;}
    @Column()
public int    fightsPendingDrawSeason {get; set;}
    @Column()
public Team    favoriteTeam {get; set;}
    @Column()
public string    favoriteTagPartner {get; set;}
    @Column()
public int    timesFoughtWithFavoriteTagPartner {get; set;}
    @Column()
public string    nemesis {get; set;}
    @Column()
public int    lossesAgainstNemesis {get; set;}
    @Column()
public int    averageDiceRoll {get; set;}
    @Column()
public int    missedAttacks {get; set;}
    @Column()
public int    actionsCount {get; set;}
    @Column()
public int    actionsDefended {get; set;}

    @Column()
public int    matchesInLast24Hours {get; set;}
    @Column()
public int    matchesInLast48Hours {get; set;}

    @Column()
public int = 2000    eloRating {get; set;}
    @Column()
public int    globalRank {get; set;}

    @Column()
public int    forfeits {get; set;}
    @Column()
public int    quits {get; set;}

    get winrate():int{
        var winRate = 0.00;
        if(this.fightsCount > 0 && this.wins > 0){
            winRate = this.fightsCount/this.wins;
        }
        else if(this.fightsCount > 0 && this.losses > 0){
            winRate = 1 - this.fightsCount/this.losses;
        }
        return winRate;
    }
}