using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManagerScript : MonoBehaviour
{
    // private variables
    private List<GameObject> currentCustomers;
    private List<Vector3> currentCustomersPositions;
    private List<Vector3> currentCustomersDestinations;
    private Queue<GameObject> futureCustomers;
    private float timePassed;
    private bool addCustomerInProgress = false;
    private float startTime;
    private float travelDistance = 0;
    private float totalDistance = 1.1f;
    private float speed = 1f;
    private float moveDistance = 3;
    private Vector3 instantiatePosition = new Vector3(5, 0, 0);

    public bool isAddingCustomer()
    {
        return addCustomerInProgress;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentCustomers = new List<GameObject>();
        currentCustomersPositions = new List<Vector3>();
        currentCustomersDestinations = new List<Vector3>();
        futureCustomers = new Queue<GameObject>();

        foreach (Transform child in transform)
        {
            child.position = instantiatePosition;
            futureCustomers.Enqueue(child.gameObject);
            child.gameObject.SetActive(false);
        }

        futureCustomers.Peek().SetActive(true);
        currentCustomers.Add(futureCustomers.Peek());
        futureCustomers.Dequeue();
        // currentCustomers.Add(Instantiate(newCustomer, new Vector3(5, 0, 0), Quaternion.identity));
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Time Passed: " + timePassed);
        Debug.Log("Customer Count: " + currentCustomers.Count);

        /*
        foreach (GameObject customer in currentCustomers)
        {
            if (customer.gameObject.GetComponent<CustomerScript>().isTimerUp())
            {
                Destroy(customer);
            }
        }
        */

        if (!addCustomerInProgress || futureCustomers.Count == 0)
        {
            timePassed += Time.deltaTime;

            if (timePassed >= 10)
            {
                foreach (GameObject customer in currentCustomers)
                {
                    currentCustomersPositions.Add(customer.transform.position);
                    currentCustomersDestinations.Add(new Vector3(customer.transform.position.x - moveDistance, customer.transform.position.y, customer.transform.position.z));
                }
                startTime = Time.time;
                travelDistance = 0;
                addCustomerInProgress = true;
            }
        }
        else
        {
            travelDistance = (Time.time - startTime) * speed;
            travelDistance = travelDistance / totalDistance;

            int length = currentCustomers.Count;
            for (int i = 0; i < currentCustomers.Count; i++)
            {
                currentCustomers[i].transform.position = Vector3.Lerp(currentCustomersPositions[i], currentCustomersDestinations[i], travelDistance);
            }

            if (travelDistance >= 1)
            {
                futureCustomers.Peek().SetActive(true);
                currentCustomers.Add(futureCustomers.Peek());
                futureCustomers.Dequeue();
                // currentCustomers.Add(Instantiate(newCustomer, new Vector3(5, 0, 0), Quaternion.identity));
                timePassed = 0;
                addCustomerInProgress = false;
            }
        }
    }
}
