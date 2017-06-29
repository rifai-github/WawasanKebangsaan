using WawasanKebangsaanBase;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class GetPrivinsiItemJSON : JSONParsing
{
    public GetPrivinsiItemJSON(string JSONPath) : base(JSONPath) { }

    protected override List<ItemClass> JSONObjectToAlfaItems(JSONNode jsonNode)
    {
        List<ItemClass> itemClass = new List<ItemClass>();

        for (int i = 0; i < jsonNode.Count; i++)
        {
            JSONNode node = jsonNode[i];

            int id = node["id_provinsi"];
            string name = node["nama_provinsi"];
            string lambang = node["lambang"];

            string[] suku = new string[node["suku"].Count];
            for (int j = 0; j < node["suku"].Count; j++)
            {
                suku[j] = node["suku"][j];
            }

            string[] video = new string[node["video"].Count];
            for (int j = 0; j < node["video"].Count; j++)
            {
                video[j] = node["video"][j];
            }

            ItemClass item = new ProvinsiItemClass(id, name, lambang, suku, video);
            itemClass.Add(item);
        }
        return itemClass;
    }
}
