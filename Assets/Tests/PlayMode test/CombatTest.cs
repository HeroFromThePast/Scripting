using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CombatTest
{
    GameObject test1CharObj;
    Player testPlayer1;
    GameObject oponent1CharObj;
    EnemyScript testEnemy1;

    GameObject test2CharObj;
    Player testPlayer2;
    GameObject oponent2CharObj;
    EnemyScript testEnemy2;

    GameObject test3CharObj;
    Player testPlayer3;
    GameObject oponent3CharObj;
    EnemyScript testEnemy3;

    #region CombatWinnerTest
    [UnitySetUp]
    public IEnumerator CombatWinnerTestsSetUp()
    {
        test1CharObj = new GameObject();
        testPlayer1 = test1CharObj.AddComponent<Player>();
        oponent1CharObj = new GameObject();
        testEnemy1 = oponent1CharObj.AddComponent<EnemyScript>();

        test2CharObj = new GameObject();
        testPlayer2 = test2CharObj.AddComponent<Player>();
        oponent2CharObj = new GameObject();
        testEnemy2 = oponent2CharObj.AddComponent<EnemyScript>();

        test3CharObj = new GameObject();
        testPlayer3 = test3CharObj.AddComponent<Player>();
        oponent3CharObj = new GameObject();
        testEnemy3 = oponent3CharObj.AddComponent<EnemyScript>();

        //en este caso gana el "jugador"
        testPlayer1.level = 5;
        testPlayer1.UnitName = "TestPlayer 1";
        testEnemy1.level = 3;
        testEnemy1.UnitName = "TestOponent 1";

        //en este caso pierde el "jugador"
        testPlayer2.level = 5;
        testPlayer2.UnitName = "TestPlayer 2";
        testEnemy2.level = 5;
        testEnemy2.UnitName = "TestOponent 2";

        //en este caso pierde el "jugador"
        testPlayer3.level = 3;
        testPlayer3.UnitName = "TestPlayer 3";
        testEnemy3.level = 5;
        testEnemy3.UnitName = "TestOponent 3";

        yield return null;
    }
    [UnityTest]
    public IEnumerator CombatWinnerTests()
    {
        Assert.AreEqual(testPlayer1.UnitName, testPlayer1.Combat(testEnemy1).UnitName); // la idea es que devuelva la unidad que ganó y se compara el nombre con el quese espera que gane

        Assert.AreEqual(testEnemy2.UnitName, testPlayer2.Combat(testEnemy2).UnitName);

        Assert.AreEqual(testEnemy3.UnitName, testPlayer3.Combat(testEnemy3).UnitName);

        yield return null;
    }
    
    [UnityTearDown]
    public IEnumerator CombatWinnerTestsTearDown()
    {
        Object.Destroy(test1CharObj);
        Object.Destroy(testPlayer1);
        Object.Destroy(oponent1CharObj);
        Object.Destroy(testEnemy1);

        Object.Destroy(test2CharObj);
        Object.Destroy(testPlayer2);
        Object.Destroy(oponent2CharObj);
        Object.Destroy(testEnemy2);

        Object.Destroy(test3CharObj);
        Object.Destroy(testPlayer3);
        Object.Destroy(oponent3CharObj);
        Object.Destroy(testEnemy3);
        yield return null;
    }
    #endregion
}
