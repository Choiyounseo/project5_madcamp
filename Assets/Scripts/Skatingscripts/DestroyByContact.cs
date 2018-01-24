using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    private AudioController audioController;
    public GameObject playerExplosion;
    private int count=0;
    private bool noground = false;
    public float maxDistance,minDistance;

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
    private void FixedUpdate()
    { 
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, maxDistance))
        {
            if (hit.distance > minDistance)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "Player")
        {

            audioController.playDeathAudio();
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

            Destroy(other.gameObject);
            gameController.GameOver();

        }
        if (other.tag == "BronzeCoin")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "SilverCoin")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "GoldCoin")
        {
            Destroy(other.gameObject);
        }

    }
}
