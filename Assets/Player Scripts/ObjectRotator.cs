using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
  public float rotateX =0, rotateY =0, rotateZ=0; 
    
      void Update()
    {
       transform.Rotate(xAngle: rotateX*Time.deltaTime, yAngle: rotateY*Time.deltaTime, zAngle: rotateZ*Time.deltaTime); 
    }
}
