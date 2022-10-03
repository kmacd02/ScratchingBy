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
    private float volAdjust = 80f;
    
    // Start is called before the first frame update
    void Start()
    {
        g = FindObjectOfType<GameManager>();
        
        masterVol.value = g.LoadSetting<float>(MASTER_VOL);
        aux.SetFloat("MasterVolume", masterVol.value - volAdjust);
    }

    public void UpdateMasterVolume(float vol)
    {
        g.SaveSetting(MASTER_VOL, vol);
        aux.SetFloat("MasterVolume", vol - volAdjust);
    }

    public void MuteMasterVolume(bool mute) // mute all sound
    {
        if (mute)
        {
            aux.SetFloat("MasterVolume", -volAdjust);
            masterVol.interactable = false; // make slider un interactable
        } else
        {
            masterVol.value = g.LoadSetting<float>(MASTER_VOL);
            aux.SetFloat("MasterVolume", masterVol.value - volAdjust);

            masterVol.interactable = true; // make interactable
        }
    }
}
