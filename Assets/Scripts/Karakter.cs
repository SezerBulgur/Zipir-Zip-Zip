using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    [SerializeField] float hareketHizi;
    [SerializeField] float ziplamaKuvveti;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float yatayEksen = Input.GetAxis("Horizontal");
        gameObject.transform.Translate(yatayEksen * hareketHizi * Time.deltaTime, 0, 0);
        if (yatayEksen < 0) {
            spriteRenderer.flipX = true;
        } else if (yatayEksen > 0) {
            spriteRenderer.flipX = false;
        }

    }

    public void KarakteriZiplat()
    {
        rb.velocity = new Vector2(rb.velocity.x, ziplamaKuvveti);
        // rb.AddForce(Vector2.up * ziplamaKuvveti);
        // if (rb.velocity.y >= 10) 
        // {
            
        // }
    }
}
