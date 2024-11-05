using UnityEngine;
using UnityEngine.UI;

public class ItemThrowDrop : MonoBehaviour
{
    public Image dropImage; // A imagem de UI que ser� "jogada"
    public float throwSpeed = 500f; // Velocidade inicial do arremesso
    public Vector2 throwDirection = new Vector2(1, 1); // Dire��o inicial do arremesso
    public float gravity = 800f; // For�a gravitacional que faz o item cair

    private Vector2 velocity;
    private bool isThrowing;

    void Start()
    {
        dropImage.gameObject.SetActive(false); // A imagem est� invis�vel inicialmente
    }

    public void OnItemClicked()
    {
        // Defina a posi��o inicial e ative a imagem
        dropImage.rectTransform.position = Input.mousePosition;
        dropImage.gameObject.SetActive(true);

        // Configura a velocidade inicial baseada na dire��o e na velocidade de arremesso
        velocity = throwDirection.normalized * throwSpeed;

        // Come�a o arremesso
        isThrowing = true;
    }

    void Update()
    {
        if (isThrowing)
        {
            // Aplica a gravidade na velocidade vertical
            velocity.y -= gravity * Time.deltaTime;

            // Atualiza a posi��o da imagem baseada na velocidade
            dropImage.rectTransform.position += (Vector3)(velocity * Time.deltaTime);

            // Verifica se a imagem caiu abaixo da posi��o inicial (opcional para parar a anima��o)
            if (dropImage.rectTransform.position.y < Input.mousePosition.y)
            {
                isThrowing = false;
                
            }
        }
    }
}
