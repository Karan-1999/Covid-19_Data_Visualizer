using LitJson;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System;

public class ParseJSON_Other
{
    public ArrayList but_code;
    public ArrayList but_recovered;
    public ArrayList but_confirmed;
    public ArrayList but_death;
}

public class InfoBehaviourOther : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    [SerializeField] float scale = 130f;

    Vector3 desiredScale = new Vector3(100, 100, 100);
    Vector3 desiredPosition;
    Vector3 defaultPosition;

    private string confirmed;
    private string recovered;
    private string deaths;
    [SerializeField] string code;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI confirmedText;
    [SerializeField] TextMeshProUGUI recoveredText;
    [SerializeField] TextMeshProUGUI deathText;
    [SerializeField] TextMeshProUGUI codeText;

    [SerializeField] Material[] materials;

    ParseJSON_Other parseJSON_Other;

    private void Awake()
    {
        defaultPosition = gameObject.transform.localPosition;
        desiredPosition = gameObject.transform.localPosition;
    }

    IEnumerator Start()
    {
        string url = "https://api.covid19api.com/summary";
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

        parseJSON_Other = new ParseJSON_Other();

        parseJSON_Other.but_code = new ArrayList();
        parseJSON_Other.but_recovered = new ArrayList();
        parseJSON_Other.but_confirmed = new ArrayList();
        parseJSON_Other.but_death = new ArrayList();

        for (int i = 0; i < jsonvale["Countries"].Count; i++)
        {
            parseJSON_Other.but_code.Add(jsonvale["Countries"][i]["CountryCode"].ToString());
            parseJSON_Other.but_confirmed.Add(jsonvale["Countries"][i]["TotalConfirmed"].ToString());
            parseJSON_Other.but_recovered.Add(jsonvale["Countries"][i]["TotalRecovered"].ToString());
            parseJSON_Other.but_death.Add(jsonvale["Countries"][i]["TotalDeaths"].ToString());
        }

        ColorChangeDueToCaese();
    }

    private void ColorChangeDueToCaese()
    {
        for (int i = 0; i < parseJSON_Other.but_code.Count; i++)
        {
            if (parseJSON_Other.but_code[i].ToString() == code)
            {
                confirmed = parseJSON_Other.but_confirmed[i].ToString();

                int cases = int.Parse(confirmed);
                if (cases >= 1000000)
                {
                    transform.GetComponent<MeshRenderer>().material = materials[0];
                }
                else if (cases >= 100000 && cases < 1000000)
                {
                    transform.GetComponent<MeshRenderer>().material = materials[1];
                }
                else if (cases >= 10000 && cases < 100000)
                {
                    transform.GetComponent<MeshRenderer>().material = materials[2];
                }
                else
                {
                    transform.GetComponent<MeshRenderer>().material = materials[3];
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, desiredScale, Time.deltaTime * speed);
        gameObject.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, desiredPosition, Time.deltaTime * speed);
    }

    public void OpenInfo()
    {
        FetchingInformationFromArray();

        InputText();
        desiredPosition = new Vector3(gameObject.transform.localPosition.x, 2, gameObject.transform.localPosition.z);
        desiredScale = new Vector3(scale, scale, scale);
    }

    private void FetchingInformationFromArray()
    {
        for (int i = 0; i < parseJSON_Other.but_code.Count; i++)
        {
            if (parseJSON_Other.but_code[i].ToString() == code)
            {
                recovered = parseJSON_Other.but_recovered[i].ToString();
                confirmed = parseJSON_Other.but_confirmed[i].ToString();
                deaths = parseJSON_Other.but_death[i].ToString();
                break;
            }
            else if (parseJSON_Other.but_code[i].ToString() != code)
            {
                recovered = "NA";
                confirmed = "NA";
                deaths = "NA";
            }
        }
    }

    private void InputText()
    {
        confirmedText.text = confirmed;
        recoveredText.text = recovered;
        deathText.text = deaths;
        codeText.text = code;
    }

    public void CloseInfo()
    {
        desiredScale = new Vector3(100, 100, 100);
        desiredPosition = defaultPosition;
    }

}
