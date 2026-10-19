using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverPlayAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Animator animator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetTrigger("Entra_Hover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
