using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{

    public Slider volumeSlider;
    public LevelManager levelManager;

    private MusicPlayer musicPlayer;


	void Start ()
    {
        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
	}

    private void Update()
    {
        musicPlayer.ChangeVolume(volumeSlider.value);
    }

    public void SetDefaults()
    {
        musicPlayer.ChangeVolume(0.8f);
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        levelManager.LoadLevel("Menu");
    }
}
