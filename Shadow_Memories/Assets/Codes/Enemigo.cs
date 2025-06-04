using System;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida = 100f;
    [SerializeField] private GameObject efectoMuerte;
    [SerializeField] private float velocidad = 2f;

    private Transform jugador;

    public EnemigoSpawnea spawner; // Aquí está el cambio: usamos el nombre correcto de la clase

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            jugador = playerObj.transform;
        }
    }

    private void Update()
    {
        if (jugador != null)
        {
            Vector3 direccion = (jugador.position - transform.position).normalized;
            transform.position += direccion * velocidad * Time.deltaTime;
        }
    }

    public void TomarDanio(float danio)
    {
        vida -= danio;

        if (vida <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        if (efectoMuerte != null)
        {
            GameObject efecto = Instantiate(efectoMuerte, transform.position, Quaternion.identity);
            Destroy(efecto, 0.5f);
        }

        if (spawner != null)
        {
            spawner.ProgramarRespawn();
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TomarDanio(10f);
        }
    }
}
