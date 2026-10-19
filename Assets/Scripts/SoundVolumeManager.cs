using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeManager : MonoBehaviour
{

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] SoundController soundController;
    [SerializeField] MenuBtnSound MenuBtnSound ;

    private Bus musicBus;
    private Bus sfxBus;
    private Bus sfxUI;
    private Bus ambSound;

    public static bool SfxMuted;


    void Start()
    {

        musicBus = RuntimeManager.GetBus("bus:/mus");
        ambSound = RuntimeManager.GetBus("bus:/amb");
        sfxBus = RuntimeManager.GetBus("bus:/sfx_ingame");
        sfxUI = RuntimeManager.GetBus("bus:/sfx_ui");

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
        }

        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 0.5f);
        }

        LoadVolume();
        
    }

    public void SetMusicVolume() 
    {
       
        float volume = musicSlider.value;
        musicBus.setVolume(volume);
        ambSound.setVolume(volume);
       // SaveVolume();
        if (volume == 0)
        {
            soundController.VolumeOff();

        }
        else
        {
            soundController.VolumeOn();
        }
        soundController.ChangeBtn();
        VerificaValor();


    }

    public void SetSfxVolume()
    {
        float volume = sfxSlider.value;
        sfxBus.setVolume(volume);
        sfxUI.setVolume(volume);
        //SaveVolume();

        SfxMuted = volume <= 0.0001;
        
        if (volume == 0)
        {
            soundController.VolumeOff();
        }
        else
        {
            soundController.VolumeOn();
        }
        soundController.ChangeBtn();
        VerificaValor();

    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);

    }

    public void LoadVolume()
    {

        //float musicVolume = PlayerPrefs.GetFloat("musicVolume");
        //float sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
        

        musicBus.setVolume(musicSlider.value);
        sfxBus.setVolume(sfxSlider.value);
        sfxUI.setVolume(sfxSlider.value);

        

    }

    public void VerificaValor()
    {
        if (musicSlider.value == 0 && sfxSlider.value == 0)
        {
            MenuBtnSound.VolumeOff();

            MenuBtnSound.ChangeBtn();
        }
        else
        {
            MenuBtnSound.VolumeOn();

            MenuBtnSound.ChangeBtn();
        }
    }
}
