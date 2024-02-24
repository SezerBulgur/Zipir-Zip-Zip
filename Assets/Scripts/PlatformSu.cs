using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSu : Platform
{
    public float buoyancyForce = 5f; // Suyun icindeki platformlarin yukari itme kuvveti
    public float slowdownFactor = 0.5f; // Su platformuna carpildiginda hizin azaltilma faktoru

    // Start is called before the first frame update
    void Start()
    {
        // Eger ozel baslatma islemleri yapmaniz gerekiyorsa, buraya ekleyebilirsiniz.
    }

    // Update is called once per frame
    void Update()
    {
        // Eger ozel guncelleme islemleri yapmaniz gerekiyorsa, buraya ekleyebilirsiniz.
    }

    // Doodle karakteri bu ozel su platformuna carptiginda yapilacak islemler
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Karakter"))
        {
            // Ozel su platformlarinda ozel bir islem yapabilirsiniz.

            // Ornegin, karakterin hizini azaltan bir kuvvet uygulayabilirsiniz:
            collision.gameObject.GetComponent<Rigidbody2D>().velocity *= slowdownFactor;

            // Platformun suya carptigini gosteren bir ses efekti calabilirsiniz:
            AudioSource.PlayClipAtPoint(splashSound, transform.position);
        }
    }
}

