using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItem : MonoBehaviour
{
    [SerializeField] Image dropItem; // A imagem de UI que será "jogada"

    [SerializeField] float throwSpeed; // Velocidade inicial do arremesso
    [SerializeField] float gravity; // Força gravitacional que faz o item cair


    [SerializeField] float throwDuration;
    [SerializeField] Vector2 throwOffset;

    [SerializeField] AudioSource sfxSound;


    private Vector2 startPosition;
    private Vector2 endPosition;
    private float elapsedTime;
    private bool isThrowing;
    private SFXManager sfxManager;


    // Start is called before the first frame update
    void Start()
    {
        sfxManager = sfxSound.GetComponent<SFXManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isThrowing)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / throwDuration;

            dropItem.rectTransform.position = Vector2.Lerp(startPosition, endPosition, progress);

            if (progress >= 1f)
            {
                isThrowing = false;
            }
        }
    }

    public void OnItemClicked()
    {
        sfxManager.PlaySFX(sfxManager.sfx_item_interaction);


        startPosition = Input.mousePosition;
        endPosition = startPosition + throwOffset;

        dropItem.rectTransform.position = startPosition;
        dropItem.gameObject.SetActive(true);

        elapsedTime = 0f;
        isThrowing = true;
    }
}
