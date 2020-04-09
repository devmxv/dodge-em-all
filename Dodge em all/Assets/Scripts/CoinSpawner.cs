using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinSpawner : MonoBehaviour
{
    [SerializeField] int numberOfCoins = 0;
    [SerializeField] int waitForSpawn = 3;

    [Tooltip ("Define space in Y Axis where coin should spawn")]
    [SerializeField] float spawnCoinAreaMinValue = -1.0f;
    [Tooltip("Define space in Y Axis where coin should spawn")]
    [SerializeField] float spawnCoinAreaMaxValue = -4.0f;

    [SerializeField] GameObject coinObject;

    bool spawnCoin = true;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawnCoin)
        {
            yield return new WaitForSeconds(waitForSpawn);
            SpawnCoin();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnCoin()
    {
        float xPosition = 0;
        float yPosition = 0;

        xPosition = UnityEngine.Random.Range(-7f, 7f);
        //yPosition = UnityEngine.Random.Range(-4f, 4f);
        yPosition = UnityEngine.Random.Range(spawnCoinAreaMinValue, spawnCoinAreaMaxValue);
        transform.position = new Vector2(xPosition, yPosition);

        Spawn(coinObject);



    }

    private void Spawn(GameObject coinObject)
    {
        GameObject newCoin =
        Instantiate(coinObject, transform.position, transform.rotation) as GameObject;
        newCoin.transform.parent = transform;


    }
}
