using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    private float startDelay = 2;
    private float startDelayPowers = 5;
    private float startDelayCoins = 7;
    private float repeatRate = 10;
    private float repeatRatePowers = 30;
    private float repeatRateCoins = 20;

    public GameObject obstaclePrefab;
    private Vector3 spawnPos;

    public static GameObject powerUpPrefab1;
    public static GameObject powerUpPrefab2;
    public static GameObject powerUpPrefab3;
    public static GameObject powerUpPrefab4;

    public GameObject coinPrefab;

    public GameObject powerUpPrefab;
    public GameObject[] powerUpTypes = {powerUpPrefab1, powerUpPrefab2, powerUpPrefab3, powerUpPrefab4};

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnPowers", startDelayPowers, repeatRatePowers);
        InvokeRepeating("SpawnCoins", startDelayCoins, repeatRateCoins);
        // playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObstacle()
    {
        //if (playerControllerScript.gameOver == false)
        //{
        spawnPos = new Vector3(0, 0, Random.Range(-5,5));
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        //}
    }
    void SpawnPowers()
    {
        //if (playerControllerScript.gameOver == false)
        //{
        spawnPos = new Vector3(0, 0, Random.Range(-5, 5));
        powerUpPrefab = powerUpTypes[Random.Range(0, 3)];
        Instantiate(powerUpPrefab, spawnPos, powerUpPrefab.transform.rotation); 
        //}
    }
    void SpawnCoins()
    {
        //if (playerControllerScript.gameOver == false)
        //{
        spawnPos = new Vector3(0, 0, Random.Range(-5, 5));
        Instantiate(coinPrefab, spawnPos, coinPrefab.transform.rotation);
        //}
    }
}
