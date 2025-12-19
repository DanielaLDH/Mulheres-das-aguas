using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class TipsAudioManager : MonoBehaviour
{
 
    [SerializeField] private int maxPlays;
    [SerializeField] private int pointsPerSinglePlay;
    [SerializeField] private MoneyManagement moneyManagement;
    [SerializeField] private AudioPrincipalManager principalManager;

    [SerializeField] private Sprite[] normalSprites; // Sprites para o estado normal (0, 1, 2, 3 vezes)
    [SerializeField] private Sprite[] hoverSprites;  // Sprites para o estado hover (0, 1, 2, 3 vezes)

    [SerializeField] GameObject videoPlayer;
    [SerializeField] private GameObject legenda;

    [SerializeField] GameObject sfxSound;
    [SerializeField] GameObject falasSound;

    [SerializeField] private string audioEventPath;

    [SerializeField] private BtnLibra BtnLibra;

    SFXManager sfxManager;
    FalasManager falasManager;
    bool isPaused;

    private int playCount = 0;
    private bool scorePoint = false;
    private bool isAudioPlaying = false;
    private Image image;
    private Animator animator;
    float currentAudioTime;


    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        sfxManager = sfxSound.GetComponent<SFXManager>();
        falasManager = falasSound.GetComponent<FalasManager>();
        animator = gameObject.GetComponent<Animator>();

    }

    public void PlayAudio()
    {

        //Se outro áudio está tocando ou pausado, não deixa tocar outro
        if (principalManager.AudioPlaying() && !principalManager.isSameAudio(audioEventPath))
        {
            Debug.Log("Outro áudio de voz está tocando. Aguarde antes de reproduzir um novo.");
            return;
        }

        //Se o mesmo áudio está tocando, PAUSA
        if (principalManager.isSameAudio(audioEventPath) && !principalManager.IsPaused())
        {
            Debug.Log("Pausando");
            currentAudioTime = falasManager.PauseFala();
            principalManager.PauseAudio();
            isPaused = true;
            animator.speed = 0;
            if (BtnLibra.isActive && videoPlayer.TryGetComponent<VideoPlayer>(out VideoPlayer vp))
            {
                vp.Pause();
            }

            return;
        }

        //Se o mesmo áudio está pausado, RETOMA
        if (principalManager.IsPaused() && principalManager.isSameAudio(audioEventPath))
        {
            Debug.Log("Retomando áudio...");
            falasManager.ResumeFala(currentAudioTime);
            principalManager.ResumeAudio();
            isPaused = false;
            animator.speed = 1;
            if (BtnLibra.isActive && videoPlayer.TryGetComponent<VideoPlayer>(out VideoPlayer vp))
            {
                vp.Play();
            }
            return;
        }

        if (playCount < maxPlays) 
        {
            isAudioPlaying = true;
            principalManager.AudioStatus(true, audioEventPath);
            sfxManager.PlaySFX(sfxManager.sfx_item_play);
            if (BtnLibra.isActive)
            {
                videoPlayer.GetComponent<VideoManager>().ShowVideo();
            }
            legenda.SetActive(true);

            playCount++;


            switch (playCount)
            {
                case 1:
                    if (!scorePoint)
                    {
                        moneyManagement.AddMoney(1);
                        scorePoint = true;
                    }
                    PlayVoiceAndSyncAnimation(audioEventPath, "anim1");
                    break;

                case 2:
                    moneyManagement.RemoveMoney(1);
                    PlayVoiceAndSyncAnimation(audioEventPath, "anim2");
                    break;

                case 3:
                    PlayVoiceAndSyncAnimation(audioEventPath, "anim3");
                    break;

            }

            Debug.Log("Áudio tocado " + playCount + " vez(es).");
            Debug.Log(scorePoint);
            

        }
        else
        {
            Debug.Log("O áudio já foi ouvido o número máximo de vezes.");
        }
    }

    private void PlayVoiceAndSyncAnimation(string voiceEventPath, string animationTrigger)
    {
        isAudioPlaying = true;

        animator.enabled = true;

        falasManager.PlayFala(voiceEventPath);

        float duration = falasManager.GetFalaDuration(voiceEventPath);

        animator.SetTrigger(animationTrigger);
        animator.SetFloat("speedMultiplier", 1.0f / duration);
        
        StartCoroutine(WaitForAudioToEnd(duration));

    }

    private IEnumerator WaitForAudioToEnd(float duration)
    {
        yield return new WaitForSeconds(duration);
        isAudioPlaying = false;
        animator.SetFloat("speedMultiplier", 1.0f);// Reseta a velocidade da animação
        animator.enabled = false;
        UpdateButtonSprite();
        principalManager.AudioStatus(false, audioEventPath);

    }

    public void ForceStopAudio()
    {
        falasManager.StopCurrentFala();
        principalManager.AudioStatus(false, audioEventPath);
        isAudioPlaying = false;
        isPaused = false;
        animator.SetFloat("speedMultiplier", 1.0f);
        animator.enabled = false;
        legenda.SetActive(false);
    }


    public void OnHover()
    {
        if (playCount < hoverSprites.Length)
        {
            Debug.Log(normalSprites[2].name);
            image.sprite = hoverSprites[playCount];
        }
    }

    public void ExitHover()
    {
        if (playCount < normalSprites.Length)
        {
            image.sprite = normalSprites[playCount];
        }
    }

    private void UpdateButtonSprite()
    {
        // Atualiza o sprite com base no número de vezes que o áudio foi reproduzido
        if (playCount < normalSprites.Length)
        {
            Debug.Log("atualizou");
            image.sprite = normalSprites[playCount];
            legenda.SetActive(false);
        }
    }

}
