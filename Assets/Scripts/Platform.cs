using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  Platform.cs
//  Zipir-Zip-Zip
//
//  Created by Mehmet Ali on 23/02/2024.
//

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) //karakter platforma çarptýðý zaman güç uygulayacak
    {
        if (collision.gameObject.CompareTag("Karakter")
        {
            if(collision.relativeVelocity.y <= 0f) 
            {
            
            }
            collision.gameObject.GetComponent<Karakter>().KarakteriZiplat();
            Destroy(this.gameObject);
        }
    }
}
