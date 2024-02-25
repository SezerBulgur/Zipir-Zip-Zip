using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ground : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] public GameObject ground;
    [SerializeField] public int kameraFarki;

    private Vector2 lastPosition;

    void OnEnable()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Karakter").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        Vector2 lastVektor = new Vector2();
        lastVektor = playerTransform.position;
        lastVektor.y = lastVektor.y - kameraFarki;
        lastPosition = lastVektor;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y >= lastPosition.y + kameraFarki)
        {
            lastPosition.y = playerTransform.position.y - kameraFarki;

            Vector2 groundVektor = new Vector2();
            groundVektor.x = ground.transform.position.x;
            groundVektor.y = lastPosition.y;
            ground.transform.position = groundVektor;
            // Call your custom function or perform actions here
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Karakter"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
