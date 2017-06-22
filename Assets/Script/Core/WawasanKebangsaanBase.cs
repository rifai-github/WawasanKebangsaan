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
        JAWA_BARAT = 1,
        JAWA_TENGAH = 2,
        NANGGROE_ACEH_DARUSSALAM = 3,
        BALI = 4,
        BANTEN = 5,
        BENGKULU = 6,
        GORONTALO = 7,
        DKI_JAKARTA = 8,
        JAMBI = 9,
        JAWA_TIMUR = 10,
        KALIMANTAN_BARAT = 11,
        KALIMANTAN_SELATAN = 12,
        KALIMANTAN_TENGAH = 13,
        KALIMANTAN_TIMUR = 14,
        KALIMANTAN_UTARA = 15,
        DI_YOGYAKARTA = 16,
        BANGKA_BELITUNG = 17,
        KEPULAUAN_RIAU = 18,
        LAMPUNG = 19,
        MALUKU = 20,
        KEPULAUAN_MALUKU = 21,
        NUSA_TENGGARA_BARAT = 22,
        NUSA_TENGGARA_TIMUR = 23,
        PAPUA = 24,
        PAPUA_BARAT = 25,
        RIAU = 26,
        SULAWESI_BARAT = 27,
        SULAWESI_SELATAN = 28,
        SULAWESI_TENGAH = 29,
        SULAWESI_UTARA = 30,
        SUMATERA_BARAT = 31,
        SUMATERA_SELATAN = 32,
        SUMATERA_UTARA = 33,
        SULAWESI_TENGGARA = 34
    }

}