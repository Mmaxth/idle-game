using System;
using System.Collections;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.Networking;

public class TimeAPI : MonoBehaviour
{
#region Singleton Class: TimeAPI
    public static TimeAPI Instance;

    void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else
        {
            Destroy(this.gameObject);
        }
    }
#endregion


    struct TimeInfo
    {
        public string datetime;
    }

    const string API_URL = "http://worldtimeapi.org/api/ip";

    [HideInInspector]public static bool IstimeLoaded = false;

    private DateTime _currentDateTime = DateTime.Now;

    void Start()
    {
        StartCoroutine(GetRealTimeFromAPI());
    }


    public DateTime GetCurrentTime()
    {
        return _currentDateTime.AddSeconds(Time.realtimeSinceStartup);
    }

    IEnumerator GetRealTimeFromAPI() 
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(API_URL);
        Debug.Log("Getting Time from API");

        yield return webRequest.SendWebRequest();

        if(webRequest.result == UnityWebRequest.Result.Success)
        {
            // getting time
            TimeInfo timeInfo = JsonUtility.FromJson<TimeInfo>(webRequest.downloadHandler.text);
            _currentDateTime = ParseDateTime(timeInfo.datetime);
            IstimeLoaded = true;

			Debug.Log ( "API request success." );
        }
        else
        {
            Debug.Log("Error: " + webRequest.error);
        }
    }

    DateTime ParseDateTime(string datetime)
{
        //match 0000-00-00
		string date = Regex.Match(datetime, @"^\d{4}-\d{2}-\d{2}").Value;

		//match 00:00:00
		string time = Regex.Match(datetime, @"\d{2}:\d{2}").Value;

		return DateTime.Parse(string.Format("{0} {1}", date, time));
}

}