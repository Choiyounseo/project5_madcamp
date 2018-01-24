using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public float speed = 1.0f;

    private void FixedUpdate()
    {
        transform.position -= Vector3.forward * speed * Time.deltaTime;
    }

    

}
