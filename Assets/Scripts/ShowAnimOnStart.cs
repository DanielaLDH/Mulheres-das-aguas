using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ShowAnimOnStart : MonoBehaviour
{
    public static ShowAnimOnStart Instance { get; private set; }


    [SerializeField] GameObject videoPlayer;
    [SerializeField] GameObject fadeout;

    void Awake()
    {
        // Garante que só exista um por vez
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.GetComponent<VideoManager>().ShowVideo();
    }

   
    public void OnFinish()
    {
        StartCoroutine(FadeAndStart());
    }

    IEnumerator FadeAndStart()
    {
        fadeout.SetActive(true);
        yield return new WaitForSeconds(1f); // tempo da animação de fade

        SceneManager.LoadScene(2);
    }
}
