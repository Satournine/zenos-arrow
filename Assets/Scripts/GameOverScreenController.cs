using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Restarts the game
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    //Go back to the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
