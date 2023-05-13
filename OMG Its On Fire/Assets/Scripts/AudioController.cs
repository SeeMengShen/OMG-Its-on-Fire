using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    [SerializeField]
    private AudioProfiles m_Profiles;

    [SerializeField]
    private List<AudioSlider> m_volumeSliders = new List<AudioSlider>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        if (m_Profiles != null)
            m_Profiles.SetProfiles(m_Profiles);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Settings.profile && Settings.profile.audioMixer != null)
            Settings.profile.GetAudioLevel();
    }

    public void ApplyChanges()
    {
        if (Settings.profile && Settings.profile.audioMixer != null)
            Settings.profile.SaveAudioLevels();
    }

    public void CancelChanges()
    {
        if(Settings.profile && Settings.profile.audioMixer != null)
            Settings.profile.GetAudioLevel();

        for(int i = 0; i < m_volumeSliders.Count; i++)
        {
            m_volumeSliders[i].ResetSliderValue();
        }
    }
}
