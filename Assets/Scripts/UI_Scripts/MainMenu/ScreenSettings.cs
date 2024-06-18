using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

[Serializable]
public class Settings
{
    public int resolutionValue;
    public bool fullScreen;
    public bool on_Sound;
    public float volume;
}
public class ScreenSettings : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionParametr;
    [SerializeField] private Toggle onFullScreen;
    [SerializeField] private Toggle onSounds;
    [SerializeField] private Slider volume;



    [SerializeField] private GameObject dangerScreen;
    [SerializeField] private GameObject settingsMenu;

    public Settings settings = new Settings();
    // Start is called before the first frame update
    void Start()
    {
        string json = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "Settings.json"));
        settings = JsonUtility.FromJson<Settings>(json);
        resolutionParametr.value = settings.resolutionValue;
        onFullScreen.isOn = settings.fullScreen;
        onSounds.isOn = settings.on_Sound;
        volume.value = settings.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveSettings()
    {
        settings.resolutionValue = resolutionParametr.value;
        settings.fullScreen = onFullScreen.isOn;
        settings.on_Sound = onSounds.isOn;
        settings.volume = volume.value;
        string json = JsonUtility.ToJson(settings);
        File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "Settings.json"), json);

        if (settings.resolutionValue == 0)
        {
            Screen.SetResolution(1280, 720, settings.fullScreen);
            print("1280:720");
        }
        else if(settings.resolutionValue == 1)
        {
            Screen.SetResolution(1366, 768, settings.fullScreen);
            print("1366:768");
        }
        else if (settings.resolutionValue == 2)
        {
            Screen.SetResolution(1600, 900, settings.fullScreen);
            print("1600:900");
        }
        else if (settings.resolutionValue == 3)
        {
            Screen.SetResolution(1920, 1080, settings.fullScreen);
            print("1920:1080");
        }
        settingsMenu.SetActive(false);
    }
    public void ExitSettings()
    {
        if (settings.resolutionValue != resolutionParametr.value || settings.fullScreen != onFullScreen.isOn || settings.on_Sound != onSounds.isOn || settings.volume != volume.value)
        {
            dangerScreen.SetActive(true);
            
        }
        else
        {
            settingsMenu.SetActive(false);
        }
    }
    public void RemoveSettings()
    {
        string json = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "Settings.json"));
        settings = JsonUtility.FromJson<Settings>(json);
        resolutionParametr.value = settings.resolutionValue;
        onFullScreen.isOn = settings.fullScreen;
        onSounds.isOn = settings.on_Sound;
        volume.value = settings.volume;
        dangerScreen.SetActive(false);
    }
}
