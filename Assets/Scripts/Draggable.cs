using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCam;
    public bool dragging = false;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        offset = transform.position - mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        offset = new Vector3(offset.x, offset.y, 0);
        dragging = true;
    }

    private void OnMouseDrag()
    {
        transform.position = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue()) + offset;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
