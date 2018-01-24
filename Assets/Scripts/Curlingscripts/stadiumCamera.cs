using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stadiumCamera : MonoBehaviour {

    private Vector3 start;
    private Quaternion origin;
    private bool height;
    private bool xaxis;

	// Use this for initialization
	void Start () {
        start = transform.position;
        height = false;
        xaxis = false;
        origin = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (!height && !xaxis)
        {
            transform.Translate(Time.deltaTime*10, 0, 0, Space.World);
            if (transform.position.x >= 73)
            {
                xaxis = true;
            }
        }
        if(!height && xaxis)
        {
            transform.Translate(0, 0, Time.deltaTime*10, Space.World);
            transform.Rotate(Vector3.up * Time.deltaTime * -3, Space.World);
            /*
            if (transform.position.z >= -40 && transform.position.z<=0)
            {
                transform.Rotate(Vector3.up * Time.deltaTime*-10, Space.World);
            }
            */
            if(transform.position.z>=150)
            {
                height = true;
            }
        }
        if(height && xaxis)
        {
            transform.position = start;
            xaxis = false;
            height = false;
            transform.rotation = origin;
        }
	}
}
