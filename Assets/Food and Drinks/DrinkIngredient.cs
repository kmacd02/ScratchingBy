using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DrinkIngredient : MonoBehaviour
{
    public string name;
    public string category;

    private Draggable draggable;
    private float timer = 0.1f;
    
    public bool used = false;

    // Start is called before the first frame update
    void Start()
    {
        draggable = GetComponent<Draggable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (draggable.dragging)
        {
            timer = 0.1f;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public string getName()
    {
        return name;
    }

    public string getCategory()
    {
        return category;
    }
}
