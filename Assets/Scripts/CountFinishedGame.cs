using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CountFinishedGame : MonoBehaviour
{

    public static CountFinishedGame instance { get; set; }

    [SerializeField] private GameObject finishScreen;

    [SerializeField] private GameObject videoPlayer;



    int countHistories;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        
    }

    public void CountToFinish()
    {
        countHistories += 1;
        if (countHistories >= 8)
        {
            StartCoroutine(PlayVideoThenFinish());
        }
    }

    IEnumerator PlayVideoThenFinish()
    {
        VideoManager vm = videoPlayer.GetComponent<VideoManager>();
        vm.ShowVideo();

        if (videoPlayer.TryGetComponent<VideoPlayer>(out var vp))

        {
            while(vp.length <= 0.01f)
                yield return null;

            yield return new WaitForSeconds((float)vp.length);
        }

        finishScreen.SetActive(true);
    }
}
