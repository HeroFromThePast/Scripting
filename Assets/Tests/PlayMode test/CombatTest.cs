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

    GameObject test1ObstacleObj;
    Obstacle test1Obstacle;
    GameObject test2ObstacleObj;
    Obstacle test2Obstacle;
    GameObject test3ObstacleObj;
    Obstacle test3Obstacle;

    #region CombatWinnerTest
    [UnityTest]
    public IEnumerator CombatWinnerTests()
    {
        Player.instance = null;
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

        Assert.AreEqual(testPlayer1.UnitName, testPlayer1.Combat(testEnemy1, UnitTypes.UnitType.Enemy).UnitName); // la idea es que devuelva la unidad que ganó y se compara el nombre con el quese espera que gane

        Assert.AreEqual(testEnemy2.UnitName, testPlayer2.Combat(testEnemy2, UnitTypes.UnitType.Enemy).UnitName);

        Assert.AreEqual(testEnemy3.UnitName, testPlayer3.Combat(testEnemy3, UnitTypes.UnitType.Enemy).UnitName);

        yield return null;
    }
    
    #endregion

    #region TestWinnerLevel
    [UnityTest]
    public IEnumerator TestWinnnerLevel()
    {
        Player.instance = null;
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

        Assert.AreEqual(8, testPlayer1.Combat(testEnemy1, UnitTypes.UnitType.Enemy).level); // la idea es que devuelva la unidad que ganó y se compara el nivel con el que se espera

        Assert.AreEqual(10, testPlayer2.Combat(testEnemy2, UnitTypes.UnitType.Enemy).level);

        Assert.AreEqual(8, testPlayer3.Combat(testEnemy3, UnitTypes.UnitType.Enemy).level);
         yield return null;
    }

    #endregion

    #region TestFightObstacle
    [UnityTest]
    public IEnumerator TestFightObstacle()
    {
        Player.instance = null;
        test1CharObj = new GameObject();
        testPlayer1 = test1CharObj.AddComponent<Player>();
        test1ObstacleObj = new GameObject();
        test1Obstacle = test1ObstacleObj.AddComponent<Obstacle>();

        test2CharObj = new GameObject();
        testPlayer2 = test2CharObj.AddComponent<Player>();
        test2ObstacleObj = new GameObject();
        test2Obstacle = test2ObstacleObj.AddComponent<Obstacle>();


        test3CharObj = new GameObject();
        testPlayer3 = test3CharObj.AddComponent<Player>();
        test3ObstacleObj = new GameObject();
        test3Obstacle = test3ObstacleObj.AddComponent<Obstacle>();


        testPlayer1.level = 3;
        testPlayer1.UnitName = "TestPlayer 1";
        test1Obstacle.level = 5;

        testPlayer2.level = 5;
        testPlayer2.UnitName = "TestPlayer 2";
        test2Obstacle.level = 5;

        testPlayer3.level = 5;
        testPlayer3.UnitName = "TestPlayer 3";
        test3Obstacle.level = 2;

        Assert.AreEqual(8, testPlayer1.Combat(test1Obstacle, UnitTypes.UnitType.Support).level);
        Assert.AreEqual(10, testPlayer2.Combat(test2Obstacle, UnitTypes.UnitType.Support).level);
        Assert.AreEqual(7, testPlayer3.Combat(test3Obstacle, UnitTypes.UnitType.Support).level);

        yield return null;
    }
    #endregion
}
