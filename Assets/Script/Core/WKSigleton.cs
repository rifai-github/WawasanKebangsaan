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
    [SerializeField]
    private bool _bOnlineMode;
    public bool OnlineMode { get { return _bOnlineMode; } }

    private Provinsi _Provinsi;
    public Provinsi PROVINSI { get { return _Provinsi; } set { _Provinsi = value; } }

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
