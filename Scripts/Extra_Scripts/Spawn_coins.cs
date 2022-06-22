using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_coins : MonoBehaviour
{
    public GameObject coinPrefab;

    GameObject[] allCoinSpawns;

    private List<GameObject> allCoins = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        allCoinSpawns = GameObject.FindGameObjectsWithTag("CoinSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateCoins()
    {
        foreach (GameObject currentCoin in allCoinSpawns)
        {
            GameObject newCoin = Instantiate(coinPrefab, currentCoin.transform);
            allCoins.Add(newCoin);
        }
    }
    public void DestroyAllCoins()
    {
        foreach (GameObject currentCoin in allCoins)
        {
            Destroy(currentCoin);
        }
    }
}
