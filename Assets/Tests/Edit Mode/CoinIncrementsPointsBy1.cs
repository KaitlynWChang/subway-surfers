using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CoinIncrementsPointsBy1
{
    [Test]
    public void CoinCanIncrementsPointsBy1()
    {
        //Assign
        GameObject player = new GameObject("Robot Kyle");
        PlayerController controller = player.AddComponent<PlayerController>();
        Points points = player.AddComponent<Points>();
        Points.Instance = points; 
        
        int initial_points = points.point;

        //Act
        controller.IncrementPoints();

        //Assert
        Assert.AreEqual(initial_points + 1, points.point);
    }
}
