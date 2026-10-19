using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPrincipalManager : MonoBehaviour
{

    private bool isAudioPlaying;
    private bool isAudioPaused;
    private string currentAudioEvent;

    private IVoiceOwner currentVoiceOwner;

    public bool AudioPlaying()
    {
        return isAudioPlaying || isAudioPaused;
    }

    public bool IsPaused()
    {
        return isAudioPaused;
    }

    public void RequestPlay(string audioEventPath, IVoiceOwner newOwner)
    {
        if (AudioPlaying() && currentVoiceOwner != null)
        {
            bool differentOwner = currentVoiceOwner != newOwner;
            bool differentAudio = !isSameAudio(audioEventPath);

            if (differentOwner && differentAudio)
            {
                currentVoiceOwner.ForceStopAudio();
            }
        }

        currentVoiceOwner = newOwner;
        currentAudioEvent = audioEventPath;

        isAudioPlaying = true;
        isAudioPaused = false;
    }

    public bool isSameAudio(string audioEventPath)
    {
      //  return isAudioPlaying && currentAudioEvent == audioEventPath;
      return !string.IsNullOrEmpty(currentAudioEvent) && currentAudioEvent == audioEventPath;
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
            if (isSameAudio(audioEventPath))
            {
                currentAudioEvent = null;
                isAudioPaused = false;
                currentVoiceOwner = null;
            }
            
        }
    }

    public void PauseAudio()
    {
        if (isAudioPlaying)
        {
            isAudioPaused = true;
            isAudioPlaying= false;
        }
    }

    public void ResumeAudio()
    {
        if (isAudioPaused)
        {
            isAudioPaused = false;
            isAudioPlaying = true;
        }
    }

    public void ForceStopCurrent()
    {
        if(currentVoiceOwner != null)
        {
            currentVoiceOwner.ForceStopAudio();
        }
        else
        {
            isAudioPlaying = false;
            isAudioPaused = false;
            currentAudioEvent = null;
        }
    }

}
