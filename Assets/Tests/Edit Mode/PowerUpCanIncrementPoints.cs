using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PowerUpCanIncrementPoints
{
    // A Test behaves as an ordinary method
    [Test]
    public void PowerUpCanIncrementPointsByPointChange()
    {
        //Assign
        GameObject powerUp = new GameObject("Power Up");
        PowerUpDisplay powerUpDisplay = powerUp.AddComponent<PowerUpDisplay>();
        powerUpDisplay.pointChange = 3;
        Points points = powerUp.AddComponent<Points>();
        Points.Instance = points;

        int initial_points = points.point;

        //Act
        powerUpDisplay.IncrementPoints(powerUpDisplay.pointChange);

        //Assert
        Assert.AreEqual(initial_points + powerUpDisplay.pointChange, points.point);
    }
}
