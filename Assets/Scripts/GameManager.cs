using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public UnityEvent tenSecondsPassed;
    [NonSerialized] public float timer = 0f;

    [SerializeField] private Image fade; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 10f)
        {
            tenSecondsPassed.Invoke();
            timer = 0;
        }

        fade.rectTransform.offsetMax = new Vector2(fade.rectTransform.offsetMax.x, -timer / 10 * 150);
    }
}
