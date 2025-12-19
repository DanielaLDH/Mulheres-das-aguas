using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;

    public Image imagemCompre;
    public Image imagemBuzios;
    public Image imagemItem;
    public Image imagemPista;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = Screen.width * 0.05f;   // 10% da largura da tela
        float offsetY = Screen.height * -0.07f; // 10% da altura da tela
        Vector3 offset = new Vector3(offsetX, offsetY, 0f);

        transform.position = Input.mousePosition + offset;
    }

    public void SetAndShowToolTip(Image showImage)
    {
        Image tooltipImage = GetComponent<Image>();

        tooltipImage.sprite = showImage.sprite;

        tooltipImage.preserveAspect = true;

        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);

    }
}
