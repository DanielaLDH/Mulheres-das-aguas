using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager _instance;

    public static CoroutineManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gameObject = new GameObject("CoroutineManager");
                _instance = gameObject.AddComponent<CoroutineManager>();
                DontDestroyOnLoad(gameObject);
            }
            return _instance;
        }
    }


    public void StartCorr(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

}
