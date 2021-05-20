using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFlow : MonoBehaviour
{
    [SerializeField] float speed = 20;

    bool speedIncrease = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!speedIncrease)
        {
            speed += PlayerPrefs.GetInt("obstacleSpeed"); //Increment the speed of the obstacles periodically
            speedIncrease = true;
        }
        
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
