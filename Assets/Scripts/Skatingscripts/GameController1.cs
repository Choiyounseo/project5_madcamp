using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController1 : MonoBehaviour {
    public GameObject ground;
    public Vector3 spawnValues;
    public float spawnWait;
    public float waveWait;
    public int Count;

    public Text restartText;
    public Text gameOverText;
    public Text gobackText;

    private bool restart;
    private bool gameover;

    // Use this for initialization


    void Start () {
        StartCoroutine (SpawnWaves());
        gameover = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        gobackText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }


    IEnumerator SpawnWaves()
    {
        
        while (true)
        {
            int groundCount = Random.Range(1, Count);
            for (int i = 0; i < groundCount; i++)
            {
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(ground, spawnValues, spawnRotation);
            
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameover)
            {
                restartText.text = "Press 'R' for Restart";
                gobackText.text = "Go back to Main";
                restart = true;
                break;
            }
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameover = true;
    }
	
}
