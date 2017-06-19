using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class ARState : FSMState
{
    public ARState()
    {
        stateID = StateID.AR_STATE;
    }

    public override void OnEnter()
    {
        WKStaticFunction.WKMessageLog("Enter ARState");
        ARModal arModal = ARModal.Instance();
        arModal.OpenModal();

        base.OnEnter();
    }

    public void On3DAction()
    {
        WKStaticFunction.WKMessageLog("Close3D");        
    }

    public void PlayVideoAction()
    {
        WKStaticFunction.WKMessageLog("Play Video");

        AppRuntime appRuntime = _FSMCaller as AppRuntime;
        appRuntime.SetTransition(Transition.TRANSITION_TO_VIDEOTUTORIALSTATE);
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
        WKStaticFunction.WKMessageLog("Leave ARState");

        ARModal arModal = ARModal.Instance();
        arModal.UnRegisterModal();
        arModal.CloseModal();

        base.OnLeave();
    }
}
