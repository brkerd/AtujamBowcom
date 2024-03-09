using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public bool pressing;

    private void Start() { pressing  = false; }

    private void OnTriggerEnter2D(Collider2D collision) { pressing = true; }

    private void OnTriggerExit2D(Collider2D collision) { pressing = false; }

    public bool IsPressed() { return pressing; }
}
