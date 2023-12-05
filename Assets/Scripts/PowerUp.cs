using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPowerUp", menuName ="Power Up")]
public class PowerUp : ScriptableObject
{
    public string powerName;
    public string description;

    public float speedMultiplier;
    public float jumpMultiplier;

    public int pointChange;

    public void PowerUpText()
    {
        Debug.Log("You got a power up!");
    }
}
