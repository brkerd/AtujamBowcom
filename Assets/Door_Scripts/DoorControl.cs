using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public List<ButtonControl> buttonsToListen;
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
        foreach(ButtonControl button in buttonsToListen)
        {
            
            if (button.IsPressed() && position < maxHeight)
            {
                transform.position += move;
                position++;
                return;
            }
        }


        if (position > 0)
        {
            transform.position -= move;
            position--;
        }

    }
}
