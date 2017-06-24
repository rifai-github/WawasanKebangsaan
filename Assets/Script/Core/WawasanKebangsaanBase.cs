using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;

namespace WawasanKebangsaanBase
{
    public struct CONTS_VAR
    {
        public static string OFFLINE_URL = "file://"+Application.persistentDataPath + "/";
        public static string SERVER_URL = "http://rivayx.000webhostapp.com/WawasanKebangsaan/";
        public static string OFFLINE_VIDEO = OFFLINE_URL + "video/";
        public static string ONLINE_VIDEO = SERVER_URL + "video/";
    }

    public enum StateID 
    {
        NullStateID = 0,
        MATINEE_STATE = 1,
        HOME_STATE = 2,
        AR_STATE = 3,
        VIDEO_TUTORIAL_STATE = 4
    }

    public enum Transition
    {
        NullTransition = 0,
        TRANSITION_TO_MATINEESTATE = 1,
        TRANSITION_TO_ARSTATE = 2,
        TRANSITION_TO_HOMESTATE = 3,
        TRANSITION_TO_VIDEOTUTORIALSTATE = 4
    }
    
    public enum Provinsi
    {
        Null = 0,
        JawaBarat = 1,
        JawaTengah = 2,
        NanggroeAcehDarussalam = 3,
        Bali = 4,
        Banten = 5,
        Bengkulu = 6,
        Gorontalo = 7,
        DKIJakarta = 8,
        Jambi = 9,
        JawaTimur = 10,
        KalimantanBarat = 11,
        KalimantanSelatan = 12,
        KalimantanTengah = 13,
        KalimantanTimur = 14,
        KalimantanUtara = 15,
        DIYogyakarta = 16,
        BangkaBelitung = 17,
        KepulauanRiau = 18,
        Lampung = 19,
        Maluku = 20,
        KepulauanMaluku = 21,
        NusaTenggaraBarat = 22,
        NusaTenggaraTimur = 23,
        Papua = 24,
        PapuaBarat = 25,
        Riau = 26,
        SulawesiBarat = 27,
        SulawesiSelatan = 28,
        SulawesiTengah = 29,
        SulawesiUtara = 30,
        SumateraBarat = 31,
        SumateraSelatan = 32,
        SumateraUtara = 33,
        SulawesiTenggara = 34

    }

    public enum VideoType
    {
        Null = 0,
        VIDEO_TUTORIAL = 1,
        VIDEO_PROVINSI = 2
    }
}