using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[System.Serializable]
public class Volume
{
    public string name;
    public float volume = 0.5f;
    public float tempVolume = 0.5f;
}

public class Settings
{
    public static AudioProfiles profile;
}

[CreateAssetMenu(menuName = "Create Profile")]

public class AudioProfiles : ScriptableObject
{
    public bool savePlayerPref = true;
    public string prefix = "Settings_";

    public AudioMixer audioMixer;
    public Volume[] volumeControl;

    public void SetProfiles(AudioProfiles profile)
    {
        Settings.profile = profile;
    }

    public float GetAudioLevels(string name)
    {
        float volume = 1f;

        if (!audioMixer)
        {
            Debug.LogWarning("There is no AudioMixer defined in the profiles file");
            return volume;
        }

        for (int i = 0; i < volumeControl.Length; i++)
        {
            if(volumeControl[i].name != name)
            {
                continue;
            }
            else
            {
                if (savePlayerPref)
                {
                    if(PlayerPrefs.HasKey(prefix + volumeControl[i].name))
                    {
                        volumeControl[i].volume = PlayerPrefs.GetFloat(prefix + volumeControl[i].name);
                    }
                }

                volumeControl[i].tempVolume = volumeControl[i].volume;

                if (audioMixer)
                    audioMixer.SetFloat(volumeControl[i].name, Mathf.Log(volumeControl[i].volume) * 20f);

                volume = volumeControl[i].volume;

                break;
            }
        }

        return volume;
    }

    public void GetAudioLevel()
    {
        if (!audioMixer)
        {
            Debug.LogWarning("There is no AudioMixer defined in the profiles files");
            return;
        }

        for (int i = 0; i < volumeControl.Length; i++)
        {
            if (savePlayerPref)
            {
                if (PlayerPrefs.HasKey(prefix + volumeControl[i].name))
                {
                    volumeControl[i].volume = PlayerPrefs.GetFloat(prefix + volumeControl[i].name);
                }
            }

            //Reset audio volume
            volumeControl[i].tempVolume = volumeControl[i].volume;

            //Set mixer to match volume
            audioMixer.SetFloat(volumeControl[i].name, Mathf.Log(volumeControl[i].volume) * 20f);
        }
    }

    public void SetAudioLevels(string name, float volume)
    {
        if (!audioMixer)
        {
            Debug.LogWarning("There is no AudioMixer defined in the profiles files");
            return;
        }

        for(int i = 0; i < volumeControl.Length; i++)
        {
            if(volumeControl[i].name != name)
            {
                continue;
            }
            else
            {
                audioMixer.SetFloat(volumeControl[i].name, Mathf.Log(volume) * 20);
                volumeControl[i].tempVolume = volume;
                break;
            }
        }
    }

    public void SaveAudioLevels()
    {
        if (!audioMixer)
        {
            Debug.LogWarning("There is no AudioMixer defined in the profiles files");
            return;
        }

        float volume = 0f;
        for (int i = 0; i < volumeControl.Length; i++)
        {
            volume = volumeControl[i].tempVolume;
            if (savePlayerPref)
            {
                PlayerPrefs.SetFloat(prefix + volumeControl[i].name, volume);
            }
            audioMixer.SetFloat(volumeControl[i].name, Mathf.Log(volume) * 20);
            volumeControl[i].tempVolume = volume;
        }
    }

}
