using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PowerUpDisplay : MonoBehaviour
{
    public PowerUp powerUp;

    public string powerName;
    public string description;

    public float speedMultiplier;
    public float jumpMultiplier;
 
    public int pointChange;

    // Start is called before the first frame update
    void Start()
    {
        powerName = powerUp.powerName;
        description = powerUp.description;

        speedMultiplier = powerUp.speedMultiplier;
        jumpMultiplier = powerUp.jumpMultiplier;

        pointChange = powerUp.pointChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // powerUp.ApplyPowerUp();
            GameObject player = GameObject.Find("RobotKyle");

            PlayerController playerController = player.GetComponent<PlayerController>();
            //ThirdPersonController playerController2 = player.GetComponent<ThirdPersonController>();

            playerController.speed *= speedMultiplier;
            //playerController2.JumpHeight *= jumpMultiplier;

            IncrementPoints(pointChange);

            playerController.CoolDown();

            powerUp.PowerUpText();

            Destroy(gameObject);
        }
    }

    public void IncrementPoints(int pointChange)
    {
        Points.Instance.point += pointChange;
    }

    override
    public string ToString()
    {
        return powerName + ": " + description;
    }
}
