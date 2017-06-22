using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class BaseCaller : MonoBehaviour 
{
    [SerializeField]
    protected Provinsi _Provinsi;

    void OnMouseDown()
    {
        OnClickAction();
    }
    
    protected virtual void OnClickAction()
    {

    }
}
