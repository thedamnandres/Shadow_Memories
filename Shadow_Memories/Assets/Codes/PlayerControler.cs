using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public Transform puntoLinterna; // Asigna el punto en la mano
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
    }

    void Update()
    {
        // Movimiento horizontal
        float moveX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y); // corregido: 'linearVelocity' no existe

        // Girar sprite a izquierda/derecha
        if (moveX < 0)
            spriteRenderer.flipX = true;
        else if (moveX > 0)
            spriteRenderer.flipX = false;

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
        // Detecta si el personaje aterriza en el suelo
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Linterna") && !tieneLinterna)
        {
            collision.GetComponent<Collider2D>().enabled = false;
            collision.transform.SetParent(puntoLinterna);
            collision.transform.localPosition = Vector3.zero;
            collision.transform.localRotation = Quaternion.identity;
            tieneLinterna = true;
        }
    }
}
