using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorDetectaCofre : MonoBehaviour
{
    public int llavesRecogidas = 0;

    public GameObject puerta;               // Asignar desde el Inspector
    public GameObject enemigoPrefab;        // Prefab del enemigo
    public Transform[] puntosSpawnEnemigos; // Asignar desde el Inspector

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Cofre"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cofre cofre = other.GetComponent<Cofre>();
                if (cofre != null)
                {
                    cofre.Abrir();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Llave"))
        {
            llavesRecogidas++;
            Debug.Log("✅ Llave recogida. Total: " + llavesRecogidas);
            Destroy(other.gameObject);

            // SOLO instanciar 1 enemigo nuevo por cada llave recogida
            int index = llavesRecogidas - 1;
           if (enemigoPrefab != null && puntosSpawnEnemigos.Length > 0)
        {
            int randomIndex = Random.Range(0, puntosSpawnEnemigos.Length);
            Instantiate(enemigoPrefab, puntosSpawnEnemigos[randomIndex].position, Quaternion.identity);
            Debug.Log("👹 Enemigo generado en punto aleatorio.");
        }

            else
            {
                Debug.LogWarning("⚠️ No hay punto de spawn definido para la llave #" + llavesRecogidas);
            }

            if (llavesRecogidas == 5 && puerta != null)
            {
                puerta.SetActive(true);
                Debug.Log("🚪 ¡Puerta activada!");
            }
        }

        if (other.CompareTag("Puerta"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
