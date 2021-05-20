using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //To destroy the asteroid that collides with the player.
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            //Explosion effect
            var explosionParticle = Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "P3Laser")
        {
            Destroy(gameObject);
            var explosionParticle = Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
