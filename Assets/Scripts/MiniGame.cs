using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{

    [SerializeField] GameObject blur;
    [SerializeField] GameObject Audio;
    [SerializeField] Image winCongrats;

    private MusicManager musicManager;

    // Start is called before the first frame update
    void Start()
    {
        musicManager = Audio.GetComponent<MusicManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnExit()
    {
        gameObject.SetActive(false);
        blur.SetActive(false);
        musicManager.EnterMap();

    }

    public void OnWin()
    {        
        StartCoroutine(ShowCongrats());
    }

    IEnumerator ShowCongrats()
    {
        winCongrats.gameObject.SetActive(true);

        // Fade in
        yield return StartCoroutine(FadeImage(0f, 1f, 0.8f));

        yield return new WaitForSeconds(2f);

        // Fade out
        yield return StartCoroutine(FadeImage(1f, 0f, 0.8f));

        winCongrats.gameObject.SetActive(false);
        blur.SetActive(false);
        musicManager.EnterMap();
        gameObject.SetActive(false);
    }

    IEnumerator FadeImage(float start, float end, float duration)
    {
        float elapsed = 0f;
        Color c = winCongrats.color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Lerp(start, end, elapsed / duration);
            winCongrats.color = c;
            yield return null;
        }

        c.a = end;
        winCongrats.color = c;
    }
}
