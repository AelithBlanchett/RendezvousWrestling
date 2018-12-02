import * as RWGameSettingsJson from "./Configuration/RWGameSettings.json"
import {RWFighterState} from "./Fight/RWFighterState";
import {RWFight} from "./Fight/RWFight";
import {IFChatLib} from "fchatlib/dist/src/Interfaces/IFChatLib";
import {CommandHandler} from "./CommandHandler";
import {RWGameSettings} from "./Configuration/RWGameSettings";
import {RWUser} from "./Fight/RWUser";

public class RendezVousWrestling extends CommandHandler{
    constructor(IFChatLib fChatLib,string  channel) {
        super(RWFight, RWUser, RWFighterState, fChatLib, channel);
        RWGameSettings.loadConfigFile(RWGameSettingsJson);
    }
}