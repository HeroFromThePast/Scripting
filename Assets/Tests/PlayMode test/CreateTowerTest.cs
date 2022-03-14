using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CreateTowerTest
{
    [UnityTest]
    public IEnumerator CreateTowerTestWithOneLevel()
    {
        GameObject towerCraftObj = new GameObject();
        TowerCrafter towerCrafter = towerCraftObj.AddComponent<TowerCrafter>();

        //Torre de 1 nivel
        Tower towerTest;
        EnemyScript enemyTest1 = new GameObject().AddComponent<EnemyScript>();
        enemyTest1.UnitName = DefaultEnemy.UnitName;
        enemyTest1.level = DefaultEnemy.level;

        //Torre de un nivel
        towerTest = towerCrafter.CreateTower(enemyTest1, TowerTypes.TowerType.EnemyTower);

        Assert.AreEqual(1, towerTest.towerLevels.Count);

        yield return null;
        
    }

    [UnityTest]
    public IEnumerator AttempToCreateATowerWihtEmptyArray()
    {
        GameObject towerCraftObj = new GameObject();
        TowerCrafter towerCrafter = towerCraftObj.AddComponent<TowerCrafter>();

        //Torre de 0 nivel
        Tower towerTest;
        Unit[] emptyArray = new Unit[0];

        //Torre de un nivel
        towerTest = towerCrafter.CreateTower(emptyArray, TowerTypes.TowerType.EnemyTower);

        LogAssert.Expect(LogType.Assert, "The array its invalid");
        Assert.AreEqual(null, towerTest);

        yield return null;
    }

    [UnityTest]
    public IEnumerator CreateATowerWithFiveEmptySlots()
    {
        GameObject towerCraftObj = new GameObject();
        TowerCrafter towerCrafter = towerCraftObj.AddComponent<TowerCrafter>();

        //Torre de 5 nivel
        Tower towerTest;
        Unit[] Array = new Unit[5];
        //Torre de un nivel
        towerTest = towerCrafter.CreateTower(Array, TowerTypes.TowerType.EnemyTower);

        LogAssert.Expect(LogType.Assert, "The array its empty");
        Assert.AreEqual(null, towerTest);

        yield return null;

    }


    [UnityTest]
    public IEnumerator CreateATowerWithFiveEnemys()
    {
        GameObject towerCraftObj = new GameObject();
        TowerCrafter towerCrafter = towerCraftObj.AddComponent<TowerCrafter>();

        //Torre de 5 nivel
        Tower towerTest;
        Unit[] Array = new Unit[5];

        EnemyScript enemyTest1 = new GameObject().AddComponent<EnemyScript>();
        enemyTest1.UnitName = DefaultEnemy.UnitName;
        enemyTest1.level = DefaultEnemy.level;

        for (int i = 0; i < Array.Length; i++)
        {
            Array[i] = enemyTest1;
        }

        //Torre de un nivel
        towerTest = towerCrafter.CreateTower(Array, TowerTypes.TowerType.EnemyTower);

        Assert.AreEqual(5, towerTest.towerLevels.Count);

        yield return null;

    }
}
