using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{

    [SerializeField] GameObject blur;
    // Start is called before the first frame update
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
