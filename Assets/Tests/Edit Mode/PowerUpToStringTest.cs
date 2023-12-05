using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PowerUpToStringTest
{
    [Test]
    public void PowerUpToStringTester()
    {
        //Assign
        GameObject powerUp = new GameObject("Power Up");
        PowerUpDisplay powerUpDisplay = powerUp.AddComponent<PowerUpDisplay>();
        powerUpDisplay.powerName = "Power Up";
        powerUpDisplay.description = "A cool powerup!";

        //Act
        string result = powerUpDisplay.ToString();

        //Assert
        Assert.AreEqual("Power Up: A cool powerup!", result); 
    }
}
