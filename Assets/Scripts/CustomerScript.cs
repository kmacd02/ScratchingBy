using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    // private variables
    float timer = 20f;
    [SerializeField] string order;

    // get functions
    public bool isTimerUp()
    {
        if (timer > 0)
            return false;
        return true;
    }

    public string getOrder()
    {
        return order;
    }

    // set functions
    public void setOrder(string o)
    {
        order = o;
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
