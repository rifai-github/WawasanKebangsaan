using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.Events;
using WawasanKebangsaanBase;
using System.IO;

public class JSONGetter : MonoBehaviour
{
    private WWW _URLLink;
    private JSONEvent _JSONEventCaller;
    public CreateName _CreateName;

    void Awake()
    {
        gameObject.AddComponent<CreateName>();
        _CreateName = gameObject.GetComponent<CreateName>();
    }

    public static JSONGetter GetJSON()
    {
        GameObject json = new GameObject("JSONGetter");
        json.AddComponent<JSONGetter>();
        JSONGetter jsonGetter = json.GetComponent<JSONGetter>() as JSONGetter;
        return jsonGetter;
    }

    public void StartParsing(EJSONType jsonType, UnityAction<string> unityAction)
    {
        string jsonName = WKStaticFunction.GetJSONName(jsonType);

        StartCoroutine(StartParsingCourotine(jsonName, jsonType, unityAction));
    }

    private IEnumerator StartParsingCourotine(string jsonName, EJSONType jsonType, UnityAction<string> unityAction)
    {
        if (!File.Exists(CONST_VAR.JSON_PATH + jsonName)) //json notFound
        {
            JSONCreated(jsonName);
        }
        else
        {
            _URLLink = new WWW(CONST_VAR.JSON_URL + jsonName);
            yield return _URLLink;

            JSONNode node = JSON.Parse(_URLLink.text);

            Debug.Log(node);
            _JSONEventCaller = new JSONEvent();
            _JSONEventCaller.AddListener(unityAction);
        }
    }


    private void JSONCreated(string jsonName)
    {
        if (!Directory.Exists(CONST_VAR.JSON_PATH))
        {
            Directory.CreateDirectory(CONST_VAR.JSON_PATH);
        }

        
        JSONNode jsonString = JsonUtility.ToJson(_CreateName);
        File.WriteAllText(CONST_VAR.JSON_PATH + jsonName, jsonString);
    }
}