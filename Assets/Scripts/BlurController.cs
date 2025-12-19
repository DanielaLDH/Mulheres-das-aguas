using UnityEngine;

public class BlurController : MonoBehaviour
{
    [SerializeField] private GameObject blurEffect;

    public void HideBlur()
    {
        if (blurEffect != null)
        {
            blurEffect.SetActive(false);
            Debug.Log("Blur removido após a animação!");
        }
    }

    public void HideLocker()
    {
        gameObject.SetActive(false);
        Debug.Log("Locker desativado após a animação!");
    }
}
