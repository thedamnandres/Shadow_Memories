using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
 
    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // -1 (izquierda), 0 (quieto), 1 (derecha)
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        bool isWalking = moveInput != 0;
        animator.SetBool("IsWalking", isWalking);
        if (moveInput != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(moveInput); // 1 para derecha, -1 para izquierda
            transform.localScale = scale;
        }
 
    }
 
}