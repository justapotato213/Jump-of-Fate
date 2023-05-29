using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    /// <summary>
    /// Gets resolution of game
    /// </summary>
    Resolution[] resolutions;

    /// <summary>
    /// Resolution dropdown menu
    /// </summary>
    public TMPro.TMP_Dropdown resolutionDropdown;


    public void Start()
    {
        resolutions = Screen.resolutions;

        int currentResolutionIndex = -1;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i=0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            Debug.Log(option);

            //if (resolutions[i].width == 2048 &&
            //    resolutions[i].height == 1280)
            //{
            //    currentResolutionIndex = 1;
            //}

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = 8;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // SetResolution(-1);
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    /// <summary>
    /// Sets the screen to fullscreen or disables fullscreen
    /// </summary>
    /// <param name="isFullScreen"></param>
    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
