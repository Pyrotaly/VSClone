using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;

namespace GenericSettingsMenu
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private TMPro.TMP_Dropdown resolutionDropdown;
        private Resolution[] resolutions;

        [SerializeField] private Slider musicVolumeSlider, sfxVolumeSlider;

        const string resValue = "resolutionvalue";

        private void Start()
        {
            resolutions = Screen.resolutions;
            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currenResolutionIndex = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currenResolutionIndex = i;
                }
            }
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = PlayerPrefs.GetInt("resValue", currenResolutionIndex);       // will set resolution to the playerprefs and the default value will be determined from the for loop
            resolutionDropdown.RefreshShownValue(); 
        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            PlayerPrefs.SetInt("resValue", resolutionDropdown.value);
        }

        public void SetMusicVolume(float volume)
        {
            AudioManager.Instance.AdjustMusicVolume(musicVolumeSlider.value);
        }

        public void SetSFXVolume(float volume)
        {
            AudioManager.Instance.AdjustMusicVolume(sfxVolumeSlider.value);
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void SetFullscreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
        }
    }
}