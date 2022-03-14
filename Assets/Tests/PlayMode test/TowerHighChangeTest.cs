using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TowerHighChangeTest
{
    [UnityTest]
    public IEnumerator TowerHighChangeTestWithEnumeratorPasses()
    {
        Player.instance = null;
        PlayerTower.instance = null;
        GameObject characterCrafterObject = new GameObject();
        CharacterCrafter characterCrafter = characterCrafterObject.AddComponent<CharacterCrafter>();
        GameObject towerCrafterObject = new GameObject();
        TowerCrafter towerCrafter = towerCrafterObject.AddComponent<TowerCrafter>();
        Unit[] enemys = new Unit[2];

        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i] = characterCrafter.CreateCharacter(UnitTypes.UnitType.Enemy);
        }

        Unit player = characterCrafter.CreateCharacter(UnitTypes.UnitType.Player,"Hero", 7);
        Tower enemyTower = towerCrafter.CreateTower(enemys, TowerTypes.TowerType.EnemyTower);

        Player.instance.Combat(enemyTower.towerLevels[0], enemyTower.towerLevels[0].type);

        Assert.AreEqual(8, Player.instance.level);
        Assert.AreEqual(2, PlayerTower.instance.towerLevels.Count);

        Player.instance.Combat(enemyTower.towerLevels[0], enemyTower.towerLevels[0].type);

        Assert.AreEqual(9, Player.instance.level);
        Assert.AreEqual(3, PlayerTower.instance.towerLevels.Count);
        yield return null;
    }
}
