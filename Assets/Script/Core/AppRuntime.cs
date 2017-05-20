using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class AppRuntime : MonoBehaviour
{
    public GameObject _MatineeGameObject;

    protected FSMSystem _FSM;

    // Update is called once per frame  
    void Update()
    {
        if (_FSM != null)
        {
            _FSM.GetCurrentState.Update();
        }
    }

    // set the transition so the things in the app gonna call this to transition from one state
    //To another
    public void SetTransition(TRANSITION transition)
    {
        if (_FSM != null)
            _FSM.PerformTransition(transition);
        else
        {
            WKStaticFunction.WKMessageError("there is no fsm system in the app");
            MakeFSM();
        }
    }

    //make the fsm onto the system
    protected virtual void MakeFSM()
    {

    }
}
