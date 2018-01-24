using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    private Rigidbody rb;
    private int coinCount;
    public float xMin, xMax,yMax;
    public float jumpPower;
    public Text countText;


    private AudioClip bronzeAudioClip;
    private AudioClip silverAudioClip;
    private AudioClip goldAudioClip;

    private AudioClip jumpAudioClip;

    private AudioSource audioSource;
    

    [SerializeField]
    private float speed;
    private Animator anim;


    [SerializeField]
    GameObject platform;

    [SerializeField]
    Transform firstobject;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        coinCount = 0;
        SetCountText(0);

        audioSource = GetComponent<AudioSource>();

        bronzeAudioClip = Resources.Load<AudioClip>("Audio/예");
        silverAudioClip = Resources.Load<AudioClip>("Audio/신난다!");
        goldAudioClip = Resources.Load<AudioClip>("Audio/음마이쪙");
   
        jumpAudioClip = Resources.Load<AudioClip>("Audio/워후_1");
        


    }
    private void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        // rb.velocity = new Vector3(moveHorizontal * speed , 0,0);
        // rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax),0.2f , 0.0f  );
        rb.position = new Vector3(Mathf.Clamp(rb.position.x + moveHorizontal * speed * Time.deltaTime, xMin, xMax), rb.position.y, -5.2f);
    }

   

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(jumpAudioClip, 1.0f);
            rb.AddForce(0f, jumpPower, 0f,ForceMode.Impulse);
            anim.Play("Jumping" );
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BronzeCoin"))
        {
            audioSource.PlayOneShot(bronzeAudioClip, 1.0f);
            Destroy(other.gameObject);
            SetCountText(100);
        }
        else if (other.gameObject.CompareTag("SilverCoin"))
        {
            audioSource.PlayOneShot(silverAudioClip, 1.0f);
            Destroy(other.gameObject);

            SetCountText(500);
        }
        else if (other.gameObject.CompareTag("GoldCoin"))
        {
            audioSource.PlayOneShot(goldAudioClip, 1.0f);
            Destroy(other.gameObject);

            SetCountText(1000);
        }

    }
    void SetCountText(int count)
    {
        coinCount += count;
        countText.text = "MEDAL: " + (coinCount).ToString();
    }
}
