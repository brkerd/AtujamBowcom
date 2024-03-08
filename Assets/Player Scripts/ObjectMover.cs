using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
   float horizontalInput;
    float verticalInput;
    float time = 0f;
    public float movementSpeed_x = 5f;
    public float movementSpeed_y = 0f;
    public float movement_seconds = 5f;
    
    void Start()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
       
        float verticalInput = Input.GetAxis("Vertical");   
    }

    // Update is called once per frame
    void Update()
    {
        time = time+ Time.deltaTime;
       
        if(time < movement_seconds){
            transform.position = transform.position + new Vector3(movementSpeed_x * Time.deltaTime, movementSpeed_y * Time.deltaTime, 0);
        }
        else if(time > 2*movement_seconds){
            time=0;
        }  
        else if(time > movement_seconds){
            transform.position = transform.position - new Vector3(movementSpeed_x * Time.deltaTime, movementSpeed_y * Time.deltaTime, 0);
        }  

    }
}
