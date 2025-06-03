using System;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida = 100f;
    [SerializeField] private GameObject efectoMuerte;
    [SerializeField] private float velocidad = 2f;

    private Transform jugador;

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
            // Mover el enemigo hacia el jugador
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

        Destroy(gameObject);
    }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                // Solo le baja 10 de vida al enemigo
                TomarDanio(10f);
            }
        }

    


}
