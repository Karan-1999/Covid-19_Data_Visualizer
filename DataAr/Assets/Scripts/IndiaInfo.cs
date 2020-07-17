using System.Collections;
using System.Collections.Generic;
using LitJson;
using TMPro;
using UnityEngine;

public class IndiaJSON
{
    public string in_active;
    public string in_total;
    public string in_death;
}


public class IndiaInfo : MonoBehaviour
{
    IndiaJSON indiaJSON;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI totalText;
    [SerializeField] TextMeshProUGUI activeText;
    [SerializeField] TextMeshProUGUI deathText;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        string url = "https://api.covid19india.org/data.json";
        WWW www = new WWW(url);
        yield return www;

        if (www.error == null)
        {
            // print(www.text);
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

        indiaJSON = new IndiaJSON();
        indiaJSON.in_total = jsonvale["statewise"][0]["confirmed"].ToString();
        indiaJSON.in_active = jsonvale["statewise"][0]["active"].ToString();
        indiaJSON.in_death = jsonvale["statewise"][0]["deaths"].ToString();

        totalText.text = indiaJSON.in_total;
        activeText.text = indiaJSON.in_active;
        deathText.text = indiaJSON.in_death;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
