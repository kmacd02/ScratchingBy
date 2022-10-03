using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    [SerializeField] int cooktime;

    [SerializeField] GameObject roll;
    [SerializeField] GameObject taiyaki;
    [SerializeField] GameObject croissant;
    [SerializeField] GameObject donut;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mix_Roll"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Waiting());
            Instantiate(roll);
        }

        if(collision.gameObject.CompareTag("Mix_Taiyaki"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Waiting());
            Instantiate(taiyaki);
        }

        if(collision.gameObject.CompareTag("Mix_Donut"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Waiting());
            Instantiate(donut);
        }

        if (collision.gameObject.CompareTag("Mix_Croissant"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Waiting());
            Instantiate(croissant);
        }

    }

    IEnumerator Waiting()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(cooktime);
    }
}
