using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CreateCharacterTest
{
    [UnityTest]
    public IEnumerator CreateCharacterTestWithOutParameters()
    {
        GameObject characterCrafterObject = new GameObject();
        CharacterCrafter characterCrafter = characterCrafterObject.AddComponent<CharacterCrafter>();
        Unit resultCharacter = characterCrafter.CreateCharacter(UnitTypes.UnitType.Enemy);

        Assert.AreEqual(DefaultEnemy.UnitName, resultCharacter.UnitName);
        Assert.AreEqual(DefaultEnemy.level, resultCharacter.level);
        Assert.AreEqual(UnitTypes.UnitType.Enemy, resultCharacter.type);
        Assert.AreNotEqual(0, resultCharacter.level);
        yield return null;
    }

    [UnityTest]
    public IEnumerator CreateCharacterTestWithParameters()
    {
        Player.instance = null;
        GameObject characterCrafterObject = new GameObject();
        CharacterCrafter characterCrafter = characterCrafterObject.AddComponent<CharacterCrafter>();
        Unit resultCharacter = characterCrafter.CreateCharacter(UnitTypes.UnitType.Player, "Orco", 3);

        Assert.AreEqual("Orco", resultCharacter.UnitName);
        Assert.AreEqual(3, resultCharacter.level);
        Assert.AreEqual(UnitTypes.UnitType.Player, resultCharacter.type);
        Assert.NotNull(PlayerTower.instance);
        yield return null;
    }
}
