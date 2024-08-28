using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en la zona es la pelota
        BallController ball = other.GetComponent<BallController>();
        if (ball != null)
        {
            // Reiniciar la pelota a su posición inicial
            ball.ResetBall();
        }
    }
}


