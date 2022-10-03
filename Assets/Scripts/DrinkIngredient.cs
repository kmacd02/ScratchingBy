using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DrinkIngredient : MonoBehaviour
{
    public enum IngredientType
    {
        GreenTea, BlackTea, Milk, Fruit, Plain, Boba, Jelly, NoTopping
    }

    [SerializeField] private IngredientType type;

    private Draggable draggable;
    private float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        draggable = GetComponent<Draggable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (draggable.dragging)
        {
            timer = 5f;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public IngredientType getType()
    {
        return type;
    }
}
