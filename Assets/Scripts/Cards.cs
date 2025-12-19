using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cards : MonoBehaviour
{
    public Image cardImage;  // A imagem que será mostrada quando a carta for virada (frente)
    public Sprite frontSprite; // O sprite da frente que será definido no clique
    public Sprite backSprite;   // A imagem da parte de trás da carta (costas)
    public int idCard;

    private bool isRevealed = false; // Indica se a carta já foi virada
    private MemoryGame memoryGame;


    public void SetCard(Sprite sprite, int codCard)
    {
        frontSprite = sprite;
        cardImage.sprite = backSprite;
        idCard = codCard;
        memoryGame = FindObjectOfType<MemoryGame>();
    }

    public void OnCardClicked()
    {
        if (isRevealed || !memoryGame.canFlip) return;

        cardImage.sprite = frontSprite;   // Aplica a imagem da frente
        isRevealed = true; // Marca como revelada

        memoryGame.OnCardFlipped(this);

       
    }

    public void FlipBack()
    {
        cardImage.sprite = backSprite;
        isRevealed = false;
    }
   

}
