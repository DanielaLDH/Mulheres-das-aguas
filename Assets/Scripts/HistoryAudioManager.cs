using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryAudioManager : MonoBehaviour
{
    [SerializeField] FalasManager falasManager;
    [SerializeField] string audioEventPath;
    [SerializeField] BtnLibra btnLibra;
    [SerializeField] GameObject videoPlayer;
    [SerializeField] GameObject legenda;




    private void OnEnable()
    {
        falasManager.PlayFala(audioEventPath);

        if (btnLibra.isActive)
        {
            videoPlayer.GetComponent<VideoManager>().ShowVideo();
        }

        legenda.SetActive(true);

    }

    private void OnDisable()
    {
        falasManager.StopCurrentFala();

        gameObject.SetActive(false);
    }
}
