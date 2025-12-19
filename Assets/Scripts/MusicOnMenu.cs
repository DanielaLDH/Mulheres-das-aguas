using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOnMenu : MonoBehaviour
{
    [SerializeField] string audioEventPath;
    [SerializeField] AmbManager ambManager;

    // Start is called before the first frame update
    void Start()
    {
        ambManager.Play(audioEventPath); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        ambManager.Stop();
    }
}
