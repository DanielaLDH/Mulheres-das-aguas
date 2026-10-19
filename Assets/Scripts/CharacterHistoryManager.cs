using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHistoryManager : MonoBehaviour
{
    [SerializeField] GameObject blur;

    bool isDone = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExit()
    {
        gameObject.SetActive(false);
        blur.SetActive(false);
        if (isDone)
        {
            return;
        }
        else
        {
            CountFinishedGame.instance.CountToFinish();
            isDone = true;
        }

    }
}
