using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvinsiClick : BaseCaller 
{
    protected override void OnClickAction()
    {
        WKSigleton.Instance.PROVINSI = _Provinsi;

        ARModal ar = ARModal.Instance();
        ar.ProvinsiAction(gameObject);

        base.OnClickAction();
    }
}
