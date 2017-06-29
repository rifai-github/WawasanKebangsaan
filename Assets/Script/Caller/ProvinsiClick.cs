using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class ProvinsiClick : BaseCaller
{
    [SerializeField]
    private Provinsi _Provinsi;
    private string _LambangPath;
    private string[] _Suku;
    private string[] _VideoPath;

    public Provinsi GetProvinsi { get { return _Provinsi; } }
    public string GetLambangPath;// { get { return _LambangPath; } set { _LambangPath = value; } }
    public string[] GetSuku { get { return _Suku; } set { _Suku = value; } }
    public string[] GetVideoPath { get { return _VideoPath; } set { _VideoPath = value; } }

    void Awake()
    {
        gameObject.name = StaticFunction.GameObjectFullName(_Provinsi);
    }

    protected override void OnClickAction()
    {
        ARModal ar = ARModal.Instance();
        ar.ProvinsiAction(gameObject, _Provinsi);

        base.OnClickAction();
    }
}
