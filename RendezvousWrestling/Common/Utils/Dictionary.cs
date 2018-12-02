public class Dictionary<T, U>{
public  T[] = []    private _keys {get; set;}
public  U[] = []    private _values {get; set;}

public  string = "Key is either undefined, null or an empty string."    private undefinedKeyErrorMessage {get; set;}

    private isEitherUndefinedNullOrStringEmpty(object: any): bool {
        return (typeof object) === "undefined" || object === null || object.toString() === "";
    }

    private checkKeyAndPerformAction( { (key: T action, U): void | U | bool }, key: T, value?: U  value?): void | U | bool {

        if (this.isEitherUndefinedNullOrStringEmpty(key)) {
            throw new Error(this.undefinedKeyErrorMessage);
        }

        return action(key, value);
    }


    public add( T key, U  value): void {

         void addAction = ( T key, U  value) => {
            if (this.containsKey(key)) {
                throw new Error("An element with the same key already exists in the dictionary.");
            }

            this._keys.push(key);
            this._values.push(value);
        };

        this.checkKeyAndPerformAction(addAction, key, value);
    }

    public remove(key: T): bool {

         T): bool removeAction = (key => {
            if (!this.containsKey(key)) {
                return false;
            }

            var index = this._keys.indexOf(key);
            this._keys.splice(index, 1);
            this._values.splice(index, 1);

            return true;
        };

        return <bool>(this.checkKeyAndPerformAction(removeAction, key));
    }

    public getValue(key: T): U {

         T): U getValueAction = (key => {
            if (!this.containsKey(key)) {
                return null;
            }

            var index = this._keys.indexOf(key);
            return this._values[index];
        };

        return <U>this.checkKeyAndPerformAction(getValueAction, key);
    }

    public containsKey(key: T): bool {

         T): bool containsKeyAction = (key => {
            return this._keys.indexOf(key) !== -1;
        };

        return <bool>this.checkKeyAndPerformAction(containsKeyAction, key);
    }

    public changeValueForKey( T key, U  newValue): void {

         void changeValueForKeyAction = ( T key, U  newValue) => {
            if (!this.containsKey(key)) {
                throw new Error("In the dictionary there is no element with the given key.");
            }

            var index = this._keys.indexOf(key);
            this._values[index] = newValue;
        };

        this.checkKeyAndPerformAction(changeValueForKeyAction, key, newValue);
    }

    public keys(): T[] {
        return this._keys;
    }

    public values(): U[] {
        return this._values;
    }

    public count(): int {
        return this._values.length;
    }
}