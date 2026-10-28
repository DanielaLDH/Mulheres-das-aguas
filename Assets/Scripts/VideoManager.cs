using UnityEngine;
using UnityEngine.Video;
using System.IO;

public class VideoManager : MonoBehaviour
{
    //[SerializeField] private GameObject tela;
    [SerializeField] private string videoFileName;
    [SerializeField] private GameObject tela;
    [SerializeField] private bool isStart;

    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = gameObject.GetComponent<VideoPlayer>();

        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    public void ShowVideo()
    {
        if (videoPlayer)
        {
            tela.SetActive(true);
            gameObject.SetActive(true);

            string videoPath = Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath);

            videoPlayer.url = videoPath;
            videoPlayer.Prepare(); // Prepare the video before playing
        }
    }

    private void OnVideoPrepared(VideoPlayer source)
    {
        // Now that the video is prepared, you can access its length
        Debug.Log("Video Length: " + videoPlayer.length + " seconds");

        videoPlayer.Play();
    }

    // Pause or resume the video
    public void TogglePause()
    {
        Debug.Log("pausou");
        if (videoPlayer.isPaused)
        {
            videoPlayer.Play();
        }
        else if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
    }

    // Skip the video and execute its finish logic
    public void SkipVideo()
    {
        Debug.Log("skipou");

        videoPlayer.Stop();
        FinishVideo();
    }

    // Called when the video reaches its end
    private void OnVideoFinished(VideoPlayer source)
    {
        FinishVideo();
    }

    private void FinishVideo()
    {
        if (isStart)
        {
            ShowAnimOnStart.Instance.OnFinish();
        }
        else
        {
            tela.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        videoPlayer.prepareCompleted -= OnVideoPrepared;
        videoPlayer.loopPointReached -= OnVideoFinished;
    }
}