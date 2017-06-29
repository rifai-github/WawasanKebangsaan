using WawasanKebangsaanBase;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class JSONGetter : MonoBehaviour
{
    private WWW _URLLink;
    private TypeJSON _JSONType;
    private JSONEvent _JSONEventCaller;

    public static JSONGetter GetJSON()
    {
        GameObject game = new GameObject("JSONGetter");
        game.AddComponent<JSONGetter>();

        JSONGetter getter = game.GetComponent<JSONGetter>() as JSONGetter;

        return getter;
    }


    public void StartParsing(TypeJSON jsonType, UnityAction<string> unityAction)
    {
        string jsonName = "";
        switch (jsonType)
        {
            case TypeJSON.JSON_PROVINSI:
                jsonName = "Provinsi";
                break;

            default:
                StaticFunction.WKMessageError("Wrong Call Method GetJSON");
                break;
        }

        string path = StaticFunction.JSONURL(jsonName);
        StaticFunction.WKMessageLog(path);
        _URLLink = new WWW(path);

        _JSONEventCaller = new JSONEvent();
        _JSONEventCaller.AddListener(unityAction);
    }
    
    void FixedUpdate()
    {
        if (_URLLink != null)
        {
            if (_URLLink.isDone)
            {
                if (_URLLink.error != null)
                {
                    _JSONEventCaller.Invoke(null);
                    StaticFunction.WKMessageError(_URLLink.error);
                    Destroy(this.gameObject);
                }
                else
                {
                    _JSONEventCaller.Invoke(_URLLink.text);
                    Destroy(this.gameObject);
                }
            }
        }
    }

    void OnDestroy()
    {
        _JSONEventCaller.RemoveAllListeners();
        _JSONEventCaller = null;
    }
}
