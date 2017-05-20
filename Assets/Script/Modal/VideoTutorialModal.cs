using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class VideoTutorialModal : BaseModal
{
    private static VideoTutorialModal _Instance;

    public static VideoTutorialModal Instance()
    {
        if (_Instance == null)
        {
            _Instance = GameObject.FindObjectOfType<VideoTutorialModal>();

            if (_Instance == null)
            {
                WKStaticFunction.WKMessageError("there is no VideoTutorialModal in the system");
            }
        }
        return _Instance;
    }
}
