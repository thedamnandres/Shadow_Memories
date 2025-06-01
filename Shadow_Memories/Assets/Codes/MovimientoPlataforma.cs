using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool moviendoDerecha = true;
    [SerializeField] private LayerMask capaDelSuelo;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Raycast para detectar el suelo con capa
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia, capaDelSuelo);

        // Si no hay suelo, gira
        if (!informacionSuelo)
        {
            Girar();
        }

        // Movimiento constante
        rb.linearVelocity = new Vector2(moviendoDerecha ? velocidad : -velocidad, rb.linearVelocity.y);

        // Dibuja el rayo para depuración
        Debug.DrawRay(controladorSuelo.position, Vector2.down * distancia, Color.red);
    }

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, moviendoDerecha ? 0 : 180, 0); // Gira visualmente
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.position, controladorSuelo.position + Vector3.down * distancia);
    }
}