using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public float speed = 10f; // Velocidad base de la pelota
    public float minSpeed = 5f; // Velocidad mínima para evitar que la pelota se detenga
    public Transform playerPaddle; // Referencia a la paleta del jugador
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (playerPaddle == null)
        {
            Debug.LogError("La paleta del jugador no está asignada. Asigna la paleta en el Inspector.");
        }

        LaunchBall();
    }

    void Update()
    {
        // Verificar si la velocidad actual es menor que la mínima
        if (rb.velocity.magnitude < minSpeed)
        {
            rb.velocity = rb.velocity.normalized * minSpeed;
        }
    }

    public void LaunchBall()
    {
        // Reseteamos la velocidad y la rotación para evitar comportamientos incontrolados
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Genera un vector de dirección inicial aleatorio
        Vector3 direction = new Vector3(
            Random.Range(-1f, 1f),
            0, // Mantén el eje Y en cero si estás trabajando en 2D
            Random.Range(-1f, 1f)
        ).normalized;

        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetZone"))
        {
            ResetBall();
            CheckGameOver(); // Llama al método para verificar si el juego ha terminado
        }
    }
    private void CheckGameOver()
    {
        // Suponiendo que detectas una condición de pérdida en el juego, cambia a la pantalla de inicio
        SceneManager.LoadScene("MainMenu"); // Cambia "MainMenu" por el nombre de tu escena de inicio
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
        rb.velocity = direction * speed;

        // Asegurar que la velocidad no caiga por debajo de la velocidad mínima
        if (rb.velocity.magnitude < minSpeed)
        {
            rb.velocity = rb.velocity.normalized * minSpeed;
        }
    }

    public void ResetBall()
    {
        // Reiniciar la posición de la pelota justo encima de la paleta del jugador
        transform.position = new Vector3(playerPaddle.position.x, playerPaddle.position.y + 1f, playerPaddle.position.z);

        // Reiniciar la rotación de la pelota
        transform.rotation = Quaternion.identity;

        // Resetear las velocidades para evitar que salga disparada
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Relanzar la pelota después de reiniciarla
        LaunchBall();
    }
}
