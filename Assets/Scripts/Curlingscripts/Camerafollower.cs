using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollower : MonoBehaviour {
    private GameObject player;

    private Vector3 offset;
    private Vector3 start;
    private bool red;
    private bool yellow;
    private float smoothSpeed = 0.5f;
	// Use this for initialization
	void Start () {

        //Calculate the offset value 
        start = transform.position;
        red = false;
        yellow = false;
        
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (!player)
        {
            red = false;
            yellow = false;
            transform.position = start;
        }
        if (GameObject.FindGameObjectWithTag("Red")&&!red)
        {
            player = GameObject.FindGameObjectWithTag("Red");
            offset = transform.position - player.transform.position;
            red = true;
            
        }
        if (GameObject.FindGameObjectWithTag("Yellow")&&!yellow)
        {
            player = GameObject.FindGameObjectWithTag("Yellow");
            yellow = true;
            offset = transform.position - player.transform.position;
           
        }
        // Set the position of the camera's transform relative to player
        if (red||yellow)
        {
           

            Vector3 desiredPosition = player.transform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime*2);
            transform.position = smoothedPosition;
            
        }
        
    }
       
	
}
