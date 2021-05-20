using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script decides when to spawn a "bad" purple asteroid
public class P4_DebrisController : MonoBehaviour
{
    [SerializeField] GameObject particle1;
    [SerializeField] GameObject particle2;
    [SerializeField] GameObject particle3;
    [SerializeField] GameObject particle4;
    [SerializeField] GameObject particle5;

    int randomNum;
    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(1, 8);
    }

    // Update is called once per frame
    void Update()
    {
        if(randomNum == 1)
        {
            particle1.SetActive(true);
            particle2.SetActive(true);
            particle3.SetActive(true);
            particle4.SetActive(true);
            particle5.SetActive(true);
        }
    }
}
