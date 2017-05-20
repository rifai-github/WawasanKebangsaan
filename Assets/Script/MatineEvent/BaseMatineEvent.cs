using System;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public abstract class BaseMatineeEvent : MonoBehaviour
{
    [SerializeField]
    protected EMatineeType _MatineeID;


    public EMatineeType GetMatineeType()
    {
        return _MatineeID;
    }

    public virtual void Play()
    {
        WKStaticFunction.WKMessageLog("play the matinee");
    }

    public virtual void Stop()
    {
        WKStaticFunction.WKMessageLog("stop the matinee");
    }

}