using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Si el objeto que colisiona es la pelota
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Rebate la pelota al invertir la dirección de la velocidad
                Vector3 normal = collision.GetContact(0).normal;
                rb.velocity = Vector3.Reflect(rb.velocity, normal);
            }
        }
    }
}


