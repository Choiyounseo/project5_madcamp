using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    private AudioClip deathSound;

    private AudioSource audioSource;

    void Start () {
        audioSource = GetComponent<AudioSource>();
        deathSound = Resources.Load<AudioClip>("Audio/죽음3");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playDeathAudio()
    {
        audioSource.PlayOneShot(deathSound);
    }
}
