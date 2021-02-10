using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PauseGame(true);
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    public void PauseGame(bool gameIsPaused)
    {
        if (gameIsPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1;
    }
}
