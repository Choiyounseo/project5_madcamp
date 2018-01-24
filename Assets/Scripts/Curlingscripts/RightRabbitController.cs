using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRabbitController : MonoBehaviour {

    public float speed = 3f;
    public float jumpPower = 5f;
    public float rotateSpeed = 10f;

    private RightRabbitplaceAccelerate rightplaceAccelerate;

    Rigidbody rb;
    Animator animator;

    // 이동 관련
    Vector3 movement;
    float horizontalMove;
    float verticalMove;

    // 점프
    bool isJumping;

    public bool isbrushing;

    private CharacterController controller;

    private int hashHit = Animator.StringToHash("Base Layer.Hit");
    private int hashDead = Animator.StringToHash("Base Layer.Dead");
    private int hashWalk = Animator.StringToHash("Base Layer.Walk");
    private int hashJump = Animator.StringToHash("Base Layer.Jump");
    private int hashPick = Animator.StringToHash("Base Layer.Pick");
    private int hashPunch = Animator.StringToHash("Base Layer.Punch");

    // Use this for initialization
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.speed = speed;
        isbrushing = false;

        GameObject rightplaceAccelerateObject = GameObject.FindWithTag("Rightplace");
        {
            if (rightplaceAccelerateObject != null)
            {
                rightplaceAccelerate = rightplaceAccelerateObject.GetComponent<RightRabbitplaceAccelerate>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        /*
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        */
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");


        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        if (Input.GetButtonDown("Rightbrush"))
        {
            isbrushing = true;
            animator.Play(hashPunch);
        }

        if (rightplaceAccelerate == null)
        {
            //Debug.Log("Cannot find 'RightplaceAccelerate' script");
        }

        if (rightplaceAccelerate.flags == 1)
        {
            isbrushing = false;
        }

        //AnimationUpdate();

    }
/*
    private void FixedUpdate()
    {
        Run();
        //Turn();
        //Jump();
    }


    // Animation Function

    void AnimationUpdate()
    {
        // moving
        bool move = (horizontalMove != 0.0f || verticalMove != 0.0f);
        animator.speed = move ? 2.0f : 1.0f;
        animator.SetFloat("Speed", move ? 1.0f : 0.0f);
    }

    private bool isStop()
    {
        return (horizontalMove == 0 && verticalMove == 0);
    }


    // Active Function

    public void Run()
    {
        movement.Set(horizontalMove, 0, verticalMove);
        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    public void Turn()
    {

        if (isStop())
        {
            return;
        }
        Quaternion newRotation = Quaternion.LookRotation(movement);

        rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }


    public void ForceJump()
    {
        isJumping = true;
    }


    public void Jump()
    {
        if (!isJumping)
            return;

        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

        isJumping = false;

    }*/
}
