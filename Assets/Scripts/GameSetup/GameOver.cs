using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Canvas canvas;
    public AudioClip lose;
    public bool gameOver;

    public void GameOverScene()
    {
        gameOver = true;
        Time.timeScale = 0f;
        GameObject.Find("Canvas").transform.Find("GameOver").gameObject.SetActive(true);
        SoundManager.instance.ToggleMusic();

        if (!SoundManager.instance.effects.isPlaying)
        {
            SoundManager.instance.PlaySound(lose);
        }
    }
    IEnumerator PauseMusic()
    {
        SoundManager.instance.ToggleMusic();

        for (int i = 0; i < 1; i++)
        {
            yield return new WaitForSecondsRealtime(0.5f);
        }

        SoundManager.instance.ToggleMusic();
    }
}
