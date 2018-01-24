using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brushanimate : MonoBehaviour
{
    //private int leftbrushnum;
    //private int rightbrushnum;
    private int brushnum;

    private void Start()
    {
        /*leftbrushnum = 0;
        rightbrushnum = 0;*/
        brushnum = 0;
    }

    private void Update()
    {
        /*if (Input.GetButtonDown("Leftbrush"))
        {
            if(leftbrushnum )
            transform.Rotate(0, -10, 0);
            //transform.Rotate(0, 10, 0);
            //transform.rotation = Quaternion.Euler(155, 90, -90);
        }

        if (Input.GetButtonDown("Rightbrush"))
        {
            transform.Rotate(0, -10, 0);
            //transform.rotation = Quaternion.Euler(155, 180, -90);
        }*/

        if (Input.GetButtonDown("Leftbrush") || Input.GetButtonDown("Rightbrush"))
        {
            if( brushnum%2 == 0 )
            {
                transform.Rotate(0, -10, 0);
            }
            else
            {
                transform.Rotate(0, 10, 0);
            }
            brushnum++;
        }
    }
}