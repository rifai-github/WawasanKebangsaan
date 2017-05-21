using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class HomeState : FSMState
{

    public HomeState()
    {
        _STATE_ID = STATE_ID.HOME_STATE;
    }

    public override void OnEnter()
    {
        WKStaticFunction.WKMessageLog("Enter HomeState");
        HomeModal homeModal = HomeModal.Instance();
        homeModal.OpenModal();
        homeModal.OnRegisterModal(StartAction);

        base.OnEnter();
    }

    private void StartAction()
    {
        WKStaticFunction.WKMessageLog("Start on Click");

        AppRuntime appRuntime = _FSMCaller as AppRuntime;
        appRuntime.SetTransition(TRANSITION.TRANSITION_TO_ARSTATE);
    }

    public override void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        base.Update();
    }

    public override void OnLeave()
    {
        WKStaticFunction.WKMessageLog("Leave ARState");

        HomeModal homeModal = HomeModal.Instance();
        homeModal.UnRegisterModal();
        homeModal.CloseModal();

        base.OnLeave();
    }
}
