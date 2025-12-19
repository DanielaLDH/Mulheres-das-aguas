using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemThrowDrop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject sfxSound;

    public Image dropImage; // A imagem de UI que será "jogada"
    public float throwSpeed = 500f; // Velocidade inicial do arremesso
    public Vector2 throwDirection = new Vector2(1, 1); // Direção inicial do arremesso
    public float gravity = 800f; // Força gravitacional que faz o item cair
    public RectTransform floorLimit; // Arraste o GameObject "FloorLimit" no Inspector
    public RectTransform rightLimit; // Referência para o limite direito


    private Vector2 velocity;
    private bool isThrowing;
    private SFXManager sfxManager;
    private Animator hoverAnim;

    private bool isPlacedCorrectly;
    private Vector3 originalScale;
    public float scaleFactor = 1.1f; // Fator de aumento, por exemplo, 1.1 para 10% maior


    void Start()
    {
        hoverAnim = GetComponent<Animator>();
        
        sfxManager = sfxSound.GetComponent<SFXManager>();
        originalScale = transform.localScale;

       //Image itemImage = GetComponent<Image>();
      //  itemImage.alphaHitTestMinimumThreshold = 0.1f;

        if (dropImage != null)
        {
            dropImage.gameObject.SetActive(false); // A imagem está invisível inicialmente          
        }

    }

    public void OnItemClicked()
    {
        if (isPlacedCorrectly) return;
        
        sfxManager.PlaySFX(sfxManager.sfx_item_interaction);

        // Defina a posição inicial e ative a imagem
        dropImage.rectTransform.position = Input.mousePosition;
        dropImage.gameObject.SetActive(true);

        // Configura a velocidade inicial baseada na direção e na velocidade de arremesso
        velocity = throwDirection.normalized * throwSpeed;

        // Começa o arremesso
        isThrowing = true;
    }

    void Update()
    {
        if (isThrowing)
        {
            // Aplica a gravidade na velocidade vertical
            velocity.y -= gravity * Time.deltaTime;

            // Atualiza a posição da imagem baseada na velocidade
            Vector3 newPosition = dropImage.rectTransform.position + (Vector3)(velocity * Time.deltaTime);

            // ?? Verifica o limite horizontal à direita
            float halfWidth = dropImage.rectTransform.sizeDelta.x * dropImage.rectTransform.lossyScale.x / 2f;
            newPosition.x = Mathf.Clamp(newPosition.x, halfWidth, rightLimit.position.x - halfWidth);

            // ?? Verifica se atingiu o "chão" definido pelo FloorLimit
            float halfHeight = dropImage.rectTransform.sizeDelta.y * dropImage.rectTransform.lossyScale.y / 2f;
            if (newPosition.y <= floorLimit.position.y + halfHeight)
            {
                newPosition.y = floorLimit.position.y + halfHeight; // Mantém na altura do piso
                isThrowing = false; // Para o movimento ao tocar o chão
            }

            dropImage.rectTransform.position = newPosition;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sfxManager.PlaySFX(sfxManager.sfx_ui_map_hover);
        hoverAnim.SetTrigger("Entra_Hover");
        //transform.localScale = originalScale * scaleFactor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverAnim.SetTrigger("Sai_Hover");

        //transform.localScale = originalScale;
    }

    public void SetAsPlaced()
    {
        isPlacedCorrectly = true;
    }
}
