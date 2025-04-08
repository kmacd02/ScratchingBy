using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoffeeContainer : MonoBehaviour
{
    [SerializeField] private bool disabled;
    [NonSerialized] public List<CoffeeIngredient.IngredientType> ingredients = new();

    public List<CoffeeIngredient.IngredientType> getIngredients()
    {
        return ingredients;
    }

    [SerializeField] public Sprite light;
    [SerializeField] public Sprite medium;
    [SerializeField] public Sprite dark;
    [SerializeField] public Sprite creamLight;
    [SerializeField] public Sprite creamMedium;
    [SerializeField] public Sprite creamDark;
    [SerializeField] public Sprite carmelLight;
    [SerializeField] public Sprite carmelMedium;
    [SerializeField] public Sprite carmelDark;
    [SerializeField] public Sprite icedCreamLight;
    [SerializeField] public Sprite icedCreamMedium;
    [SerializeField] public Sprite icedCreamDark;
    [SerializeField] public Sprite icedCarmelLight;
    [SerializeField] public Sprite icedCarmelMedium;
    [SerializeField] public Sprite icedCarmelDark;

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
        if(disabled) return;
        if (!draggable.dragging && !draggable.inWorkArea)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0.1f;
        }

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void addIngredient(CoffeeIngredient.IngredientType type)
    {
        if (!ingredientSwitch(type, CoffeeIngredient.IngredientType.Dark,
                CoffeeIngredient.IngredientType.Medium, CoffeeIngredient.IngredientType.Light) &&
            !ingredientSwitch(type, CoffeeIngredient.IngredientType.Cream,
                CoffeeIngredient.IngredientType.Carmel))
        {
            if(!ingredients.Contains(type) && ingredients.Count < 3)
            {
                ingredients.Add(type);
                changeSprite();
            }
        }
        foreach (var types in ingredients)
        {
            Debug.Log(types.ToString());
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        CoffeeIngredient di = col.gameObject.GetComponent<CoffeeIngredient>();
        if (di != null && !di.gameObject.GetComponent<Draggable>().dragging)
        {
            if (!ingredientSwitch(di.getType(), CoffeeIngredient.IngredientType.Dark,
                    CoffeeIngredient.IngredientType.Medium, CoffeeIngredient.IngredientType.Light) &&
                !ingredientSwitch(di.getType(), CoffeeIngredient.IngredientType.Cream,
                    CoffeeIngredient.IngredientType.Carmel))
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

    bool ingredientSwitch(CoffeeIngredient.IngredientType type, params CoffeeIngredient.IngredientType[] ingredientTypes)
    {
        if (!ingredientTypes.Contains(type))
        {
            return false;
        }
        foreach (var t in ingredientTypes)
        {
            if (t == type)
            {
                if(!ingredients.Contains(type))
                {
                    ingredients.Add(type);
                }
            }else if (ingredients.Contains(t))
            {
                ingredients.Remove(t);
            }
        }

        changeSprite();
        return true;
    }

    void changeSprite()
    {
        Debug.Log("test");
        int count = ingredients.Count();
        if (count == 0)
            return;
        if (ingredients.Contains(CoffeeIngredient.IngredientType.Light))
        {
            if (count == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = light;
            }
            else
            {
                if (ingredients.Contains(CoffeeIngredient.IngredientType.Cream))
                {
                    if (count == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = creamLight;
                    }
                    else
                    {
                        if (ingredients.Contains(CoffeeIngredient.IngredientType.Ice))
                        {
                            this.GetComponent<SpriteRenderer>().sprite = icedCreamLight;
                        }
                    }
                }
                else if (ingredients.Contains(CoffeeIngredient.IngredientType.Carmel))
                {
                    if (count == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = carmelLight;
                    }
                    else
                    {
                        if (ingredients.Contains(CoffeeIngredient.IngredientType.Ice))
                        {
                            this.GetComponent<SpriteRenderer>().sprite = icedCarmelLight;
                        }
                    }
                }
            }
        }
        else if (ingredients.Contains(CoffeeIngredient.IngredientType.Medium))
        {
            if (count == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = medium;
            }
            else
            {
                if (ingredients.Contains(CoffeeIngredient.IngredientType.Cream))
                {
                    if (count == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = creamMedium;
                    }
                    else
                    {
                        if (ingredients.Contains(CoffeeIngredient.IngredientType.Ice))
                        {
                            this.GetComponent<SpriteRenderer>().sprite = icedCreamMedium;
                        }
                    }
                }
                else if (ingredients.Contains(CoffeeIngredient.IngredientType.Carmel))
                {
                    if (count == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = carmelMedium;
                    }
                    else
                    {
                        if (ingredients.Contains(CoffeeIngredient.IngredientType.Ice))
                        {
                            this.GetComponent<SpriteRenderer>().sprite = icedCarmelMedium;
                        }
                    }
                }
            }
        }
        else if (ingredients.Contains(CoffeeIngredient.IngredientType.Dark))
        {
            if (count == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = dark;
            }
            else
            {
                if (ingredients.Contains(CoffeeIngredient.IngredientType.Cream))
                {
                    if (count == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = creamDark;
                    }
                    else
                    {
                        if (ingredients.Contains(CoffeeIngredient.IngredientType.Ice))
                        {
                            this.GetComponent<SpriteRenderer>().sprite = icedCreamDark;
                        }
                    }
                }
                else if (ingredients.Contains(CoffeeIngredient.IngredientType.Carmel))
                {
                    if (count == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = carmelDark;
                    }
                    else
                    {
                        if (ingredients.Contains(CoffeeIngredient.IngredientType.Ice))
                        {
                            this.GetComponent<SpriteRenderer>().sprite = icedCarmelDark;
                        }
                    }
                }
            }
        }
    }
}
