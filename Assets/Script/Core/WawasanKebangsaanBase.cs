using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;

namespace WawasanKebangsaanBase
{
    public delegate void OnMatineeEventDelegate(EMatineeType matineeType);

    public enum STATE_ID 
    {
        NullStateID = 0,
        MATINEE_STATE = 1,
        HOME_STATE = 2,
        AR_STATE = 3,
        VIDEO_TUTORIAL_STATE = 4
    }

    public enum TRANSITION
    {
        NullTransition = 0,
        TRANSITION_TO_MATINEESTATE = 1,
        TRANSITION_TO_ARSTATE = 2,
        TRANSITION_TO_HOMESTATE = 3,
        TRANSITION_TO_VIDEOTUTORIALSTATE = 4
    }
    
    public enum ETrackingName
    {
        TRACKING_NULL = 0,
        TRACKING_PANCASILA = 1,
        TRACKING_NKRI = 2,
        TRANKING_UUD45 = 3,
        TRACKING_BHENIKA = 4
    }

    public enum EMatineeType
    {
        MATINEE_NULL = 0,
        MATINEE_ENTRANCE = 1
    }
}