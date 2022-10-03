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
    [SerializeField] private Slider musicVol;
    [SerializeField] private Slider sfxVol;
    
    private const string MASTER_VOL = "Master Volume";
    private const string MUSIC_VOL = "Music Volume";
    private const string SFX_VOL = "SFX Volume";
    
    // Start is called before the first frame update
    void Start()
    {
        g = FindObjectOfType<GameManager>();
        
        masterVol.value = g.LoadSetting<float>(MASTER_VOL);
        aux.SetFloat("MasterVolume", masterVol.value - 80);
        musicVol.value = g.LoadSetting<float>(MUSIC_VOL);
        aux.SetFloat("MusicVolume", musicVol.value - 80);
        sfxVol.value = g.LoadSetting<float>(SFX_VOL);
        aux.SetFloat("SFXVolume", sfxVol.value - 80);
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
    public void UpdateMusicVolume(float vol)
    {
        g.SaveSetting(MUSIC_VOL, vol);
        aux.SetFloat("MusicVolume", vol - 80);
    }
    public void UpdateSFXVolume(float vol)
    {
        g.SaveSetting(SFX_VOL, vol);
        aux.SetFloat("SFXVolume", vol - 80);
    }
}
