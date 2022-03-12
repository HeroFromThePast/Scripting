using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    [SerializeField] int lives = 3;
    // Start is called before the first frame update

    public override void Die()
    {
        base.Die();
        lives--;
    }
}
