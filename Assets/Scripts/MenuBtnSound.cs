using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;


public class MenuBtnSound : MonoBehaviour
{
    [SerializeField] GameObject soundPanel;
    [SerializeField] GameObject sfxSound;

    //sprites btn audio
    [SerializeField] Sprite hover;
    [SerializeField] Sprite hoverOnOff;
    [SerializeField] Sprite normalOff;
    [SerializeField] Sprite normalOn;

    Image image;
    bool onOff;
    SFXManager sfxManager;


    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
        sfxManager = sfxSound.GetComponent<SFXManager>();
        soundPanel.SetActive(false);
    }

    public void OnClick()
    {
        if (soundPanel.activeSelf == true)
        {
            //sfxManager.PlaySFX(sfxManager.sfx_ui_play_click);
            soundPanel.SetActive(false);

        }
        else if (soundPanel.activeSelf == false)
        {
            //sfxManager.PlaySFX(sfxManager.sfx_ui_play_click);
            soundPanel.SetActive(true);
        }
    }


    public void OnMouseEnter()
    {

        image.sprite = onOff ? hoverOnOff : hover;


    }
    public void OnMouseExit()
    {
        image.sprite = onOff ? normalOff : normalOn;

    }

    public bool VolumeOff()
    {
        return onOff = true;
    }

    public bool VolumeOn()
    {
        return onOff = false;
    }

    public void ChangeBtn()
    {
        Debug.Log(onOff);
         image.sprite = onOff ? normalOff : normalOn;

    }
}
