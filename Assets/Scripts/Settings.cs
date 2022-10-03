using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private GameManager g;

    [SerializeField] private AudioMixer aux;
    
    [SerializeField] private Slider masterVol;
    
    private const string MASTER_VOL = "Master Volume";
    
    // Start is called before the first frame update
    void Start()
    {
        g = FindObjectOfType<GameManager>();
        
        masterVol.value = g.LoadSetting<float>(MASTER_VOL);
        aux.SetFloat("MasterVolume", masterVol.value - 80);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMasterVolume(float vol)
    {
        g.SaveSetting(MASTER_VOL, vol);
        aux.SetFloat("MasterVolume", vol - 80);
    }
}
