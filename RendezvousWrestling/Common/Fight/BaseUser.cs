
public abstract class BaseUser{
public string = ""    Name {get; set;}
public bool = true    AreStatsPrivate {get; set;}
public  int = 50    Tokens {get; set;}
public  int = 0    TokensSpent {get; set;}
public Date    CreatedAt {get; set;}
public Date    UpdatedAt {get; set;}
public bool = false    Deleted {get; set;}

public BaseAchievement[]    Achievements {get; set;}
public BaseFighterStats    Statistics {get; set;}
public BaseFeature[]    Features {get; set;}
public BaseFighterState[]    FightStates {get; set;}

public IFeatureFactory    featureFactory {get; set;}

    public BaseUser(string name, IFeatureFactory featureFactory)
    {
        Name = name;
        FeatureFactory = featureFactory;
    }

    getFeaturesList(){
        var strResult = [];
        for(var feature of this.features){
            var usesLeft = "";
            if(feature.uses > 0){
                usesLeft = ` - ${feature.uses} uses left`;
            }
            else{
                usesLeft = ` - permanent`;
            }
            strResult.push(`${feature.type}${usesLeft}`);
        }
        return strResult.join(", ");
    }

    getAchievementsList(){
        var strResult = [];
        for(var achievement of this.achievements){
            strResult.push(`${achievement.getDetailedDescription()}`);
        }
        return strResult.join(", ");
    }

    removeFeature(type:string):void{
        var index = this.features.findIndex(x => x.type == type);
        if(index != -1){
            this.features.splice(index, 1);
        }
        else{
            throw new Error("You don't have this feature, you can't remove it.");
        }
    }

    addFeature(string type,int  matches):int{
        any feature = this.featureFactory.getFeature(type, this, matches);

        if(feature == null){
            throw new Error( ${this.featureFactory.getExistingFeatures().join(' `Feature not found. These are the existing features,')}`);
        }

        if(feature.getCost() > 0 && matches == 0){
            throw new Error(`A paid feature requires a specific int of matches.`);
        }

        int amountToRemove = feature.getCost() * matches;

        if(this.tokens - amountToRemove >= 0){
            var index = this.features.findIndex(x => x.type == type);
            if(index == -1){
                this.features.push(feature);
                return amountToRemove;
            }
            else{
                throw new Error(Messages.cantAddFeatureAlreadyHaveIt);
            }
        }
        else{
public  ${amountToRemove}.`)            throw new Error(`Not enough tokens. Required {get; set;}
        }
    }

    clearFeatures(){
        this.features = [];
    }

    hasFeature(featureType:string):bool{
        return this.features.findIndex(x => x.type == featureType) != -1;
    }

    public async void giveTokens(int amount,TransactionType, fromFighter:string = ""  transactionType):Promise<void>{
        this.tokens += amount;
        await this.saveTokenTransaction(this.name, amount, transactionType, fromFighter);
    }

    public async void removeTokens(int amount,TransactionType, fromFighter:string = ""  transactionType):Promise<void>{
        this.tokens -= amount;
        this.tokensSpent += amount;
        if(this.tokens < 0){
            this.tokens = 0;
        }
        await this.saveTokenTransaction(this.name, amount, transactionType, fromFighter);
    }

    canPayAmount(amount):bool{
        return (this.tokens - amount >= 0);
    }

    fightTier():FightTier{
        if(this.statistics == null){
            return FightTier.Bronze;
        }
        if(this.statistics.wins < FightTierWinRequirements.Silver){
            return FightTier.Bronze;
        }
        else if(this.statistics.wins < FightTierWinRequirements.Gold){
            return FightTier.Silver
        }
        else if(this.statistics.wins >= FightTierWinRequirements.Gold){
            return FightTier.Gold;
        }
        else{
            return FightTier.Bronze;
        }
    }

public string    abstract outputStats() {get; set;}
public Array<int>)    abstract restat(statArray {get; set;}
public TransactionType, fromFighter?:string  amount):Promise<void>    abstract public async void saveTokenTransaction(string idFighter,int, transactionType {get; set;}

}