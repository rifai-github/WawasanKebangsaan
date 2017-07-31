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
        StaticFunction.WKMessageLog("Enter ARState");
        ARModal ar = ARModal.Instance();
        ar.OpenModal();

        base.OnEnter();
    }

    public override void Update()
    {
        ARModal ar = ARModal.Instance();
        if (!ar.ShowProvinsi)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                AppRuntime appRuntime = _FSMCaller as AppRuntime;
				appRuntime.SetTransition(Transition.TRANSITION_TO_HOMESTATE);
				return;
            }
        }
        
        base.Update();
    }

    public override void OnLeave()
    {
        StaticFunction.WKMessageLog("Leave ARState");

        ARModal ar = ARModal.Instance();
        ar.CloseModal();

        base.OnLeave();
    }
}
