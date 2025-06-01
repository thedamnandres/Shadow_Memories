using UnityEngine;

public class BalaControl : MonoBehaviour
{
  [SerializeField] private float velocidad;

  [SerializeField] private float danio;


    private void Update()
    {
        
    transform.Translate(Vector2.right * velocidad * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            other.GetComponent<Enemigo>().TomarDanio(danio);
            Destroy(gameObject);
        }
        
    }


}
