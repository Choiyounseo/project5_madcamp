/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculate : MonoBehaviour {

    public GameObject scoreorigin;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        {
            if (gameControllerObject != null)
            {
                gameController = gameControllerObject.GetComponent<GameController>();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RedStone"))
        {
            Distancefunc(other.gameObject.transform.position, gameController.redscore);
        }

        if(other.gameObject.CompareTag("YellowStone"))
        {
            Distancefunc(other.gameObject.transform.position, gameController.yellowscore);
        }
    }

    void Distancefunc(Vector3 position, int score)
    {
        float dist = Vector3.Distance(position, scoreorigin.transform.position);

        if(dist <= 0.89)
        {
            score += 5;
        }
        else if( dist <= 3.09)
        {
            score += 3;
        }
        else if( dist <= 6.23)
        {
            score += 2;
        }
        else if( dist <= 9.18)
        {
            score += 1;
        }
        else
        {
            score += 100;
        }
        Debug.Log("RedScore!");
        Debug.Log(gameController.redscore);
    }
}*/
