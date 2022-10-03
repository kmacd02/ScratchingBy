using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ingredient;
    [SerializeField] private bool limitedQuantity = false;
    [NonSerialized] public int amount = 0;
    private SpriteRenderer highlight;

    private SpriteRenderer sp;
    
    // Start is called before the first frame update
    void Start()
    {
        highlight = GetComponentInChildren<SpriteRenderer>();
        if (limitedQuantity) sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (limitedQuantity)
        {
            sp.enabled = amount > 0;
        }
    }

    private void OnMouseDown()
    {
        if (!limitedQuantity || amount > 0)
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            GameObject g = Instantiate(ingredient, position, Quaternion.identity);
            g.GetComponent<Draggable>().clicked();
            if (limitedQuantity) amount--;
        }
    }

    private void OnMouseOver()
    {
        highlight.enabled = true;
    }

    private void OnMouseExit()
    {
        highlight.enabled = false;
    }
}
