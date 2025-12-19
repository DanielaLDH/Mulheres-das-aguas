using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SubtitleLine
{
    public float startTime;
    public float endTime;
    public string text;
}

public class SubtitleManager : MonoBehaviour
{
    public Text subtitleText;
    public string audioEventPath;
    public List<SubtitleLine> subtitles;
    private EventInstance eventInstance;



    private void Update()
    {
        FalasManager falasManager = FindObjectOfType<FalasManager>();


        if (falasManager != null)
        {
            eventInstance = falasManager.GetCurrentEventInstance();
        }
        else
        {
            Debug.LogError("FalasManager não encontrado!");
        }
        if (eventInstance.isValid())
        {
            int timelinePosition = 0;
            eventInstance.getTimelinePosition(out timelinePosition);

            float currentTime = timelinePosition / 1000f; // Converte milissegundos para segundos
            UpdateSubtitle(currentTime);

        }
        
    }

    private void UpdateSubtitle(float currentTime)
    {
        foreach (var line in subtitles)
        {
            if (currentTime >= line.startTime && currentTime <= line.endTime)
            {
                subtitleText.text = line.text;
                return;
            }
        }

        subtitleText.text = string.Empty;


    }


    private void OnDestroy()
    {
        if (eventInstance.isValid())
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }

}
