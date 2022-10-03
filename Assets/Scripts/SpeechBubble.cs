using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    private List<DrinkIngredient.IngredientType> ingredients;

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
        ingredients = gameObject.transform.parent.gameObject.GetComponent<Customer>().getOrder();
        GameObject order = gameObject.transform.GetChild(0).gameObject;

        int count = ingredients.Count;
        if (count == 0)
            return;
        if (ingredients[0] == DrinkIngredient.IngredientType.GreenTea)
        {
            if (count == 1)
            {
                order.GetComponent<SpriteRenderer>().sprite = green;
            }
            else
            {
                if (ingredients[1] == DrinkIngredient.IngredientType.Milk)
                {
                    if (count == 2)
                    {
                        order.GetComponent<SpriteRenderer>().sprite = greenmilk;
                    }
                    else
                    {
                        if (ingredients[2] == DrinkIngredient.IngredientType.Boba)
                        {
                            order.GetComponent<SpriteRenderer>().sprite = greenmilkboba;
                        }
                        else if (ingredients[2] == DrinkIngredient.IngredientType.Jelly)
                        {
                            order.GetComponent<SpriteRenderer>().sprite = greenmilkjelly;
                        }
                    }
                }
                else if (ingredients[1] == DrinkIngredient.IngredientType.Fruit)
                {
                    if (count == 2)
                    {
                        order.GetComponent<SpriteRenderer>().sprite = greenfruit;
                    }
                    else
                    {
                        if (ingredients[2] == DrinkIngredient.IngredientType.Boba)
                        {
                            order.GetComponent<SpriteRenderer>().sprite = greenfruitboba;
                        }
                        else if (ingredients[2] == DrinkIngredient.IngredientType.Jelly)
                        {
                            order.GetComponent<SpriteRenderer>().sprite = greenfruitjelly;
                        }
                    }
                }
            }
        }
        else if (ingredients[0] == DrinkIngredient.IngredientType.BlackTea)
        {
            if (count == 1)
            {
                order.GetComponent<SpriteRenderer>().sprite = black;
            }
            else
            {
                if (ingredients[1] == DrinkIngredient.IngredientType.Milk)
                {
                    if (count == 2)
                    {
                        order.GetComponent<SpriteRenderer>().sprite = blackmilk;
                    }
                    else
                    {
                        if (ingredients[2] == DrinkIngredient.IngredientType.Boba)
                        {
                            order.GetComponent<SpriteRenderer>().sprite = blackmilkboba;
                        }
                        else if (ingredients[2] == DrinkIngredient.IngredientType.Jelly)
                        {
                            order.GetComponent<SpriteRenderer>().sprite = blackmilkjelly;
                        }
                    }
                }
                else if (ingredients[1] == DrinkIngredient.IngredientType.Fruit)
                {
                    if (count == 2)
                    {
                        order.GetComponent<SpriteRenderer>().sprite = blackfruit;
                    }
                    else
                    {
                        if (ingredients[2] == DrinkIngredient.IngredientType.Boba)
                        {
                            order.GetComponent<SpriteRenderer>().sprite = blackfruitboba;
                        }
                        else if (ingredients[2] == DrinkIngredient.IngredientType.Jelly)
                        {
                            order.GetComponent<SpriteRenderer>().sprite = blackfruitjelly;
                        }
                    }
                }
            }
        }
    }
}
