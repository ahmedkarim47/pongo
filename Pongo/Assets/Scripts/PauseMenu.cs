using UnityEngine;
//add namespace to make sure code works
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //pause button is called upon
    [SerializeField] GameObject pauseMenu;

    public static bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        //pauses the game by making the time passing in-game zero
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()   
    {
        pauseMenu.SetActive(false);
        //resumes the game by making the time passing in-game one
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Home (int sceneID)
    {
        Time.timeScale = 1f;
        //loads the main menu when home button is clicked
        SceneManager.LoadScene(sceneID);
    }
}