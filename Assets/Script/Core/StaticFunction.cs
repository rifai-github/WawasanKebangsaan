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
}