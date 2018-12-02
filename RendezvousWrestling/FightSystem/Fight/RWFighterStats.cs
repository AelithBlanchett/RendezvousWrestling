import {BaseFighterStats} from "../../Common/Fight/BaseFighterStats";
import {Column, Entity, JoinColumn, OneToOne} from "typeorm";
import {RWUser} from "./RWUser";

@Entity()
public class RWFighterStats extends BaseFighterStats{

    @OneToOne(type => RWUser, fighter => fighter.statistics)
    @JoinColumn()
public RWUser    fighter {get; set;}
    @Column()
public int    brawlAtksCount {get; set;}
    @Column()
public int    sexstrikesCount {get; set;}
    @Column()
public int    tagsCount {get; set;}
    @Column()
public int    restCount {get; set;}
    @Column()
public int    subholdCount {get; set;}
    @Column()
public int    sexholdCount {get; set;}
    @Column()
public int    bondageCount {get; set;}
    @Column()
public int    humholdCount {get; set;}
    @Column()
public int    itemPickups {get; set;}
    @Column()
public int    sextoyPickups {get; set;}
    @Column()
public int    degradationCount {get; set;}
    @Column()
public int    forcedWorshipCount {get; set;}
    @Column()
public int    highRiskCount {get; set;}
    @Column()
public int    penetrationCount {get; set;}
    @Column()
public int    stunCount {get; set;}
    @Column()
public int    escapeCount {get; set;}
    @Column()
public int    submitCount {get; set;}
    @Column()
public int    straptoyCount {get; set;}
    @Column()
public int    finishCount {get; set;}
    @Column()
public int    masturbateCount {get; set;}
}