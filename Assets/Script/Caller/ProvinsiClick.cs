using UnityEngine;
using WawasanKebangsaanBase;

public class ProvinsiClick : BaseCaller
{
    [SerializeField]
    private Provinsi _Provinsi;
    [SerializeField]
    private Transform _Object;

    public string GetLambangPath;
    public string[] GetSuku;
	public string[] GetVideoPath;
	float _DoubleTapTime;
    bool _bDoubleTap;

    public bool Selected { set { _bDoubleTap = value; }}

    void Awake()
	{
		_bDoubleTap = false;
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        gameObject.name = StaticFunction.GameObjectFullName(_Provinsi);
    }

    protected override void OnClickAction()
    {
        if (Time.time < _DoubleTapTime + .3f)
        {
			_bDoubleTap = true;
        }
		_DoubleTapTime = Time.time;

        base.OnClickAction();
    }

    protected override void OnUpdate()
    {
        if(_bDoubleTap)
        {
			ARModal ar = ARModal.Instance();
			ar.ProvinsiAction(gameObject, _Object);
			_bDoubleTap = false;
        }
        base.OnUpdate();
    }
}
