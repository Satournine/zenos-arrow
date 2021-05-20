using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script controls the pause menu
public class PauseController : MonoBehaviour
{
    private AudioSource[] allAudio;

    public static bool paused = false;
    public GameObject pauseMainUI;
    public GameObject pauseMenuUI;
    public GameObject optionsMenu;


    // Start is called before the first frame update
    void Start()
    {
        pauseMainUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        optionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
                ResumeAudio();
            }
            else
            {
                Pause();
                PauseAudio();
            }
        }
    }

    //To resume the game
    public void Resume()
    {
        ResumeAudio();

        pauseMainUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //To pause the game
    void Pause()
    {
        pauseMainUI.SetActive(true);
        pauseMenuUI.SetActive(true);
        optionsMenu.SetActive(false);
        Time.timeScale = 0f;
        paused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //View the options
    public void Options()
    {
        pauseMenuUI.SetActive(false);
        optionsMenu.SetActive(true);
    }

    //Quit to the main menu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    void PauseAudio()
    {
        allAudio = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource sound in allAudio)
        {
            sound.Pause();
        }
    }

    void ResumeAudio()
    {
        allAudio = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource sound in allAudio)
        {
            sound.UnPause();
        }
    }
}
