using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    public float speed = 20f;  // Velocidad del paddle IA
    public Transform ball;    // Referencia a la pelota

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Obtener el Rigidbody del paddle IA

        if (ball == null)
        {
            Debug.LogError("La pelota no está asignada al Paddle AI. Asigna la pelota en el Inspector.");
        }

        // Configurar el Rigidbody como no cinemático para permitir colisiones físicas
        rb.isKinematic = false;
        rb.freezeRotation = true;  // Evitar que el paddle se voltee accidentalmente
    }

    void Update()
    {
        if (ball == null) return;

        // Log para seguir la posición de la pelota
        Debug.Log("Posición de la pelota: " + ball.position);

        Vector3 targetPosition = new Vector3(ball.position.x, transform.position.y, transform.position.z);
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        Debug.Log("Nueva posición del paddle: " + newPosition);

        rb.MovePosition(newPosition);

        Vector3 clampedPosition = rb.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -5f, 5f);
        rb.position = clampedPosition;
    }
}
