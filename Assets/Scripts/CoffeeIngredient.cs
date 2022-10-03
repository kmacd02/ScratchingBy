using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CoffeeIngredient : MonoBehaviour
{
    public enum IngredientType
    {
        Light, Medium, Dark, Carmel, Cream, Ice
    }

    [SerializeField] private IngredientType type;

    private Draggable draggable;
    private float timer = 0.1f;

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
            timer = 0.1f;
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
