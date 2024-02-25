using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSu : Platform
{
    float platformMaxX = 5f;
    float platformMinX = -5f;
    float platformMaxY = 2f;
    float platformMinY = 1.6f;
    Transform playerTransform;


    public float buoyancyForce = 5f; // Suyun icindeki platformlarin yukari itme kuvveti
    public float slowdownFactor = 0.4f; // Su platformuna carpildiginda hizin azaltilma faktoru

    void OnEnable()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Karakter").transform;
    }

    void Update()
    {
        if (playerTransform.position.y - 10 > transform.position.y)
        {
            gameObject.SetActive(false);
        }
    }

    public void SpawnSuPlatform() 
    {

        for (int i = 0; i < 3; i++)
        {
            GameObject platform = PlatformPool.instance.GetObjectFromSuPlatformPool();
            if (platform != null)
            {
                Vector2 platformVektor = new Vector2();
                platformVektor.x = Random.Range(platformMinX, platformMaxX);
                platformVektor.y += Random.Range(playerTransform.position.y, playerTransform.position.y + 5);
                platform.transform.position = platformVektor;
                platform.SetActive(true);
            }
        }
        
    }

    // Doodle karakteri bu ozel su platformuna carptiginda yapilacak islemler
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Karakter"))
        {
            if(collision.relativeVelocity.y <= 0.5f) 
            {
                collision.gameObject.GetComponent<Karakter>().KarakteriZiplat();
                gameObject.SetActive(false);
                //SpawnPlatform();
                collision.gameObject.GetComponent<Rigidbody2D>().velocity *= slowdownFactor;


            }
            //Destroy(this.gameObject);
        }
    }
}

