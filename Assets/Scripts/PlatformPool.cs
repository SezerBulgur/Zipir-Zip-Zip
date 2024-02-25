using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    public static PlatformPool instance;

    [SerializeField] private int amountPlatforms = 100;
    [SerializeField] private int amountSuPlatforms = 20;
    [SerializeField] private int amountLavaPlatforms = 20;



    private List<GameObject> pooledPlatforms = new List<GameObject>();
    private List<GameObject> pooledSuPlatforms = new List<GameObject>();
    private List<GameObject> pooledLavaPlatforms = new List<GameObject>();



    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject suPlatformPrefab;
    [SerializeField] private GameObject lavaPlatformPrefab;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountPlatforms; i++)
        {
            GameObject platform = Instantiate(platformPrefab);

            //ayni zamanda yok etmek istedigimiz platformunda SetActive degerini false ayarlariz
            platform.SetActive(false);
            pooledPlatforms.Add(platform);
        }
        for (int i = 0; i < amountSuPlatforms; i++)
        {
            GameObject suPlatform = Instantiate(suPlatformPrefab);

            //ayni zamanda yok etmek istedigimiz platformunda SetActive degerini false ayarlariz
            suPlatform.SetActive(false);
            pooledSuPlatforms.Add(suPlatform);
        }
        for (int i = 0; i < amountLavaPlatforms; i++)
        {
            GameObject lavaPlatform = Instantiate(lavaPlatformPrefab);

            //ayni zamanda yok etmek istedigimiz platformunda SetActive degerini false ayarlariz
            lavaPlatform.SetActive(false);
            pooledLavaPlatforms.Add(lavaPlatform);
        }
    }


    public GameObject GetObjectFromPlatformPool()
    {
        for (int i = 0; i < pooledPlatforms.Count; i++)
        {
            //buradan cagirilan platform, platform nesnesi icinde spawn tarzi bir metodun icinde kullanilmali
            if (!pooledPlatforms[i].activeInHierarchy) 
            {   
                return pooledPlatforms[i];
            }
            
        }

        return null;
    }

    public GameObject GetObjectFromSuPlatformPool()
    {
        for (int i = 0; i < pooledSuPlatforms.Count; i++)
        {
            //buradan cagirilan platform, platform nesnesi icinde spawn tarzi bir metodun icinde kullanilmali
            if (!pooledSuPlatforms[i].activeInHierarchy) 
            {   
                return pooledSuPlatforms[i];
            }
            
        }

        return null;
    }
}
