using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public Text dankText;
    public double dank = 0;
    public Button clicker;

    // Start is called before the first frame updaste
    void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        dank = data.dank;
    }

    // Update is called once per frame
    void Update()
    {
        dank += 1 * Time.deltaTime;
        dankText.text = (int)dank + "";
        SaveSystem.SavePlayer(this);
    }

    public void Clicker(Button clicker)
    {
        dank += 1000;
        dankText.text = (int)dank + "";
    }


    public void GetComputerByID()
    {
    
    }
}
