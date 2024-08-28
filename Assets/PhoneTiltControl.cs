using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTiltControl : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 tilt = new Vector3(Input.acceleration.x, Input.acceleration.y, 0f);
        Vector3 movement = tilt * speed;

        rb.velocity = new Vector3(movement.x, movement.y, 0f);
    }
}

