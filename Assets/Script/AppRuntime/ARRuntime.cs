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
        homeState.AddTRANSITION(TRANSITION.TRANSITION_TO_ARSTATE, STATE_ID.AR_STATE);

        ARState arState = new ARState();
        arState.AddTRANSITION(TRANSITION.TRANSITION_TO_HOMESTATE, STATE_ID.HOME_STATE);
        arState.AddTRANSITION(TRANSITION.TRANSITION_TO_VIDEOTUTORIALSTATE, STATE_ID.VIDEO_TUTORIAL_STATE);

        VideoTutorialState videoState = new VideoTutorialState();
        videoState.AddTRANSITION(TRANSITION.TRANSITION_TO_ARSTATE, STATE_ID.AR_STATE);

        _FSM = new FSMSystem(this);
        _FSM.AddState(homeState);
        _FSM.AddState(arState);
        _FSM.AddState(videoState);

        base.MakeFSM();
    }
}
