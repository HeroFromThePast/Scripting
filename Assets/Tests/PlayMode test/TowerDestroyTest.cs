using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TowerDestroyTest
{

    [UnityTest]
    public IEnumerator TowerDestroyTestWithEnumeratorPasses()
    {
        GameObject towerCrafterObject = new GameObject();
        TowerCrafter towerCrafer = towerCrafterObject.AddComponent<TowerCrafter>();
        GameObject characterCraferObject = new GameObject();
        CharacterCrafter characterCrafer = characterCraferObject.AddComponent<CharacterCrafter>();
        GameObject levelManagerObject = new GameObject();
        LevelManager levelManager = levelManagerObject.AddComponent<LevelManager>();
        Unit[] enemys = new Unit[3];

        characterCrafer.CreateCharacter(UnitTypes.UnitType.Player, "Hero", 10);
        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i] = characterCrafer.CreateCharacter(UnitTypes.UnitType.Enemy);
        }

        levelManager.AddTower(towerCrafer.CreateTower(enemys, TowerTypes.TowerType.EnemyTower));


        int enemyCount = enemys.Length;

        for (int i = 0; i < enemyCount; i++)
        {
            Player.instance.Combat(enemys[i], enemys[i].type);
        }

        Assert.AreEqual(0, levelManager.enemyTowers.Count);
        yield return null;
    }


}
