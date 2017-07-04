using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class VideoGetter
{      
    public void PlayVideo(VideoType type)
    {
        switch (type)
        {
            case VideoType.VIDEO_TUTORIAL:
                PlayVideo("video tutorial.mp4");
                break;
            default:
                StaticFunction.WKMessageError("Wrong Call Method PlayVideo");
                break;
        }
    }

    public void PlayVideo(string videoName)
    {
        string path = StaticFunction.VideoURL(videoName);
        bool vPlay = Handheld.PlayFullScreenMovie(path, Color.black, FullScreenMovieControlMode.Minimal, FullScreenMovieScalingMode.AspectFit);
        StaticFunction.WKMessageLog("Play Video :: " + path); ;
    }                                                   
}
