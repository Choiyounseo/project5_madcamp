using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByWave : MonoBehaviour {

    public GameObject playerExplosion;
    private AudioController audioController;
    private GameController1 gameController;

    private AudioClip deathAudioClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioController>();

        deathAudioClip = Resources.Load<AudioClip>("Audio/예");

        GameObject gameControllerObject = GameObject.FindWithTag("GameController2");
        {
            if (gameControllerObject != null)
            {
                gameController = gameControllerObject.GetComponent<GameController1>();
            }
        }

    }


    // Use this for initialization
    private void OnTriggerStay(Collider other)
    {

        
        if (other.tag == "Player")
        {
            audioController.playDeathAudio();
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

            Destroy(other.gameObject);
            gameController.GameOver();
        }
        
        
    }
}
