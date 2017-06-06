using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WawasanKebangsaanBase;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WKSigleton : MonoBehaviour
{

    private string _PlayerName;
    public string GetPlayerName { get { return _PlayerName; } set { _PlayerName = value; } }

    public static WKSigleton Instance { get; private set; }
        
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            if (Instance == null)
            {
                Instantiate(Instance);
                WKStaticFunction.WKMessageError("error when trying to create singleton");
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
