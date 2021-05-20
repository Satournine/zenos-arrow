using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script controls the score system.
public class ScoreController : MonoBehaviour
{
    float timer1 = 30f;
    bool bossSpawn;
    public GameObject portalSwitcher;
    public Text scoreText;
    public int scoreNum;
    int scoreSpeed = 0; //The speed of the obstacles will increase with your score

    // Start is called before the first frame update
    void Start()
    {
        scoreNum = 0;
        scoreSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bossSpawn = portalSwitcher.GetComponent<PortalSwitch>().bossTime;

        PlayerPrefs.SetInt("obstacleSpeed", scoreSpeed);

        //To update the score text
        scoreText.text = scoreNum.ToString();

        if (!bossSpawn)
        {
            timer1 -= Time.deltaTime;
            if (timer1 <= 0.0f)
            {
                scoreNum += 10;
                timer1 = 30f;
                scoreSpeed += 1;
            }
        }
        
    }
}
