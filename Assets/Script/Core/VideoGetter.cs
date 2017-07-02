using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WawasanKebangsaanBase;

public class VideoGetter : MonoBehaviour 
{
    public static VideoGetter GetVideo()
    {
        GameObject game = new GameObject("VideoPlayer");
        game.AddComponent<JSONGetter>();

        VideoGetter playVid = game.GetComponent<VideoGetter>() as VideoGetter;

        return playVid;
    }

    public void PlayVideo(VideoType type)
    {
        switch (type)
        {
            case VideoType.VIDEO_TUTORIAL:
                StartCoroutine(PlayVideoCourotine("video tutorial.mp4"));
                break;
            default:
                StaticFunction.WKMessageError("Wrong Call Method PlayVideo");
                break;
        }
    }

    public void PlayVideo(string videoName)
    {
        string path = StaticFunction.VideoURL(videoName);
        StartCoroutine(PlayVideoCourotine(path));
    }

    private IEnumerator PlayVideoCourotine(string path)
    {      
        bool vPlay = Handheld.PlayFullScreenMovie(path, Color.black, FullScreenMovieControlMode.Minimal, FullScreenMovieScalingMode.AspectFit);
        StaticFunction.WKMessageLog("Play Video :: " + vPlay);
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        StaticFunction.WKMessageLog("Stop Video");
        Destroy(this.gameObject);
    }
}
