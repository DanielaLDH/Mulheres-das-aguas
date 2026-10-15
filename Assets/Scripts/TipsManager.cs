using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TipsManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;    [SerializeField] private int maxPlays;
    [SerializeField] private int pointsPerSinglePlay;

    private int playCount = 0;
    private bool scorePoint = false;

    public void PlayAudio()
    {
        if (playCount < maxPlays) 
        {
            playCount++;

            audioSource.clip = clip;
            audioSource.Play();

            if (playCount == 1 && !scorePoint)
            {
                AwardPoint();
                scorePoint = true;
            }
            if (playCount > 1) 
            {
                Debug.Log("Ponto excluido!");
            }

            Debug.Log("Áudio tocado " + playCount + " vez(es).");
            Debug.Log(scorePoint);

        }
        else
        {
            Debug.Log("O áudio já foi ouvido o número máximo de vezes.");
        }
    }

    private void AwardPoint()
    {
        Debug.Log("Ponto concedido! O jogador ouviu o áudio apenas uma vez e ganhou " + pointsPerSinglePlay + " pontos.");

    }

}
