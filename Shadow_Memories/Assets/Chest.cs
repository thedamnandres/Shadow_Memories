using System.Collections;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    private Animator animator;
    public GameObject llave;
    private bool isOpened = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Abrir()
    {
        if (isOpened) return;

        isOpened = true;

        Debug.Log("📦 Cofre abierto (animación + espera para llave)");

        animator.speed = 2f; // acelera la animación del cofre
        animator.Play("Abierto");

        StartCoroutine(GetChestItem());
    }

    IEnumerator GetChestItem()
{
    yield return new WaitForSeconds(2f); // Espera 2 segundos exactos

    GameObject obj = Instantiate(llave, transform.position, Quaternion.identity);

    Debug.Log("🔑 Llave instanciada en posición: " + transform.position);

    Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
    if (rb != null)
    {
        rb.AddForce(Vector2.up * 500f); // ⬆️ más fuerza vertical = sube más alto
        rb.AddTorque(100f);             // 🔄 sigue girando
    }
}

}
