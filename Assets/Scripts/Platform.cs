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
    Transform playerTransform;

//BU KODU YAZINCA UNITY PROJEYI ACAMIYOR
    //PlatformSu platformSu = new PlatformSu();
    
    void OnEnable()
    {
        if (GameObject.FindGameObjectWithTag("Karakter").transform != null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Karakter").transform;
        }
    }
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Karakter").transform;

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
            GameObject platform = PlatformPool.instance.GetObjectFromPlatformPool();
            if (platform != null)
            {
                Vector2 platformVektor = new Vector2();
                platformVektor.x = Random.Range(platformMinX, platformMaxX);
                platformVektor.y += Random.Range(playerTransform.position.y, playerTransform.position.y + 5);
                platform.transform.position = platformVektor;
                platform.SetActive(true);
            }
        }
        GameObject suPlatform = PlatformPool.instance.GetObjectFromSuPlatformPool();
        if (suPlatform != null)
            {
                Vector2 platformVektor = new Vector2();
                platformVektor.x = Random.Range(platformMinX, platformMaxX);
                platformVektor.y += Random.Range(playerTransform.position.y, playerTransform.position.y + 5);
                suPlatform.transform.position = platformVektor;
                suPlatform.SetActive(true);
            }
        GameObject lavaPlatform = PlatformPool.instance.GetObjectFromLavaPlatformPool();
            if (suPlatform != null)
            {
                Vector2 platformVektor = new Vector2();
                platformVektor.x = Random.Range(platformMinX, platformMaxX);
                platformVektor.y += Random.Range(playerTransform.position.y, playerTransform.position.y + 5);
                lavaPlatform.transform.position = platformVektor;
                lavaPlatform.SetActive(true);
            }
        //BU KODU YAZINCA UNITY PROJEYI ACAMIYOR
        //platformSu.SpawnSuPlatform();       
    }

    private void OnCollisionEnter2D(Collision2D collision) //karakter platforma carptigi zaman guc uygulayacak
    {
        if (collision.gameObject.CompareTag("Karakter"))
        {
            if(collision.relativeVelocity.y <= 0.5f) 
            {
                collision.gameObject.GetComponent<Karakter>().KarakteriZiplat();
                gameObject.SetActive(false);
                this.SpawnPlatform();


            }
            //Destroy(this.gameObject);
        }
    }
}
