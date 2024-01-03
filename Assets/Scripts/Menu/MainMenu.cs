using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject playerSlots;
    public void StartGame()
    {
        if(PlayerPrefs.HasKey("activePlayer"))
        {
            LevelManager.Instance.LoadGame(PlayerPrefs.GetInt("level" + PlayerPrefs.GetInt("activePlayer")));
        }
        else
        {
            playerSlots.SetActive(true);
        }
    }
    public void NewGame()
    {
        PlayerPrefs.SetInt("level" + PlayerSlots.id, 1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void DeletePref()
    {
        PlayerPrefs.DeleteAll();
    }
}
