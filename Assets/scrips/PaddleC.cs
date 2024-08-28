using UnityEngine;

public class PaddleC : MonoBehaviour
{
    public float xSpeed = 0.02f;  // Velocidad en el eje X
    public float ySpeed = 0.2f;   // Velocidad en el eje Y
    private float moveInputX;
    private float moveInputY;

    private Rigidbody rb;

    // Agrega los límites en los ejes X e Y
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f;
    public float maxY = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Obtén el Rigidbody del paddle
        rb.isKinematic = false;  // Asegúrate de que el Rigidbody no es kinemático
        rb.interpolation = RigidbodyInterpolation.Interpolate;  // Para un movimiento más suave

        // Restringir la rotación en el eje Z (o en todos los ejes si lo prefieres)
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }

    void Update()
    {
        // Obtener la entrada horizontal del usuario
        moveInputX = Input.GetAxis("Horizontal");
        // Obtener la entrada vertical del usuario
        moveInputY = Input.GetAxis("Vertical");

        // Crear el vector de movimiento solo en los ejes X e Y
        Vector3 movement = new Vector3(moveInputX * xSpeed, moveInputY * ySpeed, 0f);

        // Aplicar la fuerza para mover el paddle
        rb.velocity = movement;

        // Limitar la posición del paddle dentro de los límites definidos
        Vector3 clampedPosition = rb.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        clampedPosition.z = 0.06f; // Mantener la Z constante

        rb.position = clampedPosition;

        // Debugging
        Debug.Log($"Paddle Position: {rb.position}, Velocity: {rb.velocity}");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Si choca con una pared, detén el movimiento
            rb.velocity = Vector3.zero;
        }
    }
}
