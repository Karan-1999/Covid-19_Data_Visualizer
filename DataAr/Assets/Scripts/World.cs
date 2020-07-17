using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using TMPro;
using UnityEngine;

public class ParseJSONWorld_C
{
    public string confirmed;
    public string recovered;
    public string dead;

}

public class World : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI confirmedCountOld;
    [SerializeField] TextMeshProUGUI recoveredCountOld;
    [SerializeField] TextMeshProUGUI deathCountOld;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        string url = "https://api.covid19api.com/summary";
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            Processjson(www.text);
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }

    private void Processjson(string jsonString)
    {
        JsonData jsonvale = JsonMapper.ToObject(jsonString);
        ParseJSONWorld_C parseJSONWorld_C;

        parseJSONWorld_C = new ParseJSONWorld_C();
        parseJSONWorld_C.confirmed = jsonvale["Global"]["TotalConfirmed"].ToString();
        parseJSONWorld_C.recovered = jsonvale["Global"]["TotalRecovered"].ToString();
        parseJSONWorld_C.dead = jsonvale["Global"]["TotalDeaths"].ToString();

        confirmedCountOld.text = parseJSONWorld_C.confirmed;
        recoveredCountOld.text = parseJSONWorld_C.recovered;
        deathCountOld.text = parseJSONWorld_C.dead;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
