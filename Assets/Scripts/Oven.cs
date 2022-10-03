using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    [SerializeField] int cooktime;
    [SerializeField] GameObject dot;

    [SerializeField] IngredientSpawner roll;
    [SerializeField] IngredientSpawner taiyaki;
    [SerializeField] IngredientSpawner croissant;
    [SerializeField] IngredientSpawner donut;
    
    bool ovenActive = false;

    private void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Draggable d = collision.GetComponent<Draggable>();
        if(d != null) if(d.dragging) return;
        
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
    }

    IEnumerator Waiting(IngredientSpawner pastry)
    {
        ovenActive = true;
        dot.SetActive(true);
        
        yield return new WaitForSeconds(cooktime);

        pastry.amount++;
        
        ovenActive = false;
        dot.SetActive(false);
    }
}
