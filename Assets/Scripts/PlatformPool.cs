using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    public static PlatformPool instance;

    [SerializeField] private int amountPlatforms = 20;

    private List<GameObject> pooledPlatforms = new List<GameObject>();

    [SerializeField] private GameObject platformPrefab;

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
    }

    public GameObject GetObjectFromPool()
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
}
