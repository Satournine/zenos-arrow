using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipController : MonoBehaviour
{
    [SerializeField] private AudioClip[] TeleportSFX;
    [SerializeField] private AudioSource sourceofTeleport;
    [SerializeField] GameObject warpParticle;
    [SerializeField] GameObject warpParticle2;
    [SerializeField] private float speed;
    private float coordX;
    private float coordY;
    private Vector3 target = new Vector3(0.0f, 5.0f, 0.0f);
    private float jumpTimeCooldown;
    private float jumpTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        sourceofTeleport = GetComponent<AudioSource>();
        sourceofTeleport.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Directions();
        HoltzmanEffect();
    }

    private void HoltzmanEffect()
    {
        if (Input.GetKey(KeyCode.W) && Time.time > jumpTimeCooldown)
        {
            var warpPart = Instantiate(warpParticle, transform.position, transform.rotation);
            warpParticle2.GetComponent<ParticleSystem>().Play();

            jumpTimeCooldown = Time.time + jumpTimer;
            coordY = 13 - gameObject.transform.position.y;
            coordX = -gameObject.transform.position.x;
            transform.position = new Vector3(coordX, coordY);
            transform.Rotate(0, 0, 180);
            sourceofTeleport.PlayOneShot(TeleportSFX[Random.Range(0, TeleportSFX.Length)]);
            sourceofTeleport.Play();
        }
    }

    private void Directions()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.RotateAround(new Vector3(-0.2f, 6.5f, 147.3f), new Vector3(0f, 0f, 1f), 90f * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.RotateAround(new Vector3(-0.2f, 6.5f, 147.3f), new Vector3(0f, 0f, -1f), 90f * Time.deltaTime * speed);
        }
    }
}
