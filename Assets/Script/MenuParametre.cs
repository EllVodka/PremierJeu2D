using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class MenuParametre : MonoBehaviour
{
    public AudioMixer audioMixer;

    Resolution[] resolutions;

    public Dropdown resolutionDropdown;

    public Slider musicSlider;
    public Slider effetSonoreSlider;

    public void Start()
    {
        //recuperation des sons et les mettre dans les slider
        audioMixer.GetFloat("Music", out float musiqueValeurSlider);
        audioMixer.GetFloat("EffetSonore", out float effetValeurSlider);
        musicSlider.value = musiqueValeurSlider;
        effetSonoreSlider.value = effetValeurSlider;


        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int resolutionActuelIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                resolutionActuelIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = resolutionActuelIndex;
        resolutionDropdown.RefreshShownValue();

        Screen.fullScreen = true;

    }
    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("Music",volume);
    }
    
    public void SetEffetSonore(float volume)
    {
        audioMixer.SetFloat("EffetSonore",volume);
    }

    public void SetPleinEcran(bool estPleinEcran)
    {
        Screen.fullScreen = estPleinEcran;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }
}
