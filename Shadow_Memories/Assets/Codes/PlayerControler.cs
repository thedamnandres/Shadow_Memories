using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int vidaMaxima = 100;
    private int vidaActual;
    private bool esInvulnerable = false;
    public float tiempoInvulnerabilidad = 1.0f;

    public float speed = 5f;
    public float jumpForce = 10f;
    public Transform puntoLinterna;
    private bool tieneLinterna = false;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        vidaActual = vidaMaxima;
    }

    void Update()
    {
        // Movimiento horizontal
        float moveX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        // Activar/desactivar animación de caminar
        animator.SetBool("isWalking", moveX != 0);

        // Girar personaje con todos sus hijos sin afectar el movimiento
        if (moveX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (moveX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Salto
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            RecibirDano(20); // Cambia el número si quieres más o menos daño
        }

        if (collision.CompareTag("Linterna") && !tieneLinterna)
        {
            collision.GetComponent<Collider2D>().enabled = false;
            collision.transform.SetParent(puntoLinterna);
            collision.transform.localPosition = Vector3.zero;
            collision.transform.localRotation = Quaternion.identity;
            tieneLinterna = true;
        }
    }


    public bool TieneLinterna()
    {
        return tieneLinterna;
    }

    public void RecibirDano(int cantidad)
    {
        if (esInvulnerable) return;

        vidaActual -= cantidad;
        Debug.Log("Vida actual: " + vidaActual);

        if (vidaActual <= 0)
        {
            Morir();
        }
        else
        {
            StartCoroutine(InvulnerabilidadTemporal());
        }
    }

    private void Morir()
    {
        Debug.Log("Jugador muerto");

        // Desactiva el personaje visualmente
        gameObject.SetActive(false);

        // Luego muestra el menú Game Over
        FindObjectOfType<GameOverManager>().ActivarGameOver();
    }


    private System.Collections.IEnumerator InvulnerabilidadTemporal()
    {
        esInvulnerable = true;
        for (int i = 0; i < 5; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        esInvulnerable = false;
    }





}