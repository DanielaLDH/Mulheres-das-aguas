
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingManager : MonoBehaviour
{
    public static int nextScene;

    [SerializeField] private Slider progressBar;
  //  [SerializeField] private TMP_Text progressText;

    private void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        yield return null;

        AsyncOperation operation =
            SceneManager.LoadSceneAsync(nextScene);

        if (operation == null)
        {
            Debug.LogError("Não foi possível carregar a cena.");
            yield break;
        }

        operation.allowSceneActivation = false;

        while (operation.progress < 0.9f)
        {
            float progress =
                Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.value = progress;
         //   progressText.text =
               // Mathf.RoundToInt(progress * 100f) + "%";

            yield return null;
        }

        progressBar.value = 1f;
       // progressText.text = "100%";

        yield return null;

        operation.allowSceneActivation = true;
    }

    public static void LoadScene(int sceneNum)
    {
        nextScene = sceneNum;
        SceneManager.LoadScene("Loading");
    }
}
