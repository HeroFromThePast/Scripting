using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CombatTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void CombatWinnerTests()
    {
        Unit testChar1 = new Unit();

        testChar1.level = 5;

        int character1Level = 5;
        int oponent1Level1 = 2;

        int character2Level = 3;
        int oponent2Level = 5;

        int character3Level = 5;
        int oponent3Level = 5;




        Assert.Pass();
        // Use the Assert class to test conditions
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.

}
