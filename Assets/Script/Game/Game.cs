using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    void Start()
    {
        PauseGame(true);
        FindObjectOfType<AudioManager>().Play("Theme");
        //LoadLastData();
    }

    public void PauseGame(bool gameIsPaused)
    {
        if (gameIsPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1;
    }

    public void LoadLastData()
    {
        FindObjectOfType<TextRestart>().LoadData();
    }
}
