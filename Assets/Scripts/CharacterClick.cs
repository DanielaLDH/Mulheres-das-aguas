using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField] GameObject CharacterMap;
    [SerializeField] GameObject blur;
    [SerializeField] Image anim;
    [SerializeField] GameObject memoryGameAbrilhante; // Refer�ncia ao MemoryGameAbrilhante

    [SerializeField] GameObject sfxSound;
    [SerializeField] GameObject musicSound;

    SFXManager sfxManager;
    MusicManager musicManager;


    // Start is called before the first frame update
    void Start()
    {
        sfxManager = sfxSound.GetComponent<SFXManager>();
        musicManager = musicSound.GetComponent<MusicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (anim != null)
        {
            sfxManager.PlaySFX(sfxManager.sfx_ui_memory_click);

            blur.SetActive(true);

            CharacterMap.gameObject.SetActive(true);

            anim.gameObject.SetActive(true);
            StartCoroutine(DisableAfterTime(6f)); // Inicia a Coroutine para desativar ap�s 6 segundos
            musicManager.EnterMemoryGame();
           
            
        }
        else
        {
            sfxManager.PlaySFX(sfxManager.sfx_ui_map_click);

            CharacterMap.gameObject.SetActive(true);
            blur.SetActive(true);
            musicManager.EnterPhase();
        }

        
    }

    public void ChangeCharacterMap(GameObject newGame)
    {
        CharacterMap = newGame;
    }

    IEnumerator DisableAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.gameObject.SetActive(false);
        memoryGameAbrilhante.gameObject.SetActive(true);
        sfxManager.PlaySFX(sfxManager.sfx_ui_memory_play);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sfxManager.PlaySFX(sfxManager.sfx_ui_map_hover);

    }

}
