using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Database/Computer Database")]
public class ComputerDatabase : ScriptableObject
{
    public List<Computer> allComps;
}
