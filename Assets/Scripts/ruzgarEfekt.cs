using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindEffect : MonoBehaviour
{
    public float windForce = 5f; // Ruzgar Kuvveti
    public float changeDirectionInterval = 2f; // Ruzgarin yonunu degistirme ve araligi
    private Vector2 windDirection; // Ruzgarin gecerli yonu

    private float timer = 0f;

    void Start()
    {
        // Baslangicta rastgele bir ruzgar yonu olustur
        SetRandomWindDirection();
    }

    void Update()
    {
        // Belirli araliklarla ruzgar yonunu degistir
        timer += Time.deltaTime;
        if (timer >= changeDirectionInterval)
        {
            SetRandomWindDirection();
            timer = 0f;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Ruzgar etkisi uygula sadece belirli tipte nesneler uzerinde (ornegin, oyuncu)
        if (other.CompareTag("Karakter"))
        {
            Rigidbody2D otherRigidbody = other.GetComponent<Rigidbody2D>();
            if (otherRigidbody != null)
            {
                // Ruzgar kuvvetini uygula
                otherRigidbody.AddForce(windDirection * windForce, ForceMode2D.Force);
            }
        }
    }

    void SetRandomWindDirection()
    {
        // Rastgele bir yon belirle
        windDirection = new Vector2(Random.Range(-1f, 1f), 0f).normalized;
    }
}

