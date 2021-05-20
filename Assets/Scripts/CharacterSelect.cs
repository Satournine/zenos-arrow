using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the character selection. Once a spaceship is selected, the selection will be saved
public class CharacterSelect : MonoBehaviour
{
    public GameObject parentMenu;
    public GameObject characterSelectMenu;

    public GameObject warp1;
    public GameObject warp2;
    public GameObject warp3;
    public GameObject warp4;

    public GameObject ship1;
    public GameObject ship2;
    public GameObject ship3;
    public GameObject ship4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //PlayerPrefs stores the specified int value
    public void Blue()
    {
        PlayerPrefs.SetInt("ship", 0);
        PlayerPrefs.Save();

        warp1.GetComponent<ParticleSystem>().Play();
        warp2.GetComponent<ParticleSystem>().Play();
        warp3.GetComponent<ParticleSystem>().Play();
        warp4.GetComponent<ParticleSystem>().Play();

        ship1.SetActive(false);
        ship2.SetActive(false);
        ship3.SetActive(false);
        ship4.SetActive(false);

        parentMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Red()
    {
        PlayerPrefs.SetInt("ship", 1);
        PlayerPrefs.Save();

        warp1.GetComponent<ParticleSystem>().Play();
        warp2.GetComponent<ParticleSystem>().Play();
        warp3.GetComponent<ParticleSystem>().Play();
        warp4.GetComponent<ParticleSystem>().Play();

        ship1.SetActive(false);
        ship2.SetActive(false);
        ship3.SetActive(false);
        ship4.SetActive(false);

        parentMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Green()
    {
        PlayerPrefs.SetInt("ship", 2);
        PlayerPrefs.Save();

        warp1.GetComponent<ParticleSystem>().Play();
        warp2.GetComponent<ParticleSystem>().Play();
        warp3.GetComponent<ParticleSystem>().Play();
        warp4.GetComponent<ParticleSystem>().Play();

        ship1.SetActive(false);
        ship2.SetActive(false);
        ship3.SetActive(false);
        ship4.SetActive(false);

        parentMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Black()
    {
        PlayerPrefs.SetInt("ship", 3);
        PlayerPrefs.Save();

        warp1.GetComponent<ParticleSystem>().Play();
        warp2.GetComponent<ParticleSystem>().Play();
        warp3.GetComponent<ParticleSystem>().Play();
        warp4.GetComponent<ParticleSystem>().Play();

        ship1.SetActive(false);
        ship2.SetActive(false);
        ship3.SetActive(false);
        ship4.SetActive(false);

        parentMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
