using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

using System.Net;
using System;
using System.IO;
using UnityEngine.Networking;

public class WebAPITesting : MonoBehaviour
{

    //Test data based on:  https://www.red-gate.com/simple-talk/dotnet/c-programming/calling-restful-apis-unity3d/
    [SerializeField]
    public class Weather
    {
        public int id;
        public string main;
    }
    [SerializeField]
    public class WeatherInfo
    {
        public int id;
        public string name;
        public List<Weather> weather;
    }

    private const string API_KEY = "e683b50e91c6b7372e75995b3058f380";
    public string CityId;
    public GameObject SnowSystem;
    private const float API_CHECK_MAXTIME = 10 * 60.0f; //10 minutes
    private float apiCheckCountdown = API_CHECK_MAXTIME;

    //void Start()
    //{
    //    CheckSnowStatus();
    //}
    //void Update()
    //{
    //    apiCheckCountdown -= Time.deltaTime;
    //    if (apiCheckCountdown <= 0)
    //    {
    //        CheckSnowStatus();
    //        apiCheckCountdown = API_CHECK_MAXTIME;
    //    }
    //}

    void Start()
    {
        StartCoroutine(GetWeather(CheckSnowStatus));
    }
    void Update()
    {
        apiCheckCountdown -= Time.deltaTime;
        if (apiCheckCountdown <= 0)
        {
            apiCheckCountdown = API_CHECK_MAXTIME;
            StartCoroutine(GetWeather(CheckSnowStatus));
        }
    }
    //public async void CheckSnowStatus()
    //{
    //    bool snowing = (await GetWeather()).weather[0].main.Equals("Snow");
    //    if (snowing)
    //        SnowSystem.SetActive(true);
    //    else
    //        SnowSystem.SetActive(false);
    //}
    public void CheckSnowStatus(WeatherInfo weatherObj)
    {

        //bool snowing = weatherObj.weather[0].main.Equals("Snow");

        Debug.Log(weatherObj.id);
       //if (snowing)
       //    SnowSystem.SetActive(true);
       //else
       //    SnowSystem.SetActive(false);
    }
    ////private async Task<WeatherInfo> GetWeather()
    //{
    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}", CityId, API_KEY));
    //    HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());
    //    StreamReader reader = new StreamReader(response.GetResponseStream());
    //    string jsonResponse = reader.ReadToEnd();
    //    WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
    //    Debug.Log(info.weather[0].main.ToString());
    //    return info;
    //}
    //
    //private WeatherInfo GetWeather()
    //{
    //    HttpWebRequest request =
    //    (HttpWebRequest)WebRequest.Create(String.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}",
    //     CityId, API_KEY));
    //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    //    StreamReader reader = new StreamReader(response.GetResponseStream());
    //    string jsonResponse = reader.ReadToEnd();
    //    WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
    //    return info;
    //}


    IEnumerator GetWeather(Action<WeatherInfo> onSuccess)
    {
        using (UnityWebRequest req = UnityWebRequest.Get(String.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}", CityId, API_KEY)))
        {
            yield return req.Send();
            while (!req.isDone)
                yield return null;
            byte[] result = req.downloadHandler.data;
            Debug.Log(result.ToString());
            string weatherJSON = System.Text.Encoding.Default.GetString(result);
            WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(weatherJSON);
                
            Debug.Log(info.id);
            Debug.Log(weatherJSON);
            onSuccess(info);
        }
    }
}
