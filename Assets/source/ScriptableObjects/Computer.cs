using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "ScriptableObjects/Computer")]
public class Computer : ScriptableObject
{
    public string comID;
    public string prefabName;
    public string description;
    public double electricityConsumed;
    public int MinHeat;
    public int MaxHeat;
    public double heat;
    public double cost;
    public double dankpersec;
    public Sprite image;
    public Transform xposition;
    public Transform yposition;
}
