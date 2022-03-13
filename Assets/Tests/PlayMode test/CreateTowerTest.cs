using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CreateTowerTest
{
    [UnityTest]
    public IEnumerator CreateTowerTestWithEnumeratorPasses()
    {
        GameObject testTower = new GameObject();
        Tower tower = testTower.AddComponent<Tower>();

        Assert.AreEqual(1, tower.towerLevels.Count);
        yield return null;
    }
}
