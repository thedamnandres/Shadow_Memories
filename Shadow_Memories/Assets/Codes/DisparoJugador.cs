using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;

    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    void Update()
    {
        if (playerController != null && playerController.TieneLinterna() && Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }
}
