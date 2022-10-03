using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ingredient;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        GameObject g = Instantiate(ingredient, position, Quaternion.identity);
        g.GetComponent<Draggable>().clicked();
    }
}
