using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVoiceOwner
{
    void ForceStopAudio();
    string GetVoicePath();
}
