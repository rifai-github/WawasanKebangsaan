using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class ARRuntime : AppRuntime
{

    [SerializeField]
    private bool _bMacBookMode;
    [SerializeField]
    private GameObject _Camera;
    [SerializeField]
    private GameObject _ARCamera;
    [SerializeField]
    private GameObjectProvinsiVariable _3DProvinsi;

    private void Awake()
    {
        Singleton.Instance.Get3DProvinsi = _3DProvinsi;
        Singleton.Instance.MacBookMode = _bMacBookMode;
    }

    void Start()
    {

#if UNITY_EDITOR

		Singleton.Instance.MacBookMode = _bMacBookMode;

        if (_bMacBookMode)
        {
            Destroy(_ARCamera);
        }
        else
        {
            Destroy(_Camera);
        }
#elif UNITY_ANDROID

        Singleton.Instance.MacBookMode = false;
        Destroy(_Camera);
#endif

        MakeFSM();
    }

    protected override void MakeFSM()
    {
        HomeState homeState = new HomeState();
        homeState.AddTRANSITION(Transition.TRANSITION_TO_ARSTATE, StateID.AR_STATE);

        ARState arState = new ARState();
        arState.AddTRANSITION(Transition.TRANSITION_TO_HOMESTATE, StateID.HOME_STATE);
        arState.AddTRANSITION(Transition.TRANSITION_TO_VIDEOTUTORIALSTATE, StateID.VIDEO_TUTORIAL_STATE);

        VideoTutorialState videoState = new VideoTutorialState();
        videoState.AddTRANSITION(Transition.TRANSITION_TO_ARSTATE, StateID.AR_STATE);
        
        _FSM = new FSMSystem(this);
        _FSM.AddState(homeState);
        _FSM.AddState(arState);
        _FSM.AddState(videoState);

        base.MakeFSM();
    }
}
