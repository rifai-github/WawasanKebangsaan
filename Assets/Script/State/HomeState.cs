using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class HomeState : FSMState
{

    public HomeState()
    {
        stateID = StateID.HOME_STATE;
    }

    public override void OnEnter()
    {
        StaticFunction.WKMessageLog("Enter ARState");
        HomeModal homeModal = HomeModal.Instance();
        homeModal.OpenModal();
        homeModal.OnRegisterModal(StartAction);

        base.OnEnter();
    }

    private void StartAction()
    {
        StaticFunction.WKMessageLog("Start on Click");

        AppRuntime appRuntime = _FSMCaller as AppRuntime;
        appRuntime.SetTransition(Transition.TRANSITION_TO_ARSTATE);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnLeave()
    {
        StaticFunction.WKMessageLog("Leave ARState");

        HomeModal homeModal = HomeModal.Instance();
        homeModal.UnRegisterModal();
        homeModal.CloseModal();

        base.OnLeave();
    }
}
