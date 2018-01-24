using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public GameObject Redrabbit;
    public GameObject Yellowrabbit;
    public GameObject arrow;

    public Transform origin;
    public Transform rabbitstart;
    public Transform arrowstart;
    private Rigidbody rb;

    public Camera mainCamera;
    public Camera objectCamera;
    public Camera walkCamera;
    public Camera stadiumCamera;
    public Camera skyCamera;

    public Text player1Text;
    public Text player2Text;
    public Text restartText;
    public Text winnerText;
    public Text gobackText;

    public float turnWait;
    public float startWait;

    private bool player1turn;
    private bool player2turn;
    private bool restart;
    private bool enabled;
    private bool thrown;
    private bool arrowfixed;
    private int num;
    private Vector3 direct;

    private float timeCurrent;
    private float timeAtButtonDown;
    private float timeAtButtonUp;
    private float timeButtonHeld;

    private GameObject selectedObject;
    private GameObject redrabbitObject;
    private GameObject yellowrabbitObject;
    private GameObject arrowObject;
    private int flag;
    private int flag2;
    private int ans;
    public bool stoneplace;
    public bool destroy_rest_rabbit;

    public int redscore;
    public int yellowscore;
    private bool skyon;
    private int nunu;

    private ScoreCalculating scoreCalculating;

    void Start()
    {
        num = 0;
        flag = 0;
        flag2 = 0;
        redscore = 0;
        yellowscore = 0;
        stoneplace = false;
        destroy_rest_rabbit = false;
        timeButtonHeld = 0;
        enabled = true;
        restart = false;
        arrowfixed = true;
        ans = 0;
        thrown = false;
        player1turn = true;
        player2turn = false;
        restartText.text = "";
        player1Text.text = "";
        player2Text.text = "";
        winnerText.text = "";
        gobackText.text = "";
        StartCoroutine(Turns());
        mainCamera.enabled = false;
        objectCamera.enabled = false;
        walkCamera.enabled = false;
        skyCamera.enabled = false;
        stadiumCamera.enabled = true;
        skyon = false;
        nunu = 1;
        stadiumCamera.rect = new Rect(0, 0, 1, 1);
        print("start");
        GameObject scoreCalculatingObject = GameObject.FindWithTag("ScoreRange");
        {
            if (scoreCalculatingObject != null)
            {
                scoreCalculating = scoreCalculatingObject.GetComponent<ScoreCalculating>();
            }
        }
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        timeCurrent = Time.fixedTime;
        //testclone gameobject is made
        if (arrowObject && arrowfixed)
        {
            thrown = false;
            if (enabled)
            {
                arrowObject.transform.RotateAround(Vector3.zero, Vector3.up, Time.deltaTime * 30);
                ans++;
                if (ans >= 120)
                {
                    enabled = false;
                    ans = 0;
                }
            }
            else
            {
                arrowObject.transform.RotateAround(Vector3.zero, Vector3.up, -Time.deltaTime * 30);
                ans++;
                if (ans >= 120)
                {
                    enabled = true;
                    ans = 0;
                }
            }
            // arrowObject.transform.RotateAround(Vector3.zero, Vector3.up, deltaAngle);

        }
        //print(walkCamera.enabled);
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown("enter"))
        {
            print("Yes");
            stadiumCamera.enabled = false;
            mainCamera.enabled = true;
            mainCamera.rect = new Rect(0, 0, 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (thrown)
            {
                walkCamera.enabled = true;
                mainCamera.enabled = false;
                ChangeSplitScreen(objectCamera,walkCamera);
                print("thrown Pressed");
            }
            else
            {
                walkCamera.enabled = false;
                mainCamera.enabled = true;
                ChangeSplitScreen(objectCamera, mainCamera);
                print("Key Q");
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            nunu++;
            print("pressed S");
            
           // while the ball is rolling trying to turn on skycamera
           // Doing fine
            if (!mainCamera.enabled && walkCamera.enabled)
            {
                skyon = true;
                print("Hello1~~");
                walkCamera.enabled = false;
                skyCamera.enabled = true;
                skyCamera.rect = new Rect(0, 0, 1, 1);
            }
         
            // while the ball is rolling trying to turn off skycamera
            if (!mainCamera.enabled && (nunu%2==1))
            {
                print("Hello2~~");
                walkCamera.enabled = true;
                skyCamera.enabled = false;
                walkCamera.rect = new Rect(0, 0, 1, 1);
                skyon = false;
            }

        }
        if(thrown&&(redrabbitObject||yellowrabbitObject))
        {
            if (!skyCamera.enabled)
            {
                print("Key skyCam");
                walkCamera.enabled = true;
                mainCamera.enabled = false;
                walkCamera.rect = new Rect(0, 0, 1, 1);
            }
        }
        if(thrown&& !(redrabbitObject || yellowrabbitObject))
        {
            if (!skyCamera.enabled)
            {
                print("Key skyCam2");
                walkCamera.enabled = false;
                objectCamera.enabled = true;
                objectCamera.rect = new Rect(0, 0, 1, 1);
            }
        }
        if(!thrown&&!stadiumCamera.enabled)
        {
            print("Key skyCam3");
            if (!skyCamera.enabled)
            {
                print("Key skyCam4");
                mainCamera.enabled = true;
                walkCamera.enabled = false;
                mainCamera.rect = new Rect(0, 0, 1, 1);
            }
        }
       
    }
    void ChangeSplitScreen( Camera small, Camera big)
    {
        // target camera is on
        if (small.enabled)
        {
            small.enabled = false;
            big.rect = new Rect(0, 0, 1, 1);
        }
        // target camera is off
        else
        {
            small.enabled = true;
            //small.rect = new Rect(0, 0, 0.5f, 1);
            //small.rect = new Rect(0.4f, 0.4f, 0.2f, 1);
            small.rect = new Rect(0.8f, 0, 0.2f, 0.5f);
            big.rect = new Rect(0.5f, 0, 0.5f, 1);
        }

    }
    void FixedUpdate()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            flag = 1;
            timeAtButtonDown = timeCurrent;
        }
        if (flag == 1 && Input.GetMouseButtonUp(0))
        {
            timeAtButtonUp = timeCurrent;
            timeButtonHeld = (timeAtButtonUp - timeAtButtonDown);
            addforcefunc();
            //Debug.Log(selectedObject.transform.position);

            if ((num % 2) == 0) //it was player2's turn => now change to player1turn
            {
                player1turn = true;
            }
            else if ((num % 2) == 1)
            {
                player2turn = true;
            }

        }
        */
        // Get Space button just once 
        // This space button chooses which direction the ball will go
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flag2 = 1;
            timeAtButtonDown = timeCurrent;
            arrowfixed = false;
            //whoplayer++;
            direct = arrowObject.transform.position - origin.position;
            direct = direct.normalized;

        }
        if (flag2 == 1 && Input.GetKey(KeyCode.Space))
        {
            arrowObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.0f);
            timeAtButtonUp = timeCurrent;
            timeButtonHeld = (timeAtButtonUp - timeAtButtonDown);
            //print(timeButtonHeld);
            Destroy(arrowObject, 1.0f);
            addforcefunc(direct);
            if ((num % 2) == 0) //it was player2's turn => now change to player1turn
            {
                player1turn = true;
                // arrowfixed = true;
            }
            else if ((num % 2) == 1)
            {
                player2turn = true;
                // arrowfixed = true;
            }
        }
        if ((selectedObject != null) && (selectedObject.transform.position.z >= 36))
        {
            stoneplace = true;
            if(selectedObject.transform.position.z > 163)
            {
                stoneplace = false;
            }
        }

        if( rb != null && rb.velocity.sqrMagnitude < 0.001 && selectedObject.transform.position.z >=10)
        {
            stoneplace = false;
        }
        
    }

    IEnumerator Turns()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            if (player1turn && !stoneplace &&!stadiumCamera.enabled)
            {
                if (yellowrabbitObject != null)
                {
                    Destroy(yellowrabbitObject);
                    yield return new WaitForSeconds(3);
                }
                ans = 0;
                enabled = true;
               
                player1Text.text = "Player1 turn";
                player2Text.text = "";
                selectedObject = Instantiate(player1, origin.position, origin.rotation);
                redrabbitObject = Instantiate(Redrabbit, rabbitstart.position, rabbitstart.rotation);
                arrowObject = Instantiate(arrow, arrowstart.position, arrowstart.rotation);
                //print(arrowObject);
                player1turn = false;
                num++;
                arrowfixed = true;
                ans = 0;
            }

            if (player2turn && !stoneplace)
            {
                if (redrabbitObject != null)
                {
                    Destroy(redrabbitObject);
                    yield return new WaitForSeconds (3);
                }
                ans = 0;
                enabled = true;
              //  thrown = false;
                player2Text.text = "Player2 turn";
                player1Text.text = "";
                selectedObject = Instantiate(player2, origin.position, origin.rotation);
                yellowrabbitObject = Instantiate(Yellowrabbit, rabbitstart.position, rabbitstart.rotation);
                arrowObject = Instantiate(arrow, arrowstart.position, arrowstart.rotation);
                //print(arrowObject);
                player2turn = false;
                num++;
                arrowfixed = true;
                ans = 0;
            }

            yield return new WaitForSeconds(turnWait);

            if (num == 6)
            {
                yield return new WaitForSeconds(10);
                FinalScore();
                restartText.text = "Press 'R' for Restart";
                gobackText.text = "Go Back to Main";
                restart = true;
                break;
            }
        }
    }

    void addforcefunc(Vector3 position)
    {
        rb = selectedObject.GetComponent<Rigidbody>();
        rb.AddForce(2 * position.x, 2 * position.y, 2 * position.z, ForceMode.Impulse);
        rb.rotation = Quaternion.Euler(-90, 0.0f, 0.0f);
        thrown = true;
    }

    public GameObject Getplayer()
    {
        return selectedObject;
    }

    void FinalScore()
    {
        if( scoreCalculating!= null)
        {
            scoreCalculating.Distancefunc();
        }
    }
}

//mouseclick 횟수가 너무 짧을경우, try again 만들기
//Async 문제..? player1, player1인 경우도 다수 발생...고치기!