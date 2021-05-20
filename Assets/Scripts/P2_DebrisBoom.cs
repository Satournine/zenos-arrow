using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for the bomb debris obstacles, commonly found during the red portal phase
public class P2_DebrisBoom : MonoBehaviour
{
    public GameObject explosionRed;
    float randomTime;

    // Start is called before the first frame update
    void Start()
    {
        randomTime = Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        randomTime -= Time.deltaTime;
        if (randomTime <= 0.0f)
        {
            Destroy(gameObject);
            //Explosion effect
            var explosionParticle = Instantiate(explosionRed, transform.position, transform.rotation);
        }
    }
}
