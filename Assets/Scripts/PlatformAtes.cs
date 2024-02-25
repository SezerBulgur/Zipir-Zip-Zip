using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAtes : Platform
{
    float platformMaxX = 5f;
    float platformMinX = -5f;
    float platformMaxY = 2f;
    float platformMinY = 1.6f;
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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

    void OnCollisionExit2D(Collision2D col)
    {
        // Nesnenin ba�ka bir nesneye �arpmay� b�rakt��� durumu izler
        if (col.gameObject.CompareTag("Karakter"))
        {
            // "Karakter" etiketine sahip bir objeye �arpmay� b�rakt���nda �al���r

            gameObject.SetActive(false);
            //SpawnPlatform();        
        }
    }

    public void SpawnLavaPlatform() 
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

}
