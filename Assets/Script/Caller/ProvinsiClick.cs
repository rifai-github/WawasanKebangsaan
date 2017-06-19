using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class ProvinsiClick : BaseCaller 
{
    [SerializeField]
    private Provinsi _Provinsi;

    protected override void OnClickAction()
    {
        Debug.Log(_Provinsi);

        ARModal ar = ARModal.Instance();
        ar.ProvinsiAction(gameObject, gameObject.transform);

        base.OnClickAction();
    }
}
