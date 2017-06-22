using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvinsiClick : BaseCaller 
{
    [SerializeField]
    private GameObject _MateriProv;

    protected override void OnClickAction()
    {
        WKSigleton.Instance.PROVINSI = _Provinsi;

        ARModal ar = ARModal.Instance();
        ar.ProvinsiAction(gameObject, _MateriProv);

        base.OnClickAction();
    }
}
