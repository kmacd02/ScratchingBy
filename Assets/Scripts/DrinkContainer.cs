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
        Debug.Log("timer: " + timer);

        if (!draggable.dragging && !draggable.inWorkArea)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 5f;
        }

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        DrinkIngredient di = col.gameObject.GetComponent<DrinkIngredient>();
        if (di != null && !di.gameObject.GetComponent<Draggable>().dragging)
        {
            if (!ingredientSwitch(di.getType(), DrinkIngredient.IngredientType.Boba,
                    DrinkIngredient.IngredientType.Jelly) &&
                !ingredientSwitch(di.getType(), DrinkIngredient.IngredientType.Fruit,
                    DrinkIngredient.IngredientType.Milk) &&
                !ingredientSwitch(di.getType(), DrinkIngredient.IngredientType.BlackTea,
                    DrinkIngredient.IngredientType.GreenTea))
            {
                if(!ingredients.Contains(di.getType()) && ingredients.Count < 3)
                {
                    ingredients.Add(di.getType());
                    changeSprite();
                }
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
            if (t == type)
            {
                if(!ingredients.Contains(type) && ingredients.Count < 3)
                {
                    ingredients.Add(type);
                    changeSprite();
                }
            }else if (ingredients.Contains(t))
            {
                ingredients.Remove(t);
            }
        }

        return true;
    }

    void changeSprite()
    {
        int count = ingredients.Count();
        if (count == 0)
            return;
        if (ingredients[0] == DrinkIngredient.IngredientType.GreenTea)
        {
            if (count == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = green;
            }
            else
            {
                if (ingredients[1] == DrinkIngredient.IngredientType.Milk)
                {
                    if (count == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = greenmilk;
                    }
                    else
                    {
                        if (ingredients[2] == DrinkIngredient.IngredientType.Boba)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = greenmilkboba;
                        }
                        else if (ingredients[2] == DrinkIngredient.IngredientType.Jelly)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = greenmilkjelly;
                        }
                    }
                }
                else if (ingredients[1] == DrinkIngredient.IngredientType.Fruit)
                {
                    if (count == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = greenfruit;
                    }
                    else
                    {
                        if (ingredients[2] == DrinkIngredient.IngredientType.Boba)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = greenfruitboba;
                        }
                        else if (ingredients[2] == DrinkIngredient.IngredientType.Jelly)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = greenfruitjelly;
                        }
                    }
                }
            }
        }
        else if (ingredients[0] == DrinkIngredient.IngredientType.BlackTea)
        {
            if (count == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = black;
            }
            else
            {
                if (ingredients[1] == DrinkIngredient.IngredientType.Milk)
                {
                    if (count == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = blackmilk;
                    }
                    else
                    {
                        if (ingredients[2] == DrinkIngredient.IngredientType.Boba)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = blackmilkboba;
                        }
                        else if (ingredients[2] == DrinkIngredient.IngredientType.Jelly)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = blackmilkjelly;
                        }
                    }
                }
                else if (ingredients[1] == DrinkIngredient.IngredientType.Fruit)
                {
                    if (count == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = blackfruit;
                    }
                    else
                    {
                        if (ingredients[2] == DrinkIngredient.IngredientType.Boba)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = blackfruitboba;
                        }
                        else if (ingredients[2] == DrinkIngredient.IngredientType.Jelly)
                        {
                            this.GetComponent<SpriteRenderer>().sprite = blackfruitjelly;
                        }
                    }
                }
            }
        }
    }
}
