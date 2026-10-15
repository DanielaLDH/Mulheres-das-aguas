using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] int codigo;
    [SerializeField] private TipsGameManager tipsGameManager;
    [SerializeField] GameObject sfxSound;

    bool isPlaced;


    SFXManager sfxManager;

    private void Start()
    {
        sfxManager = sfxSound.GetComponent<SFXManager>();

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (isPlaced) return;

        if (eventData.pointerDrag != null)
        {
            DragDrop draggedItem = eventData.pointerDrag.GetComponent<DragDrop>();

            if (draggedItem.codigo == codigo)
            {
                Debug.Log("correto");
                sfxManager.PlaySFX(sfxManager.sfx_item_right);


                tipsGameManager.WinVerification(true);

                //posição do item e slot
                RectTransform draggedRect = eventData.pointerDrag.GetComponent<RectTransform>();
                RectTransform slotRect = GetComponent<RectTransform>();


                draggedRect.SetParent(slotRect);

                draggedRect.localPosition = Vector2.zero;

                draggedItem.SetAsPlaced();

                isPlaced = true;
            }
            else
            {
                draggedItem.ResetPosition();
                sfxManager.PlaySFX(sfxManager.sfx_item_wrong);

            }

        }
    }

}
