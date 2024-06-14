using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSettings : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionParametr;
    [SerializeField] private bool onFullScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ChangedValue()
    {
        if(resolutionParametr.value == 0)
        {
            Screen.SetResolution(1280, 720, onFullScreen);
            print("1280:720");
        }
        else if(resolutionParametr.value == 1)
        {
            Screen.SetResolution(1366, 768, onFullScreen);
            print("1366:768");
        }
        else if (resolutionParametr.value == 2)
        {
            Screen.SetResolution(1600, 900, onFullScreen);
            print("1600:900");
        }
        else if (resolutionParametr.value == 3)
        {
            Screen.SetResolution(1920, 1080, onFullScreen);
            print("1920:1080");
        }
    }
}
