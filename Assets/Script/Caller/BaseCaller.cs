using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class BaseCaller : MonoBehaviour 
{    
    void OnMouseDown()
    {
        OnClickAction();
    }
    
    protected virtual void OnClickAction()
    {

    }
    void Update()
    {
        OnUpdate();
    }
    protected virtual void OnUpdate()
    {
        
    }
}
