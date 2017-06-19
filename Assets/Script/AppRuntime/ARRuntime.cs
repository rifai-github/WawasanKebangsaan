using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class ARRuntime : AppRuntime
{
    void Start()
    {
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
