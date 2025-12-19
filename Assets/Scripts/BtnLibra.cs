using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnLibra : MonoBehaviour
{
    [SerializeField] Sprite hover;
    [SerializeField] Sprite hoverOnOff;
    [SerializeField] Sprite normalOff;
    [SerializeField] Sprite normalOn;

    Image image;
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }


    public void OnHover()
    {
        if (isActive)
        {
            image.sprite = hover;
        }
        else
        {
            image.sprite = hoverOnOff;
        }
    }

    public void OnHoverExit()
    {
        if (isActive)
        {
            image.sprite = normalOn;
        }
        else
        {
            image.sprite = normalOff;
        }
    }

    public void OnClick()
    {
        if (isActive)
        {

            isActive = false;
            image.sprite = normalOff;
        }
        else
        {
            isActive = true;
            image.sprite = normalOn;
        }
    }
}
