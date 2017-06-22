using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideoAdat : BaseCaller
{
    protected override void OnClickAction()
    {
        _Provinsi = WKSigleton.Instance.PROVINSI;

        ARModal ar = ARModal.Instance();
        ar.PlayVideo(_Provinsi);

        base.OnClickAction();
    }
}