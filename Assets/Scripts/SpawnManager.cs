using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    private float __startDelay = 2;
    private float __startDelayPowers = 5;
    private float __startDelayCoins = 7;
    private float __repeatRate = 10;
    private float __repeatRatePowers = 30;
    private float __repeatRateCoins = 20;

    public GameObject ObstaclePrefab;
    private Vector3 __spawnPos;

    public static GameObject PowerUpPrefab1;
    public static GameObject PowerUpPrefab2;
    public static GameObject PowerUpPrefab3;
    public static GameObject PowerUpPrefab4;

    public GameObject CoinPrefab;

    public GameObject PowerUpPrefab;
    public GameObject[] PowerUpTypes = { PowerUpPrefab1, PowerUpPrefab2, PowerUpPrefab3, PowerUpPrefab4 };

    private PlayerController __playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", __startDelay, __repeatRate);
        InvokeRepeating("SpawnPowers", __startDelayPowers, __repeatRatePowers);
        InvokeRepeating("SpawnCoins", __startDelayCoins, __repeatRateCoins);
        // playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("RobotKyle").GetComponent<PlayerController>().gameOver)
        {
            CancelInvoke("SpawnObstacle");
            CancelInvoke("SpawnPowers");
            CancelInvoke("SpawnCoins");
        }
    }
    void SpawnObstacle()
    {
        //if (__playerControllerScript.gameOver == false)
        //{
        __spawnPos = new Vector3(0, 0, Random.Range(-5, 5));
        Instantiate(ObstaclePrefab, __spawnPos, ObstaclePrefab.transform.rotation);
        //}
    }
    void SpawnPowers()
    {
        //if (__playerControllerScript.gameOver == false)
        //{
        __spawnPos = new Vector3(0, 0, Random.Range(-5, 5));
        PowerUpPrefab = PowerUpTypes[Random.Range(0, 3)];
        Instantiate(PowerUpPrefab, __spawnPos, PowerUpPrefab.transform.rotation);
        //}
    }
    void SpawnCoins()
    {
        //if (__playerControllerScript.gameOver == false)
        //{
        __spawnPos = new Vector3(0, 0, Random.Range(-5, 5));
        Instantiate(CoinPrefab, __spawnPos, CoinPrefab.transform.rotation);
        //}
    }
}
