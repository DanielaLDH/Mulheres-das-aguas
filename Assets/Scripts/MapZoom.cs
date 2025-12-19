using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapZoom : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] RectTransform mapContainer; //obj pai
    [SerializeField] float zoomSpeed;
    [SerializeField] float minZoom;
    [SerializeField] float maxZoom;

    [SerializeField] Sprite btnZoomOutClick;
    [SerializeField] Sprite btnZoomInClick;
    [SerializeField] Sprite btnZoonOutHover;
    [SerializeField] Sprite btnZoonInHover;
    [SerializeField] Sprite btnZoom;
    [SerializeField] Button btn;

    private Vector2 lastMousePosition;
    private RectTransform canvasRect;
    private bool zoomIn;
    private Vector2 initialPosition;            // Posição inicial do mapa


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = mapContainer.anchoredPosition;

        canvasRect = mapContainer.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
    }

    public void OnHover()
    {
        if (zoomIn)
        {
            btn.image.sprite = btnZoonInHover;
        }
        else
        {
            btn.image.sprite = btnZoonOutHover;
        }
    }

    public void OnHoverExit()
    {
        btn.image.sprite = btnZoom;
    }

    public void OnClick()
    {
        if (zoomIn)
        {
            ZoomOut();
            btn.image.sprite = btnZoomOutClick;
        }
        else
        {
            ZoomIn();
            btn.image.sprite = btnZoomInClick;

        }
    }

    private void ZoomIn()
    {
        float newScale = Mathf.Clamp(mapContainer.localScale.x + zoomSpeed, minZoom, maxZoom);
        mapContainer.localScale = new Vector3(newScale, newScale, 1);
        zoomIn = true;

    }

    private void ZoomOut()
    {
        float newScale = Mathf.Clamp(mapContainer.localScale.x - zoomSpeed, minZoom, maxZoom);
        mapContainer.localScale = new Vector3(newScale, newScale, 1);
        zoomIn = false;

        AdjustMap();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canvasRect == null) return;
        if (zoomIn)
        {
            Vector2 currentMousePosition = eventData.position;
            Vector2 delta = currentMousePosition - lastMousePosition;

            mapContainer.anchoredPosition += delta;

            Vector3 clampedPosition = ClampToCanvas(mapContainer);
            mapContainer.anchoredPosition = clampedPosition;

            lastMousePosition = currentMousePosition;
        }
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastMousePosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Não é necessário fazer nada aqui, mas o método é obrigatório por IDragHandler
    }

    private Vector3 ClampToCanvas(RectTransform map)
    {
        Vector3 position = map.anchoredPosition;

        //float margem = 100f; // ajuste isso pra mais ou menos liberdade


        Vector3 minPosition = canvasRect.rect.min - map.rect.min * map.localScale.x ;
        Vector3 maxPosition = canvasRect.rect.max - map.rect.max * map.localScale.x ;

        position.x = Mathf.Clamp(position.x, minPosition.x - 150f, maxPosition.x + 150f);
        position.y = Mathf.Clamp(position.y, minPosition.y - 200f, maxPosition.y + 200f);

        return position;
    }

    private void AdjustMap()
    {
        mapContainer.anchoredPosition = initialPosition;
    }
}
