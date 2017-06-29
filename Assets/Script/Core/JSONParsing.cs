using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public abstract class JSONParsing
{
    protected string _JSONFilePath = "";

    public JSONParsing(string JSONpath)
    {
        _JSONFilePath = JSONpath;
    }

    public List<ItemClass> ParseJSON()
    {
        if (_JSONFilePath == null)
        {
            return new List<ItemClass>();
        }

        JSONNode jsonNode = JSON.Parse(_JSONFilePath);

        return JSONObjectToAlfaItems(jsonNode);
    }

    protected virtual List<ItemClass> JSONObjectToAlfaItems(JSONNode jsonNode) { return null; }

}