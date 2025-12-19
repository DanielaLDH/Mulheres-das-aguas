using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    //[SerializeField] private GameObject tela;
    [SerializeField] private string videoFileName;
    [SerializeField] private GameObject tela;
    [SerializeField] bool isStart;

    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
    }

    public void ShowVideo()
    {

        if (videoPlayer) 
        {

            tela.SetActive(true);
            gameObject.SetActive(true);
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
            //StartCoroutine(StopVideo());
            videoPlayer.Prepare(); // Prepare the video before playing
            videoPlayer.prepareCompleted += OnVideoPrepared;

        }

    }

    private void OnVideoPrepared(VideoPlayer source)
    {
        // Now that the video is prepared, you can access its length
        Debug.Log("Video Length: " + videoPlayer.length + " seconds");
        videoPlayer.Play();
        StartCoroutine(StopVideo());
    }

    private IEnumerator StopVideo()
    {
        yield return new WaitForSeconds((float)videoPlayer.length);
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
}
