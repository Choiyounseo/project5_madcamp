using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRabbitplaceAccelerate : MonoBehaviour {

    private Rigidbody rb;
    private bool isbrushing2 = false;
    public int flags = 0;

    private RightRabbitController rabbitController;

    void Update()
    {
        flags = 0;
        GameObject rabbitControllerObject = GameObject.FindWithTag("RightRabbit");
        {
            if (rabbitControllerObject != null)
            {
                rabbitController = rabbitControllerObject.GetComponent<RightRabbitController>();
            }
        }

        if (rabbitController == null)
        {
            //Debug.Log("Cannot find 'RabbitController' script");
        }

        if (rabbitController.isbrushing)
        {
            isbrushing2 = true;
        }
    }


    void OnTriggerStay(Collider other)
    {
        if ((other.tag == "RedStone" || other.tag == "YellowStone") && isbrushing2)
        {
            rb = other.GetComponent<Rigidbody>();
            rb.AddForce(0.05f, 0, 0.05f, ForceMode.Impulse);
            isbrushing2 = false;
            flags = 1;
        }
    }
}
//Quaternion 도 약간 변경해주기