using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    private float startDelay = 2;
    private float repeatRate = 10;

    public GameObject obstaclePrefab;
    private Vector3 spawnPos;

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
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
        spawnPos = new Vector3(0, 0, Random.Range(-10,10));
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        //}
    }
}
