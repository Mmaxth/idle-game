using System.Linq;
using UnityEngine;


public class Database : MonoBehaviour
{
    public ComputerDatabase computer;

    private static Database instance;

    private void Awake()
    {
        if(instance ==  null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Computer GetComputerByID(string ID)
    {
        return instance.computer.allComps.FirstOrDefault(i => i.comID == ID);
    }
}
