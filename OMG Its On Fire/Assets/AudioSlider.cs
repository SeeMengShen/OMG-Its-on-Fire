using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(Slider))]

public class AudioSlider : MonoBehaviour
{
    //public AudioMixer mixer;

    [Header("Volume Name")]
    [Tooltip("This is the name of the exposed parameter")]
    [SerializeField]
    private string volumeName;

    [Header("Volume Label")]
    [SerializeField]
    private Text volumeLabel;

    Slider slider
    {
        get
        {
            return GetComponent<Slider>();
        }
    }

    private void Start()
    {
        ResetSliderValue();

        slider.onValueChanged.AddListener(delegate 
        {
            UpdateValueOnChange(slider.value);
        }
        );
    }

    public void UpdateValueOnChange(float value)
    {
        /*
        if(Settings.profile && Settings.profile.audioMixer)
            Settings.profile.audioMixer.SetFloat(volumeName, Mathf.Log(value)*20f);
        */

        if (volumeLabel != null)
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";

        if (Settings.profile)
        {
            Settings.profile.SetAudioLevels(volumeName, value);
        }
    }

    public void ResetSliderValue()
    {
        if (Settings.profile)
        {
            float volume = Settings.profile.GetAudioLevels(volumeName);

            UpdateValueOnChange(volume);
            slider.value = volume;
        }
    }

}
