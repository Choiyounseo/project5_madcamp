using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.velocity = transform.forward * speed;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

}
