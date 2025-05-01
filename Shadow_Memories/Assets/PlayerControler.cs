using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5f;
    //private Rigidbody2D rb;
    //private Animator animator;
    //private SpriteRenderer spriteRenderer;
 
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        float velocidadX = Input.GetAxis("Horizontal")*Time.deltaTime*speed; 
        Vector3 posicion = transform.position;
        transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);
 
    }
 
}