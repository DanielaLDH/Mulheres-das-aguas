using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Tooltip("Canvas que cont�m os objetos arrast�veis.")]
    [SerializeField] Canvas canvas;
    public int codigo;

    private Vector3 startPosition;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private bool isPlacedCorrectly = false;

    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;

    }

    // M�todo chamado no in�cio do arrasto
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isPlacedCorrectly) return;

        canvasGroup.alpha = 0.6f; // Torna o objeto parcialmente transparente
        canvasGroup.blocksRaycasts = false; // Permite que o objeto passe por outros objetos raycast
    }

    // M�todo chamado durante o arrasto
    public void OnDrag(PointerEventData eventData)
    {
        if (isPlacedCorrectly) return;

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    // M�todo chamado no fim do arrasto
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f; // Restaura a opacidade do objeto
        canvasGroup.blocksRaycasts = true; // Bloqueia novamente os raycasts
    }


    public void ResetPosition()
    {
        rectTransform.anchoredPosition = startPosition; // Volta o item para a posi��o inicial
    }

    public void SetAsPlaced()
    {
        isPlacedCorrectly = true;
    }

}
