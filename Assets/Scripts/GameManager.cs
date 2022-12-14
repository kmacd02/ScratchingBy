using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnityEvent tenSecondsPassed;
    [NonSerialized] public float timer = 10f;
    public static int score;

    [SerializeField] private Image fade;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Texture2D cursor;
    
    public static Inputs inputs;
    public static bool hasPastries = false;
    public static bool hasCoffee = false;

    [SerializeField] private float fullGameTime = 600f; // 600 seconds for a full game

    // Start is called before the first frame update
    void Start()
    {
        inputs = new Inputs();
        
        inputs.Player.ClickDown.Enable();
        inputs.Player.ClickUp.Enable();
        
        StartCoroutine(FullGame()); // full game time
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        text.text = Mathf.RoundToInt(timer).ToString(); // convert timer to string
        if (timer <= 0f)
        {
            tenSecondsPassed.Invoke();
            timer = 10f;
        }

        if(fade != null) fade.rectTransform.offsetMax = new Vector2(fade.rectTransform.offsetMax.x, -150 + timer / 10 * 150);
    }

    private void OnDestroy()
    {
        inputs.Player.ClickDown.Disable();
        inputs.Player.ClickUp.Disable();
    }

    public bool SaveSetting<T> (string s, T value)
    {
        if (typeof(T) == typeof(string))
        {
            PlayerPrefs.SetString(s, (string)(object)value);
            return true;
        }
        if (typeof(T) == typeof(int))
        {
            PlayerPrefs.SetInt(s, (int)(object)value);
            return true;
        }
        if (typeof(T) == typeof(float))
        {
            PlayerPrefs.SetFloat(s, (float)(object)value);
            return true;
        }

        return false;
    }

    public T LoadSetting<T>(string s)
    {
        if (!PlayerPrefs.HasKey(s)) return default;
        
        if (typeof(T) == typeof(string))
        {
            return (T) Convert.ChangeType(PlayerPrefs.GetString(s), typeof(T));
        }
        if (typeof(T) == typeof(int))
        {
            return (T) Convert.ChangeType(PlayerPrefs.GetInt(s), typeof(T));
        }
        if (typeof(T) == typeof(float))
        {
            return (T) Convert.ChangeType(PlayerPrefs.GetFloat(s), typeof(T));
        }

        return default;
    }

    public bool HasSetting(string s)
    {
        return PlayerPrefs.HasKey(s);
    }
    
    private IEnumerator FullGame()
    {
        yield return new WaitForSeconds(fullGameTime/3); // full game
        hasPastries = true;
        yield return new WaitForSeconds(fullGameTime/3); // full game
        hasCoffee = true;
        yield return new WaitForSeconds(fullGameTime/3); // full game

        SceneManager.LoadScene("EndScreen");
    }
}
