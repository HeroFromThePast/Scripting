using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CreatePlayerTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void CreatePlayerTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator CreatePlayerTestWithEnumeratorPasses()
    {
        yield return null;
    }
}
