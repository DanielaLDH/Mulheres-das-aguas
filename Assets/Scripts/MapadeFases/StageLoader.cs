using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class StageLoader : MonoBehaviour
{
    public void LoadStage(int sceneIndex)
    {
        LoadingManager.LoadScene(sceneIndex);
       // SceneManager.LoadScene(sceneIndex);
    }
}