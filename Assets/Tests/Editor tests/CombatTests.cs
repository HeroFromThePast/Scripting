using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CombatTests
{
    // A Test behaves as an ordinary method

    [Test]
    public void TestWinnnerLevel()
    {
       /* Player test1Char = new Player();
        Player test2Char = new Player();
        Player test3Char = new Player();

        Unit oponent1char = new Unit();
        Unit oponent2char = new Unit();
        Unit oponent3char = new Unit();

        //en este caso gana el "jugador"
        test1Char.level = 5;
        test1Char.UnitName = "TestPlayer 1";
        oponent1char.level = 3;
        oponent1char.UnitName = "TestOponent 1";

        //en este caso pierde el "jugador"
        test2Char.level = 5;
        test1Char.UnitName = "TestPlayer 2";
        oponent2char.level = 5;
        oponent2char.UnitName = "TestOponent 2";

        //en este caso pierde el "jugador"
        test3Char.level = 3;
        test1Char.UnitName = "TestPlayer 3";
        oponent3char.level = 5;
        oponent3char.UnitName = "TestOponent 3";

        Assert.AreEqual(8, test1Char.Combat(oponent1char).level); // la idea es que devuelva la unidad que ganó y se compara el nivel con el que se espera

        Assert.AreEqual(10, test2Char.Combat(oponent2char).level);

        Assert.AreEqual(8, test3Char.Combat(oponent3char).level);*/
    }

    [Test]
    public void TestFightobstacle()
    {
        Player test1Char = new Player();
        Player test2Char = new Player();
        Player test3Char = new Player();


        Obstacle test1Obstacle = new Obstacle();
        Obstacle test2Obstacle = new Obstacle();
        Obstacle test3Obstacle = new Obstacle();

        test1Char.level = 3;
        test1Char.UnitName = "TestPlayer 1";
        test1Obstacle.level = 5;

        test2Char.level = 5;
        test1Char.UnitName = "TestPlayer 2";
        test2Obstacle.level = 5;
            
        test3Char.level = 5;
        test1Char.UnitName = "TestPlayer 3";
        test3Obstacle.level = 2;

        Assert.AreEqual(8, test1Char.FightObstacle(test1Obstacle));
        Assert.AreEqual(10, test2Char.FightObstacle(test2Obstacle));
        Assert.AreEqual(7, test3Char.FightObstacle(test3Obstacle));
    }
}
