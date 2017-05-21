using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;

namespace WawasanKebangsaanBase
{
    public enum STATE_ID 
    {
        NullStateID = 0,
        HOME_STATE = 1,
        AR_STATE = 2,
        VIDEO_TUTORIAL_STATE = 3
    }

    public enum TRANSITION
    {
        NullTransition = 0,
        TRANSITION_TO_ARSTATE = 1,
        TRANSITION_TO_HOMESTATE = 2,
        TRANSITION_TO_VIDEOTUTORIALSTATE = 3
    }
}