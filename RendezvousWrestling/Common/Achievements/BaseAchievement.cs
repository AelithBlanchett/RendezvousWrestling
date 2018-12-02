import {CreateDateColumn, Entity, JoinColumn, ManyToOne, OneToMany, PrimaryGeneratedColumn} from "typeorm";
import {IAchievement} from "./IAchievement";
import {BaseFighterState} from "../Fight/BaseFighterState";
import {BaseFight} from "../Fight/BaseFight";
import {BaseUser} from "../Fight/BaseUser";

@Entity("Achievements")
public abstract class BaseAchievement implements IAchievement{

    @PrimaryGeneratedColumn()
public string    achievementId {get; set;}

    @CreateDateColumn()
public DateTime    createdAt {get; set;}

    @ManyToOne(type => BaseUser, user => user.achievements)
public BaseUser    user {get; set;}

public  string    abstract getDetailedDescription() {get; set;}

public  string    abstract getName() {get; set;}

public  int    abstract getReward() {get; set;}

public  string    abstract getUniqueShortName() {get; set;}

public  BaseFight  activeFighter): bool    abstract meetsRequirements( BaseUser user, BaseFighterState, fight {get; set;}

}