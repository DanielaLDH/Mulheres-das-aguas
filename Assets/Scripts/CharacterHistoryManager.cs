using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHistoryManager : MonoBehaviour
{
    [SerializeField] GameObject blur;

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

    }
}
