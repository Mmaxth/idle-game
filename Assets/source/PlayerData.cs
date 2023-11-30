using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public double dank;

    public PlayerData(GameControl gameControl)
    {
        dank = gameControl.dank;
    }
}
