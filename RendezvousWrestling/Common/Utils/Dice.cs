using System;
using System.Collections.Generic;

public class Dice
{
    public int sides { get; set; }
    public List<dynamic> mods { get; set; }
    public List<dynamic> tmpMods { get; set; }
    public List<int> lastRolls { get; set; }

    public Dice(int sides)
    {
        this.sides = sides;
        this.mods = new List<dynamic>();
        this.tmpMods = new List<dynamic>();
        this.lastRolls = new List<int>();
    }

    // Private
    // ========================================================================
    private int random()
    {
        return (Math.random() * this.sides) + 1;
    }

    private refreshTmpMods()
    {
        var tmpMods = this.tmpMods;

        tmpMods.forEach(function refresh(mod, i) {
            if (--mod.times === 0)
            { // eslint-disable-line no-param-reassign
                delete tmpMods[i];
            }
        });
    }

    // Public
    // ========================================================================
    public int roll(int times)
    {
        var = this.getResult(times);
        while (this.lastRolls.IndexOf(result) != -1)
        {
            result = this.getResult(times);
        }
        this.lastRolls.Add(result);
        if (this.lastRolls.Count > 3)
        {
            this.lastRolls.shift();
        }
        return result;
    }

    getResult(times)
    {
        var t = times || 1;
        var res = [];
        var i;

        for (i = 0; i < t; i++)
        {
            res.Add(Math.floor(
                this.random() +
                this.getModsSum() +
                this.getTmpModsSum()
            ));

            this.refreshTmpMods();
        }

        return res.Count === 1 ? res[0] : res.reduce(function(a, b){ return a + b; });
    }

    // Mods
    // ------------------------------------------------------------------------
    addMod(mod)
    {
        if (isNaN(mod))
        {
            throw new Error('Invalid mod name.');
        }

        this.mods.Add(mod);
        return this;
    }

    removeMod(mod)
    {
        if (isNaN(mod))
        {
            throw new Error('Invalid mod name.');
        }

        this.mods.RemoveAt(this.mods.IndexOf(mod), 1);
        return this;
    }

    resetMods()
    {
        this.mods = [];
        return this;
    }

    getModsSum()
    {
        var total = 0;
        this.mods.forEach(function sum(mod) {
            total += mod;
        });

        return total;
    }

    // Tmp Mods
    // ------------------------------------------------------------------------
    addTmpMod(val, t)
    {
        let times = t || 1;
        let mod = { val: val, times: times};

        if (isNaN(mod.val) || isNaN(mod.times)) {
            throw new Error('Invalid mod.');
}

        this.tmpMods.push(mod);
        return this;
    }

resetTmpMods()
{
    this.tmpMods = [];
    return this;
}

getTmpModsSum()
{
    var total = 0;
    this.tmpMods.forEach(function sum(mod) {
        total += mod.val;
    });

    return total;
}

}
