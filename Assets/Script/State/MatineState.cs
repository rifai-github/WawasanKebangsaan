using System.Collections.Generic;
using System.Collections;
using WawasanKebangsaanBase;
using UnityEngine;


public class MatineeState : FSMState
{

    public MatineeState()
    {
        _STATE_ID = STATE_ID.MATINEE_STATE;
    }

    public override void OnEnter()
    {
        WKStaticFunction.WKMessageLog("enter matinee state");
        base.OnEnter();

        SelectMatineeType();
    }

    private void MatineeEventStop(EMatineeType matineeType)
    {
        ARRuntime appRuntime = _FSMCaller as ARRuntime;
        BaseMatineeEvent matineeEvent = null;

        switch (matineeType)
        {
            case EMatineeType.MATINEE_ENTRANCE:
                matineeEvent = appRuntime._MatineeGameObject.GetComponent<Matinee_Entrance>();
                break;
        }

        matineeEvent.Stop();
        appRuntime.SetTransition(TRANSITION.TRANSITION_TO_ARSTATE);
    }

    private void SelectMatineeType()
    {
        EMatineeType matineeType = WKSigleton.Instance.MatineeType;
        ARRuntime appRuntime = _FSMCaller as ARRuntime;

        BaseMatineeEvent matineeEvent = null;

        switch (matineeType)
        {
            case EMatineeType.MATINEE_ENTRANCE:
                matineeEvent = appRuntime._MatineeGameObject.GetComponent<Matinee_Entrance>();
                break;
        }
        matineeEvent.Play();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnLeave()
    {
        WKStaticFunction.WKMessageLog("Leave Matine");
        
        base.OnLeave();
    }

}
