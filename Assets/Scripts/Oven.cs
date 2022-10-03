using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    [SerializeField] GameObject roll;
    [SerializeField] GameObject taiyaki;
    [SerializeField] GameObject croissant;
    [SerializeField] GameObject donut;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mix_Roll"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Waiting());
            Instantiate(roll);
        }

    }

    IEnumerator Waiting()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(15);
    }
}
