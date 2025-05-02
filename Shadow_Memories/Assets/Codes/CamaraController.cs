using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform objetivo;
    public float velocidadSeguimiento = 0.025f;
    public Vector3 desplazamiento = new Vector3(3f, 2f, -10f);

    private void Start()
    {
        // Posiciona la cámara directamente en el lugar correcto desde el principio
        transform.position = objetivo.position + desplazamiento;
    }

    private void LateUpdate()
    {
        Vector3 posicionDeseada = objetivo.position + desplazamiento;
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, velocidadSeguimiento);
        transform.position = posicionSuavizada;
    }
}
