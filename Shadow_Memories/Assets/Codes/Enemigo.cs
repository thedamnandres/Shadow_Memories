using System;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
   [SerializeField] private float vida = 100f;

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
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
