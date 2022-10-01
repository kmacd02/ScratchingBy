using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkIngredient : MonoBehaviour
{
    public enum IngredientType
    {
        GreenTea, BlackTea, Milk, Fruit
    }

    [SerializeField] private IngredientType type;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IngredientType getType()
    {
        return type;
    }
}
