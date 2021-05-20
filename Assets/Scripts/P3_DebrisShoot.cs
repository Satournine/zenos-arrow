using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for the shooting debris, commonly found during the yellow portal phase
public class P3_DebrisShoot : MonoBehaviour
{
    [SerializeField] GameObject warningParticle;
    [SerializeField] GameObject shootParticle;
    [SerializeField] GameObject shootCollider;
    [SerializeField] GameObject explosion;

    float timer = 2.2f;
    int randomNum;
    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //If 1, shoot
        if(randomNum == 1)
        {
            //To warn the player
            warningParticle.SetActive(true);

            //The asteroid will shoot a beam after some time. The beam destroys everything it hits.
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                shootCollider.SetActive(true);
                shootParticle.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
