using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Options : MonoBehaviour {
    float masterAudio;
    [SerializeField] private AudioSource[] speakers;       //A list of the audio sources in the scene

    private void Awake() {
        masterAudio = GetFloat("volume");       //Collect the volume setting from player preferances
        speakers = FindObjectsOfType<AudioSource>();        //This will collect all of the objects with an audio source in the scene
        UpdateSpeakers(masterAudio);            //Set the volume of all speakers
    }

    //Setting Player Preferances
    public void SetFloat(string KeyName, float Value)       //Setting preferances
    {
        PlayerPrefs.SetFloat(KeyName, Value);
    }

    public float GetFloat(string KeyName)                   //Getting preferances
    {
        return PlayerPrefs.GetFloat(KeyName);
    }
    //****

    public void SliderValueUpdate(Slider slider) {
        masterAudio = slider.value;
        SetFloat("volume", masterAudio);        //Setting the player preferances for the audio
        UpdateSpeakers(masterAudio);
    }

    private void UpdateSpeakers(float volume) {
        foreach (AudioSource speaker in speakers) {
            speaker.volume = volume;
        }
    }
}
