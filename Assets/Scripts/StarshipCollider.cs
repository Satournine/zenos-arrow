using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipCollider : MonoBehaviour
{
    public GameObject laserSound;
    public GameObject eyeSound;
    public GameObject powerupSound;

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject shield;
    [SerializeField] GameObject shieldParticle;
    [SerializeField] GameObject shootParticle;
    [SerializeField] GameObject eyeParticle;
    [SerializeField] GameObject laserParticle;

    bool powerShoot = false;

    //To defeat the eye boss, collect the eyes (value will be stored as a PlayerPrefs)
    int eyeCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PowerShoot();
        eyeCount = PlayerPrefs.GetInt("eyesCount");
    }

    private void OnTriggerEnter(Collider other) //If the player picks up the red power up, they will be able to shoot a projectile.
    {
        if (other.CompareTag("PowerUpShoot"))
        {
            powerShoot = true;
            Destroy(other.gameObject);

            GameObject pSound = Instantiate(powerupSound, transform.position, powerupSound.transform.rotation);

            shootParticle.GetComponent<ParticleSystem>().Play();
        }

        if (other.CompareTag("PowerUpShield")) //If the player picks up the green power up, they will protect themselves with a shield.
        {
            Destroy(other.gameObject);
            shield.SetActive(true);     //The shield will absorb 1 point of damage. (1 collision)

            GameObject pSound = Instantiate(powerupSound, transform.position, powerupSound.transform.rotation);

            shieldParticle.GetComponent<ParticleSystem>().Play();
        }

        if(other.CompareTag("EyePickup")) //Collect the eyes during the boss phase
        {
            Destroy(other.gameObject);
            GameObject eSound = Instantiate(eyeSound, transform.position, eyeSound.transform.rotation);

            eyeCount += 1;
            PlayerPrefs.SetInt("eyesCount", eyeCount);

            eyeParticle.GetComponent<ParticleSystem>().Play();
        }
    }

    private void PowerShoot()  //The shooting process. Press space to shoot.
    {
        if (Input.GetKey(KeyCode.Space) && powerShoot)
        {
            GameObject lSound = Instantiate(laserSound, transform.position, laserSound.transform.rotation);

            laserParticle.GetComponent<ParticleSystem>().Play();

            GameObject ShootProjectile = Instantiate(projectile, transform.position, projectile.transform.rotation);
            Destroy(ShootProjectile, 10f);

            powerShoot = false;
        }
    }
}
