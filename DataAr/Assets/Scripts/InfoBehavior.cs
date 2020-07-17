using LitJson;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class parseJSON
{
    public string title;
    public string id;
    public ArrayList but_code;
    public ArrayList but_active;
    public ArrayList but_total;
    public ArrayList but_death;
}

public class InfoBehavior : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    [SerializeField] float scale = 130f;

    Vector3 desiredScale = new Vector3(100, 100, 100);
    Vector3 desiredPosition;
    Vector3 defaultPosition;

    private string total;
    private string active;
    private string deaths;
    [SerializeField] string code;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI totalText;
    [SerializeField] TextMeshProUGUI activeText;
    [SerializeField] TextMeshProUGUI deathText;
    [SerializeField] TextMeshProUGUI codeText;

    [SerializeField] Material[] materials;

    parseJSON parsejson;

    private void Awake()
    {
        defaultPosition = gameObject.transform.localPosition;
        desiredPosition = gameObject.transform.localPosition;
    }

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

        parsejson = new parseJSON();

        parsejson.but_code = new ArrayList();
        parsejson.but_active = new ArrayList();
        parsejson.but_total = new ArrayList();
        parsejson.but_death = new ArrayList();

        for (int i = 0; i < jsonvale["statewise"].Count; i++)
        {
            parsejson.but_code.Add(jsonvale["statewise"][i]["statecode"].ToString());
            parsejson.but_active.Add(jsonvale["statewise"][i]["active"].ToString());
            parsejson.but_total.Add(jsonvale["statewise"][i]["confirmed"].ToString());
            parsejson.but_death.Add(jsonvale["statewise"][i]["deaths"].ToString());
        }

        ColorChangeDueToCaese();

    }

    private void ColorChangeDueToCaese()
    {
        for (int i = 0; i < parsejson.but_code.Count; i++)
        {
            if (parsejson.but_code[i].ToString() == code)
            {
                active = parsejson.but_active[i].ToString();

                int cases = int.Parse(active);
                if (cases >= 10000)
                {
                    transform.GetComponent<MeshRenderer>().material = materials[0];
                }
                else if (cases >= 5000 && cases < 10000)
                {
                    transform.GetComponent<MeshRenderer>().material = materials[1];
                }
                else if (cases >= 1000 && cases < 5000)
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
        for (int i = 0; i < parsejson.but_code.Count; i++)
        {
            if (parsejson.but_code[i].ToString() == code)
            {
                active = parsejson.but_active[i].ToString();
                total = parsejson.but_total[i].ToString();
                deaths = parsejson.but_death[i].ToString();
            }

        }
    }

    private void InputText()
    {
        totalText.text = total;
        activeText.text = active;
        deathText.text = deaths;
        codeText.text = code;

        

    }

    public void CloseInfo()
    {
        desiredScale = new Vector3(100, 100, 100);
        desiredPosition = defaultPosition;
    }
}
