using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBossAppear : MonoBehaviour
{
    [SerializeField] float speed = 20;
    bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        if (transform.position.z <= 116.4)
        {
            move = false;
        }
    }
}
