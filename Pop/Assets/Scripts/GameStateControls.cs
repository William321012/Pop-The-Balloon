using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateControls : MonoBehaviour
{
    GameObject[] pauseMode;
    GameObject[] playMode;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;


        pauseMode = GameObject.FindGameObjectsWithTag("PauseModeActive");
        playMode = GameObject.FindGameObjectsWithTag("PlayModeActive");

        foreach (GameObject i in pauseMode)
            i.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu ()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;

        foreach(GameObject i in pauseMode)
            i.SetActive(true);

        foreach(GameObject i in playMode)
            i.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;

        foreach (GameObject i in pauseMode)
            i.SetActive(false);

        foreach (GameObject i in playMode)
            i.SetActive(true);
    }
}
