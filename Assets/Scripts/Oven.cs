using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    [SerializeField] int cooktime;
    [SerializeField] GameObject dot;

    [SerializeField] GameObject roll;
    [SerializeField] GameObject taiyaki;
    [SerializeField] GameObject croissant;
    [SerializeField] GameObject donut;

    bool roll_exists = false;
    bool donut_exists = false;
    bool croissant_exists = false;
    bool taiyaki_exists = false;

    bool ovenActive = false;

    private void Update()
    {
        //TODO: turn dot on/off:
        //if oven active
            //display that oven is active
        //if oven inactive
            //delete display
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (ovenActive)
            return;

        if (collision.gameObject.CompareTag("Mix_Roll"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Waiting(roll));
        }

        if(collision.gameObject.CompareTag("Mix_Taiyaki"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Waiting(taiyaki));
        }

        if(collision.gameObject.CompareTag("Mix_Donut"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Waiting(donut));
        }

        if (collision.gameObject.CompareTag("Mix_Croissant"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(Waiting(croissant));
        }

        switch (collision.gameObject.tag)
        {
            case "Mix_Roll":
                if (roll_exists == false)
                {
                    Instantiate(roll);
                    roll_exists = true;
                }
                break;
            case "Mix_Taiyaki":
                if (taiyaki_exists == false)
                {
                    Instantiate(taiyaki);
                    taiyaki_exists = true;
                }
                break;
            case "Mix_Donut":
                if (donut_exists == false)
                {
                    Instantiate(donut);
                    donut_exists = true;
                }
                break;
            case "Mix_Croissant":
                if (croissant_exists == false)
                {
                    Instantiate(croissant);
                    croissant_exists = true;
                }
                break;
            default:
                break;
        }

        return;

    }

    IEnumerator Waiting(GameObject pastry)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //ovenActive = true;

        //switch (pastry.gameObject.tag)
        //{
        //    case "Mix_Roll":
        //        if (roll_exists == false)
        //        {
        //            Instantiate(roll);
        //            roll_exists = true;
        //        }
        //        break;
        //    case "Mix_Taiyaki":
        //        if (taiyaki_exists == false)
        //        {
        //            Instantiate(taiyaki);
        //            taiyaki_exists = true;
        //        }
        //        break;
        //    case "Mix_Donut":
        //        if (donut_exists == false)
        //        {
        //            Instantiate(donut);
        //            donut_exists = true;
        //        }
        //        break;
        //    case "Mix_Croissant":
        //        if (croissant_exists == false)
        //        {
        //            Instantiate(croissant);
        //            croissant_exists = true;
        //        }
        //        break;
        //    default:
        //        break;
        //}

        //ovenActive = false;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(cooktime);

        //TODO: See if there is a way to accomplish the switch statement AFTER wait for seconds has been called
        //Note: I tried instantiating the pastries after StartCoroutine in OnTriggerEnter2D but this is Not a solution

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
