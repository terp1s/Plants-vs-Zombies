using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool gameOver = false;

    private void Update()
    {
        if (gameOver)
        {
            GameOverScene();
        }
    }

    public void GameOverScene()
    {
        Time.timeScale = 0f;
        GameObject.Find("Canvas").transform.Find("GameOver").gameObject.SetActive(true);
    }
}
