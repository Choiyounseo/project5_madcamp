using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
