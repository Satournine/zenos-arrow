using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the eye boss
public class EyeBoss : MonoBehaviour
{
    GameObject bossBeam;
    AudioSource bossBeamSound;
    public AudioSource bossBeamStop;
    public GameObject bossGrowl;
    public GameObject bossDie;

    int eyeCount;
    public GameObject realBoss;
    public GameObject beams;

    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
    public GameObject laser4;

    public GameObject warp1;
    public GameObject warp2;
    public GameObject warp3;
    public GameObject warp4;

    public GameObject shootCollider1;
    public GameObject shootCollider2;
    public GameObject shootCollider3;
    public GameObject shootCollider4;
    public GameObject shootColliderMain;

    Animator anim;
    float timerWarning = 8.5f;
    float timer = 10f;
    float timer2 = 6f;
    bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bossBeam = GameObject.FindWithTag("BeamSound");
        bossBeamSound = bossBeam.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //The boss will die if the player collects 10 eyes
        eyeCount = PlayerPrefs.GetInt("eyesCount");
        if(eyeCount >= 10)
        {
            timer = 100f;
            anim.SetInteger("State", 2);

            bossDie.SetActive(true);
        }

        //To warn the player 
        timerWarning -= Time.deltaTime;
        if(timerWarning <= 0.0f && !shoot)
        {
            bossGrowl.SetActive(true);

            warp1.GetComponent<ParticleSystem>().Play();
            warp2.GetComponent<ParticleSystem>().Play();
            warp3.GetComponent<ParticleSystem>().Play();
            warp4.GetComponent<ParticleSystem>().Play();
        }

        //After some time, the eye will shoot
        timer -= Time.deltaTime;
        if(timer <= 0.0f && !shoot)
        {
            bossBeamSound.Play();

            shoot = true;
            beams.SetActive(true);

            shootCollider1.SetActive(true);
            shootCollider2.SetActive(true);
            shootCollider3.SetActive(true);
            shootCollider4.SetActive(true);

            laser1.GetComponent<ParticleSystem>().Play();
            laser2.GetComponent<ParticleSystem>().Play();
            laser3.GetComponent<ParticleSystem>().Play();
            laser4.GetComponent<ParticleSystem>().Play();
        }

        //The eye will continue shooting for a set amount of time
        if(shoot)
        {
            anim.SetInteger("State", 1);

            shootColliderMain.transform.Rotate(0, 0, 30 * Time.deltaTime);

            //It will then get tired, and return back to its idle state
            timer2 -= Time.deltaTime;
            if (timer2 <= 0.0f)
            {
                bossBeamSound.Stop();
                bossBeamStop.Play();
                bossGrowl.SetActive(false);

                beams.SetActive(false);

                shootCollider1.SetActive(false);
                shootCollider2.SetActive(false);
                shootCollider3.SetActive(false);
                shootCollider4.SetActive(false);

                warp1.GetComponent<ParticleSystem>().Stop();
                warp2.GetComponent<ParticleSystem>().Stop();
                warp3.GetComponent<ParticleSystem>().Stop();
                warp4.GetComponent<ParticleSystem>().Stop();

                laser1.GetComponent<ParticleSystem>().Stop();
                laser2.GetComponent<ParticleSystem>().Stop();
                laser3.GetComponent<ParticleSystem>().Stop();
                laser4.GetComponent<ParticleSystem>().Stop();

                shootColliderMain.transform.rotation = Quaternion.Euler(0, 0, 0);

                anim.SetInteger("State", 0);
                timer2 = 6f;
                timer = 10f;
                timerWarning = 8.5f;
                shoot = false;
            }
        }
    }

    //Animation event, destroy the boss and reset the eye count
    void DestroyEye()
    {
        Destroy(realBoss);
        PlayerPrefs.SetInt("eyesCount", 0);
    }
}
