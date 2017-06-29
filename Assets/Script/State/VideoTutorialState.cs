using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class VideoTutorialState : FSMState 
{
    public VideoTutorialState()
    {
        stateID = StateID.VIDEO_TUTORIAL_STATE;
    }

    public override void OnEnter()
    {
        StaticFunction.WKMessageLog("Enter ARState");
        VideoTutorialModal videoModal = VideoTutorialModal.Instance();
        videoModal.OpenModal();

        base.OnEnter();
    }

    public override void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            AppRuntime appRuntime = _FSMCaller as AppRuntime;
            appRuntime.SetTransition(Transition.TRANSITION_TO_HOMESTATE);
        }
        base.Update();
    }

    public override void OnLeave()
    {
        StaticFunction.WKMessageLog("Leave ARState");

        VideoTutorialModal videoModal = VideoTutorialModal.Instance();
        videoModal.CloseModal();

        base.OnLeave();
    }
}
