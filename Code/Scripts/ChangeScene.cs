using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This namespace is needed to use a function called LoadScene from the SceneManager class
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        //every scene created will have a unique ID assigned to it
        SceneManager.LoadScene(sceneID);
    }
    //this will be called whenever player presses the quit button
    public void Quit()
    {
        //application will quit due to this script
        Application.Quit();
    }
}
