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


    public void PlayVideo(VideoType type)
    {
        switch (type)
        {
            case VideoType.VIDEO_TUTORIAL:
                StartCoroutine(PlayVideoCourotine("Video Tutorial.mp4"));
                break;
            default:
                WKStaticFunction.WKMessageError("Wrong Call Method PlayVideo");
                break;
        }
    }

    public void PlayVideo(string videoName)
    {
        StartCoroutine(PlayVideoCourotine(videoName));
    }

    public void PlayVideo(VideoType type, string videoName)
    {

    }

    private IEnumerator PlayVideoCourotine(string videoName)
    {
        string path;

        if (WKSigleton.Instance.OnlineMode)
            path = CONTS_VAR.ONLINE_VIDEO + videoName;
        else
            path = CONTS_VAR.OFFLINE_VIDEO + videoName;

        bool vPlay = Handheld.PlayFullScreenMovie(path, Color.black, FullScreenMovieControlMode.Minimal, FullScreenMovieScalingMode.AspectFit);
        WKStaticFunction.WKMessageLog("Play Video :: " + vPlay);
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        WKStaticFunction.WKMessageLog("Stop Video");
    }
}
