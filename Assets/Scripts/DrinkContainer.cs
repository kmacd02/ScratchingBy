using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrinkContainer : MonoBehaviour
{
    private Dictionary<String, String> ingredients = new();

    public Dictionary<String, String> getIngredients()
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
    private float timer = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        draggable = GetComponent<Draggable>();
    }

    // Update is called once per frame
    void Update()
    {
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

    private void OnCollisionStay2D(Collision2D col)
    {
        DrinkIngredient di = col.gameObject.GetComponent<DrinkIngredient>();
        if (di != null && !di.gameObject.GetComponent<Draggable>().dragging && !di.used)
        {
            if (ApplyIngredient(di))
            {
                if (di.used)
                {
                    Destroy(col.gameObject);
                    changeSprite();
                }
                
                Debug.Log(ingredients.Count);
                foreach (var type in ingredients)
                {
                    Debug.Log(type.ToString());
                }
            }
        }
    }

    bool ApplyIngredient(DrinkIngredient di)
    {
        if (ingredients.ContainsKey(di.getCategory()) && ingredients[di.getCategory()] != di.getName())
        {
            ingredients[di.getCategory()] = di.getName();
            di.used = true;
        }
        else
        {
            ingredients.Add(di.getCategory(), di.getName());
            di.used = true;
        }

        return true;
    }

    void changeSprite()
    {
        string dBase;
        if (!ingredients.TryGetValue("Base", out dBase)) dBase = "None";
        
        string dMix;
        if (!ingredients.TryGetValue("Mix", out dMix)) dMix = "None";
        
        string dAdditives;
        if (!ingredients.TryGetValue("Additives", out dAdditives)) dAdditives = "None";
        
        int count = ingredients.Count;
        if (count == 0)
            return;
        if (dBase == "GreenTea")
        {
            if (count == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = green;
            }
            else
            {
                if (dMix == "Milk")
                {
                    if (count == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = greenmilk;
                    }
                    else
                    {
                        if (dAdditives == "Boba")
                        {
                            this.GetComponent<SpriteRenderer>().sprite = greenmilkboba;
                        }
                        else if (dAdditives == "Jelly")
                        {
                            this.GetComponent<SpriteRenderer>().sprite = greenmilkjelly;
                        }
                    }
                }
                else if (dMix == "Fruit")
                {
                    if (count == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = greenfruit;
                    }
                    else
                    {
                        if (dAdditives == "Boba")
                        {
                            this.GetComponent<SpriteRenderer>().sprite = greenfruitboba;
                        }
                        else if (dAdditives == "Jelly")
                        {
                            this.GetComponent<SpriteRenderer>().sprite = greenfruitjelly;
                        }
                    }
                }
            }
        }
        else if (dBase == "BlackTea")
        {
            if (count == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = black;
            }
            else
            {
                if (dMix == "Milk")
                {
                    if (count == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = blackmilk;
                    }
                    else
                    {
                        if (dAdditives == "Boba")
                        {
                            this.GetComponent<SpriteRenderer>().sprite = blackmilkboba;
                        }
                        else if (dAdditives == "Jelly")
                        {
                            this.GetComponent<SpriteRenderer>().sprite = blackmilkjelly;
                        }
                    }
                }
                else if (dMix == "Fruit")
                {
                    if (count == 2)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = blackfruit;
                    }
                    else
                    {
                        if (dAdditives == "Boba")
                        {
                            this.GetComponent<SpriteRenderer>().sprite = blackfruitboba;
                        }
                        else if (dAdditives == "Jelly")
                        {
                            this.GetComponent<SpriteRenderer>().sprite = blackfruitjelly;
                        }
                    }
                }
            }
        }
    }
}
