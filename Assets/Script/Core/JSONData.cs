using UnityEngine;
using SimpleJSON;
using WawasanKebangsaanBase;

public class PlayerName
{
    public static void Save(JSONNode jsonNode, string name)
    {
        jsonNode["name"] = name;
    }

    public static string Load(JSONNode jsonNode)
    {
        string _PlayerName = jsonNode["name"];
        return _PlayerName;
    }
}
