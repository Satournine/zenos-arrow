using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the switching mechanic of the portals.
public class PortalSwitch : MonoBehaviour
{
    //To start the boss fight
    public bool bossTime = false;
    int levelCount = 0;
    int eyeCount;

    [SerializeField] AudioSource levelSwSound;
    [SerializeField] GameObject eyeBossSound;
    [SerializeField] GameObject eyeBossMusic;
    [SerializeField] GameObject backgroundMusic;
    [SerializeField] GameObject ambientSound;

    [SerializeField] GameObject scoreCon;

    //Spaceships
    [SerializeField] GameObject spaceship1;
    [SerializeField] GameObject spaceship2;
    [SerializeField] GameObject spaceship3;
    [SerializeField] GameObject spaceship4;
    int shipNum;

    //The first portal
    [SerializeField] GameObject p1_center;
    [SerializeField] GameObject p1_centerBackground;
    [SerializeField] GameObject p1_background1;
    [SerializeField] GameObject p1_background2;
    [SerializeField] GameObject p1_background3;
    [SerializeField] GameObject p1_hyperdrive;

    //The second portal
    [SerializeField] GameObject p2_center;
    [SerializeField] GameObject p2_centerBackground;
    [SerializeField] GameObject p2_background1;
    [SerializeField] GameObject p2_background2;
    [SerializeField] GameObject p2_background3;
    [SerializeField] GameObject p2_background4;
    [SerializeField] GameObject p2_hyperdrive;

    //The third portal
    [SerializeField] GameObject p3_center;
    [SerializeField] GameObject p3_centerBackground;
    [SerializeField] GameObject p3_background1;
    [SerializeField] GameObject p3_background2;
    [SerializeField] GameObject p3_background3;
    [SerializeField] GameObject p3_background4;
    [SerializeField] GameObject p3_hyperdrive;

    //The fourth portal
    [SerializeField] GameObject p4_center;
    [SerializeField] GameObject p4_centerBackground;
    [SerializeField] GameObject p4_background1;
    [SerializeField] GameObject p4_background2;
    [SerializeField] GameObject p4_hyperdrive;

    float timer = 30f;
    public int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("eyesCount", 0);
        PlayerPrefs.SetInt("obstacleSpeed", 0);

        //To resume the gameplay after a game over screen
        Time.timeScale = 1f;

        //To lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        shipNum = PlayerPrefs.GetInt("ship");
        SpaceshipSelect();

        //The boss will spawn after 5 phase changes
        if (levelCount >= 5)
        {
            bossTime = true;
        }

        //If the player collects 10 eyes, the boss will die
        eyeCount = PlayerPrefs.GetInt("eyesCount");
        if (bossTime && eyeCount >= 10)
        {
            scoreCon.GetComponent<ScoreController>().scoreNum += 50;
            bossTime = false;
            levelCount = 0;

            eyeBossSound.SetActive(false);
            eyeBossMusic.SetActive(false);

            backgroundMusic.SetActive(true);
            ambientSound.SetActive(true);
        }

        if(bossTime)
        {
            eyeBossSound.SetActive(true);
            eyeBossMusic.SetActive(true);

            backgroundMusic.SetActive(false);
            ambientSound.SetActive(false);
        }

        //After a set amount of time, the "level" will be switched.
        timer -= Time.deltaTime;
        if (timer <= 0.0f && !bossTime)
        {
            if (level == 1)
            {
                level = Random.Range(2, 5);
            }
            else if(level == 2)
            {
                level = Random.Range(3, 5);
            }
            else if (level == 3)
            {
                level = Random.Range(1, 3);
            }
            else if (level == 4)
            {
                level = Random.Range(1, 4);
            }

            timer = 30f;
            levelCount += 1;
            LevelSwitch();
        }
    }

    //The loaded spaceship depends on the player's choice
    void SpaceshipSelect()
    {
        if(shipNum == 0)
        {
            spaceship1.SetActive(true);
            spaceship2.SetActive(false);
            spaceship3.SetActive(false);
            spaceship4.SetActive(false);
        }
        else if (shipNum == 1)
        {
            spaceship1.SetActive(false);
            spaceship2.SetActive(true);
            spaceship3.SetActive(false);
            spaceship4.SetActive(false);
        }
        else if (shipNum == 2)
        {
            spaceship1.SetActive(false);
            spaceship2.SetActive(false);
            spaceship3.SetActive(true);
            spaceship4.SetActive(false);
        }
        else if (shipNum == 3)
        {
            spaceship1.SetActive(false);
            spaceship2.SetActive(false);
            spaceship3.SetActive(false);
            spaceship4.SetActive(true);
        }
    }

    void LevelSwitch()
    {
        levelSwSound.Play();

        //Which level is it
        if (level == 1)
        {
            p1_center.SetActive(true);
            p2_center.SetActive(false);
            p3_center.SetActive(false);
            p4_center.SetActive(false);

            p1_centerBackground.GetComponent<ParticleSystem>().Play();
            p1_background1.GetComponent<ParticleSystem>().Play();
            p1_background2.GetComponent<ParticleSystem>().Play();
            p1_background3.GetComponent<ParticleSystem>().Play();
            p1_hyperdrive.GetComponent<ParticleSystem>().Play();

            p2_centerBackground.GetComponent<ParticleSystem>().Stop();
            p2_background1.GetComponent<ParticleSystem>().Stop();
            p2_background2.GetComponent<ParticleSystem>().Stop();
            p2_background3.GetComponent<ParticleSystem>().Stop();
            p2_background4.GetComponent<ParticleSystem>().Stop();
            p2_hyperdrive.GetComponent<ParticleSystem>().Stop();

            p3_centerBackground.GetComponent<ParticleSystem>().Stop();
            p3_background1.GetComponent<ParticleSystem>().Stop();
            p3_background2.GetComponent<ParticleSystem>().Stop();
            p3_background3.GetComponent<ParticleSystem>().Stop();
            p3_background4.GetComponent<ParticleSystem>().Stop();
            p3_hyperdrive.GetComponent<ParticleSystem>().Stop();

            p4_centerBackground.GetComponent<ParticleSystem>().Stop();
            p4_background1.GetComponent<ParticleSystem>().Stop();
            p4_background2.GetComponent<ParticleSystem>().Stop();
            p4_hyperdrive.GetComponent<ParticleSystem>().Stop();

        }
        else if (level == 2)
        {
            p1_center.SetActive(false);
            p2_center.SetActive(true);
            p3_center.SetActive(false);
            p4_center.SetActive(false);

            p1_centerBackground.GetComponent<ParticleSystem>().Stop();
            p1_background1.GetComponent<ParticleSystem>().Stop();
            p1_background2.GetComponent<ParticleSystem>().Stop();
            p1_background3.GetComponent<ParticleSystem>().Stop();
            p1_hyperdrive.GetComponent<ParticleSystem>().Stop();

            p2_centerBackground.GetComponent<ParticleSystem>().Play();
            p2_background1.GetComponent<ParticleSystem>().Play();
            p2_background2.GetComponent<ParticleSystem>().Play();
            p2_background3.GetComponent<ParticleSystem>().Play();
            p2_background4.GetComponent<ParticleSystem>().Play();
            p2_hyperdrive.GetComponent<ParticleSystem>().Play();

            p3_centerBackground.GetComponent<ParticleSystem>().Stop();
            p3_background1.GetComponent<ParticleSystem>().Stop();
            p3_background2.GetComponent<ParticleSystem>().Stop();
            p3_background3.GetComponent<ParticleSystem>().Stop();
            p3_background4.GetComponent<ParticleSystem>().Stop();
            p3_hyperdrive.GetComponent<ParticleSystem>().Stop();

            p4_centerBackground.GetComponent<ParticleSystem>().Stop();
            p4_background1.GetComponent<ParticleSystem>().Stop();
            p4_background2.GetComponent<ParticleSystem>().Stop();
            p4_hyperdrive.GetComponent<ParticleSystem>().Stop();
        }
        else if (level == 3)
        {
            p1_center.SetActive(false);
            p2_center.SetActive(false);
            p3_center.SetActive(true);
            p4_center.SetActive(false);

            p1_centerBackground.GetComponent<ParticleSystem>().Stop();
            p1_background1.GetComponent<ParticleSystem>().Stop();
            p1_background2.GetComponent<ParticleSystem>().Stop();
            p1_background3.GetComponent<ParticleSystem>().Stop();
            p1_hyperdrive.GetComponent<ParticleSystem>().Stop();

            p2_centerBackground.GetComponent<ParticleSystem>().Stop();
            p2_background1.GetComponent<ParticleSystem>().Stop();
            p2_background2.GetComponent<ParticleSystem>().Stop();
            p2_background3.GetComponent<ParticleSystem>().Stop();
            p2_background4.GetComponent<ParticleSystem>().Stop();
            p2_hyperdrive.GetComponent<ParticleSystem>().Stop();

            p3_centerBackground.GetComponent<ParticleSystem>().Play();
            p3_background1.GetComponent<ParticleSystem>().Play();
            p3_background2.GetComponent<ParticleSystem>().Play();
            p3_background3.GetComponent<ParticleSystem>().Play();
            p3_background4.GetComponent<ParticleSystem>().Play();
            p3_hyperdrive.GetComponent<ParticleSystem>().Play();

            p4_centerBackground.GetComponent<ParticleSystem>().Stop();
            p4_background1.GetComponent<ParticleSystem>().Stop();
            p4_background2.GetComponent<ParticleSystem>().Stop();
            p4_hyperdrive.GetComponent<ParticleSystem>().Stop();
        }
        else if (level == 4)
        {
            p1_center.SetActive(false);
            p2_center.SetActive(false);
            p3_center.SetActive(false);
            p4_center.SetActive(true);

            p1_centerBackground.GetComponent<ParticleSystem>().Stop();
            p1_background1.GetComponent<ParticleSystem>().Stop();
            p1_background2.GetComponent<ParticleSystem>().Stop();
            p1_background3.GetComponent<ParticleSystem>().Stop();
            p1_hyperdrive.GetComponent<ParticleSystem>().Stop();

            p2_centerBackground.GetComponent<ParticleSystem>().Stop();
            p2_background1.GetComponent<ParticleSystem>().Stop();
            p2_background2.GetComponent<ParticleSystem>().Stop();
            p2_background3.GetComponent<ParticleSystem>().Stop();
            p2_background4.GetComponent<ParticleSystem>().Stop();
            p2_hyperdrive.GetComponent<ParticleSystem>().Stop();

            p3_centerBackground.GetComponent<ParticleSystem>().Stop();
            p3_background1.GetComponent<ParticleSystem>().Stop();
            p3_background2.GetComponent<ParticleSystem>().Stop();
            p3_background3.GetComponent<ParticleSystem>().Stop();
            p3_background4.GetComponent<ParticleSystem>().Stop();
            p3_hyperdrive.GetComponent<ParticleSystem>().Stop();

            p4_centerBackground.GetComponent<ParticleSystem>().Play();
            p4_background1.GetComponent<ParticleSystem>().Play();
            p4_background2.GetComponent<ParticleSystem>().Play();
            p4_hyperdrive.GetComponent<ParticleSystem>().Play();
        }
    }
}
