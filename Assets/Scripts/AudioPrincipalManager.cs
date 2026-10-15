using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPrincipalManager : MonoBehaviour
{

    private bool isAudioPlaying;
    private bool isAudioPaused;
    private string currentAudioEvent;

    public bool AudioPlaying()
    {
        return isAudioPlaying;
    }

    public bool IsPaused()
    {
        return isAudioPaused;
    }

    public bool isSameAudio(string audioEventPath)
    {
        return isAudioPlaying && currentAudioEvent == audioEventPath;
    }

    public void AudioStatus(bool audioStatus, string audioEventPath)
    {
        isAudioPlaying = audioStatus;

        if (audioStatus)
        {
            currentAudioEvent = audioEventPath;
            isAudioPaused = false;
        }
        else
        {
            currentAudioEvent = null;
            isAudioPaused = false;
        }
    }

    public void PauseAudio()
    {
        if (isAudioPlaying)
        {
            isAudioPaused = true;
        }
    }

    public void ResumeAudio()
    {
        if (isAudioPlaying && isAudioPaused)
        {
            isAudioPaused=false;
        }
    }

}
