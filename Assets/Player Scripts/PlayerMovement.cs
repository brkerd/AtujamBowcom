using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public BoxCollider2D groundCheck;
    public Animator animator;
    public LayerMask groundMask;

    public float acceleration;
    [Range(0f, 1f)]
    public float groundDecay;
    public float maxGroundSpeed;

    public float jumpSpeed;

    public bool grounded;
    public bool isFacingRight;
    public Vector3 tpBack;
    float xInput;
    float yInput;
    float startTime;

    public Time_faster faster;
    public Time_slower slower;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        tpBack = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        HandleJump();

        if(Time.time - startTime > 5){
            Debug.Log(transform.position);
            tpBack = transform.position;
            startTime = Time.time;
        }

        animator.SetFloat("Velocity",Mathf.Abs(body.velocity.x));
    }

    void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        
        if(Input.GetKey(KeyCode.Q)){
            slower.Slower();
        }
        if(Input.GetKey(KeyCode.E)){
            faster.Faster();
        }
        if(Input.GetKey(KeyCode.F)){
            TeleportBack();
        }
    }
    void HandleXInput()
    {


        if (Mathf.Abs(xInput) > 0)
        {
            float increment = xInput * acceleration;
            float newSpeed = Mathf.Clamp(body.velocity.x + increment, -maxGroundSpeed, maxGroundSpeed);
            body.velocity = new Vector2(newSpeed, body.velocity.y);

            FaceInput();

        }

    }

    void FaceInput()
    {
        float direction = Mathf.Sign(xInput);
        //transform.localScale = new Vector3(-direction, 1, 1);
        if(direction == -1f){
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = false;
        }
        if(direction == 1f){
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = true;
        }
    }

    void TeleportBack(){
        transform.position = tpBack;
    }

    void FixedUpdate()
    {
        CheckGround();
        HandleXInput();
        ApplyFriction();
    }

    void ApplyFriction()
    {   
        if (grounded && xInput == 0)
        {
            body.velocity = new Vector2(body.velocity.x*groundDecay, body.velocity.y);
        }
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }




}
