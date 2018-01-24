using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitsController : MonoBehaviour {

    public GameObject player; //player: stone

    private Vector3 offset;
    private bool notnull;

    private GameController gameController;

    void Start()
    {
        notnull = false;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        {
            if (gameControllerObject != null)
            {
                gameController = gameControllerObject.GetComponent<GameController>();
            }
        }
        if (gameController == null)
        {
            //Debug.Log("Cannot find 'Gamecontroller' script");
        }
    }

    void FixedUpdate()
    {
        if(gameController.stoneplace)
        {
            offset = new Vector3(-0.2f, -4.9f , -3);
            notnull = true;
        }
    }

    void LateUpdate()
    {
        if (notnull)
        {
            transform.position = gameController.Getplayer().transform.position + offset;
        }

        if( transform.position.z >= 163)
        {
            Destroy(gameObject);
        }

        if(gameController.destroy_rest_rabbit)
        {
            Destroy(gameObject);
        }
    }

}
