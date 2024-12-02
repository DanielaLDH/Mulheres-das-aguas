using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private EventReference musMapMemoryEvent; // Evento para mus_map_memory
    [SerializeField]
    private EventReference musIngameEvent; // Evento para mus_ingame

    private EventInstance musMapMemoryInstance; // Inst�ncia do evento mus_map_memory
    private EventInstance musIngameInstance; // Inst�ncia do evento mus_ingame
    private int completedStages = 0; // N�mero de fases conclu�das

    public void Start()
    {
        musMapMemoryInstance = RuntimeManager.CreateInstance(musMapMemoryEvent);
        musIngameInstance = RuntimeManager.CreateInstance(musIngameEvent);

        EnterMap();
    }

    public void EnterMap()
    {
        musIngameInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        musMapMemoryInstance.setParameterByName("p_stage", 0);
        musMapMemoryInstance.start();
    }

    public void EnterMemoryGame()
    {
        musMapMemoryInstance.setParameterByName("p_stage", 1);
    }

    public void EnterPhase()
    {
        musMapMemoryInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        musIngameInstance.setParameterByName("p_stage", completedStages);
        musIngameInstance.start();
    }

    public void CompletePhase()
    {
        completedStages++;
        musIngameInstance.setParameterByName("p_stage", completedStages);
    }

    private void OnDestroy()
    {
        // Libera as inst�ncias ao destruir o objeto
        musMapMemoryInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        musMapMemoryInstance.release();

        musIngameInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        musIngameInstance.release();
    }
}
