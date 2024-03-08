using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float drag = 0.9f;
    public Rigidbody2D body;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    public bool grounded;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(xInput)>0)
        {
            body.velocity = new Vector2(xInput*speed, body.velocity.y);
        }
        if (Mathf.Abs(yInput)>0)
        {
            body.velocity = new Vector2(body.velocity.x, yInput*speed);
        }


        Vector2 direction = new Vector2(xInput,yInput).normalized;
        body.velocity = direction*speed;
    }

    void FixedUpdate() {
        CheckGround();
        if (grounded){
            body.velocity *= drag;
        }
    }

    void CheckGround(){
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }
}
