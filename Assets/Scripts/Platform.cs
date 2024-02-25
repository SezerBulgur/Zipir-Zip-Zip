using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//
//  Platform.cs
//  Zipir-Zip-Zip
//
//  Created by Mehmet Ali on 23/02/2024.
//

public class Platform : MonoBehaviour
{
    [SerializeField] float platformMaxX = 5f;
    [SerializeField] float platformMinX = -5f;
    [SerializeField] float platformMaxY = 2f;
    [SerializeField] float platformMinY = 1.6f;
    [SerializeField] Transform playerTransform;
    
    void OnEnable()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Karakter").transform;
    }
    void Start()
    {
        // for (int i = 0; i < 5; i++)
        // {
        //     SpawnPlatform();
        // }
    }

    void Update()
    {
        if (playerTransform.position.y - 10 > transform.position.y)
        {
            gameObject.SetActive(false);
        }
    }
    public void SpawnPlatform() 
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject platform = PlatformPool.instance.GetObjectFromPool();
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

    private void OnCollisionEnter2D(Collision2D collision) //karakter platforma carptigi zaman guc uygulayacak
    {
        if (collision.gameObject.CompareTag("Karakter"))
        {
            if(collision.relativeVelocity.y <= 0f) 
            {
                collision.gameObject.GetComponent<Karakter>().KarakteriZiplat();
                gameObject.SetActive(false);
                SpawnPlatform();


            }
            //Destroy(this.gameObject);
        }
    }
}
