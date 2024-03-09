using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public ButtonControl buttonToListen;
    public int maxHeight = 430;
    public float speed = 0.005f;

    private int position = 0;

    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        move = new Vector3(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonToListen.IsPressed() && position < maxHeight)
        {
            transform.position += move;
            position++;
        }

        else if (!buttonToListen.IsPressed() && position > 0)
        {
            transform.position -= move;
            position--;
        }

        Debug.Log(position);
 
    }
}
