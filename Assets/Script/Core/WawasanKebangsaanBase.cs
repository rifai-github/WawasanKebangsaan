using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;

namespace WawasanKebangsaanBase
{
    public class JSONEvent : UnityEvent<string>
    {

    }

    public struct CONST_VAR
    {
        public static string JSON_PATH = Application.persistentDataPath + "/JSONData/";
        public static string JSON_URL = "file:///" + JSON_PATH;
    }

    public enum EJSONType
    {
        NullJSON = 0,
        JSON_PLAYERNAME = 1
    }

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