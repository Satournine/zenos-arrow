using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollider : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            Destroy(other.gameObject);

            var explosionParticle = Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
