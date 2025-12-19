using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MemoryGame : MonoBehaviour
{
    [SerializeField] GameObject backCard;
    [SerializeField] Sprite[] cardFaces;

    [SerializeField] GameObject sfxSound;

    MemoryGameManager memoryGameManager;
    SFXManager sfxManager;


    private List<GameObject> cards = new List<GameObject>();

    public bool canFlip = true;  // Controle para evitar virar mais cartas enquanto valida
    private Cards firstCard = null;   // Armazena a primeira carta virada
    private Cards secondCard = null;  // Armazena a segunda carta virada


    // Start is called before the first frame update
    void Start()
    {
        sfxManager = sfxSound.GetComponent<SFXManager>();

        memoryGameManager = gameObject.GetComponent<MemoryGameManager>();

        List<CardData> cardList = new List<CardData>();

        //cada sprite duplica e vai para nova lista
        for (int i = 0; i < cardFaces.Length; i++)
        {
            cardList.Add(new CardData(cardFaces[i], i));
            cardList.Add(new CardData(cardFaces[i], i));
        }
        cardList = Shuffle(cardList);

        //cada item da lista embaralhada instancia
        for (int i = 0; i < cardList.Count; i++) 
        {
            GameObject newCard = Instantiate(backCard, transform);
            newCard.GetComponent<Cards>().SetCard(cardList[i].cardface, cardList[i].pairId);


            cards.Add(newCard);
        }
    }

    //gera numero aleatorio usando range e muda index
    List<CardData> Shuffle(List<CardData> list)
    {
        for (int i = 0;i < list.Count; i++)
        {
            CardData temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }

        return list;

    }

    public class CardData
    {
        public Sprite cardface;
        public int pairId;

        public CardData(Sprite face, int Id)
        {
            cardface = face;
            pairId = Id;
        }
    }

    //quando são viradas
    public void OnCardFlipped(Cards card)
    {
        if (!canFlip) return;

        if (firstCard == null)
        {
            sfxManager.PlaySFX(sfxManager.sfx_memory_card_x);

            firstCard = card;
        }
        else if (secondCard == null)
        {
            sfxManager.PlaySFX(sfxManager.sfx_memory_card_x);
            secondCard = card;
            canFlip = false;

            if (firstCard.idCard == secondCard.idCard) 
            {
                sfxManager.PlaySFX(sfxManager.sfx_memory_right);

                firstCard = null;
                secondCard = null;
                canFlip = true;
                memoryGameManager.WinVerification(true);
            }
            else
            {
                sfxManager.PlaySFX(sfxManager.sfx_memory_wrong);

                StartCoroutine(ResetCards());
            }
        }
    }

    private IEnumerator ResetCards()
    {
        yield return new WaitForSeconds(1f);

        firstCard.FlipBack();
        secondCard.FlipBack();

        firstCard = null;
        secondCard = null;
        canFlip = true;
    }

}
