using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script deactivates the collider of the shooting obstacles
public class P3_ColliderDestroyer : MonoBehaviour
{
    float timer = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
