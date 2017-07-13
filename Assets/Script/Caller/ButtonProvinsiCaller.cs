using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonProvinsiCaller : BaseCaller
{
    private int idProvinsi;
    public int setIDProvinsi { set { idProvinsi = value; } }
    
    public void onPress()
    {
        StaticFunction.Get3DProvinsi(idProvinsi).GetComponent<ProvinsiClick>().Selected = true;
    }
}
