using UnityEngine;
using WawasanKebangsaanBase;
using System;
using System.Collections;
using System.Globalization;
using System.IO;

public class WKStaticFunction
{
    public static void WKMessageLog(string message)
    {
        Debug.Log("Wawasan Kebangsaan Log :: " + message);
    }
    public static void WKMessageWarning(string message)
    {
        Debug.LogWarning("Wawasan Kebangsaan LogWarning :: " + message);
    }
    public static void WKMessageError(string message)
    {
        Debug.LogError("Wawasan Kebangsaan LogError :: " + message);
    }

    public static string GetTrackingName(ETrackingName TrackName)
    {
        string trackingName = "";

        switch (TrackName)
        {
            case ETrackingName.TRACKING_PANCASILA:
                trackingName = "Pancasila";
                break;
            case ETrackingName.TRACKING_NKRI:
                trackingName = "Negara Kesatuan Republik Indonesia";
                break;
            case ETrackingName.TRANKING_UUD45:
                trackingName = "Undang - Undang Dasar 1945";
                break;
            case ETrackingName.TRACKING_BHENIKA:
                trackingName = "Bhineka Tunggal Ika";
                break;
        }
        return trackingName;
    }
}