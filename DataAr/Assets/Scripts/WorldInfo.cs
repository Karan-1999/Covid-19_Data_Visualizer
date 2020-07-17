using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using TMPro;
using UnityEngine;


public class ParseJSONWorld
{
    public string confirmed;
    public string recovered;
    public string dead;

    public string newConfirmed;
    public string newRecovered;
    public string newDead;

}

public class WorldInfo : MonoBehaviour
{
    [Header("Old")]
    [SerializeField] TextMeshProUGUI confirmedCountOld;
    [SerializeField] TextMeshProUGUI recoveredCountOld;
    [SerializeField] TextMeshProUGUI deathCountOld;

    [Header("New")]
    [SerializeField] TextMeshProUGUI confirmedCountNew;
    [SerializeField] TextMeshProUGUI recoveredCountNew;
    [SerializeField] TextMeshProUGUI deathCountNew;

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
        ParseJSONWorld parseJSONWorld;

        parseJSONWorld = new ParseJSONWorld();
        parseJSONWorld.confirmed = jsonvale["Global"]["TotalConfirmed"].ToString();
        parseJSONWorld.recovered = jsonvale["Global"]["TotalRecovered"].ToString();
        parseJSONWorld.dead = jsonvale["Global"]["TotalDeaths"].ToString();

        confirmedCountOld.text = parseJSONWorld.confirmed;
        recoveredCountOld.text = parseJSONWorld.recovered;
        deathCountOld.text = parseJSONWorld.dead;


        parseJSONWorld.newConfirmed = jsonvale["Global"]["NewConfirmed"].ToString();
        parseJSONWorld.newRecovered = jsonvale["Global"]["NewRecovered"].ToString();
        parseJSONWorld.newDead = jsonvale["Global"]["NewDeaths"].ToString();

        confirmedCountNew.text = parseJSONWorld.newConfirmed;
        recoveredCountNew.text = parseJSONWorld.newRecovered;
        deathCountNew.text = parseJSONWorld.newDead;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
