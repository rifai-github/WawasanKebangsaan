using UnityEngine;
using WawasanKebangsaanBase;

public class ProvinsiClick : BaseCaller
{
    [SerializeField]
    private Provinsi _Provinsi;
    public string GetLambangPath;
    public string[] GetSuku;
    public string[] GetVideoPath;

    public Provinsi GetProvinsi { get { return _Provinsi; } }
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
