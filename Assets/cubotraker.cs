using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboTracker : MonoBehaviour
{
    public GameObject target;             // Objeto objetivo (pelota o cualquier otro objeto)
    public float smoothTime = 0.3f;       // Tiempo de suavizado para el SmoothDamp
    private Vector3 velocity = Vector3.zero;  // Variable para almacenar la velocidad del suavizado

    void FixedUpdate()
    {
        // Usar SmoothDamp para suavizar el movimiento del objeto hacia la posición del objetivo
        Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true; // Congelar la rotación

            // Bloquear el movimiento en el eje Z
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
}


