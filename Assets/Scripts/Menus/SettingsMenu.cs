/*
 * Authors: Edison 
 */
using System.Collections.Generic;
using UnityEngine;

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

    /// <summary>
    /// Initializes the resolution dropdown menu
    /// </summary>
    public void Start()
    {
        resolutions = Screen.resolutions;

        int currentResolutionIndex = -1;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        // Adds the resolution options 
        for (int i=0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            // Debug.Log(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                // Default resolution set at the current resolution
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    /// <summary>
    /// Changes the resolution of the screen
    /// </summary>
    /// <param name="resolutionIndex">The index of the resolution in the dropdown menu</param>
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    /// <summary>
    /// Sets the screen to fullscreen or disables fullscreen
    /// </summary>
    /// <param name="isFullScreen">A boolean of whether the fullscreen is on or off</param>
    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
