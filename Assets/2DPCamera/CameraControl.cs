using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject objectToFollow;
    GameObject rightMove, leftMove;

    // Start is called before the first frame update
    void Start()
    {
        leftMove = GameObject.Find("LeftMovement");
        rightMove = GameObject.Find("RightMovement");

        leftMove.GetComponent<CinemachineVirtualCamera>().m_Follow
            = rightMove.GetComponent<CinemachineVirtualCamera>().m_Follow
            = objectToFollow.transform;


        leftMove.SetActive(false);
        rightMove.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            leftMove.SetActive(false);
            rightMove.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftMove.SetActive(true);
            rightMove.SetActive(false);
        }
    }
}
