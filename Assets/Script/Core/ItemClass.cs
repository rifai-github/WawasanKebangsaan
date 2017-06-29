using System.Collections.Generic;
using WawasanKebangsaanBase;

public abstract class ItemClass
{
    protected TypeJSON _ID = 0;


    public TypeJSON GetItemID()
    {
        return _ID;
    }
}

public class ProvinsiItemClass : ItemClass
{
    private int _id;
    private string _name;
    private string _lambang_path;
    private string[] _suku;
    private string[] _video_path;

    public ProvinsiItemClass(int id, string name, string lambang_path, string[] suku, string[] video_path)
    {
        _id = id;
        _name = name;
        _lambang_path = lambang_path;
        _suku = suku;
        _video_path = video_path;

        _ID = TypeJSON.JSON_PROVINSI;
    }

    public int GetID { get { return _id; } }
    public string GetName { get { return _name; } }
    public string GetLambang { get { return _lambang_path; } }
    public string[] GetSuku { get { return _suku; } }
    public string[] GetVideo { get { return _video_path; } }
}
