using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAtes : Platform
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionExit2D(Collision2D col)
    {
        // Nesnenin baþka bir nesneye çarpmayý býraktýðý durumu izler
        if (col.gameObject.CompareTag("Karakter"))
        {
            // "Karakter" etiketine sahip bir objeye çarpmayý býraktýðýnda çalýþýr

            Destroy(gameObject);
        }
    }



}
