using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WawasanKebangsaanBase;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Singleton : MonoBehaviour
{
    [SerializeField]
    private bool _bOnlineMode;
    [SerializeField]
    private GameObjectProvinsiVariable _3DProvinsi;

    public bool OnlineMode { get { return _bOnlineMode; } }
    public GameObjectProvinsiVariable Get3DProvinsi { get { return _3DProvinsi; } }
        
    
    public static Singleton Instance { get; private set; }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            if (Instance == null)
            {
                Instantiate(Instance);
                StaticFunction.WKMessageError("error when trying to create singleton");
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
