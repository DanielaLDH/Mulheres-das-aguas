using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AchievementsManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Sprite achievementDoneSprite;
    [SerializeField] MoneyManagement moneyManagement;
    [SerializeField] int achievementCost;
    [SerializeField] GameObject characterHistory; 

    private Image achiementSprite;
    private bool pointEnter = true;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (pointEnter)
        {
            TooltipManager.Instance.SetAndShowToolTip(TooltipManager.Instance.imagemCompre);

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.Instance.HideToolTip();
    }

    public void changeImage()
    {
        if (achievementDoneSprite != null)
        {
            achiementSprite.sprite = achievementDoneSprite;
            pointEnter = false;
        }
    }

    public void BuyAchievement()
    {
        int coins = moneyManagement.amount;

        if (!pointEnter)
        {
            characterHistory.SetActive(true);
        }
        else
        {
            if (coins >= achievementCost)
            {
                changeImage();
                moneyManagement.RemoveMoney(achievementCost);
            }
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        achiementSprite =  gameObject.GetComponent<Image>();
    }

}
