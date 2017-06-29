using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WawasanKebangsaanBase;

public class ProvinsiButtonVariable : BaseVariableGatherer 
{
    [SerializeField]
    private Text _Text;

    public Text GetText { get { return _Text; } }

    //private Provinsi _Provinsi;
    //private string _LambangPath;
    //private string[] _Suku;
    //private string[] _VideoPath;

    //public Provinsi GetProvinsi { get { return _Provinsi; } set { _Provinsi = value; } }
    //public string GetLambangPath { get { return _LambangPath; } set { _LambangPath = value; } }
    //public string[] GetSuku { get { return _Suku; } set { _Suku = value; } }
    //public string[] GetVideoPath { get { return _VideoPath; } set { _VideoPath = value; } }
}
