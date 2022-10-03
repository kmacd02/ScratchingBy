using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    private List<DrinkIngredient.IngredientType> customerOrder;

    // Start is called before the first frame update
    void Start()
    {
        customerOrder = gameObject.transform.parent.gameObject.GetComponent<Customer>().getOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void 
}
