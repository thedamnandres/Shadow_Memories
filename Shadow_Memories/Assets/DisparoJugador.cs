using System.Runtime.CompilerServices;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
   
    [SerializeField] private Transform controladorDisparo;

    [SerializeField] private GameObject bala;
    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
                Disparar();
        }

    }


    private void Disparar()
    {
        Instantiate(bala,controladorDisparo.position,controladorDisparo.rotation);
    }
}
