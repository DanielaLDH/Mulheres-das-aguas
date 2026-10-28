using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class StageLoader : MonoBehaviour
{
    public void LoadStage(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}