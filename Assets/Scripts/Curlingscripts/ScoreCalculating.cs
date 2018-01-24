using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculating : MonoBehaviour {

    private List<GameObject> gameObjectlist = new List<GameObject>();
    public GameObject scoreorigin;

    public Text player1Text;
    public Text player2Text;
    public Text winnerText;

    private int score = 0;
    private int redscore = 0;
    private int yellowscore = 0;
    private int win = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RedStone" || other.gameObject.tag == "YellowStone")
        {
            gameObjectlist.Add(other.gameObject);
            Debug.Log("Enterlist");
            Debug.Log(gameObjectlist);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RedStone" || other.gameObject.tag == "YellowStone")
        {
            gameObjectlist.Remove(other.gameObject);
            Debug.Log("Existlist");
            Debug.Log(gameObjectlist);
        }
    }

    public void Distancefunc()
    {
        if (gameObjectlist != null)
        {
            foreach (GameObject stone in gameObjectlist)
            {
                score = 0;
                float dist = Vector3.Distance(stone.transform.position, scoreorigin.transform.position);
                if (dist <= 1.2)
                {
                    score = 5;
                }
                else if (dist <= 3.23)
                {
                    score = 3;
                }
                else if (dist <= 7.07)
                {
                    score = 2;
                }
                else
                {
                    score = 1;
                }

                if (stone.tag == "RedStone")
                {
                    redscore += score;
                }

                else if (stone.tag == "YellowStone")
                {
                    yellowscore += score;
                }
            }
        }
        //red win
        if (redscore > yellowscore) {
            winnerText.text = "RedTeam Won!";
        }
            
        if (redscore < yellowscore)
        {
            winnerText.text = "YellowTeam Won!";
        }
            
        if (redscore == yellowscore)
        {
            winnerText.text = "Draw!";
        }
            
        player1Text.text = "Player1 Score: " + redscore;
        player2Text.text = "Player2 Score: " + yellowscore;
        
    }
}
