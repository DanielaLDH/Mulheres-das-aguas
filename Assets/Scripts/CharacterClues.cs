using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClues : MonoBehaviour
{

    [SerializeField] GameObject blur;
    [SerializeField] GameObject Audio;
    [SerializeField] FalasManager falasManager; // Referência ao FalasManager
    [SerializeField] AmbManager ambManager;
    [SerializeField] string audioEventPath;
    [SerializeField] AudioPrincipalManager principalManager;
    [SerializeField] bool isPlaying = false;

    private MusicManager musicManager;

    void OnEnable()
    {
        musicManager = Audio.GetComponent<MusicManager>();
        ambManager.Play(audioEventPath);

        TooltipManager.Instance.SetAndShowToolTip(TooltipManager.Instance.imagemPista);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExit()
    {
        if (principalManager.AudioPlaying())
        {
            return;
        }
        gameObject.SetActive(false);
        blur.SetActive(false);
        musicManager.EnterMap();
        ambManager.Stop();
        // Para a fala atual
        if (falasManager != null)
        {
            falasManager.StopCurrentFala();
        }

    }
}
