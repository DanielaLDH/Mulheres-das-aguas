using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsGameManager : MonoBehaviour
{
    public bool[] gameDone;
    [SerializeField] int gameCountToWin;
    [SerializeField] Image mapIcon;
    [SerializeField] Image changeIcon;
    [SerializeField] CharacterClick characterClick;
    [SerializeField] MoneyManagement moneyManagement;
    [SerializeField] GameObject gameTG;
    [SerializeField] GameObject locker;
    [SerializeField] GameObject achiev;
    [SerializeField] FalasManager falasManager;
    [SerializeField] AudioPrincipalManager principalManager;

    private Animator animatorLocker;

    [SerializeField] GameObject musicSound;

    [SerializeField] GameObject memoryGame;

    private MusicManager musicManager;
    private int index = 1;

    private void Start()
    {
        animatorLocker = locker.GetComponent<Animator>();
        gameDone = new bool[gameCountToWin];
        musicManager = musicSound.GetComponent<MusicManager>();
    }

    public void WinVerification(bool gameResult)
    {
        if (index >= gameDone.Length)
        {
            Debug.Log("game is done");

            //mapIcon.sprite = changeIcon.sprite;
            //RectTransform rectTransform = mapIcon.GetComponent<RectTransform>();
            //rectTransform.sizeDelta = new Vector2(369.1146f, 522.0625f);

            TipsAudioManager tipsAudioManager = FindObjectOfType<TipsAudioManager>();
            if (tipsAudioManager != null)
            {
                tipsAudioManager.ForceStopAudio();
            }


            moneyManagement.AddMoney(4);

            gameTG.SetActive(false);

            locker.SetActive(true);
            animatorLocker.SetTrigger("open");

            // animação carinha

            achiev.SetActive(true);
            memoryGame.SetActive(true);
            musicManager.CompletePhase();

        }
        else
        {
            Debug.Log($"Índice atual: {index}");
            gameDone[index] = gameResult;
            index++;
            
        }
    }
}
