using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anim_MiniGame : MonoBehaviour
{
    [SerializeField] Image anim;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        StartCoroutine(DisableAfterTime(6f)); // Inicia a Coroutine para desativar após 6 segundos
    }

    // Coroutine para desativar o gameObject após um tempo especificado
    IEnumerator DisableAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
