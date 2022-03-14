using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerLoseLife
{
    GameObject testCharObj;
    Player testPlayer;
    GameObject testCharObj2;
    Player testPlayer2;
    GameObject oponentCharObj;
    EnemyScript testEnemy;
    GameObject oponentCharObj2;
    EnemyScript testEnemy2;

    // A Test behaves as an ordinary method
    [Test]
    public void PlayerLoseLifeSimplePasses()
    {
        //Leañado el script que deseo probar
        // Use the Assert class to test conditions
    }
   

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PlayerLoseLifeWithEnumeratorPasses()
    {
        Player.instance = null;
        //player
        testCharObj = new GameObject();
        testPlayer = testCharObj.AddComponent<Player>();
        testCharObj2 = new GameObject();
        testPlayer2 = testCharObj2.AddComponent<Player>();

        //enemy
        oponentCharObj = new GameObject();
        testEnemy = oponentCharObj.AddComponent<EnemyScript>();
        oponentCharObj2 = new GameObject();
        testEnemy2 = oponentCharObj2.AddComponent<EnemyScript>();

        //inicializar valores
        testPlayer.level = 3;
        testPlayer.UnitName = "TestPlay1";
        testPlayer2.level = 6;
        testPlayer2.UnitName = "TestPlay2";

        testEnemy.level = 8;
        testEnemy.UnitName = "TestOpnonent2";
        testEnemy2.level = 6;
        testEnemy2.UnitName = "TestOpnonent2";


        //Enemy level>jugador
        //dos vidas
        Assert.AreEqual(testPlayer.level+testEnemy.level, testPlayer.Combat(testEnemy, UnitTypes.UnitType.Enemy).level);
         Assert.AreEqual(2,testPlayer.lives);

        //una vida vidas
     
        Assert.AreEqual(testPlayer.level + testEnemy.level, testPlayer.Combat(testEnemy, UnitTypes.UnitType.Enemy).level);
        Assert.AreEqual(1, testPlayer.lives);
        
        // sin vidas
        Assert.AreEqual(testPlayer.level + testEnemy.level, testPlayer.Combat(testEnemy, UnitTypes.UnitType.Enemy).level);
        Assert.AreEqual(0, testPlayer.lives);

        //Enemy level==jugador

        //dos vidas
        Assert.AreEqual(testPlayer2.level + testEnemy2.level, testPlayer2.Combat(testEnemy2, UnitTypes.UnitType.Enemy).level);
        Assert.AreEqual(2, testPlayer2.lives);

        //una vida vidas

        Assert.AreEqual(testPlayer2.level + testEnemy2.level, testPlayer2.Combat(testEnemy2, UnitTypes.UnitType.Enemy).level);
        Assert.AreEqual(1, testPlayer2.lives);

        // sin vidas
        Assert.AreEqual(testPlayer2.level + testEnemy2.level, testPlayer2.Combat(testEnemy2, UnitTypes.UnitType.Enemy).level);
        Assert.AreEqual(0, testPlayer2.lives);
        Assert.IsFalse(-1== testPlayer2.lives);
        Debug.Log(testPlayer2.lives);







        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    

}
