using System;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida = 100f;

    [SerializeField] private GameObject efectoMuerte;

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
            // Instancia el efecto de muerte
            GameObject efecto = Instantiate(efectoMuerte, transform.position, Quaternion.identity);

            // Destruye el efecto después de 2 segundos
            Destroy(efecto, 0.5f);
        }

        // Destruye el enemigo
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (efectoMuerte != null)
            {
                GameObject efecto = Instantiate(efectoMuerte, transform.position, Quaternion.identity);
                Destroy(efecto, 2f);
            }

            Destroy(gameObject);
        }
    }
}
