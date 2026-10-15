using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{

    [SerializeField] GameObject soundSlide;
    [SerializeField] Sprite hover;
    [SerializeField] Sprite hoverOnOff;
    [SerializeField] Sprite normalOff;
    [SerializeField] Sprite normalOn;


    Image image;
    bool onOff;


    void Awake()
    {
        image = GetComponent<Image>();
        soundSlide.SetActive(false);

    }

    public void OnMouseEnter()
    {
        image.sprite = onOff ? hoverOnOff : hover;
       
        soundSlide.SetActive(true);


    }
    public void OnMouseExit()
    {
        image.sprite = onOff ? normalOff : normalOn;
        
        soundSlide.SetActive(false);
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

        image.sprite = onOff ? normalOff : normalOn;
       
    }
}
