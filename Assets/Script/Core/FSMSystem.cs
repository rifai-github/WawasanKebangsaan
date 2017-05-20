using UnityEngine;
using System;
using WawasanKebangsaanBase;
using System.Collections;
using System.Collections.Generic;


public abstract class FSMState
{
    protected MonoBehaviour _FSMCaller;
    protected Dictionary<TRANSITION, STATE_ID> _Map = new Dictionary<TRANSITION, STATE_ID>();
    protected STATE_ID _STATE_ID;
    public STATE_ID _PreviousState;
    public STATE_ID ID { get { return _STATE_ID; } }
    public STATE_ID PreviousSTATE_ID { get { return _PreviousState; } }
    
    public void AddTRANSITION(TRANSITION TRANSITION, STATE_ID STATE_ID)
    {
        if (TRANSITION == TRANSITION.NullTransition)
        {
            WKStaticFunction.WKMessageError("The Transition is error");
            return;
        }

        if (STATE_ID == STATE_ID.NullStateID)
        {
            WKStaticFunction.WKMessageError("The State is error");
            return;
        }

        if (_Map.ContainsKey(TRANSITION))
        {
            WKStaticFunction.WKMessageError("The FSM already have this transition for state");
            return;
        }
        _Map.Add(TRANSITION, STATE_ID);
    }

    public void DeleteTransition(TRANSITION transition)
    {
        if (transition == TRANSITION.NullTransition)
        {
            WKStaticFunction.WKMessageError("The Transition is null, or not fully initialized");
            return;
        }

        if (_Map.ContainsKey(transition))
        {
            _Map.Remove(transition);
            return;
        }

        WKStaticFunction.WKMessageLog("The Transition is not on the transition _Map");
    }
    
    public STATE_ID GetState(TRANSITION transition)
    {
        if (_Map.ContainsKey(transition))
        {
            return _Map[transition];
        }

        return STATE_ID.NullStateID;
    }

    public virtual void OnEnter() { }

    public virtual void OnLeave() { }

    public virtual void Update() { }

    public void SetFSMCaller(MonoBehaviour inMonoScript)
    {

        _FSMCaller = inMonoScript;
    }
}

public class FSMSystem
{
    private List<FSMState> _States;

    private STATE_ID _CurrentStateID;
    public STATE_ID GetCurrentStateID { get { return _CurrentStateID; } }
    private FSMState _CurrentState;
    public FSMState GetCurrentState { get { return _CurrentState; } }
    private MonoBehaviour _Caller;
    public MonoBehaviour GetCaller { get { return _Caller; } }

    public FSMSystem(MonoBehaviour fsmCaller)
    {
        _States = new List<FSMState>();
        _Caller = fsmCaller;
    }
    public void AddState(FSMState stateToAdd)
    {
        if (stateToAdd == null)
        {
            WKStaticFunction.WKMessageError("there is no state to add");
        }

        stateToAdd.SetFSMCaller(_Caller);

        if (_States.Count == 0)
        {
            _States.Add(stateToAdd);
            _CurrentState = stateToAdd;
            _CurrentStateID = stateToAdd.ID;
            _CurrentState.OnEnter();
            return;
        }

        foreach (FSMState state in _States)
        {
            if (state.ID == stateToAdd.ID)
            {
                WKStaticFunction.WKMessageError("state is already there");
                return;
            }
        }
        _States.Add(stateToAdd);
    }

    public void DeleteState(STATE_ID stateID)
    {
        if (stateID == STATE_ID.NullStateID)
        {
            WKStaticFunction.WKMessageError("the state id is null");
            return;
        }

        foreach (FSMState state in _States)
        {
            if (state.ID == stateID)
            {
                _States.Remove(state);
                return;
            }
        }
        WKStaticFunction.WKMessageError("the state is not found in the fsm map");
    }

    public void PerformTransition(TRANSITION transition)
    {
        if (transition == TRANSITION.NullTransition)
        {
            WKStaticFunction.WKMessageError("the transition is null");
            return;
        }

        STATE_ID stateID = _CurrentState.GetState(transition);
        if (stateID == STATE_ID.NullStateID)
        {
            WKStaticFunction.WKMessageError("the state of transition is null ::" + _CurrentState.ID.ToString() + transition.ToString());
            return;
        }

        _CurrentStateID = stateID;
        STATE_ID previousState = _CurrentState.ID;
        foreach (FSMState state in _States)
        {
            if (state.ID == _CurrentStateID)
            {
                _CurrentState.OnLeave();
                _CurrentState = state;
                _CurrentState._PreviousState = previousState;
                _CurrentState.OnEnter();
                break;
            }
        }
    }
}