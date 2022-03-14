using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerSpawnInTowerTest
{

    [UnityTest]
    public IEnumerator PlayerSpawnInTowerTestWithEnumeratorPasses()
    {
        Player.instance = null;
        PlayerTower.instance = null;
        GameObject characterCrafterObject = new GameObject();
        CharacterCrafter characterCrafer = characterCrafterObject.AddComponent<CharacterCrafter>();
        Unit player = characterCrafer.CreateCharacter(UnitTypes.UnitType.Player);

        Assert.IsNotNull(PlayerTower.instance);
        Assert.AreEqual(UnitTypes.UnitType.Player, player.type);
        Assert.IsNotNull(Player.instance);
        Assert.IsTrue(PlayerTower.instance.towerLevels[0].type == UnitTypes.UnitType.Player);
        yield return null;
    }
}
