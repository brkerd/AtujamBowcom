using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;

    public float acceleration;
    [Range(0f, 1f)]
    public float groundDecay;
    public float maxGroundSpeed;

    public float jumpSpeed;

    public bool grounded;
    float xInput;
    float yInput;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        HandleJump();
    }

    void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
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
        transform.localScale = new Vector3(-direction, 1, 1);
    }

    void FixedUpdate()
    {
        CheckGround();
        HandleXInput();
        ApplyFriction();
    }

    void ApplyFriction()
    {
        // if (body.velocity.y != 0)
        // {
        //     Debug.Log(body.velocity.y);
        // }
        
        if (grounded && xInput == 0 && (body.velocity.y <= 0f || body.velocity.y >= 0f))
        {
            body.velocity *= groundDecay;
        }
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            float idleJump = body.velocity.y == 0 ? jumpSpeed / groundDecay : jumpSpeed;
            body.velocity = new Vector2(body.velocity.x, idleJump);
        }
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }


}
