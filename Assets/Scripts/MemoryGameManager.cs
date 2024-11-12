
using UnityEngine;

public class MemoryGameManager : MonoBehaviour
{
    public bool[] gameDone;
    [SerializeField] int gameCountToWin;
    [SerializeField] GameObject gameIcon;
    [SerializeField] MoneyManagement moneyManagement;


    private int index = 0;

    private void Start()
    {
        gameDone = new bool[gameCountToWin];
    }

    public void WinVerification(bool gameResult)
    {
        if (index >= gameDone.Length)
        {
            Debug.Log("game is done");
            moneyManagement.AddMoney(4);
            gameIcon.SetActive(false);
        }
        else
        {
            Debug.Log($"�ndice atual: {index}");
            gameDone[index] = gameResult;
            index++;

        }
    }
}
