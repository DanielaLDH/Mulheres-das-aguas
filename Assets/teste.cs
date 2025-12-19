using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/amb/amb_christine");
        FMODUnity.RuntimeManager.PlayOneShot("event:/amb/amb_diele");
        FMODUnity.RuntimeManager.PlayOneShot("event:/amb/amb_menu");
        FMODUnity.RuntimeManager.PlayOneShot("event:/amb/amb_salete");

        Debug.Log(FMODUnity.RuntimeManager.PathToGUID("event:/amb/amb_christine")); // Deve retornar o GUID do evento


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
