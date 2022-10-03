using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrinkContainer : MonoBehaviour
{
    private List<DrinkIngredient.IngredientType> ingredients = new();

    public List<DrinkIngredient.IngredientType> getIngredients()
    {
        return ingredients;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        DrinkIngredient di = col.gameObject.GetComponent<DrinkIngredient>();
        if (di != null && !di.gameObject.GetComponent<Draggable>().dragging)
        {
            if (!ingredientSwitch(di.getType(), DrinkIngredient.IngredientType.Fruit,
                    DrinkIngredient.IngredientType.Milk) &&
                !ingredientSwitch(di.getType(), DrinkIngredient.IngredientType.BlackTea,
                    DrinkIngredient.IngredientType.GreenTea))
            {
                if(!ingredients.Contains(di.getType())) ingredients.Add(di.getType());
            }
            
            Destroy(col.gameObject);
            Debug.Log(ingredients.Count);
            foreach (var type in ingredients)
            {
                Debug.Log(type.ToString());
            }
        }
    }

    bool ingredientSwitch(DrinkIngredient.IngredientType type, params DrinkIngredient.IngredientType[] ingredientTypes)
    {
        if (!ingredientTypes.Contains(type))
        {
            return false;
        }
        foreach (var t in ingredientTypes)
        {
            if (t == type && !ingredients.Contains(type))
            {
                ingredients.Add(type);
            }else if (ingredients.Contains(t))
            {
                ingredients.Remove(t);
            }
        }

        return true;
    }
}
