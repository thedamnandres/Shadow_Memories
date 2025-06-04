using UnityEngine;

public class EnemigoSpawnea : MonoBehaviour
{
    [SerializeField] private GameObject prefabEnemigo;
    [SerializeField] private Transform puntoSpawn;
    [SerializeField] private float tiempoRespawn = 5f;

    private GameObject enemigoActual;

    private void Start()
    {
        SpawnEnemigo();
    }

    public void SpawnEnemigo()
    {
        enemigoActual = Instantiate(prefabEnemigo, puntoSpawn.position, Quaternion.identity);
        Enemigo enemigo = enemigoActual.GetComponent<Enemigo>();
        if (enemigo != null)
        {
            enemigo.spawner = this; // Aquí también debe coincidir con el nombre real de la clase
        }
    }

    public void ProgramarRespawn()
    {
        Invoke(nameof(SpawnEnemigo), tiempoRespawn);
    }
}
