using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    //calls upon the bg music
    private static BackgroundMusic backgroundMusic;
    //'awake' keeps this code alive
    private void Awake()
    {
        //if there is no bg music then start playing music
        if(backgroundMusic == null)
        {
            //since I used only 1 bg music for simplicity, 
            //I dont need to specify which music I want my game to play
            backgroundMusic = this;
            //makes it so the bg music is not destroyed/stopped
            DontDestroyOnLoad(backgroundMusic);
        }
        else
        {
            //makes it so bg music is not constantly being created
            Destroy(gameObject);
        }
        
    }
}
