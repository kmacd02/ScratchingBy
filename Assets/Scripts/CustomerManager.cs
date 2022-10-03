using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private Vector3 instantiatePosition;
    [SerializeField] private Vector3 pausePosition;
    [SerializeField] private float distanceBetweenCustomers;
    
    // private variables
    [SerializeField] private GameObject customerPrefab;
    private List<GameObject> currentCustomers = new();
    private int currentCustomersInQueue = 0;
    [SerializeField] private int numCustomersLeft = 10;
    [NonSerialized] public int successfulOrders = 0;
    public TextMeshProUGUI scoreCounter;

    [Header("Overflow Slider")]
    [SerializeField] private Slider overflow;

    // Start is called before the first frame update
    void Start()
    {
        scoreCounter.text = "0";
        
        GameObject newCustomer = Instantiate(customerPrefab, instantiatePosition, Quaternion.identity);
        newCustomer.GetComponent<Customer>().Init(speed);
        currentCustomers.Add(newCustomer);
        // numCustomersLeft--;

        currentCustomersInQueue = Random.Range(0, 3);
        
        FindObjectOfType<GameManager>().tenSecondsPassed.AddListener(() =>
        {
            currentCustomersInQueue += Random.Range(1,4);
        });
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < currentCustomers.Count; i++)
        {
            if (currentCustomers[i] == null)
            {
                currentCustomers.Remove(currentCustomers[i]);
            }
        }

        for (int i = 1; i < currentCustomers.Count; i++)
        {
            currentCustomers[i].GetComponent<Customer>().moving = Vector3.Distance(currentCustomers[i].transform.position, currentCustomers[i-1].transform.position) > distanceBetweenCustomers;
        }

        if (currentCustomers.Count == 0 && currentCustomersInQueue > 0)
        {
            GameObject newCustomer = Instantiate(customerPrefab, instantiatePosition, Quaternion.identity);
            newCustomer.GetComponent<Customer>().Init(speed);
            currentCustomers.Add(newCustomer);
            currentCustomersInQueue--;
        }

        if (currentCustomers.Count != 0)
        {
            if (Vector3.Distance(currentCustomers.Last().transform.position, instantiatePosition) >
            distanceBetweenCustomers && currentCustomersInQueue > 0 && currentCustomers.Count < 4)
            {
                GameObject newCustomer = Instantiate(customerPrefab, instantiatePosition, Quaternion.identity);
                newCustomer.GetComponent<Customer>().Init(speed);
                currentCustomers.Add(newCustomer);
                // numCustomersLeft--;
                currentCustomersInQueue--;
            }
        }

        if (currentCustomers.Count != 0)
        {
            currentCustomers.First().GetComponent<Customer>().moving =
            currentCustomers.First().transform.position.x > pausePosition.x;
        }

        // show current customers in queue on screen
        if(currentCustomersInQueue <= 5) overflow.value = currentCustomersInQueue;

        Score();

        if (overflow.value >= 5)
        {
            
        }
    }

    // the most generic scoring system you've ever seen but done so horribly at like 1 am
    void Score()
    {
        GameManager.score = 100 * successfulOrders; // store
        scoreCounter.text = GameManager.score.ToString();
    }
}
