using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This script controls the main menu
public class MainMenuController : MonoBehaviour
{
    public Text scoreText;
    int scoreNum;

    public GameObject warp1;
    public GameObject warp2;
    public GameObject warp3;
    public GameObject warp4;

    public GameObject MenuUI;
    public GameObject optionsMenu;
    public GameObject creditsMenu;
    public GameObject spaceshipMenu;
    public GameObject spaceship1;
    public GameObject spaceship2;
    public GameObject spaceship3;
    public GameObject spaceship4;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("obstacleSpeed", 0);

        scoreNum = PlayerPrefs.GetInt("score");
        scoreText.text = scoreNum.ToString();

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        scoreNum = PlayerPrefs.GetInt("score");
        scoreText.text = scoreNum.ToString();
    }

    //Starts a new game
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Spaceships()
    {
        MenuUI.SetActive(false);
        spaceshipMenu.SetActive(true);

        warp1.GetComponent<ParticleSystem>().Play();
        warp2.GetComponent<ParticleSystem>().Play();
        warp3.GetComponent<ParticleSystem>().Play();
        warp4.GetComponent<ParticleSystem>().Play();

        spaceship1.SetActive(true);
        spaceship2.SetActive(true);
        spaceship3.SetActive(true);
        spaceship4.SetActive(true);
    }

    //Turn on the options menu
    public void Options()
    {
        MenuUI.SetActive(false);
        optionsMenu.SetActive(true);
    }

    //View the credits
    public void Credits()
    {
        MenuUI.SetActive(false);
        creditsMenu.SetActive(true);
    }

    //To quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

    //To reset the score
    public void ResetButton()
    {
        PlayerPrefs.SetInt("score", 0);
    }
}
