using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    [SerializeField] float hareketHizi;
    [SerializeField] float ziplamaKuvveti;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float yatayEksen = Input.GetAxis("Horizontal");
        gameObject.transform.Translate(yatayEksen * hareketHizi * Time.deltaTime, 0, 0);

    }

    public void KarakteriZiplat()
    {
        rb.AddForce(Vector2.up * ziplamaKuvveti);
    }
}
