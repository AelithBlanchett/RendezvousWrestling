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
        mods = new List<int>();
        tmpMods = new List<TempMod>();
        lastRolls = new List<int>();
    }

    // Private
    // ========================================================================
    private int random()
    {
        return (int)(new Random().NextDouble() * sides) + 1;
    }

    private void refreshTmpMods()
    {
        var tmpMods = this.tmpMods;

        foreach (var mod in tmpMods.ToList())
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
        var result = getResult(times);
        while (lastRolls.IndexOf(result) != -1)
        {
            result = getResult(times);
        }
        lastRolls.Add(result);
        if (lastRolls.Count > 3)
        {
            lastRolls.RemoveAt(0);
        }
        return result;
    }

    public int getResult(int times = 1)
    {
        var res = new List<int>();

        for (var i = 0; i < times; i++)
        {
            res.Add(
                random() +
                getModsSum() +
                getTmpModsSum()
            );

            refreshTmpMods();
        }

        return res.Count == 1 ? res[0] : res.Sum();
    }

    // Mods
    // ------------------------------------------------------------------------
    public Dice addMod(int mod)
    {
        mods.Add(mod);
        return this;
    }

    public Dice removeMod(int mod)
    {
        mods.RemoveAt(mods.IndexOf(mod));
        return this;
    }

    public Dice resetMods()
    {
        mods = new List<int>();
        return this;
    }

    public int getModsSum()
    {
        return mods.Sum(); ;
    }

    // Tmp Mods
    // ------------------------------------------------------------------------
    public Dice addTmpMod(int val, int times)
    {
        var mod = new TempMod() { Value = val, Times = times };

        tmpMods.Add(mod);
        return this;
    }

    public Dice resetTmpMods()
    {
        tmpMods.Clear();
        return this;
    }

    public int getTmpModsSum()
    {
        return tmpMods.Sum(x => x.Value);
    }

}
