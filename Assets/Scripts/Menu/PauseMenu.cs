using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume() 
    { 
        Time.timeScale = 1f;
    }

    public void ReturnToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        //SoundManager.instance.SceneChange();
    }

    public void Restart()
    {
        LevelManager.Instance.RestartLevel();
        Time.timeScale = 1f;
    }
}
