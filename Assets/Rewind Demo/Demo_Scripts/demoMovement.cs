using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoMovement : MonoBehaviour
   
{
    Vector3 move, move2;
    public float rotSpeed = 0.5f;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        move = new Vector3(1f, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(move);

        if (count++ < 100)
        gameObject.GetComponent<Rigidbody2D>().AddForce(move);


    }
}
