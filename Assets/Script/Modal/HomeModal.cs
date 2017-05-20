using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using WawasanKebangsaanBase;

public class HomeModal : BaseModal 
{
    [SerializeField]
    private Button _Start;

    private static HomeModal _Instance;

    public static HomeModal Instance()
    {
        if (_Instance == null)
        {
            _Instance = GameObject.FindObjectOfType<HomeModal>();

            if (_Instance == null)
            {
                WKStaticFunction.WKMessageError("there is no HomeModal in the system");
            }
        }
        return _Instance;
    }
    
    public void OnRegisterModal(UnityAction OnStartAction)
    {
        _Start.onClick.AddListener(OnStartAction);
    }

    public void UnRegisterModal()
    {
        _Start.onClick.RemoveAllListeners();
    }
}
