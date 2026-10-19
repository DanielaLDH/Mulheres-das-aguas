using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManagement : MonoBehaviour
{
    [SerializeField] float popMultiplier = 1.2f;
    [SerializeField] float popSeconds = 0.2f;
    [SerializeField] AudioSource AudioSource;

    Vector3 originalScale;
    Coroutine popRoutine;

    Text uiMoney;
    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        uiMoney = GetComponent<Text>();
        originalScale = transform.localScale;
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

        AudioSource.Play();

        if (popRoutine != null) StopCoroutine(popRoutine);
        popRoutine = StartCoroutine(PopScale());
    }

    IEnumerator PopScale()
    {
        transform.localScale = originalScale * popMultiplier;
        yield return new WaitForSeconds(popSeconds);
        transform.localScale = originalScale;
        popRoutine = null;
    }


    public void RemoveMoney(int coins)
    {
        amount -= coins;
        uiMoney.text = amount.ToString();
        Debug.Log(amount);

    }
}
