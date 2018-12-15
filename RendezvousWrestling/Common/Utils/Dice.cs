using System;
using System.Collections.Generic;
using System.Linq;

public class Dice
{
    public int sides { get; set; }
    public List<int> mods { get; set; }
    public List<TempMod> tmpMods { get; set; }
    public List<int> lastRolls { get; set; }

    public class TempMod
    {
        public int Value { get; set; }
        public int Times { get; set; }
    }

    public Dice(int sides)
    {
        this.sides = sides;
        this.mods = new List<int>();
        this.tmpMods = new List<TempMod>();
        this.lastRolls = new List<int>();
    }

    // Private
    // ========================================================================
    private int random()
    {
        return (int)(new Random().NextDouble() * this.sides) + 1;
    }

    private void refreshTmpMods()
    {
        var tmpMods = this.tmpMods;

        foreach (var mod in tmpMods)
        {
            if (--mod.Times == 0)
            {
                tmpMods.Remove(mod);
            }

        }
    }

    // Public
    // ========================================================================
    public int roll(int times)
    {
        var result = this.getResult(times);
        while (this.lastRolls.IndexOf(result) != -1)
        {
            result = this.getResult(times);
        }
        this.lastRolls.Add(result);
        if (this.lastRolls.Count > 3)
        {
            this.lastRolls.RemoveAt(0);
        }
        return result;
    }

    public int getResult(int times = 1)
    {
        var res = new List<int>();

        for (var i = 0; i < times; i++)
        {
            res.Add(
                this.random() +
                this.getModsSum() +
                this.getTmpModsSum()
            );

            this.refreshTmpMods();
        }

        return res.Count == 1 ? res[0] : res.Sum();
    }

    // Mods
    // ------------------------------------------------------------------------
    public Dice addMod(int mod)
    {
        this.mods.Add(mod);
        return this;
    }

    public Dice removeMod(int mod)
    {
        this.mods.RemoveAt(this.mods.IndexOf(mod));
        return this;
    }

    public Dice resetMods()
    {
        this.mods = new List<int>();
        return this;
    }

    public int getModsSum()
    {
        return this.mods.Sum(); ;
    }

    // Tmp Mods
    // ------------------------------------------------------------------------
    public Dice addTmpMod(int val, int times)
    {
        var mod = new TempMod() { Value = val, Times = times };

        this.tmpMods.Add(mod);
        return this;
    }

    public Dice resetTmpMods()
    {
        this.tmpMods.Clear();
        return this;
    }

    public int getTmpModsSum()
    {
        return this.tmpMods.Sum(x => x.Value);
    }

}
