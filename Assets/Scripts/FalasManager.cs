using FMODUnity;
using FMOD.Studio;
using UnityEngine;
using FMOD;

public class FalasManager : MonoBehaviour
{
    private EventInstance currentEventInstance;


    //private void Update()
    //{
    //    UnityEngine.Debug.Log("IsAudioPlaying: " + IsAudioPlaying());

    //}

    public void PlayFala(string fmodEventPath)
    {
        // Libera qualquer instância anterior antes de criar uma nova
        if (currentEventInstance.isValid())
        {
            currentEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            currentEventInstance.release();
        }

        // Cria e toca uma nova instância
        currentEventInstance = RuntimeManager.CreateInstance(fmodEventPath);
        currentEventInstance.start();

        UnityEngine.Debug.Log($"Playing Fala: {fmodEventPath}");
    }

    public float PauseFala()
    {
        if (currentEventInstance.isValid())
        {
            currentEventInstance.getTimelinePosition(out int currentTimeMs);
            currentEventInstance.setPaused(true);
            return currentTimeMs/1000f;
        }
        return 0f;
    }

    public void ResumeFala(float resumeTime)
    {
        if(currentEventInstance.isValid())
        {
            currentEventInstance.setTimelinePosition((int)(resumeTime * 1000));
            currentEventInstance.setPaused(false);
        }
    }

    public EventInstance CreateFalaInstance(string fmodEventPath)
    {
        // Libera a instância anterior antes de criar uma nova
        if (currentEventInstance.isValid())
        {
            currentEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            currentEventInstance.release();
        }

        currentEventInstance = RuntimeManager.CreateInstance(fmodEventPath);
        UnityEngine.Debug.Log($"EventInstance criado para: {fmodEventPath}");
        return currentEventInstance;
    }


    public float GetFalaDuration(string fmodEventPath)
    {
        RuntimeManager.StudioSystem.getEvent(fmodEventPath, out EventDescription eventDescription);

        float duration = 0f;
        eventDescription.getLength(out int lengthMs);
        duration = lengthMs / 1000f; // Converte milissegundos para segundos

        return duration;
    }


    public void StopCurrentFala()
    {
        if (currentEventInstance.isValid())
        {
            currentEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            currentEventInstance.release();
            UnityEngine.Debug.Log("Current fala stopped.");
        }
    }

     public EventInstance GetCurrentEventInstance()
    {
        return currentEventInstance; // Retorna a instância atual para ser usada por outras classes
    }

    //public bool IsAudioPlaying()
    //{
    //    Bus voiceBus = RuntimeManager.GetBus("bus:/vo");


    //    voiceBus.getChannelGroup(out ChannelGroup channelGroup);
    //    if (channelGroup.hasHandle())
    //    {
    //        channelGroup.getNumChannels(out int numChannels);
    //        return numChannels > 0;
    //    }
    //    return false;

    //}
}
