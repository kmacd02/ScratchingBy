using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    private List<DrinkIngredient.IngredientType> ingredients;
    private List<CoffeeIngredient.IngredientType> cingredients;

    [SerializeField] private GameObject ccef;
    private CoffeeContainer cef;

    [SerializeField] Sprite green;
    [SerializeField] Sprite black;
    [SerializeField] Sprite greenfruit;
    [SerializeField] Sprite greenmilk;
    [SerializeField] Sprite greenfruitboba;
    [SerializeField] Sprite greenfruitjelly;
    [SerializeField] Sprite greenmilkboba;
    [SerializeField] Sprite greenmilkjelly;
    [SerializeField] Sprite blackfruit;
    [SerializeField] Sprite blackmilk;
    [SerializeField] Sprite blackfruitboba;
    [SerializeField] Sprite blackfruitjelly;
    [SerializeField] Sprite blackmilkboba;
    [SerializeField] Sprite blackmilkjelly;

    [Space] 
    [SerializeField] private Sprite croissant;
    [SerializeField] private Sprite donut;
    [SerializeField] private Sprite roll;
    [SerializeField] private Sprite taiyaki;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSpeech()
    {
        GameObject order = gameObject.transform.GetChild(0).gameObject;
        
        cef = ccef.GetComponent<CoffeeContainer>();
        
        cingredients = gameObject.transform.parent.gameObject.GetComponent<Customer>().coffeeOrder;

        if (cingredients.Count > 0)
        {
            int ccount = cingredients.Count;
            if (ccount == 0)
                return;
            if (cingredients.Contains(CoffeeIngredient.IngredientType.Light))
            {
                if (ccount == 1)
                {
                    order.GetComponent<SpriteRenderer>().sprite = cef.light;
                }
                else
                {
                    if (cingredients.Contains(CoffeeIngredient.IngredientType.Cream))
                    {
                        if (ccount == 2)
                        {
                            order.GetComponent<SpriteRenderer>().sprite = cef.creamLight;
                        }
                        else
                        {
                            if (cingredients.Contains(CoffeeIngredient.IngredientType.Ice))
                            {
                                order.GetComponent<SpriteRenderer>().sprite = cef.icedCreamLight;
                            }
                        }
                    }
                    else if (cingredients.Contains(CoffeeIngredient.IngredientType.Carmel))
                    {
                        if (ccount == 2)
                        {
                            order.GetComponent<SpriteRenderer>().sprite = cef.carmelLight;
                        }
                        else
                        {
                            if (cingredients.Contains(CoffeeIngredient.IngredientType.Ice))
                            {
                                order.GetComponent<SpriteRenderer>().sprite = cef.icedCarmelLight;
                            }
                        }
                    }
                }
            }
            else if (cingredients.Contains(CoffeeIngredient.IngredientType.Medium))
            {
                if (ccount == 1)
                {
                    order.GetComponent<SpriteRenderer>().sprite = cef.medium;
                }
                else
                {
                    if (cingredients.Contains(CoffeeIngredient.IngredientType.Cream))
                    {
                        if (ccount == 2)
                        {
                            order.GetComponent<SpriteRenderer>().sprite = cef.creamMedium;
                        }
                        else
                        {
                            if (cingredients.Contains(CoffeeIngredient.IngredientType.Ice))
                            {
                                order.GetComponent<SpriteRenderer>().sprite = cef.icedCreamMedium;
                            }
                        }
                    }
                    else if (cingredients.Contains(CoffeeIngredient.IngredientType.Carmel))
                    {
                        if (ccount == 2)
                        {
                            order.GetComponent<SpriteRenderer>().sprite = cef.carmelMedium;
                        }
                        else
                        {
                            if (cingredients.Contains(CoffeeIngredient.IngredientType.Ice))
                            {
                                order.GetComponent<SpriteRenderer>().sprite = cef.icedCarmelMedium;
                            }
                        }
                    }
                }
            }
            else if (cingredients.Contains(CoffeeIngredient.IngredientType.Dark))
            {
                if (ccount == 1)
                {
                    order.GetComponent<SpriteRenderer>().sprite = cef.dark;
                }
                else
                {
                    if (cingredients.Contains(CoffeeIngredient.IngredientType.Cream))
                    {
                        if (ccount == 2)
                        {
                            order.GetComponent<SpriteRenderer>().sprite = cef.creamDark;
                        }
                        else
                        {
                            if (cingredients.Contains(CoffeeIngredient.IngredientType.Ice))
                            {
                                order.GetComponent<SpriteRenderer>().sprite = cef.icedCreamDark;
                            }
                        }
                    }
                    else if (cingredients.Contains(CoffeeIngredient.IngredientType.Carmel))
                    {
                        if (ccount == 2)
                        {
                            order.GetComponent<SpriteRenderer>().sprite = cef.carmelDark;
                        }
                        else
                        {
                            if (cingredients.Contains(CoffeeIngredient.IngredientType.Ice))
                            {
                                order.GetComponent<SpriteRenderer>().sprite = cef.icedCarmelDark;
                            }
                        }
                    }
                }
            }
            return;
        }
        
        string food = gameObject.transform.parent.gameObject.GetComponent<Customer>().getOrderFood();
        
        if (!string.IsNullOrEmpty(food))
        {
            switch (food)
            {
                case "taiyaki":
                    order.GetComponent<SpriteRenderer>().sprite = taiyaki;
                    break;
                case "roll":
                    order.GetComponent<SpriteRenderer>().sprite = roll;
                    break;
                case "donut":
                    order.GetComponent<SpriteRenderer>().sprite = donut;
                    break;
                case "croissant":
                    order.GetComponent<SpriteRenderer>().sprite = croissant;
                    break;
            }
            return;
        }
        
        ingredients = gameObject.transform.parent.gameObject.GetComponent<Customer>().getOrder();

        int count = ingredients.Count;
        if (count == 0)
            return;
        if (ingredients.Contains(DrinkIngredient.IngredientType.GreenTea))
        {
            if (count == 1)
            {
                order.GetComponent<SpriteRenderer>().sprite = green;
            }
            else
            {
                if (ingredients.Contains(DrinkIngredient.IngredientType.Milk))
                {
                    if (count == 2)
                    {
                        order.GetComponent<SpriteRenderer>().sprite = greenmilk;
                    }
                    else
                    {
                        if (ingredients.Contains(DrinkIngredient.IngredientType.Boba))
                        {
                            order.GetComponent<SpriteRenderer>().sprite = greenmilkboba;
                        }
                        else if (ingredients.Contains(DrinkIngredient.IngredientType.Jelly))
                        {
                            order.GetComponent<SpriteRenderer>().sprite = greenmilkjelly;
                        }
                    }
                }
                else if (ingredients.Contains(DrinkIngredient.IngredientType.Fruit))
                {
                    if (count == 2)
                    {
                        order.GetComponent<SpriteRenderer>().sprite = greenfruit;
                    }
                    else
                    {
                        if (ingredients.Contains(DrinkIngredient.IngredientType.Boba))
                        {
                            order.GetComponent<SpriteRenderer>().sprite = greenfruitboba;
                        }
                        else if (ingredients.Contains(DrinkIngredient.IngredientType.Jelly))
                        {
                            order.GetComponent<SpriteRenderer>().sprite = greenfruitjelly;
                        }
                    }
                }
            }
        }
        else if (ingredients.Contains(DrinkIngredient.IngredientType.BlackTea))
        {
            if (count == 1)
            {
                order.GetComponent<SpriteRenderer>().sprite = black;
            }
            else
            {
                if (ingredients.Contains(DrinkIngredient.IngredientType.Milk))
                {
                    if (count == 2)
                    {
                        order.GetComponent<SpriteRenderer>().sprite = blackmilk;
                    }
                    else
                    {
                        if (ingredients.Contains(DrinkIngredient.IngredientType.Boba))
                        {
                            order.GetComponent<SpriteRenderer>().sprite = blackmilkboba;
                        }
                        else if (ingredients.Contains(DrinkIngredient.IngredientType.Jelly))
                        {
                            order.GetComponent<SpriteRenderer>().sprite = blackmilkjelly;
                        }
                    }
                }
                else if (ingredients.Contains(DrinkIngredient.IngredientType.Fruit))
                {
                    if (count == 2)
                    {
                        order.GetComponent<SpriteRenderer>().sprite = blackfruit;
                    }
                    else
                    {
                        if (ingredients.Contains(DrinkIngredient.IngredientType.Boba))
                        {
                            order.GetComponent<SpriteRenderer>().sprite = blackfruitboba;
                        }
                        else if (ingredients.Contains(DrinkIngredient.IngredientType.Jelly))
                        {
                            order.GetComponent<SpriteRenderer>().sprite = blackfruitjelly;
                        }
                    }
                }
            }
        }
    }
}
