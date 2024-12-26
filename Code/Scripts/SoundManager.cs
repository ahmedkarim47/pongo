using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//to access the properties of ui elements via code
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    //we use serialized view when we want the code to be private 
    //but also show up in the editor
    //volume slider is called by this code
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        //if there is no saved volume level by player
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            //volume will be set to one by default
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        
    }
    
    public void ChangeVolume()
    {
        //volume of game will be equal to the volume slider
        AudioListener.volume = volumeSlider.value;
        //saves the volume temporarily
        Save();
    }

    public void Load()
    {
        //loads player's preffered volume level
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void Save()
    {
        //saves the volume for when the player relaunches
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
