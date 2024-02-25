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
        // Nesnenin ba�ka bir nesneye �arpmay� b�rakt��� durumu izler
        if (col.gameObject.CompareTag("Karakter"))
        {
            // "Karakter" etiketine sahip bir objeye �arpmay� b�rakt���nda �al���r

            Destroy(gameObject);
        }
    }



}
