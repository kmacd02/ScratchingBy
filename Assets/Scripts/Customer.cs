using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Customer : MonoBehaviour
{
    // Constructors
    public void Init(float speed)
    {
        makeRandomOrder();
        this.speed = speed;

        int spriteNum = Random.Range(0, 14);
        this.GetComponent<SpriteRenderer>().sprite = allNormalSprites[spriteNum];

        speechBubble.GetComponent<SpeechBubble>().setSpeech();
    }

    public void Init(List<DrinkIngredient.IngredientType> special, float speed, int appearance)
    {
        order = special;
        this.speed = speed;

        if (appearance > 6 || appearance < 0)
        {
            Debug.Log("Appearance: index out of range");
            return;
        }

        this.GetComponent<SpriteRenderer>().sprite = allSpecialSprites[appearance];
    }
    
    [NonSerialized] public bool moving = false;

    // private variables
    private float timer = 20f;
    private float speed = 0f;
    private bool orderComplete = false;
    [SerializeField] List<DrinkIngredient.IngredientType> order = new();
    [SerializeField] string orderFood = null;
    [SerializeField] Sprite[] allNormalSprites;
    [SerializeField] Sprite[] allSpecialSprites;
    [SerializeField] GameObject speechBubble;

    // get functions
    public bool isTimerUp()
    {
        if (timer > 0)
            return false;
        return true;
    }

    public List<DrinkIngredient.IngredientType> getOrder()
    {
        return order;
    }
    
    public void makeRandomOrder()
    {
        // int type = Random.Range(0, 2);

        if (true)
        {
            int r = Random.Range(0, 2);
            if (r == 0)
                order.Add(DrinkIngredient.IngredientType.GreenTea);
            else
                order.Add(DrinkIngredient.IngredientType.BlackTea);

            r = Random.Range(0, 2);
            if (r == 0)
                order.Add(DrinkIngredient.IngredientType.Milk);
            else if (r == 1)
                order.Add(DrinkIngredient.IngredientType.Fruit);
            else
                order.Add(DrinkIngredient.IngredientType.Plain);

            r = Random.Range(0, 2);
            if (r == 0)
                order.Add(DrinkIngredient.IngredientType.Boba);
            else if (r == 1)
                order.Add(DrinkIngredient.IngredientType.Jelly);
            else
                order.Add(DrinkIngredient.IngredientType.NoTopping);
        }
        else
        {
            int r = Random.Range(0, 4);

            if (r == 0)
            {
                orderFood = "taiyaki";
            }
            else if (r == 1)
            {
                orderFood = "roll";
            }
            else if (r == 2)
            {
                orderFood = "donut";
            }
            else
            {
                orderFood = "croissant";
            }
        }
    }

    public bool checkOrder(List<DrinkIngredient.IngredientType> order)
    {
        if (this.order.Count != order.Count)
        {
            return false;
        }

        int count = this.order.Count;
        for (int i = 0; i < count; i++)
        {
            if (this.order[i] != order[i])
                return false;
        }

        return true;
    }

    public bool isOrderComplete()
    {
        return orderComplete;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position += Time.deltaTime * speed * Vector3.left;
        }
        
        if (timer > 0)
            timer -= Time.deltaTime;
        else
            timer = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Drink Container")
        {
            if (checkOrder(collision.gameObject.GetComponent<DrinkContainer>().getIngredients()))
            {
                orderComplete = true;
                Destroy(collision.gameObject);
                Debug.Log("order complete");
            }
            else
            {
                Destroy(collision.gameObject);
                Debug.Log("wrong order");
            }
        }
    }
}
