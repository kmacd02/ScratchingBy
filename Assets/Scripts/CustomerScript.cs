using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    // Constructors
    public CustomerScript()
    {
        makeRandomOrder();
    }

    public CustomerScript(List<DrinkIngredient.IngredientType> special)
    {
        order = special;
    }

    // private variables
    private float timer = 20f;
    [SerializeField] List<DrinkIngredient.IngredientType> order = new List<DrinkIngredient.IngredientType>();
    private int r1;
    private int r2;
    private int r3;

    // get functions
    public bool isTimerUp()
    {
        if (timer > 0)
            return false;
        return true;
    }

    public void getOrder()
    {
        string result = "";

        if (order[0] == DrinkIngredient.IngredientType.GreenTea)
            result += "green tea +";
        if (order[0] == DrinkIngredient.IngredientType.BlackTea)
            result += "black tea +";
        if (order[1] == DrinkIngredient.IngredientType.Milk)
            result += "milk +";
        if (order[1] == DrinkIngredient.IngredientType.Fruit)
            result += "fruit +";
        if (order[1] == DrinkIngredient.IngredientType.Plain)
            result += "plain +";
        if (order[2] == DrinkIngredient.IngredientType.Boba)
            result += " boba";
        if (order[2] == DrinkIngredient.IngredientType.Jelly)
            result += " jelly";
        if (order[2] == DrinkIngredient.IngredientType.NoTopping)
            result += " no topping";

        Debug.Log(result);
    }

    
    public void makeRandomOrder()
    {
        //int r = Random.Range(0, 2);
        if (r1 == 0)
            order.Add(DrinkIngredient.IngredientType.GreenTea);
        else
            order.Add(DrinkIngredient.IngredientType.BlackTea);

        //r = Random.Range(0, 3);
        if (r2 == 0)
            order.Add(DrinkIngredient.IngredientType.Milk);
        else if (r2 == 1)
            order.Add(DrinkIngredient.IngredientType.Fruit);
        else
            order.Add(DrinkIngredient.IngredientType.Plain);

        //r = Random.Range(0, 3);
        if (r3 == 0)
            order.Add(DrinkIngredient.IngredientType.Boba);
        else if (r3 == 1)
            order.Add(DrinkIngredient.IngredientType.Jelly);
        else
            order.Add(DrinkIngredient.IngredientType.NoTopping);
    }

    private void Awake()
    {
        r1 = Random.Range(0, 2);
        r2 = Random.Range(0, 3);
        r3 = Random.Range(0, 3);
    }

    // Start is called before the first frame update
    void Start()
    {
        // makeRandomOrder();
        // getOrder();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
            timer = 0;
    }
}
