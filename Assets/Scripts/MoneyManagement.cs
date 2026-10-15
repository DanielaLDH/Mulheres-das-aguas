using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManagement : MonoBehaviour
{

    Text uiMoney;
    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        uiMoney = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(amount >= 10)
        {
            TooltipManager.Instance.SetAndShowToolTip(TooltipManager.Instance.imagemBuzios);

        }
    }

    public void AddMoney(int coins)
    {
        amount += coins; 
        uiMoney.text = amount.ToString();
        Debug.Log(amount);
    }

    public void RemoveMoney(int coins)
    {
        amount -= coins;
        uiMoney.text = amount.ToString();
        Debug.Log(amount);

    }
}
