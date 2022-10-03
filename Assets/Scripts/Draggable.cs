using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    public bool isMouseOver = false;
    public bool dragging = false;
    public bool inWorkArea = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) + offset;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        if (GameManager.inputs.Player.ClickDown.triggered && isMouseOver)
        {
            clicked();
        }
        Debug.Log(GameManager.inputs.Player.ClickUp.triggered);

        if (GameManager.inputs.Player.ClickUp.triggered)
        {
            dragging = false;
        }
    }

    public void clicked()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        offset = new Vector3(offset.x, offset.y, 0);
        dragging = true;
    }

    private void OnMouseOver()
    {
        isMouseOver = true;
    }
    
    private void OnMouseExit()
    {
        isMouseOver = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        WorkArea workArea = col.gameObject.GetComponent<WorkArea>();

        if (workArea != null)
        {
            inWorkArea = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D col)
    {
        WorkArea workArea = col.gameObject.GetComponent<WorkArea>();

        if (workArea != null)
        {
            inWorkArea = false;
        }
    }
}
