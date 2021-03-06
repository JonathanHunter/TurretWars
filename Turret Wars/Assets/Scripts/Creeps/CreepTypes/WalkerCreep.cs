﻿using UnityEngine;
using System.Collections;
using System;

public class WalkerCreep : BaseCreep
{

    #region IPoolable overrides
    /// <summary>
    /// Determines what prefab will be associated with this script.
    /// If testing code without model, return 'BaseCreep'
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "WalkerCreep";
    }

    /// <summary>
    /// Adjust variables accordingly given the level of the creep. Called by Creep Factory.
    /// </summary>
    /// <param name="level">The level for the creep to be associated with</param>
    public override void SetLevel(int level)
    {
        this.maxHp = 50.0f * (level / 4.0f);

        this.Hp = this.maxHp;
        this.Speed = 0.2f * (level);
        this.Value = 10 * level;


        Color[] colors = { Color.green, Color.yellow, Color.red };
        Color[] basecolors = { Color.white, Color.black };
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.SetColor("_GridColour", colors[level - 1]);
            r.material.SetColor("_BaseColour", basecolors[(int)Math.Ceiling(level / 3.0)]);
        }
    }
    #endregion
}
