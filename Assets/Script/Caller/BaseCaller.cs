using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCaller : MonoBehaviour 
{
    void OnMouseDown()
    {
        OnClickAction();
    }
    
    protected virtual void OnClickAction()
    {

    }
}
