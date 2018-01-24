using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAboveWater : MonoBehaviour {
    public float maxDistance, minDistance;
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, maxDistance))
        {
           // print("There is something below coin" + hit.distance);
            if (hit.distance > minDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}
