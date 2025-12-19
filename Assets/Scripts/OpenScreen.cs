using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScreen : MonoBehaviour
{

    [SerializeField] GameObject creditScreen;
    [SerializeField] GameObject aboutScreen;


    public void OpenCredit()
    {
        creditScreen.SetActive(true);
    }

    public void OpenAbout()
    {
        aboutScreen.SetActive(true);
    }

    public void ExitCredit()
    {
        creditScreen.SetActive(false);
    }

    public void ExitAbout()
    {
        aboutScreen.SetActive(false);
    }

}
