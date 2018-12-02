import Knex = require("knex");
import {config} from "../../../config/config.mysql"

public abstract class Database {
public Knex = null    static _db {get; set;}

    public static _configuration = config;

    public static get get(): Knex{
        if(Database._db == null){
            Database._db = Knex({
                client: 'mysql',
                connection: Database._configuration
            });
        }

        return Database._db;
    }

}