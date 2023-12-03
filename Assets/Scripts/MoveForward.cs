using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 30.0f;
    public float backBound = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("RobotKyle").GetComponent<PlayerController>().gameOver)
        {
            speed = GameObject.Find("RobotKyle").GetComponent<PlayerController>().obstacleSpeed;
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (transform.position.x > backBound)
            {
                Destroy(gameObject);
            }
        }
    }
}
