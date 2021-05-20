using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject LevelSwitcher;
    int level;
    bool powerUpDoIt = false;

    //Boss
    public GameObject boss1;
    public GameObject bossPoint;
    bool bossBattle;
    bool bossSpawned = false;
    int eyeCount;

    public GameObject[] SpaceJunk;
    public GameObject[] SpaceJunk2;
    public GameObject[] SpaceJunk3;
    public GameObject[] SpaceJunk4;
    public GameObject[] PowerUps;
    public GameObject[] BossJunk;
    private float spawnRangeX = 36;
    private float spawnRangeY = 39;
    private float spawnRangenegY = -30;
    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float powerUpDelay = 2f;
    [SerializeField] private float powerUpInterval = 10f;
    Vector3 point = new Vector3(-0.2f, 6.5f, 147.3f);


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpaceFlowCircle", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        level = LevelSwitcher.GetComponent<PortalSwitch>().level;
        bossBattle = LevelSwitcher.GetComponent<PortalSwitch>().bossTime;

        //Powerup spawn timer
        powerUpInterval -= Time.deltaTime;
        if (powerUpInterval <= 0.0f)
        {
            powerUpDoIt = true;
            powerUpInterval = 10f;
        }

        //To reset the boss spawn
        eyeCount = PlayerPrefs.GetInt("eyesCount");
        if (eyeCount >= 10)
        {
            bossSpawned = false;
        }
    }

    /*   private void SpaceFlow()                  // OLD SPAWNER SPAWNS THEM OBJECTS EVERYWHER
       {
           int index = Random.Range(0, SpaceJunk.Length);
           Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(spawnRangenegY, spawnRangeY), 275);
           Instantiate(SpaceJunk[index], spawnPosition, SpaceJunk[index].transform.rotation);
       }*/

    private void SpaceFlowCircle()   // QUICK MATHS 
    {
        
        int index = Random.Range(0, SpaceJunk.Length);
        int indexPower = Random.Range(0, PowerUps.Length);
        float radius = 34.25f;
        int num = SpaceJunk.Length;
        int angle = Random.Range(0, 360); 
        float XAngle =radius * Mathf.Cos(angle);
        float YAngle = radius * Mathf.Sin(angle);
        Vector3 spawnVector = new Vector3(XAngle, YAngle, 0);
        var spawnPosition = point + spawnVector;

        //Spawn powerups
        if(powerUpDoIt)
        {
            Instantiate(PowerUps[indexPower], spawnPosition, PowerUps[index].transform.rotation);
            powerUpDoIt = false;
        }

        //The spawned items depend on the current level
        if (level == 1 && !bossBattle)
        {
            Instantiate(SpaceJunk[index], spawnPosition, SpaceJunk[index].transform.rotation);
        }
        else if(level == 2 && !bossBattle)
        {
            Instantiate(SpaceJunk2[index], spawnPosition, SpaceJunk2[index].transform.rotation);
        }
        else if (level == 3 && !bossBattle)
        {
            Instantiate(SpaceJunk3[index], spawnPosition, SpaceJunk3[index].transform.rotation);
        }
        else if (level == 4 && !bossBattle)
        {
            Instantiate(SpaceJunk4[index], spawnPosition, SpaceJunk4[index].transform.rotation);
        }

        //For the eye boss
        if (bossBattle)
        {
            if(!bossSpawned)
            {
                var boss = Instantiate(boss1, bossPoint.transform.position, bossPoint.transform.rotation);
                bossSpawned = true;
            }
            
            Instantiate(BossJunk[index], spawnPosition, BossJunk[index].transform.rotation);
        }


        /* for (int i = 0; i<num; i++)              // SPAWNS 5 SAME OBJECTS IN A CIRCULAR FORMATION
         {
             var radians = 2 * Mathf.PI / num * i;
             var vertical = Mathf.Sin(radians);
             var horizontal = Mathf.Cos(radians);
             print(vertical);
             print(horizontal);
             var spawnVector = new Vector3(horizontal, vertical, 0);
             var spawnPosition = point + spawnVector * radius;

             var Junks = Instantiate(SpaceJunk[index], spawnPosition, SpaceJunk[index].transform.rotation);
             Junks.transform.Translate(new Vector3(0, Junks.transform.localScale.y / 2, 0));

         }*/

    }
}
