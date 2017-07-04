public class PlayVideo : BaseCaller 
{
    public string VideoName;

    public void VideoAction()
    {
        VideoGetter video = new VideoGetter();
        video.PlayVideo(VideoName);
    }
}
