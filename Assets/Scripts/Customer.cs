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
    [SerializeField] public List<CoffeeIngredient.IngredientType> coffeeOrder = new();
    [SerializeField] string orderFood = null;
    [SerializeField] Sprite[] allNormalSprites;
    [SerializeField] Sprite[] allSpecialSprites;
    [SerializeField] GameObject speechBubble;
    [SerializeField] private GameObject angy;
 
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

    public string getOrderFood()
    {
        return orderFood;
    }
    
    public void makeRandomOrder()
    {
        
        int type = GameManager.hasPastries ? (GameManager.hasCoffee ? Random.Range(0, 3) : Random.Range(0,2)) : 0;
        
        if (type == 0)
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

            r = Random.Range(0, 2);
            if (r == 0)
                order.Add(DrinkIngredient.IngredientType.Boba);
            else if (r == 1)
                order.Add(DrinkIngredient.IngredientType.Jelly);
        }
        else if(type == 1)
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
        else if (type == 2)
        {
            int r = Random.Range(0, 3);
            if (r == 0)
                coffeeOrder.Add(CoffeeIngredient.IngredientType.Light);
            else if (r == 1)
                coffeeOrder.Add(CoffeeIngredient.IngredientType.Medium);
            else if (r == 2)
                coffeeOrder.Add(CoffeeIngredient.IngredientType.Dark);

            r = Random.Range(0, 2);
            if (r == 0)
                coffeeOrder.Add(CoffeeIngredient.IngredientType.Cream);
            else if (r == 1)
                coffeeOrder.Add(CoffeeIngredient.IngredientType.Carmel);

            r = Random.Range(0, 2);
            if (r == 0)
                coffeeOrder.Add(CoffeeIngredient.IngredientType.Ice);
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
            if (!this.order.Contains(order[i]))
                return false;
        }

        return true;
    }

    public bool checkOrder(List<CoffeeIngredient.IngredientType> order)
    {
        if (this.coffeeOrder.Count != order.Count)
        {
            return false;
        }

        int count = this.coffeeOrder.Count;
        for (int i = 0; i < count; i++)
        {
            if (!this.coffeeOrder.Contains(order[i]))
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
        {
            timer = 0;
            angy.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        DrinkContainer dc = collision.GetComponent<DrinkContainer>();
        CoffeeContainer cc = collision.GetComponent<CoffeeContainer>();
        if (cc != null && !cc.gameObject.GetComponent<Draggable>().dragging)
        {
            if (checkOrder(cc.getIngredients()))
            {
                orderComplete = true;
                Destroy(collision.gameObject);
                // Debug.Log("order complete");
                if(timer > 0) FindObjectOfType<CustomerManager>().successfulOrders++;
                Destroy(gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
                // Debug.Log("wrong order");
            }
        }else if (dc != null && !dc.gameObject.GetComponent<Draggable>().dragging)
        {
            if (checkOrder(dc.getIngredients()))
            {
                orderComplete = true;
                Destroy(collision.gameObject);
                // Debug.Log("order complete");
                if(timer > 0) FindObjectOfType<CustomerManager>().successfulOrders++;
                Destroy(gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
                // Debug.Log("wrong order");
            }
        }
        else if (!string.IsNullOrEmpty(orderFood) && !collision.gameObject.GetComponent<Draggable>().dragging)
        {
            if (orderFood.Equals(collision.gameObject.tag.ToLower()))
            {
                orderComplete = true;
                Destroy(collision.gameObject);
                // Debug.Log("order complete");
                if(timer > 0) FindObjectOfType<CustomerManager>().successfulOrders++;
                Destroy(gameObject);
            }
        }
    }
}
