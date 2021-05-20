using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject backgroundMusic;
    public GameObject ambientSound;
    public GameObject eyeBossMusic;
    public GameObject eyeBossSound;
    public GameObject eyeBossBeam;

    public GameObject scoreCon;
    int scoreNew;
    int scoreOld;
    public GameObject GameOverScreen;
    public GameObject pauseScreen;
    public GameObject explosion;
    public bool playerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreNew = scoreCon.GetComponent<ScoreController>().scoreNum;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            playerDead = true;
            Dead();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "P3Laser")
        {
            var explosionParticle = Instantiate(explosion, transform.position, transform.rotation);
            playerDead = true;
            Dead();
        }

        if (other.tag == "P4Laser")
        {
            var explosionParticle = Instantiate(explosion, transform.position, transform.rotation);
            playerDead = true;
            Dead();
        }
    }

    void Dead()
    {
        Destroy(eyeBossSound.gameObject);
        Destroy(backgroundMusic.gameObject);
        Destroy(eyeBossMusic.gameObject);
        Destroy(ambientSound.gameObject);
        eyeBossBeam.SetActive(false);

        Destroy(pauseScreen.gameObject);
        GameOverScreen.SetActive(true);

        //To check whether the new score is higher or not, and then update the high score
        scoreOld = PlayerPrefs.GetInt("score");
        if(scoreNew > scoreOld)
        {
            PlayerPrefs.SetInt("score", scoreNew);
        }

        //To stop the gameplay
        Time.timeScale = 0f;

        //To unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Destroy(gameObject);
    }
}
