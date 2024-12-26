using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    //boolean is used to sense interaction with the toggle
    public void MuteToggle(bool muted)
    {
        if (muted)
        {
            //when muted box is checked the volume becomes zero
            AudioListener.volume = 0;
        }
        else
        {
            //when muted box is unchecked the volume becomes a hundred
            AudioListener.volume = 1;
        }
    }
}
