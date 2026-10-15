using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbManager : MonoBehaviour
{
    private EventInstance currentEventInstance;

    public void Play(string fmodEventPath)
    {
        Debug.Log(fmodEventPath);

        Stop();

        currentEventInstance = RuntimeManager.CreateInstance(fmodEventPath);
        currentEventInstance.start();
    }

    public void Stop()
    {
        if (currentEventInstance.isValid())
        {

            currentEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            currentEventInstance.release();
        }


    }

}
