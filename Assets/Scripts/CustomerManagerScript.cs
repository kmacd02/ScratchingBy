using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManagerScript : MonoBehaviour
{
    // private variables
    [SerializeField] private GameObject customerPrefab;
    private List<GameObject> currentCustomers;
    private List<Vector3> currentCustomersPositions;
    private List<Vector3> currentCustomersDestinations;
    // private Queue<GameObject> futureCustomers;
    // TODO: keep track of number of future customers
    private int currentCustomersInQueue = 0;
    private List<GameObject> pastCustomers;
    private float timePassed;
    private int addCustomerInProgress = 0;
    private float startTime;
    private float travelDistance = 0;
    private float totalDistance = 1.1f;
    private float speed = 1.5f;
    private float moveDistance = 3;
    private Vector3 instantiatePosition = new Vector3(5, 0, 0);
    private bool shiftExistingCustomers = false;
    // private int numOfNewCustomers = 0;

    public bool isAddingCustomer()
    {
        if (addCustomerInProgress != 0)
            return true;
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentCustomers = new List<GameObject>();
        currentCustomersPositions = new List<Vector3>();
        currentCustomersDestinations = new List<Vector3>();
        // futureCustomers = new Queue<GameObject>();

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            // child.localPosition = instantiatePosition;
            // futureCustomers.Enqueue(child.gameObject);
        }

        /*
        futureCustomers.Peek().SetActive(true);
        currentCustomers.Add(futureCustomers.Peek());
        futureCustomers.Dequeue();
        */

        GameObject newCustomer = Instantiate<GameObject>(customerPrefab, instantiatePosition, Quaternion.identity);
        currentCustomers.Add(newCustomer);

        timePassed = 0;

        foreach (GameObject customer in currentCustomers)
        {
            currentCustomersPositions.Add(customer.transform.localPosition);
            currentCustomersDestinations.Add(new Vector3(customer.transform.localPosition.x - moveDistance, customer.transform.position.y, customer.transform.position.z));
        }

        startTime = Time.time;

        addCustomerInProgress = 2;//Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("timePassed: " + timePassed);
        Debug.Log("currentCustomersInQueue: " + currentCustomersInQueue);

        int count = currentCustomers.Count;
        int numDestroyed = 0;
        for (int i = count - 1; i >= 0; i--)
        {
            if (currentCustomers[i].GetComponent<CustomerScript>().isTimerUp())
            {
                GameObject c = currentCustomers[i];
                currentCustomers.RemoveAt(i);
                Destroy(c);
                numDestroyed++;
            }
        }

        if (numDestroyed != 0)
        {
            Debug.Log("numDestroyed != 0");
            if (!shiftExistingCustomers)
            {
                foreach (GameObject customer in currentCustomers)
                {
                    currentCustomersPositions.Add(customer.transform.localPosition);
                    currentCustomersDestinations.Add(new Vector3(customer.transform.localPosition.x - (numDestroyed * moveDistance), customer.transform.position.y, customer.transform.position.z));
                }

                startTime = Time.time;
                shiftExistingCustomers = true;
            }
            else
            {
                Debug.Log("shiftExistingCustomers");
                travelDistance = (Time.time - startTime) * speed;
                travelDistance = travelDistance / totalDistance;

                int length = currentCustomers.Count;
                for (int j = 0; j < currentCustomers.Count; j++)
                {
                    currentCustomers[j].transform.localPosition = Vector3.Lerp(currentCustomersPositions[j], currentCustomersDestinations[j], travelDistance);
                }

                if (travelDistance >= totalDistance)
                {
                    currentCustomersPositions.Clear();
                    currentCustomersDestinations.Clear();
                    Debug.Log("numDestroyed = 0");
                    numDestroyed = 0;
                    shiftExistingCustomers = false;
                }
                else
                {
                    return;
                }
            }
        }

        if (currentCustomersInQueue > 0 && currentCustomers.Count < 5)
        {
            GameObject newCustomer = null;
            if (currentCustomers.Count == 4)
                newCustomer = Instantiate<GameObject>(customerPrefab, new Vector3(instantiatePosition.x + 3, instantiatePosition.y, instantiatePosition.z), Quaternion.identity);
            else
                newCustomer = Instantiate<GameObject>(customerPrefab, instantiatePosition, Quaternion.identity);
            currentCustomers.Add(newCustomer);
            currentCustomersInQueue--;
        }

        if (addCustomerInProgress == 0 /*|| futureCustomers.Count == 0*/)
        {
            timePassed += Time.deltaTime;

            if (timePassed >= 10)
            {
                foreach (GameObject customer in currentCustomers)
                {
                    currentCustomersPositions.Add(customer.transform.localPosition);
                    currentCustomersDestinations.Add(new Vector3(customer.transform.localPosition.x - moveDistance, customer.transform.position.y, customer.transform.position.z));
                }

                startTime = Time.time;
                timePassed = 0;
                addCustomerInProgress = 3;//Random.Range(1, 4);
            }
        }
        else if (currentCustomers.Count >= 4)
        {
            if (currentCustomers.Count == 5)
            {
                currentCustomersInQueue++;
                addCustomerInProgress--;

                return;
            }

            Debug.Log(addCustomerInProgress);

            /*
            if (futureCustomers.Count == 0)
                return;
            */

            // futureCustomers.Peek().transform.localPosition = new Vector3(instantiatePosition.x + 3*(currentCustomers.Count - 3), instantiatePosition.y, instantiatePosition.z);

            /*
            futureCustomers.Peek().SetActive(true);
            currentCustomers.Add(futureCustomers.Peek());
            futureCustomers.Dequeue();
            */

            GameObject newCustomer = Instantiate<GameObject>(customerPrefab, new Vector3(instantiatePosition.x + 3 * (currentCustomers.Count - 3), instantiatePosition.y, instantiatePosition.z), Quaternion.identity);
            currentCustomers.Add(newCustomer);

            addCustomerInProgress--;
        }
        else
        {
            Debug.Log(addCustomerInProgress);

            /*
            if (futureCustomers.Count == 0)
                return;
            */

            travelDistance = (Time.time - startTime) * speed;
            travelDistance = travelDistance / totalDistance;

            int length = currentCustomers.Count;
            for (int j = 0; j < currentCustomers.Count; j++)
            {
                currentCustomers[j].transform.localPosition = Vector3.Lerp(currentCustomersPositions[j], currentCustomersDestinations[j], travelDistance);
            }

            if (travelDistance >= totalDistance)
            {
                /*
                futureCustomers.Peek().SetActive(true);
                currentCustomers.Add(futureCustomers.Peek());
                futureCustomers.Dequeue();
                */

                GameObject newCustomer = Instantiate<GameObject>(customerPrefab, instantiatePosition, Quaternion.identity);
                currentCustomers.Add(newCustomer);

                addCustomerInProgress--;
                currentCustomersPositions.Clear();
                currentCustomersDestinations.Clear();

                startTime = Time.time;

                if (addCustomerInProgress == 0)
                    return;
                foreach (GameObject customer in currentCustomers)
                {
                    currentCustomersPositions.Add(customer.transform.localPosition);
                    currentCustomersDestinations.Add(new Vector3(customer.transform.localPosition.x - moveDistance, customer.transform.position.y, customer.transform.position.z));
                }
            }
        }
    }
}
