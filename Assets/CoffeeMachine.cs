using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    [SerializeField] private CoffeeMachineButton light;
    [SerializeField] private CoffeeMachineButton medium;
    [SerializeField] private CoffeeMachineButton dark;

    private List<CoffeeContainer> coffees = new();
    
    // Start is called before the first frame update
    void Start()
    {
        light.e.AddListener(addIngredientL);
        medium.e.AddListener(addIngredientM);
        dark.e.AddListener(addIngredientD);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addIngredientL()
    {
        foreach (var cof in coffees)
        {
            cof.addIngredient(CoffeeIngredient.IngredientType.Light);
        }
    }

    void addIngredientM()
    {
        foreach (var cof in coffees)
        {
            cof.addIngredient(CoffeeIngredient.IngredientType.Medium);
        }
    }

    void addIngredientD()
    {
        foreach (var cof in coffees)
        {
            cof.addIngredient(CoffeeIngredient.IngredientType.Dark);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        CoffeeContainer cc = col.gameObject.GetComponent<CoffeeContainer>();
        if (cc != null)
        {
            coffees.Add(cc);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        CoffeeContainer cc = other.gameObject.GetComponent<CoffeeContainer>();
        if (cc != null)
        {
            coffees.Remove(cc);
        }
    }
}
