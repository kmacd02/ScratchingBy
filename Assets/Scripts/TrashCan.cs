using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        Draggable dl = collision.gameObject.GetComponent<Draggable>();
        if (dl != null && !dl.dragging)
        {
            Destroy(collision.gameObject);
        }
    }
}
